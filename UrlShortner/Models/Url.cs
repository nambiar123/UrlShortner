using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UrlShortner.Models
{
    public class Url
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(2048)] // Maximum length for URLs according to HTTP specs
        public string LongUrl { get; set; }

        [Required]
        [MaxLength(100)] // Adjust as needed for your short URL length
        public string ShortUrl { get; set; }
        public int Clicks { get; set; }

        [MaxLength(255)]
        public string IPAddress { get; set; }

        [MaxLength(255)]
        public string UserAgent { get; set; }
    }
}