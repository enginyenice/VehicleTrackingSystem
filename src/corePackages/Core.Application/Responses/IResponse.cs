using System.Text.Json.Serialization;

namespace Core.Application.Responses
{
    public interface IResponse<T> where T : class
    {
        public int StatusCode { get; }
    }
}