using Application.DTOs;
using Application.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Business
{
    public class ImageProcessManagment
    {
        public async Task<Image> ProcessPicture(FormsDTO model)
        {
            
            var  image = await ConvertImage.ConvertBase64ToImage(model.imageBase64);

            if (model.size != null || model.size == 0) 
            {
                image = await ChangeImage.ResizeSize(image, model.size.Value);
            }

            if (model.blur != null || model.blur == 0)
            {
                image = await ChangeImage.ResizeSize(image, model.blur.Value);
            }

            if (model.radius != null || model.radius == 0)
            {
                image = await ChangeImage.RadiusImage(image, model.radius.Value);
            }

            if (model.effect1)
            {
                image = await ChangeImage.Effect1Image(image);
            }

            return image;
        }
    }
}
