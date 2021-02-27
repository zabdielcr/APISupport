using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSupport.Models
{
    public class Assignments
    {
        private int idIssue;
        private int idSupporter;

        public Assignments()
        {
        }

        public Assignments(int idIssue, int idSupporter)
        {
            this.IdIssue = idIssue;
            this.IdSupporter = idSupporter;
        }

        public int IdIssue { get => idIssue; set => idIssue = value; }
        public int IdSupporter { get => idSupporter; set => idSupporter = value; }
    }
}
