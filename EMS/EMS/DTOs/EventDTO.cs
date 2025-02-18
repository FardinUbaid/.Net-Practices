using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EMS.Attributes;

namespace EMS.DTOs
{
    public class EventDTO
    {
        public int EventId { get; set; }
        [StringLength(50)]
        [Name]
        public string Name { get; set; }
        [Required]
        [DATE]
        public DateTime Date { get; set; }
        [Required]
        [StringLength(50)]
        [VENUE]
        public string Venue { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }


    }
}