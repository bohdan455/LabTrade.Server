using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dto.Errors
{
    public class ErrorResponceMessage
    {
        [DataMember(Name ="error")]
        public string Error { get; set; } = string.Empty;
        [DataMember(Name = "message")]
        public string Message { get; set; } = string.Empty;
        [DataMember(Name = "details")]
        public string Details { get; set; } = string.Empty;
    }
}
