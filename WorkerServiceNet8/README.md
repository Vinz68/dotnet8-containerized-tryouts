# .NET 8 Service - With Serilog, Running in a docker container

## Pre-reqs

- [Docker Desktop](https://www.docker.com/products/docker-desktop) on Windows 11 **or**
- [Docker Engine](https://docker-docs.netlify.app/install/windows/docker-ee/) on Windows Server 2022


> Be sure to use _Windows Container Mode_ on Docker Desktop

## Logging part

Structured logging is done using [Serilog](https://serilog.net/). There are many output NuGet packages (Serilog.Sink.*). We are using Console, File and Syslog output.

_Syntax to do structured logging:_

```
var position = new { Latitude = 25, Longitude = 134 };
var elapsedMs = 34;

log.Information("Processed {@Position} in {Elapsed:000} ms.", position, elapsedMs);
```

_always_ use template properties to include variables in messages

### Microsoft.Extensions.Logging
Logging infrastructure default implementation for Microsoft.Extensions.Logging

### Serilog.Extensions.Hosting
Low-level Serilog provider for Microsoft.Extensions.Logging

### Serilog.Sinks.Console and Serilog.Sinks.File
For logging output to console and file output

### Serilog.Sinks.SyslogMessages
Fully-featured Serilog sink that logs events to remote syslog servers using UDP, TCP, and TLS over TCP, 
and can also use POSIX libc syslog functions to write to the local syslog service on Linux systems. 
Both RFC3164 and RFC5424 format messages are supported.
