/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

namespace Core.Application.Responses
{
    public class ErrorDto
    {
        #region Constructors

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

        #endregion Constructors

        #region Properties

        public List<String> Errors { get; private set; } = new List<string>();
        public bool IsShow { get; private set; }

        #endregion Properties
    }
}