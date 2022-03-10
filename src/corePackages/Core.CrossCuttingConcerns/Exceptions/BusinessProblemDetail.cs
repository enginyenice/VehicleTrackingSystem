/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core.CrossCuttingConcerns.Exceptions
{
    public class BusinessProblemDetails : ProblemDetails
    {
        #region Methods

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        #endregion Methods
    }
}