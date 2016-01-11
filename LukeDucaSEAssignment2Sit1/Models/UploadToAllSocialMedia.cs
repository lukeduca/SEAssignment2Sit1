using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LukeDucaSEAssignment2Sit1.Models.DesignPatterns;

namespace LukeDucaSEAssignment2Sit1.Models
{
    public class UploadToAllSocialMedia
    {

        public void publishEverywhere()
        {
            ArticleComponent aC = new baseArticle();
            FbArticle facebook = new FbArticle(aC);
            TwitterArticle twitter = new TwitterArticle(facebook);
            twitter.upload();
        }

    }
}