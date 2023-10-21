using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesLayerApp.Application.Services.Notes;
using NotesLayerApp.Core.Dto;

namespace NotesLayerApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INotesService _notesService;

        public NotesController(INotesService notesService)
        {
            _notesService = notesService;
        }

        [HttpGet("GetNote")]
        public async Task<ActionResult<NoteDto>> Get(int id)
        {
            var dto = await _notesService.Get(id);

            return Ok(dto);
        }

        [HttpGet("GetAllNotes")]
        public async Task<ActionResult<IEnumerable<NoteDto>>> GetAll()
        {
            var dto = await _notesService.GetAll();

            return Ok(dto);
        }

        [HttpPost("CreateNote")]
        public async Task<IActionResult> Create(NoteDto dto)
        {
            await _notesService.Create(dto);

            return Ok();
        }

        [HttpPut("UpdateNote")]
        public async Task<IActionResult> Update(int id, NoteDto dto)
        {
            await _notesService.Update(dto, id);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _notesService.Delete(id);

            return Ok();
        }
    }
}
