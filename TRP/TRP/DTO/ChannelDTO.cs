using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TRP.DTO
{
    public class ChannelDTO
    {
            public int ChannelId { get; set; }
            [Required]
            public string ChannelName { get; set; }
            [Required]
            [Range(1900,2025)]
            public int EstablishedYear { get; set; }
            [Required]
            public string Country { get; set; }
    }
}