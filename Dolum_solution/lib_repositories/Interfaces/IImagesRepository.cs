using lib_entities;
using System.Linq.Expressions;
namespace lib_repositories.Interfaces;

public interface IImagesRepository
{
    void Configure(string stringConnection);
    List<Images> GetList();
    Images Save(Images entity);
    List<Images> Search(Expression<Func<Images, bool>> conditions);
    Images Modify(Images entity);
    Images Delete(Images entity);
}