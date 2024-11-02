using Entites.TableModels;

namespace Business.Abstract
{
    public interface IPositionService
    {
        void Add(Position position);
        void Update(Position position);
        void Delete(int id);
        Position GetById(int id);
        List<Position> GetAll();
    }
}
