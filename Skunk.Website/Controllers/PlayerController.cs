using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Skunk.Website.Controllers
{
    public class PlayerController : RenderMvcController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override ActionResult Index(RenderModel model)
        {
            return Redirect("/");
        }
    }
}
