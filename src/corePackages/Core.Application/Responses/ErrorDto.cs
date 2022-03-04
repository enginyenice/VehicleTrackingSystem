namespace Core.Application.Responses
{
    public class ErrorDto
    {
        public List<String> Errors { get; private set; } = new List<string>();
        public bool IsShow { get; private set; }

        public ErrorDto() => Errors = new List<string>();

        public ErrorDto(string error, bool isShow)
        {
            Errors.Add(error);
            IsShow = isShow;
        }

        public ErrorDto(List<string> errors, bool isShow)
        {
            Errors = errors;
            IsShow = isShow;
        }
    }
}
