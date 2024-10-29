using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Contexxt;
using Entites.TableModels;

namespace DataAccess.Concrete
{
    public class BlogTagDal : BaseRepository<BlogTag, ApplicationDbContext>, IBlogTagDal { }
}
