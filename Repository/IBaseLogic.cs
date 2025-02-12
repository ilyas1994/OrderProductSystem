using Models;
using Models.BaseEntity;

namespace Repository;

public interface IBaseLogic
{
    public IRepository<BaseEntity> BaseRepo();

}