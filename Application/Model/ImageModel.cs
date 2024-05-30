using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model
{
    public class ImageModel
    {
        [Required]
        public string  imageName { get; set; }
        [Required]
        public string imageBase64 { get; set; }
    }
}
