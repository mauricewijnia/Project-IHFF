//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_IHFF.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FilmExhibitions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FilmExhibitions()
        {
            this.FilmTickets = new HashSet<FilmTickets>();
        }
    
        public int id { get; set; }
        public System.DateTime startTime { get; set; }
        public Nullable<System.DateTime> endTime { get; set; }
        public int filmId { get; set; }
    
        public virtual Films Films { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FilmTickets> FilmTickets { get; set; }
    }
}