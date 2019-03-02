using System.Collections.Generic;
using System.Linq;

namespace SimpleSearch.Api.Infrastructure.Exception
{
    public class DomainException : System.Exception
    {
        public DomainException(int errorCode)
        {
            ErrorList = new List<Error>
            {
                new Error
                {
                    ErrorCode = errorCode
                }
            };
        }

        public DomainException(List<int> errorCodeList)
        {
            if (errorCodeList != null && errorCodeList.Any())
            {
                ErrorList = new List<Error>(errorCodeList.Select(code => new Error
                {
                    ErrorCode = code
                }));
            }
        }

        public List<Error> ErrorList { get; }
    }
}