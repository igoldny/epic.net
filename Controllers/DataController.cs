using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epic.Data;
using StructureMap;

namespace Epic.Controllers
{
    public class DataController : Controller
    {
        public ActionResult Get(string Models)
        {
            JsonObject jsonObject = new JsonObject();

            string[] modelsArr = Models.Split(new char[] { ',' });
            foreach (string Model in modelsArr)
            {
                IGlobalData modelData = ObjectFactory.TryGetInstance<IGlobalData>(Model);

                if (modelData != null)
                {
                    modelData.Initialize(new GlobalObject()
                    {
                        // global object data
                    });
                    jsonObject[Model] = modelData.GetData();
                }
            }

            return Content(jsonObject.ToString(), "application/json");
        }
    }
}
