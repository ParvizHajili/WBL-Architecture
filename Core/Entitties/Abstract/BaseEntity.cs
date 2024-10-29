namespace Core.Entitties.Abstract
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public int IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastUpdatedDate { get; set; }
    }
}
