using Core.Entitties.Abstract;

namespace Entites.TableModels
{
    public class Testimonial : BaseEntity, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public string Message { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}
