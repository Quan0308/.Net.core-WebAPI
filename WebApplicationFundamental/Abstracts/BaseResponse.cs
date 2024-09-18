using Microsoft.AspNetCore.Mvc;

namespace WebApplicationFundamental.Abstracts;

public abstract class BaseResponse
{
  public struct Response<T>
  {
      public bool Success { get; set; }
      public string Message { get; set; }
      public T? Data { get; set; }
  }
  
    public static IResult Ok<T>(T data)
    {
        var response = new Response<T>
        {
        Success = true,
        Message = "Success",
        Data = data
        };
        return Results.Ok(response);
    }
    
    public static IResult Ok<T>(bool success, string message, T data)
    {
        var response = new Response<T>
        {
        Success = success,
        Message = message,
        Data = data
        };
        return Results.Ok(response);
    }

    public static IResult BadRequest(string message)
    {
        var response = new Response<object>
        {
            Success = false,
            Message = message,
            Data = null
        };
        return Results.BadRequest(response);
    }
}

