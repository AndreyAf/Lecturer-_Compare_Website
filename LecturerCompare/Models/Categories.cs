//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LecturerCompare.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Categories
    {
        public Categories()
        {
            this.Sub_Categories = new HashSet<Sub_Categories>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
    
        public virtual ICollection<Sub_Categories> Sub_Categories { get; set; }
    }
}
