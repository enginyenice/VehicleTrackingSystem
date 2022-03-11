/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Core.Application.Responses
{
    public class Response<T> : IResponse<T> where T : class
    {
        #region Properties

        public T Data { get; private set; }
        public ErrorDto Error { get; private set; }

        [JsonIgnore]
        public bool IsSuccessful { get; private set; }

        public int StatusCode { get; private set; }

        #endregion Properties

        #region Methods

        public static Response<T> Fail(ErrorDto errorDto, int statusCode)
        {
            Response<T> response = new Response<T>() { Error = errorDto, StatusCode = statusCode, IsSuccessful = false };
            return response;
        }

        public static Response<T> Fail(string message, int statusCode, bool isShow)
        {
            var errorDto = new ErrorDto(message, isShow);
            Response<T> response = new Response<T> { Error = errorDto, StatusCode = statusCode, IsSuccessful = false };
            return response;
        }

        public static Response<T> Success(T data, int statusCode)
        {
            Response<T> response = new Response<T>() { Data = data, StatusCode = statusCode, IsSuccessful = true };
            return response;
        }

        public static Response<T> Success(int statusCode)
        {
            Response<T> response = new Response<T>() { Data = default, StatusCode = statusCode, IsSuccessful = true };
            return response;
        }

        public override string ToString()
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;
            options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            return JsonSerializer.Serialize<Response<T>>(this, options);
        }

        #endregion Methods
    }
}