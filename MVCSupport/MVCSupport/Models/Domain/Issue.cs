using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSupport.Models.Domain
{
    public class Issue
    {
        private int reportNumber;
        private string classification;
        private string status;
        private TimeSpan reportTimestamp;
        private string resolutionComment;
        private int idClient;


        public Issue()
        {
        }

        public Issue(int reportNumber, string classification, string status, TimeSpan reportTimestamp, string resolutionComment, int idClient)
        {
            this.ReportNumber = reportNumber;
            this.Classification = classification;
            this.Status = status;
            this.ReportTimestamp = reportTimestamp;
            this.ResolutionComment = resolutionComment;
            this.IdClient = idClient;
        }

        public int ReportNumber { get => reportNumber; set => reportNumber = value; }
        public string Classification { get => classification; set => classification = value; }
        public string Status { get => status; set => status = value; }
        public TimeSpan ReportTimestamp { get => reportTimestamp; set => reportTimestamp = value; }
        public string ResolutionComment { get => resolutionComment; set => resolutionComment = value; }
        public int IdClient { get => idClient; set => idClient = value; }
    }
}
