using Core.Entitties.Abstract;

namespace Entites.TableModels
{
    public class Tag : BaseEntity, IEntity
    {
        public string Name { get; set; }

        public ICollection<BlogTag> BlogTags { get; set; }
    }
}
