# sigterm-demo

Purpose of this project is to test if it is possible to handle SIGTERM on asp.net core application hosted on a Linux docker container.

# build
```docker build -f SigtermDemo\Dockerfile -t "sigtermdemo:latest" .```

# run interactively
```docker run -it sigtermdemo```

# test SIGTERM
```docker stop <containerid>```

# test SIGKILL
```docker kill <containerid>```
