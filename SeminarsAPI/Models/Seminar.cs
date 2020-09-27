using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarsAPI.Models
{
    public class Seminar
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Speaker { get; set; }
        public string Topic { get; set; }
        public string Information { get; set; }
        public DateTime Time { get; set; }
        public string Location { get; set; }
        public int MaxAttendees { get; set; }
        public IList<Attendee> Seminarattendees { get; set; }
    }
}
