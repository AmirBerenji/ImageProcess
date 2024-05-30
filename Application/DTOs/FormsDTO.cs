using Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class FormsDTO :ImageModel
    {
        public bool effect1 { get; set; }
        public bool effect2 { get; set; }
        public bool effect3 { get; set; }
        public int? radius { get; set; }
        public int? size { get; set; }
        public int? blur { get; set; }
    }
}
