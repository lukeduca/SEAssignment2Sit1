//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace LukeDucaSEAssignment2Sit1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Comments
    {
        public tbl_Comments()
        {
            this.tbl_Article = new HashSet<tbl_Article>();
        }
    
        public int ArticleComment_Id { get; set; }

        [Display(Name = "Comments")]
        public string ArticleComment_Content { get; set; }
        public int User_Id { get; set; }
        public int Article_Id { get; set; }
    
        public virtual ICollection<tbl_Article> tbl_Article { get; set; }
    }
}
