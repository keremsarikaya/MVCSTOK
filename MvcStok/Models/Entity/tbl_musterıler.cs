//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcStok.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tbl_musterıler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_musterıler()
        {
            this.tbl_satislar = new HashSet<tbl_satislar>();
        }
    
        public int musteriid { get; set; }

        [Required(ErrorMessage = "İsim alanı boş bırakılamaz")]
        [StringLength(50, ErrorMessage ="En fazla 50 karakter girilebilir")]
        public string musteriad { get; set; }
        [Required(ErrorMessage = "Soyisim alanı boş bırakılamaz")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girilebilir")]
        public string musterisoyad { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_satislar> tbl_satislar { get; set; }
    }
}
