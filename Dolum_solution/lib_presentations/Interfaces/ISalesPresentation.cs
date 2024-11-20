using lib_entities;

namespace lib_presentations.Interfaces;
public interface ISalesPresentation
{
    Task<List<Sales>> GetList();
    Task<List<Sales>> Search(Sales entity, string type);
    Task<Sales> Save(Sales entity);
    Task<Sales> Modify(Sales entity);
    Task<Sales> Delete(Sales entity);
}