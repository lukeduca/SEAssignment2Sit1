﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LukeDucaSEAssignment2Sit1.Models.DesignPatterns
{
    public class FbArticle:Decorator
    {
        public FbArticle(ArticleComponent ac) : base(ac)
        {
        }
       
    }
}