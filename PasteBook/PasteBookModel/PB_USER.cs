//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PasteBookModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class PB_USER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PB_USER()
        {
            this.PB_COMMENTS = new HashSet<PB_COMMENTS>();
            this.PB_FRIENDS = new HashSet<PB_FRIENDS>();
            this.PB_FRIENDS1 = new HashSet<PB_FRIENDS>();
            this.PB_LIKES = new HashSet<PB_LIKES>();
            this.PB_NOTIFICATION = new HashSet<PB_NOTIFICATION>();
            this.PB_NOTIFICATION1 = new HashSet<PB_NOTIFICATION>();
            this.PB_POSTS = new HashSet<PB_POSTS>();
            this.PB_POSTS1 = new HashSet<PB_POSTS>();
        }
    
        public int ID { get; set; }

        [Display(Name = "User name")]
        [Required(ErrorMessage = "User name is required")]
        [StringLength(50, ErrorMessage = "User name must contain maximum of 50 characters")]
        [RegularExpression("^((\\s*([_.]?)\\s*[a-zA-Z0-9]+)+([_.]?)\\s*)$", ErrorMessage = "First name must contain only alphanumeric and not repeating symbols (-.') ")]
        public string USER_NAME { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, ErrorMessage = "Password must contain maximum of 50 characters")]
        public string PASSWORD { get; set; }
        public string SALT { get; set; }

        [Display(Name = "First name")]
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name must contain maximum of 50 characters")]
        [RegularExpression("^((\\s*[ '.-]?\\s*[a-zA-Z\\d]+)+[ '.-]?\\s*)$",ErrorMessage ="First name must contain only alphanumeric and not repeating symbols (-.') ")]
        public string FIRST_NAME { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name must contain maximum of 50 characters")]
        [RegularExpression("^((\\s*[ '.-]?\\s*[a-zA-Z\\d]+)+[ '.-]?\\s*)$", ErrorMessage = "First name must contain only alphanumeric and not repeating symbols (-.') ")]
        public string LAST_NAME { get; set; }

        [Display(Name = "Birthdate")]
        [Required(ErrorMessage = "Birthdate is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime BIRTHDATE { get; set; }

        [Display(Name = "Country")]
        public Nullable<int> COUNTRY_ID { get; set; }


        [Display(Name = "Mobile number")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Mobile number is not valid")]
        [Phone(ErrorMessage = "Mobile number is not valid")]
        public string MOBILE_NO { get; set; }

        [Display(Name = "Gender")]
        public string GENDER { get; set; }
        public byte[] PROFILE_PIC { get; set; }


        public System.DateTime DATE_CREATED { get; set; }
        public string ABOUT_ME { get; set; }

        [Display(Name = "E-mail address")]
        [Required(ErrorMessage = "E-mail address is required")]
        [StringLength(50, ErrorMessage = "Email Address must contain maximum of 50 characters")]
        [EmailAddress(ErrorMessage ="Email Address is invalid")]
        public string EMAIL_ADDRESS { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PB_COMMENTS> PB_COMMENTS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PB_FRIENDS> PB_FRIENDS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PB_FRIENDS> PB_FRIENDS1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PB_LIKES> PB_LIKES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PB_NOTIFICATION> PB_NOTIFICATION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PB_NOTIFICATION> PB_NOTIFICATION1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PB_POSTS> PB_POSTS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PB_POSTS> PB_POSTS1 { get; set; }
        public virtual PB_REF_COUNTRY PB_REF_COUNTRY { get; set; }
    }
}
