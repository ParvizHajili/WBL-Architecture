using Core.Entitties.Abstract;

namespace Entites.TableModels
{
    public class Blog : BaseEntity, IEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<BlogTag> BlogTags { get; set; }
        public ICollection<BlogComment>  BlogComments { get; set; }
    }
}
