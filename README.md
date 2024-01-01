# Welcome to 'dotnet8-containerized-tryouts'

This is a repo for users getting started with .NET 8 and Docker.
The focus is building (simple) .NET 8 application(s) which would run as a container (on Docker) and how to do this.
Example serves different use cases and some could serve as a starter template.

## Examples


| folder/example    | description | extra info and links |
|-------------------|-------------|----------------------|
| hello-dotnet-container | console output of OS & computer architecture | see also [video](https://www.youtube.com/watch?v=scIAwLrruMY&list=WL&index=2) and original source on [github](https://github.com/richlander/container-workshop) for detailed information |
| WorkerServiceNet8 | Background service with structured logging (serilog) | see also [serilog](https://serilog.net/) webpage |




## Environment

To build and execute the examples on docker, you need: 

- [Docker](https://docs.docker.com/engine/install/)
- [.NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

The following environment was used for the examples.

- Windows 11 computer, with following dotnet and docker versions:

```bash
$ dotnet --version
8.0.100
$ docker --version
Docker version 24.0.7, build afdd53b
```

## Building

You can try it out on the command line in one of the example folders (as listed in the table), and then ...

### Containerize an application

```powershell
cd [example-project]
dotnet publish -t:PublishContainer
```

### Look inside the container

```powershell
docker run -it --rm --entrypoint /bin/bash hello-dotnet-container:latest
```

```bash
app@f7c2c6eb7b25:/app$ whoami
app

app@f7c2c6eb7b25:/app$ ls
hello-dotnet-container.deps.json  hello-dotnet-container.exe  hello-dotnet-container.runtimeconfig.json
hello-dotnet-container.dll        hello-dotnet-container.pdb

app@f7c2c6eb7b25:/app$ exit
```

### Show container id and its size

```powershell
docker image list [example-project]
```
example output
```
REPOSITORY               TAG       IMAGE ID       CREATED          SIZE
hello-dotnet-container   latest    bbf52cfe7ff0   11 seconds ago   85.7MB
```

## Run

### Launch a container

```powershell
docker run --rm [example-project]
```
example 
```
docker run --rm hello-dotnet-container

Hello dot-net-container
OSDescription: Debian GNU/Linux 12 (bookworm)
OSArchitecture: X64!
```

## Extra info 
[.NET container samples](https://github.com/dotnet/dotnet-docker/blob/main/samples/README.md)

[Docker Run docs](https://docs.docker.com/engine/reference/commandline/run/)

[Chiseled Containers](https://devblogs.microsoft.com/dotnet/dotnet-6-is-now-in-ubuntu-2204/#net-in-chiseled-ubuntu-containers)

[Cross-compilation](https://devblogs.microsoft.com/dotnet/improving-multiplatform-container-support/) 

[OCI image publish](https://learn.microsoft.com/dotnet/core/docker/publish-as-container) 


