using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LukeDucaSEAssignment2Sit1.Models
{
    public class CreateModelView
    {
        //------------------------------------------------------------------------------

        public int Article_Id { get; set; }

        [Display(Name = "Account Name")]
        public string Article_Name { get; set; }

        [Display(Name = "Account Description")]
        [DataType(DataType.MultilineText)]
        public string Article_Description { get; set; }

        [Display(Name = "Article Publish Date")]
        [DataType(DataType.Date)]
        public System.DateTime Article_PublishDate { get; set; }

        [Display(Name = "User")]
        public int User_Id { get; set; }

        [Display(Name = "Media Manager")]
        public int MedaManager_Id { get; set; }
        public int ArticleStatus_Id { get; set; }
        public int Article_State_Id { get; set; }
        public Nullable<int> ArticleComment_Id { get; set; }
        
        public virtual tbl_ArticleState tbl_ArticleState { get; set; }
        public virtual tbl_ArticleStatus tbl_ArticleStatus { get; set; }
        public virtual tbl_Comments tbl_Comments { get; set; }
        public virtual tbl_Users tbl_Users { get; set; }

        public string articletype { get; set; }

        public bool CheckBoxValue
        {
            get { return Boolean.Parse(articletype); }
        }
    }
}

