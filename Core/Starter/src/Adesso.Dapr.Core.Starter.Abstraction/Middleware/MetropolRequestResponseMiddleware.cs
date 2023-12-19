using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.IO;

namespace Adesso.Dapr.Core.Starter.Abstraction.Middleware;

public class AdessoRequestResponseMiddleware
{
    private readonly RequestDelegate next;
    private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;

    public AdessoRequestResponseMiddleware(RequestDelegate Next)
    {
        next = Next;
        _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
    }

    public async Task Invoke(HttpContext httpContext)
    {
        if (UnavailableStateToRequestResponse(httpContext))
        {
            await next.Invoke(httpContext);
            return;
        }

        var originalBodyStream = httpContext.Response.Body;

        await using var responseBody = _recyclableMemoryStreamManager.GetStream();
        httpContext.Response.Body = responseBody;

        await next.Invoke(httpContext);

        httpContext.Response.Body.Seek(0, SeekOrigin.Begin);
        var responseText = await new StreamReader(httpContext.Response.Body, Encoding.UTF8).ReadToEndAsync();
        httpContext.Response.Body.Seek(0, SeekOrigin.Begin);

        await responseBody.CopyToAsync(originalBodyStream);
    }

    private static bool UnavailableStateToRequestResponse(HttpContext httpContext)
    {
        return httpContext.Request.Path == "/info" ||
               httpContext.Request.Path == "/api/health" ||
               httpContext.Request.Path.Value!.Contains("swagger") ;
    }

    private static string ReadStreamInChunks(Stream stream)
    {
        const int readChunkBufferLength = 4096;

        stream.Seek(0, SeekOrigin.Begin);

        using var textWriter = new StringWriter();
        using var reader = new StreamReader(stream);

        var readChunk = new char[readChunkBufferLength];
        int readChunkLength;

        do
        {
            readChunkLength = reader.ReadBlock(readChunk,
                0,
                readChunkBufferLength);
            textWriter.Write(readChunk, 0, readChunkLength);
        } while (readChunkLength > 0);

        return textWriter.ToString();
    }
    
    private async Task<string> getRequestBody(HttpContext context)
    {
        context.Request.EnableBuffering();

        await using var requestStream = _recyclableMemoryStreamManager.GetStream();
        await context.Request.Body.CopyToAsync(requestStream);

        string reqBody = ReadStreamInChunks(requestStream);

        context.Request.Body.Position = 0;

        return reqBody;
    }

}