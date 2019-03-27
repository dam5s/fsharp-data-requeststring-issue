# FSharp.Data encoding bug?

Run with:

```bash
dotnet run fsharp.data
dotnet run system.net.http
```

Output from fsharp.data has character encoding issues, the other one decodes the stream as expected.

On linux you might get SSL connection errors, as a workaround, set the environment variable

```
DOTNET_SYSTEM_NET_HTTP_USESOCKETSHTTPHANDLER=false
```
