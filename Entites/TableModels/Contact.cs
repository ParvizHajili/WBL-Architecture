using Core.Entitties.Abstract;

namespace Entites.TableModels
{
    public class Contact : BaseEntity, IEntity
    {
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsContacted { get; set; }
    }
}
