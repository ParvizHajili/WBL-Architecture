using Business.Abstract;
using Business.Validations;
using Core.Results.Abstract;
using Core.Results.Concrete;
using Core.Validation;
using DataAccess.Abstract;
using Entites.TableModels;
using Core.Extensions;
using Core.Constants;

namespace Business.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;
        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public IResult Add(Testimonial model)
        {
            var validationResult = ValidationTool.Validate(new TestimonialValidation(), model, out List<ValidationErrorModel> errors);
            if (!validationResult)
                return new ErrorResult(errors.ValidationErrorMessageNewLine());

            _testimonialDal.Add(model);

            return new SuccessResult(DefaultConstantValues.DATA_ADDED_SUCCESFULLY);
        }

        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Testimonial>> GetAll()
        {
            return new SuccessDataResult<List<Testimonial>>(_testimonialDal.GetAllTestimonial());
        }

        public IDataResult<Testimonial> GetById(int id)
        {
            return new SuccessDataResult<Testimonial>(_testimonialDal.GetById(id));
        }

        public IResult Update(Testimonial model)
        {
            throw new NotImplementedException();
        }
    }
}
