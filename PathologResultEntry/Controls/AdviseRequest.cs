using System;
using System.ComponentModel;

namespace PathologResultEntry.Controls
{
    public class AdviseRequest
    {
        public string CreatedBy { get; set; }
        public string OpenedFor { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreatedOn { get; set; }
        [Browsable(false)]
        public long ID { get; set; }
    }
}
