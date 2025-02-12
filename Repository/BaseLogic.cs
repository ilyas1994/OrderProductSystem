using Models;
using Models.BaseEntity;

namespace Repository;

public class BaseLogic : IBaseLogic
{
    public readonly IRepository<BaseEntity> _repository;

    public BaseLogic(IRepository<BaseEntity> repository)
    {
        _repository = repository;
    }


    public IRepository<BaseEntity> BaseRepo()
    {
        return _repository;
    }
}