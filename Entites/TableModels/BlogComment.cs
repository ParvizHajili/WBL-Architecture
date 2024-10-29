using Core.Entitties.Abstract;

namespace Entites.TableModels
{
    public class BlogComment : BaseEntity, IEntity
    {
        public int ParentId { get; set; }
        public int BlogId { get; set; }
        public string Text { get; set; }

        public Blog Blog { get; set; }
    }
}
