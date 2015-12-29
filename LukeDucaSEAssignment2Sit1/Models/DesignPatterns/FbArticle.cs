using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LukeDucaSEAssignment2Sit1.Models.DesignPatterns
{
    public class FbArticle:ArticleComponent
    {
        public FbArticle()
        {
        }

        public FbArticle(ArticleComponent ac) : base(ac)
        {
        }

        public override void upload(ArticleFactory articleFactory)
        {
            //The article will be uploaded on Facebook
        }
    }
}