using lib_entities;
namespace lib_repositories.Interfaces;

public interface IImagesRepository
{
    void Configure(string stringConnection);
    List<Images> GetList();
    Images Save(Images entity);
    Images Modify(Images entity);
    Images Delete(Images entity);
}