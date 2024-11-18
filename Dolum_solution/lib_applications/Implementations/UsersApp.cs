using lib_entities;
using lib_applications.Interfaces;
using lib_repositories.Interfaces;
using lib_repositories;
using System.Linq.Expressions;

namespace lib_applications.Implementations;
public class UsersApp : IUsersApp
{
    private IUsersRepository iRespository;

    public UsersApp(IUsersRepository iRespository)
    {
        this.iRespository = iRespository;
    }

    public void Configure(string stringConnection)
    {
        this.iRespository!.Configure(stringConnection);
    }

    public List<Users> GetList()
    {
        return this.iRespository!.GetList();
    }

    public Users Save(Users entity)
    {
        if (entity == null)
            throw new Exception("lbNullEntity");
        if (entity.Id != 0)
            throw new Exception("lbIdIsntZero");

        if (!entity.Validate())
        {
            throw new Exception("lbWrongData");
        }
        return this.iRespository!.Save(entity);
    }

    public List<Users> Search(Users entity, string type)
    {
        Expression<Func<Users, bool>>? conditions = null;
        switch (type.ToUpper())
        {
            case "NAME": conditions = x => x.Name!.Contains(entity.Name); break;
            case "EMAIL": conditions = x => x.Email!.Contains(entity.Email); break;
            case "QUALITY": conditions = x => x.Quality!.Equals(entity.Quality); break;
            case "PASSWORD": conditions = x => x.Password!.Contains(entity.Password); break;
            case "REGISTER_DATE": conditions = x => x.Register_date!.Equals(entity.Register_date); break;
            default: conditions = x => x.Id == entity.Id; break;
        }

        return this.iRespository!.Search(conditions);
    }

    public Users Modify(Users entity)
    {
        if (entity == null)
            throw new Exception("lbNullEntity");
        if (entity.Id != 0)
            throw new Exception("lbIdIsntZero");

        if (!entity.Validate())
        {
            throw new Exception("lbWrongData");
        }
        return this.iRespository!.Modify(entity);
    }

    public Users Delete(Users entity)
    {
        if (entity == null)
            throw new Exception("lbNullEntity");
        if (entity.Id != 0)
            throw new Exception("lbIdIsntZero");

        if (!entity.Validate())
        {
            throw new Exception("lbWrongData");
        }
        return this.iRespository!.Delete(entity);
    }
}