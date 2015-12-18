using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LukeDucaSEAssignment2Sit1.Models.DesignPatterns
{
    public class TwitterArticle:ArticleComponent
    {
        public TwitterArticle()
        {
        }

        public TwitterArticle(ArticleFactory af, ArticleComponent ac) : base(af, ac)
        {
        }

        public override void upload(ArticleFactory articleFactory)
        {
            //The article will be uploaded on Twitter
        }
    }
}