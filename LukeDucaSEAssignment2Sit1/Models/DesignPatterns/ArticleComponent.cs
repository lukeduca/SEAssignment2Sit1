using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LukeDucaSEAssignment2Sit1.Models.DesignPatterns
{
    public abstract class ArticleComponent
    {
        ArticleComponent aComponent { get; set; }

        protected ArticleComponent()
        {
        }

        protected ArticleComponent(ArticleComponent ac)
        {
            this.aComponent = ac;
        }

        public abstract void upload(ArticleFactory articleFactory);

    }
}