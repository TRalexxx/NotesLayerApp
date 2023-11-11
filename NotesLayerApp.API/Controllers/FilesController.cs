using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NotesLayerApp.Core.Entities;

namespace NotesLayerApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        [HttpPost]
        public ActionResult DownloadFile([FromForm] FileModel file)
        {
            try
            {
                string path = Path.Combine("H:/", "wwwroot", file.FileName);

                using (Stream stream = new FileStream(path, FileMode.Create))

                file.FormFile.CopyTo(stream);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
