# Episerver.Blazor
[![GitHub version](https://badge.fury.io/gh/DarrenStahlhut%2FEpiserver.Blazor.svg)](https://badge.fury.io/gh/DarrenStahlhut%2FEpiserver.Blazor)
[![License](http://img.shields.io/:license-apache-blue.svg?style=flat-square)](http://www.apache.org/licenses/LICENSE-2.0.html)

This repository was created as a demonstration of .NET Core Blazor (Server-side and Client-side) using a shared .NET Standard 2.0 class library to consume data from Episerver Content Delivery API.

Requirements
--------
- Visual Studio 2019 Preview (16.2.0 Preview 3.0)
- .NET Core 3.0 Preview SDK (3.0.100-preview6-012264)
- Blazor Visual Studio Extension

Solution
--------

The solution consists of the following Projects.
1. **Episerver.Alloy** - Is an ASP.NET 4.7.2 WebApp, install of Episerver Alloy v11.12.0 and Content Delivery API v2.6.0
2. **Common.Library** - Is a .NET Standard 2.0 Class Library, used to consume Episerver Content Delivery API and demonstrate how the Blazor apps can reference .Net Standard 2.0 assemblies (and in the case of client-side Blazor compile it to WebAssembly).
3. **Blazor.ServerSide** - Is a .NET Core Web Application, created with the Blazor Server App Visual Studio Project Template
4. **Blazor.ClientSide** - Is a .NET Core Web Application, created with the Blazor (client-side) Visual Studio Project Template

Installation / Get the Demo running
-----------------------------------
- Meet the Requirements :point_up:
- Clone repo, build Solution :pray:
- **Episerver.Alloy** change the Episerver Find index settings in Web.config :gear: (currently using my demo index)
- **Episerver.Alloy** rebuild the Find Index :recycle: 
- **Common.Library** in SearchService.cs replace the hardcorded URL to the Episerver Alloy Content Delivery API. Yes I know, submit a PR. :joy:
- Run the **Episerver.Alloy** and one (or both) of the **Blazor** projects :tada:

What's does this Demo demonstrate?
---------------------------------
- The **Common.Library** project provides a SearchService, that consumes the Episerver Content Delivery API Search, and returns a strongly typed List<SearchResult> which is bound to the UI in Razor.
- The **Blazor** projects contain a Search page `Pages/Search.razor` which Injects the SearchService, and binds the returned List<SearchResult> to the UI.
- When you run the **Blazor.Serverside** project and perform a Search, SignalR via Websockets sends the request back to the server, executes the Search and returns DOM Diffs to the Browser.
- When you run the **Blazor.Clientside** project and perform a Search, the entire Common.Library is compiled into WebAssembly and run in the Browser. The Client will execute the GET to Episerver Content Delivery API.

What's on the Roadmap?
---------------------------------
- Episerver Content Routing in Blazor.Serverside
- Javascript Interop examples to demonstrate calling existing Javascript Libraries from C#

References
--------
- Blazor + Episerver blog series: https://world.episerver.com/blogs/darren-s/dates/2019/7/blazor--episerver-blog-series/
- Blazor Official Site: https://dotnet.microsoft.com/apps/aspnet/web-apps/client
- Blazor Official Documentation: https://docs.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-3.0
- Blazor Video Steven Sanderson: https://www.youtube.com/watch?v=0RfUPr0KrSM
- Blazor Blog announcing release: https://devblogs.microsoft.com/aspnet/blazor-now-in-official-preview/
- Episerver Content Delivery API Developer Guide: https://world.episerver.com/documentation/developer-guides/content-delivery-api/
- Episerver Content Delivery API Reference: https://sdk.episerver.com/ContentDeliveryAPI/2.x/Index.html
