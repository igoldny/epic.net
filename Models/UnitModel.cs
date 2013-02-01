using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epic.Models
{
    [Serializable]
    public class UnitModel
    {
        public string Title { get; set; }
        public string Message { get; set; }
    }
}