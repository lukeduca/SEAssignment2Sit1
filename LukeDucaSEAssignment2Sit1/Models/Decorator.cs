using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LukeDucaSEAssignment2Sit1.Models.DesignPatterns;

namespace LukeDucaSEAssignment2Sit1.Models
{
    public class Decorator:ArticleComponent
    {
        ArticleComponent component = null;

        public Decorator(ArticleComponent articleComponent)
        {
            this.component = articleComponent;
        }

        public override void upload()
        {
            component.upload();
        }

        
     
        
       
    }
}