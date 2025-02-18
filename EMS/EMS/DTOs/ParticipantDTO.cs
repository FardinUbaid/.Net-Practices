using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMS.DTOs
{
    public class ParticipantDTO
    {
        public int PId { get; set; }
        public string Name { get; set; }
        public int Contact { get; set; }
        public int EventId { get; set; }
        
    }
}