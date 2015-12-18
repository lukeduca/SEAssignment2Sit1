using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LukeDucaSEAssignment2Sit1.Models.DesignPatterns
{
    public class UploadToEverySocialMedia
    {
        //Publishing Video to Twitter and Facebook
        public void Publish()
        {
            ArticleFactory articleFactory = new VideoArticlecs();
            ArticleComponent articleComponentDecorator = new TwitterArticle(articleFactory, new FbArticle());
            articleComponentDecorator.upload(articleFactory);
        }

    }
}