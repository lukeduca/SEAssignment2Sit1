using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LukeDucaSEAssignment2Sit1.Models.DesignPatterns
{
    public abstract class ArticleComponent
    {
        ArticleFactory aFactory { get; set; }
        ArticleComponent aComponent { get; set; }

        protected ArticleComponent()
        {
        }

        protected ArticleComponent(ArticleFactory af, ArticleComponent ac)
        {
            this.aFactory = af;
            this.aComponent = ac;
        }

        public abstract void upload(ArticleFactory articleFactory);

    }
}