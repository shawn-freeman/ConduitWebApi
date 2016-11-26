using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CONDUIT.UnityCL.Transports.ErrorHandling
{
    [Serializable]
    public class ReturnResult<T>
    {
        public ReturnResult() { }
        public ReturnResult(T value, string exceptionMessage = "")
        {
            this.HasError = !string.IsNullOrEmpty(exceptionMessage);
            this.ExceptionMessage = exceptionMessage;
            this.Value = value;
        }
        
        public bool HasError;
        public string ExceptionMessage;
        public T Value;
    }
}
