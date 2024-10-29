using Core.Entitties.Abstract;

namespace Entites.TableModels
{
    public class About : BaseEntity, IEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
