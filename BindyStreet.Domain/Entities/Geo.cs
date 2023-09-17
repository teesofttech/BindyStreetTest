using BindyStreet.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindyStreet.Domain.Entities
{
    public class Geo : BaseEntity
    {
        public string Lat { get; set; }
        public string Lng { get; set; }
    }
}
