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
    
    public partial class Specials
    {
        public int itemId { get; set; }
        public string host { get; set; }
        public int capacity { get; set; }
    
        public virtual Items Items { get; set; }
    }
}
