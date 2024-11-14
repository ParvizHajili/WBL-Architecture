using Core.Results.Abstract;
using Entites.TableModels;

namespace Business.Abstract
{
    public interface IPositionService
    {
        IResult Add(Position position);
        IResult Update(Position position);
        IResult Delete(int id);
        IDataResult<Position> GetById(int id);
        IDataResult<List<Position>> GetAll();
    }
}
