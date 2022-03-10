/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

namespace Core.CrossCuttingConcerns.Exceptions
{
    public class BusinessException : Exception
    {
        #region Constructors

        public BusinessException(string? message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        #endregion Constructors

        #region Properties

        public int StatusCode { get; private set; }

        #endregion Properties
    }
}