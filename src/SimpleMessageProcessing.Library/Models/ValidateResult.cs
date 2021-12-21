using SimpleMessageProcessing.Library.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessageProcessing.Library.Models {
    public class ValidateResult {
        public ValidateResult(bool isValid, IMessage result)
        {
            IsValid = isValid;
            Result = result;
        }

        public bool IsValid { get; set; }
        public IMessage Result { get; set; }
    }
}
