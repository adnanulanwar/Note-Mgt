using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteService.Models
{
    public class Note
    {
        public Note()
        {

        }

        public int ID { get; set; }
        public string NoteMessage { get; set; }
        public EnumNoteType NoteType { get; set; }
        public int UserID { get; set; }
        public DateTime NoteCreateTime { get; set; }
        public DateTime ReminderTime { get; set; }
        public string ErrorMessage { get; set; }
      }

    public enum EnumNoteType
    {
        Regular = 1,
        Reminder = 2,
        Task = 3,
        BookMark = 4
    }
}
