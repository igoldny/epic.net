using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epic.Models
{
    [Serializable]
    public class ArticleModel
    {
        public string Head { get; set; }
        public string Description { get; set; }
    }
}