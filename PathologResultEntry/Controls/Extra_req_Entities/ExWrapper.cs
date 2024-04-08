using System;
using System.ComponentModel;

namespace PathologResultEntry.Controls.Extra_req_Entities
{
    public class ExWrapper
    {
        public string Entity_NAME { get; set; }
        public string Action { get; set; }
        public string Details { get; set; }
        public string Created_By { get; set; }
        public DateTime? Created_on { get; set; }
        public string Status { get; set; }
        [Browsable ( false )]
        public long ID { get; set; }
    }
}
