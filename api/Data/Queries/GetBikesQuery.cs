namespace Mottu.Data.Queries
{
    public class GetBikesQuery
    {
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 25;
        public string? Plate { get; set; }
    }
}
