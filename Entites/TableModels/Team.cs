using Core.Entitties.Abstract;

namespace Entites.TableModels
{
    public class Team : BaseEntity, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string InstagramAdress { get; set; }
        public int PositionId { get; set; }

        public Position Position { get; set; }
    }
}
