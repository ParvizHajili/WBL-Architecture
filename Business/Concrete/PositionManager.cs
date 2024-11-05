using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entites.TableModels;
using FluentValidation;

namespace Business.Concrete
{
    public class PositionManager : IPositionService
    {
        IPositionDal _positionDal = new PositionDal();
        private readonly IValidator<Position> _validator;
        public PositionManager(IValidator<Position> validator)
        {
            _validator = validator;
        }

        public PositionManager()
        {
            
        }

        public void Add(Position position)
        {
            //var validationRes = _validator.Validate(position);
            //if (validationRes.IsValid)
            //{
                _positionDal.Add(position);
            //}
        }

        public void Delete(int id)
        {
            var data = _positionDal.GetById(id);

            data.IsDeleted = id;

            _positionDal.Update(data);
        }

        public List<Position> GetAll()
        {
            return _positionDal.GetAll(x => x.IsDeleted == 0);
        }

        public Position GetById(int id)
        {
            return _positionDal.GetById(id);
        }

        public void Update(Position position)
        {
            _positionDal.Update(position);
        }
    }
}
