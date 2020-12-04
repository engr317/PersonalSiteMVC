using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //I added this for validation

namespace PersonalSiteMVC.Models
{
    public class ContactViewModel
    {
        //properties

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Subject { get; set; }

        [Required(ErrorMessage = "* Message is Required")]
        [UIHint("MultilineText")]//change from a single line textbox to a multiline
        public string Message { get; set; }
    }
}