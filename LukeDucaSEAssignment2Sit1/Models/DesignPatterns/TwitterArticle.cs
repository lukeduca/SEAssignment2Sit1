using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LukeDucaSEAssignment2Sit1.Models.DesignPatterns
{
    public class TwitterArticle:Decorator
    {
        public TwitterArticle(ArticleComponent ac) : base(ac)
        {
        }

    }
}