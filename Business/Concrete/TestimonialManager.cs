using Business.Abstract;
using Business.Validations;
using Core.Constants;
using Core.Extensions;
using Core.Results.Abstract;
using Core.Results.Concrete;
using Core.Validation;
using DataAccess.Abstract;
using Entites.TableModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;
        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public Core.Results.Abstract.IResult Add(Testimonial model, IFormFile imageUrl, IWebHostEnvironment webrootPath)
        {
            model.ImageUrl = PictureHelper.UploadImage(imageUrl, webrootPath.WebRootPath);

            var validationResult = ValidationTool.Validate(new TestimonialValidation(), model, out List<ValidationErrorModel> errors);
            if (!validationResult)
                return new ErrorResult(errors.ValidationErrorMessageNewLine());

            _testimonialDal.Add(model);

            return new SuccessResult(DefaultConstantValues.DATA_ADDED_SUCCESFULLY);
        }

        public Core.Results.Abstract.IResult Delete(int id)
        {
            var model = GetById(id).Data;

            model.IsDeleted = id;
            model.LastUpdatedDate = DateTime.Now;

            _testimonialDal.Update(model);

            return new SuccessResult(DefaultConstantValues.DATA_DELETED_SUCCESFULLY);
        }

        public IDataResult<List<Testimonial>> GetAll()
        {
            return new SuccessDataResult<List<Testimonial>>(_testimonialDal.GetAllTestimonial());
        }

        public IDataResult<Testimonial> GetById(int id)
        {
            return new SuccessDataResult<Testimonial>(_testimonialDal.GetById(id));
        }

        public Core.Results.Abstract.IResult Update(Testimonial model, IFormFile imageUrl, IWebHostEnvironment webrootPath)
        {
            var existingData = _testimonialDal.GetById(model.Id);

            if (imageUrl is null)
            {
                model.ImageUrl = existingData.ImageUrl;
            }
            else
            {
                model.ImageUrl = PictureHelper.UploadImage(imageUrl, webrootPath.WebRootPath);
            }

            var validationResult = ValidationTool.Validate(new TestimonialValidation(), model, out List<ValidationErrorModel> errors);
            if (!validationResult)
                return new ErrorResult(errors.ValidationErrorMessageNewLine());

            _testimonialDal.Update(model);

            return new SuccessResult(DefaultConstantValues.DATA_UPDATED_SUCCESFULLY);
        }
    }
}
