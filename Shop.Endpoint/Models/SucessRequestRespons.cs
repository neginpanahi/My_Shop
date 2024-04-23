using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Endpoint.Models
{
    public class SucessRequestRespons
    {
        public bool Sucess { get => true; }
        public string Id { get; set; }
        public string Link { get; set; }
    }
}
