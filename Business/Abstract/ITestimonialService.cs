using Core.Results.Abstract;
using Entites.TableModels;

namespace Business.Abstract
{
    public interface ITestimonialService
    {
        IResult Add(Testimonial model);
        IResult Update(Testimonial model);
        IResult Delete(int id);
        IDataResult<Testimonial> GetById(int id);
        IDataResult<List<Testimonial>> GetAll();
    }
}
