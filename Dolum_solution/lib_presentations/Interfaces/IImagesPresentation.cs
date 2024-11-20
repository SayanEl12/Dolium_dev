using lib_entities;

namespace lib_presentations.Interfaces;
public interface IImagesPresentation
{
    Task<List<Images>> GetList();
    Task<List<Images>> Search(Images entity, string type);
    Task<Images> Save(Images entity);
    Task<Images> Modify(Images entity);
    Task<Images> Delete(Images entity);
}