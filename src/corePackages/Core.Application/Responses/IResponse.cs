/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

namespace Core.Application.Responses
{
    public interface IResponse<T> where T : class
    {
        #region Properties

        public int StatusCode { get; }

        #endregion Properties
    }
}