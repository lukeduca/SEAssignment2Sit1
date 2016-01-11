using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LukeDucaSEAssignment2Sit1.Models.DesignPatterns
{
    public class VideoArticleFactory: ArticleFactory2
    {
        public override Article create()
        {
            return new VideoArticlecs();
        }

    }
}