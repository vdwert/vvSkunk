using System;
using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Skunk.Website.Controllers
{
    public class PictureGalleryController : RenderMvcController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override ActionResult Index(RenderModel model)
        {
            Skunk.Website.Models.PictureGalleryModel pictureGalleryModel = new Skunk.Website.Models.PictureGalleryModel(model.Content);

            pictureGalleryModel.Pictures = model.Content.GetPropertyValue("pictures").ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            return View(pictureGalleryModel);
        }
    }
}
