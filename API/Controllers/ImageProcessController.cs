using Application.Business;
using Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ImageProcessController : BaseApiController
    {

        [HttpPost]
        public async Task<IActionResult> ProcessImage(FormsDTO model)
        {
            await new ImageProcessManagment().ProcessPicture(model);
            return Ok();
        }
    }
}
