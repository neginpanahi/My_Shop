using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Endpoint.Models
{
    public class FailedRequestRespons
    {
        public bool Sucess { get => false; }
        public int error_code { get; set; }
        public string error_message { get; set; }
}
}
