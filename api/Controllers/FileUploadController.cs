using Microsoft.AspNetCore.Mvc;
using Minio;
using Minio.DataModel.Args;

namespace bikes;

[ApiController]
[Route("files")]
public class FileUploadController(IMinioClient minioClient) : Controller
{
    private const string bucketName = "uploads";

    private readonly IMinioClient _minioClient = minioClient;

    [HttpPost("upload")]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            throw new ArgumentException("File is not selected or empty.", nameof(file));
        }

        var bucketArgs = new BucketExistsArgs().WithBucket(bucketName);
        bool found = await _minioClient.BucketExistsAsync(bucketArgs).ConfigureAwait(false);

        if (!found)
        {
            var mbArgs = new MakeBucketArgs().WithBucket(bucketName);
            await _minioClient.MakeBucketAsync(mbArgs).ConfigureAwait(false);
        }

        var objectName = $"{DateTime.Now:yyyyMMddHHmmss}_{file.FileName}";

        using (var memoryStream = new MemoryStream())
        {
            await file.CopyToAsync(memoryStream);
            if (memoryStream.Length > 0)
            {
                memoryStream.Seek(0, SeekOrigin.Begin);

                await _minioClient.PutObjectAsync(
                    new PutObjectArgs()
                        .WithBucket(bucketName)
                        .WithObject(objectName)
                        .WithStreamData(memoryStream)
                        .WithObjectSize(memoryStream.Length)
                        .WithContentType(file.ContentType)
                );
            }
        }

        // Move to env variable
        var publicUrl = $"http://localhost:9000/{bucketName}/{objectName}";

        return Ok(new { Url = publicUrl });
    }
}
