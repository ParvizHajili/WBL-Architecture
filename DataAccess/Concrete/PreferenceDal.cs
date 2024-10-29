using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Contexxt;
using Entites.TableModels;

namespace DataAccess.Concrete
{
    public class PreferenceDal : BaseRepository<Preference, ApplicationDbContext>, IPreferenceDal { }
}
