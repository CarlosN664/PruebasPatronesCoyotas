using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPatronesCoyotas.Utilities
{
    public class ResponseBase<T>
    {
        public ResponseType Type { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }

    }
}
