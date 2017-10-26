using Umbraco.Core.Models.PublishedContent;

namespace Skunk.Website.Models
{
    public class PictureGalleryModel : PublishedContentModel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        public PictureGalleryModel(Umbraco.Core.Models.IPublishedContent content)
            : base(content)
        {
        }

        public string[] Pictures { get; set; }
    }
}