using Business.Abstract;
using Business.Validations;
using Core.Extensions;
using Core.Results.Abstract;
using Core.Results.Concrete;
using Core.Validation;
using DataAccess.Abstract;
using Entites.TableModels;
using FluentValidation;

namespace Business.Concrete
{
    public class PositionManager : IPositionService
    {
        private readonly IPositionDal _positionDal;
        private readonly IValidator<Position> _validator;
        public PositionManager(IValidator<Position> validator, IPositionDal positionDal)
        {
            _validator = validator;
            _positionDal = positionDal;
        }

        public IResult Add(Position position)
        {
            var validation = ValidationTool.Validate(new PositionValidation(),position,out List<ValidationErrorModel> errors);
            if (!validation)
                return new ErrorResult(errors.ValidationErrorMessageNewLine());

            _positionDal.Add(position);

            return new SuccessResult("Vəzifə uğurla əlavə olundu");
        }

        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Position>> GetAll()
        {
            return new SuccessDataResult<List<Position>>(_positionDal.GetAll(x => x.IsDeleted == 0));
        }

        public IDataResult<Position> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Position position)
        {
            throw new NotImplementedException();
        }
    }
}
