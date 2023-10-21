using NotesLayerApp.Core.Dto;
using NotesLayerApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesLayerApp.Application.Mappings
{
    public static class NoteMappings
    {
        public static NoteDto ToNoteResponse(Note note)
        {
            var dto = new NoteDto
            {
                Text = note.Text,
                Title = note.Title,
            };

            return dto;
        }

        public static Note ToNote(NoteDto dto)
        {
            var note = new Note
            {
                Id = 0,
                Title = dto.Title,
                Text = dto.Text,
            };

            return note;
        }

        public static void ToNote(Note note, NoteDto dto)
        {
            note.Title = dto.Title;
            note.Text = dto.Text;            
        }
    }
}
