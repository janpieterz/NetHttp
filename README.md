# NetHttp
.NET Http Library

Easy wrapper around System.Net.Http. 

Usage
====

See the unit tests for more examples

```c#
INetHttpClient client = new NetHttpClient("https://httpbin.org");
var response = await client.GetAsync<ResponseType>("/resource");
```
