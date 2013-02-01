using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epic.Models;

namespace Epic.Data
{
    public class UnitData : IGlobalData
    {
        public void Initialize(GlobalObject obj)
        {

        }

        public object GetData()
        {
            return new UnitModel() {
                Title = "Index",
                Message = "This is a template for a simple marketing or informational website. It includes a large callout called the hero unit and three supporting pieces of content. Use it as a starting point to create something more unique."
            };
        }
    }
}