using Core.Entitties.Abstract;

namespace Entites.TableModels
{
    public class Position : BaseEntity, IEntity
    {
        public string Name { get; set; }

        public ICollection<Team> Teams { get; set; }
        public ICollection<Testimonial> Testimonials { get; set; }
    }
}
