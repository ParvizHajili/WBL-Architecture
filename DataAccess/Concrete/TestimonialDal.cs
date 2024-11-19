using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Contexxt;
using Entites.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace DataAccess.Concrete
{
    public class TestimonialDal : BaseRepository<Testimonial, ApplicationDbContext>, ITestimonialDal
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public List<Testimonial> GetAllTestimonial()
        {
            return _context.Testimonials
                .Include(x => x.Position)
                .Where(x => x.IsDeleted == 0).ToList();
        }
    }
}
