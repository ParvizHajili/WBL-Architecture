using Core.Entitties.Abstract;

namespace Entites.TableModels
{
    public class Preference : BaseEntity, IEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}
