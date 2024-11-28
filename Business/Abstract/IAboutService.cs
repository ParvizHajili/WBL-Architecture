using Core.Results.Abstract;
using Entites.TableModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
	public interface IAboutService
	{
		Core.Results.Abstract.IResult Add(About model, IFormFile imageUrl, IWebHostEnvironment webrootPath);
		Core.Results.Abstract.IResult Update(About model, IFormFile imageUrl, IWebHostEnvironment webrootPath);
		Core.Results.Abstract.IResult Delete(int id);
		IDataResult<About> GetById(int id);
		IDataResult<List<About>> GetAll();
	}
}
