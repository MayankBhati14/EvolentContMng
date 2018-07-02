using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ContactManager.Models
{
    public class PersonContactInfo
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "First Name")]
        public string FistName { get; set; }
        [Required]
        [Display(Name="Last Name")]
        [StringLength(255)]
        public string LastName { get; set; }
        [Required]
        [RegularExpression("^[a-z0-9][-a-z0-9._]+@([-a-z0-9]+.)+[a-z]{2,5}$")]
        public string Email { get; set; }
        public bool Status { get; set; }
    }
}