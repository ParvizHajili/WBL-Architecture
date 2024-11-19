using Core.DataAccess.Abstract;
using Entites.TableModels;

namespace DataAccess.Abstract
{
    public interface ITestimonialDal : IBaseRepository<Testimonial>
    {
        List<Testimonial> GetAllTestimonial();
    }
}
