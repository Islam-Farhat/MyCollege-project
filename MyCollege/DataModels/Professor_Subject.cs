//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Professor_Subject
    {
        public int id { get; set; }
        public Nullable<int> professorId_FK { get; set; }
        public Nullable<int> subjectId_FK { get; set; }
    
        public virtual Professor Professor { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
