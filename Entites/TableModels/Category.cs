using Core.Entitties.Abstract;

namespace Entites.TableModels
{
    public class Category : BaseEntity, IEntity
    {
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
