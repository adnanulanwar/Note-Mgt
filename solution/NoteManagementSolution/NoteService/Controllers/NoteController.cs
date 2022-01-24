using Microsoft.AspNetCore.Mvc;
using NoteService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NoteService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {

        XmlSerializer NoteseriaLizer = new XmlSerializer(typeof(Note));

        // GET: api/<NoteController>
        [HttpPost("GetNotesByType")]
        public List<Note> Get([FromBody] Note searchNote)
        {
            List<Note> notes = new List<Note>();

            string[] lines = System.IO.File.ReadAllLines(@"Data/notes.txt");

            foreach (var row in lines)
            {
                Note note = new Note();
                note.ID = int.Parse(row.Split("~~")[0]);
                note.NoteMessage = row.Split("~~")[1];
                note.NoteType = (EnumNoteType)int.Parse(row.Split("~~")[2]);
                note.UserID = int.Parse(row.Split("~~")[3]);
                note.NoteCreateTime = DateTime.Parse(row.Split("~~")[4]);
                note.ReminderTime = DateTime.Parse(row.Split("~~")[5]);

                notes.Add(note);
            }

            
            notes = notes.Where(x => x.UserID == searchNote.UserID && x.NoteType == searchNote.NoteType).ToList();
            return notes;
        }

        // GET api/<NoteController>/5
        [HttpGet("{id}")]
        public Note Get(int id,[FromBody] Note searchNote)
        {
            List<Note> notes = new List<Note>();

            string[] lines = System.IO.File.ReadAllLines(@"Data/notes.txt"); 

            foreach (var row in lines)
            {
                Note note = new Note();
                note.ID = int.Parse(row.Split("~~")[0]);
                note.NoteMessage = row.Split("~~")[1];
                note.NoteType = (EnumNoteType)int.Parse(row.Split("~~")[2]);
                note.UserID = int.Parse(row.Split("~~")[3]);
                note.NoteCreateTime = DateTime.Parse(row.Split("~~")[4]);
                note.ReminderTime = DateTime.Parse(row.Split("~~")[5]);

                notes.Add(note);
            }

            Note rnote = new Note();
            rnote = notes.FirstOrDefault(x => x.ID == id && x.UserID == searchNote.UserID);
            return rnote;
        }

        // POST api/<NoteController>
        [HttpPost("SaveNote")]
        public Note Post([FromBody] Note note)
        {
            if(note.NoteType == EnumNoteType.Reminder || note.NoteType == EnumNoteType.Task)
            {
                if(note.ReminderTime == DateTime.MinValue || note.ReminderTime < DateTime.Now)
                {
                    note.ErrorMessage = "Please Set the Time";
                    return note;
                }
            }

            var lastLine = System.IO.File.ReadLines(@"Data/notes.txt").LastOrDefault(); // for txt file

            //FileStream streamed = System.IO.File.OpenRead(@"c:\Users\Adnanul Anwar\Desktop\newnotes.xml");
            //var result = (List<Note>)(NoteseriaLizer.Deserialize(streamed));

            note.ID = 1;
            if (lastLine != null)
            {
                note.ID = int.Parse(lastLine.Split("~~")[0]) + 1;
                //note.ID = result.LastOrDefault().ID + 1;
            }
            note.UserID = 1;
            note.NoteCreateTime = DateTime.Now;

            string noteStr = note.ID + "~~" +note.NoteMessage + "~~" + (int)note.NoteType + "~~" +note.UserID + "~~" +note.NoteCreateTime + "~~" + note.ReminderTime;

            System.IO.File.AppendAllText(@"Data/notes.txt", noteStr + Environment.NewLine);
            //FileStream stream = System.IO.File.AppendAllText(@"c:\Users\Adnanul Anwar\Desktop\newnotes.xml");
            //NoteseriaLizer.Serialize(stream, note);
            //stream.Dispose();
            return note;

        }

        // PUT api/<NoteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NoteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
