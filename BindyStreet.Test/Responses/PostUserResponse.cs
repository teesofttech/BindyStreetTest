using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindyStreet.Test.Models
{
    public class PostUserResponse
    {
        public List<string> messages { get; set; }
        public bool succeeded { get; set; }
        public int data { get; set; }
        public object exception { get; set; }
        public int code { get; set; }

    }
}
