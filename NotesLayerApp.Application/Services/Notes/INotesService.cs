using NotesLayerApp.Core.Dto;
using NotesLayerApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesLayerApp.Application.Services.Notes
{
    public interface INotesService
    {
        Task<Note> Create(NoteDto dto);
        Task Update(NoteDto dto, int id);
        Task<NoteDto> Get(int id);
        Task<IEnumerable<NoteDto>> GetAll();
        Task Delete(int id);
    }
}
