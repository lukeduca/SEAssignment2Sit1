using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LukeDucaSEAssignment2Sit1.Models.DesignPatterns
{
    public abstract class ArticleFactory
    {

        public virtual void CreateArticle()
        { }

        public virtual void DeleteArticle()
        { }

        public virtual void UpdateArticle()
        { }

    }
}