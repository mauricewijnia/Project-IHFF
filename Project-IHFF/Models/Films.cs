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
    using Project_IHFF.Models;
    
    public partial class Films : Items
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Films()
        {
            this.Items = new HashSet<Items>();
        }
    
        public int filmId { get; set; }
        public string director { get; set; }
        public string actors { get; set; }
        public string image { get; set; }
        public string imbdLink { get; set; }
        public int capacity { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Items> Items { get; set; }

        public Items SplitItem(Films film)
        {
            return (new Items(film.description, film.location, Convert.ToDecimal(film.price), film.name, Convert.ToDateTime(film.startTime), Convert.ToDateTime(film.endTime)));
        }
    }
}
