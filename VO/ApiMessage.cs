using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class ApiMessage
    {
        public string ResultCode { get; set; }
        public string ResultMessage { get; set; }
    }

    public class ApiMessage<T>
    {
        public string ResultCode { get; set; }
        public string ResultMessage { get; set; }
        public T Data { get; set; }
    }
}
