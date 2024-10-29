using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Contexxt;
using Entites.TableModels;

namespace DataAccess.Concrete
{
    public class PositionDal : BaseRepository<Position, ApplicationDbContext>, IPositionDal { }
}
