using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PasteBook
{
    public class UserDetailsModel
    {
        public int ID { get; set; }
        [Display(Name ="User name")]
        [Required(ErrorMessage ="User name is required")]
        [StringLength(50,ErrorMessage ="User name must contain maximum of 50 characters")]
        public string UserName { get; set; }

        [Display(Name = "First name")]
        [Required(ErrorMessage ="First name is required")]
        [StringLength(50, ErrorMessage = "First name must contain maximum of 50 characters")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name must contain maximum of 50 characters")]
        public string LastName { get; set; }

        [Display(Name="E-mail address")]
        [Required(ErrorMessage = "E-mail address is required")]
        [StringLength(50, ErrorMessage = "Email Address must contain maximum of 50 characters")]
        public string EmailAddress { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, ErrorMessage = "Password must contain maximum of 50 characters")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm password is required")]
        [Compare("Password", ErrorMessage ="Password mismatch")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Birthdate")]
        [Required(ErrorMessage = "Birthdate is required")]
        public DateTime  Birthday { get; set; }

        [Display(Name = "Country")]
        public int Country { get; set; }

        [Display(Name = "Mobile number")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Mobile number is not valid")Phone]
        public string MobileNumber { get; set; }

        public string Salt { get; set; }
        public byte[] ProfilePic { get; set; }
        public DateTime DateCreated { get; set; }
        public string AboutMe { get; set; }


    }
}