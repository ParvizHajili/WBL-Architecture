using Business.Abstract;
using Business.Validations;
using Core.Constants;
using Core.Extensions;
using Core.Results.Abstract;
using Core.Results.Concrete;
using Core.Validation;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entites.TableModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
	public class AboutManager : IAboutService
	{
		private readonly IAboutDal _aboutDal;
		public AboutManager(IAboutDal aboutDal)
		{
			_aboutDal = aboutDal;
		}

		public Core.Results.Abstract.IResult Add(About model, IFormFile imageUrl, IWebHostEnvironment webrootPath)
		{
			model.ImageUrl = PictureHelper.UploadImage(imageUrl, webrootPath.WebRootPath);

			var validationResult = ValidationTool.Validate(new AboutValidation(), model, out List<ValidationErrorModel> errors);
			if (!validationResult)
				return new ErrorResult(errors.ValidationErrorMessageNewLine());

			_aboutDal.Add(model);

			return new SuccessResult(DefaultConstantValues.DATA_ADDED_SUCCESFULLY);
		}

		public Core.Results.Abstract.IResult Delete(int id)
		{
			throw new NotImplementedException();
		}

		public IDataResult<List<About>> GetAll()
		{
			return new SuccessDataResult<List<About>>(_aboutDal.GetAll());
		}

		public IDataResult<About> GetById(int id)
		{
			return new SuccessDataResult<About>(_aboutDal.GetById(id));
		}

		public Core.Results.Abstract.IResult Update(About model, IFormFile imageUrl, IWebHostEnvironment webrootPath)
		{
			throw new NotImplementedException();
		}
	}
}
