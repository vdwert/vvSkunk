using Examine;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Skunk.Website.Controllers
{
    public class SearchController : RenderMvcController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override ActionResult Index(RenderModel model)
        {
            Skunk.Website.Models.SearchModel searchModel = new Skunk.Website.Models.SearchModel(model.Content);

            var searcher = ExamineManager.Instance.SearchProviderCollection["SiteSearcher"];
            searchModel.SearchResults = searcher.Search(Request["searchTerm"], true);

            return View(searchModel);
        }
    }
}
