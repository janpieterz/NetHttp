# NetHttp
.NET Http Library

Easy wrapper around System.Net.Http. 

Early stages, see the issue tracker for planned features

Usage
====
```c#
INetHttpClient client = new NetHttpClient("https://httpbin.org");
var response = await client.GetAsync<ResponseType>("/resource");
```
