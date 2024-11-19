using lib_entities;
using lib_applications.Interfaces;
using lib_repositories.Interfaces;
using lib_repositories;
using System.Linq.Expressions;

namespace lib_applications.Implementations;
public class ImagesApp : IImagesApp
{
    private IImagesRepository iRespository;

    public ImagesApp(IImagesRepository iRespository)
    {
        this.iRespository = iRespository;
    }

    public void Configure(string stringConnection)
    {
        this.iRespository!.Configure(stringConnection);
    }

    public List<Images> GetList()
    {
        return this.iRespository!.GetList();
    }

    public Images Save(Images entity)
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

    public List<Images> Search(Images entity, string type)
    {
        Expression<Func<Images, bool>>? conditions = null;
        switch (type.ToUpper())
        {
            
            case "IDSMOKERS": conditions = x => x.Id_Smoker!.Equals(entity.Id_Smoker); break;
            case "URL": conditions = x => x.Url!.Equals(entity.Url); break;

        }

        return this.iRespository!.Search(conditions);
    }

    public Images Modify(Images entity)
    {
        if (entity == null)
            throw new Exception("lbNullEntity");
        if (entity.Id == 0)
            throw new Exception("lbIdIsntZero");

        if (!entity.Validate())
        {
            throw new Exception("lbWrongData");
        }
        return this.iRespository!.Modify(entity);
    }

    public Images Delete(Images entity)
    {
        if (entity == null)
            throw new Exception("lbNullEntity");
        if (entity.Id == 0)
            throw new Exception("lbIdIsntZero");

        if (!entity.Validate())
        {
            throw new Exception("lbWrongData");
        }
        return this.iRespository!.Delete(entity);
    }
}