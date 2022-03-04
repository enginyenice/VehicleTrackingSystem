using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Exceptions
{
    public class BusinessException : Exception
    {
        public int StatusCode { get; private set; }

        public BusinessException(string? message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}