using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LukeDucaSEAssignment2Sit1.Models.DesignPatterns.State;

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

        public virtual void ReviewArticleByReviewer()
        { }

        public virtual void ReviewArticleByMediaManager()
        { }

    }
}