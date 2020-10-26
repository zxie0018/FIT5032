using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace FIT5032_Task03.Models
{
    public class EmailModel
    {
        [Required, Display(Name = "From email")]
        public string FromEmail { get; set; }

        [Required, Display(Name = "To email")]
        public string ToEmail { get; set; }

        [Required, Display(Name = "Email Subject")]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }

        public Attachment Attachment { get; set; }
    }
}