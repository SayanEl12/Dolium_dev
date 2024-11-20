using lib_entities;

namespace lib_presentations.Interfaces;
public interface IImagesPresentation
{
    Task<List<Smokers>> GetList();
    Task<List<Smokers>> Search(Smokers entity, string type);
    Task<Smokers> Save(Smokers entity);
    Task<Smokers> Modify(Smokers entity);
    Task<Smokers> Delete(Smokers entity);
}