using System;
using System.Collections.Generic;

#nullable disable

namespace APISupport.Models
{
    public partial class Note
    {
        public int IdNotes { get; set; }
        public string Description { get; set; }
        public byte[] NoteTimestamp { get; set; }
        public int IdIssue { get; set; }

        public virtual Issue IdIssueNavigation { get; set; }
    }
}
