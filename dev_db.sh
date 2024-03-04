GIT_TAG=`git describe --abbrev=0` GIT_SHA=`git rev-parse --short HEAD` docker compose --profile default up
