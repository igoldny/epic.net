using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epic.Models;

namespace Epic.Data
{
    public class ArticleData : IGlobalData
    {
        public void Initialize(GlobalObject obj)
        {

        }

        public object GetData()
        {
            List<ArticleModel> list = new List<ArticleModel>();

            for (int i = 0; i < 3; i++)
            {
                list.Add(new ArticleModel() {
                    Head = "Heading",
                    Description = "Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem malesuada magna mollis euismod. Donec sed odio dui."
                });
            }

            return list;
        }
    }
}