//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PateBookEntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class PB_REF_COUNTRY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PB_REF_COUNTRY()
        {
            this.PB_USER = new HashSet<PB_USER>();
        }
    
        public int ID { get; set; }
        public string COUNTRY { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PB_USER> PB_USER { get; set; }
    }
}
