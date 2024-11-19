using Business.Abstract;
using Business.Validations;
using Core.Constants;
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
            var validation = ValidationTool.Validate(new PositionValidation(), position, out List<ValidationErrorModel> errors);
            if (!validation)
                return new ErrorResult(errors.ValidationErrorMessageNewLine());

            _positionDal.Add(position);

            return new SuccessResult(DefaultConstantValues.DATA_ADDED_SUCCESFULLY);
        }

        public IResult Delete(int id)
        {
            var deletedEntity = _positionDal.GetById(id);

            deletedEntity.IsDeleted = id;
            deletedEntity.LastUpdatedDate = DateTime.Now;

            _positionDal.Update(deletedEntity);

            return new SuccessResult(DefaultConstantValues.DATA_DELETED_SUCCESFULLY);
        }

        public IDataResult<List<Position>> GetAll()
        {
            return new SuccessDataResult<List<Position>>(_positionDal.GetAll(x => x.IsDeleted == 0));
        }

        public IDataResult<Position> GetById(int id)
        {
            return new SuccessDataResult<Position>(_positionDal.GetById(id));
        }

        public IResult Update(Position position)
        {
            var validationResult = ValidationTool.Validate(new PositionValidation(), position, out List<ValidationErrorModel> errors);
            if (!validationResult)
                return new ErrorResult(errors.ValidationErrorMessageNewLine());

            position.LastUpdatedDate = DateTime.Now;

            _positionDal.Update(position);

            return new SuccessResult(DefaultConstantValues.DATA_UPDATED_SUCCESFULLY);
        }
    }
}
