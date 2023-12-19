using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adesso.Dapr.Core.CQRS.Message
{
    public class AdessoCommandResult
    {
        public AdessoCommandResult(bool isSuccess) 
        {
            this.IsSuccess = isSuccess;
   
        }
                public bool IsSuccess { get; set; }
        
    }
}