using Microsoft.EntityFrameworkCore;
using NotesLayerApp.Application.Mappings;
using NotesLayerApp.Core.Dto;
using NotesLayerApp.Core.Entities;
using NotesLayerApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesLayerApp.Application.Services.Notes
{
    public class NotesService : INotesService
    {
        private readonly ApplicationDbContext _context;

        public NotesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Note> Create(NoteDto dto)
        {
            var note = NoteMappings.ToNote(dto);

            await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync();

            return note;
        }

        public async Task Delete(int id)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(x=>x.Id.Equals(id));

            if(note == null)
            {
                throw new Exception($"Element with id:{id} not found");
            }

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
        }

        public async Task<NoteDto> Get(int id)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(x=>x.Id.Equals(id));

            if(note == null)
            {
                throw new Exception($"Element with id:{id} not found");
            }

            var dto = NoteMappings.ToNoteResponse(note);
            
            return dto;
        }

        public async Task<IEnumerable<NoteDto>> GetAll()
        {
            var notes = await _context.Notes.ToListAsync();

            if(notes == null)
            {
                throw new Exception("No notes found");
            }

            var notesDto = notes.Select(NoteMappings.ToNoteResponse).ToList();

            return notesDto;
        }

        public async Task Update(NoteDto dto, int id)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if(note == null)
            {
                throw new Exception($"Element with id:{id} not found");
            }

            NoteMappings.ToNote(note, dto);

            _context.Notes.Update(note);
            await _context.SaveChangesAsync();
        }
    }
}
