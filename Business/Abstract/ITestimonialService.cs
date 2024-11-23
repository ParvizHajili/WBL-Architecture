using Core.Results.Abstract;
using Entites.TableModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ITestimonialService
    {
        Core.Results.Abstract.IResult Add(Testimonial model,IFormFile imageUrl,IWebHostEnvironment webrootPath);
        Core.Results.Abstract.IResult Update(Testimonial model, IFormFile imageUrl, IWebHostEnvironment webrootPath);
        Core.Results.Abstract.IResult Delete(int id);
        IDataResult<Testimonial> GetById(int id);
        IDataResult<List<Testimonial>> GetAll();
    }
}
