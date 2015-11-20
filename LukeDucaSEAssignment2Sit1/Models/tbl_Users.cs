//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LukeDucaSEAssignment2Sit1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class tbl_Users
    {
        public tbl_Users()
        {
            this.tbl_Article = new HashSet<tbl_Article>();
        }
    
        public int User_Id { get; set; }

        [Required]
        [Display(Name="First Name")]
        public string First_Name { get; set; }

        [Required]
        [Display(Name="Last Name")]
        public string Last_Name { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Role")]
        public int Role_Id { get; set; }
    
        public virtual ICollection<tbl_Article> tbl_Article { get; set; }
        public virtual tbl_Roles tbl_Roles { get; set; }
    }
}
