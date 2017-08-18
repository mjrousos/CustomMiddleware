Custom ASP.NET Core Middleware
==============================

This sample implements the custom [middleware](https://docs.microsoft.com/aspnet/core/fundamentals/middleware) described in [this blog post](https://blogs.msdn.microsoft.com/dotnet/2016/09/19/custom-asp-net-core-middleware-example/) for handling simple [SOAP](https://www.w3schools.com/xml/xml_soap.asp) requests.

This sample demonstrates:

1. How to create custom and use middleware for customized serving of incoming HTTP requests.
2. How to use WCF APIs to manually unpack SOAP envelopes using the BasicHTTPBinding, route the request to the correct action, and create and return a proper SOAP response.

**Note** that this sample does _not_ represent a complete implementation of [WCF](https://docs.microsoft.com/dotnet/framework/wcf/index) server functionality for .NET Core. Among other things, it has no support for message security, WSDL generation, duplex channels, non-HTTP transports, etc. This sample demonstrates custom middleware for handling a specific, simple, type of SOAP requests. 

That said, customers may find this sample useful as a demonstration of how to unpack and respond to simple SOAP messages in ASP.NET Core, or as a demonstration of how to configure [middleware](https://docs.microsoft.com/aspnet/core/fundamentals/middleware) for customized handling of HTTP requests.

For more details, read [the associated blog post](https://blogs.msdn.microsoft.com/dotnet/2016/09/19/custom-asp-net-core-middleware-example/).

Run Instructions
----------------

1. Build the solution
2. Launch TestApplication (an ASP.NET Core app which will accept incoming SOAP requests to access its Calculator service)
3. Run TestClient, passing the base URL (including port) TestApplication is listening on as a parameter. This client will use a WCF client to send requests to the TestApplication's Calculator service.

Sample Output
-------------

```
> dotnet run --framework netcoreapp1.0 http://localhost:5000
18.9324719081318 + 6.05137448108353 == 24.9838463892154
18.9324719081318 - 6.05137448108353 == 12.8810974270483
18.9324719081318 * 6.05137448108353 == 114.5674773687
18.9324719081318 / 6.05137448108353 == 3.12862341726071
```