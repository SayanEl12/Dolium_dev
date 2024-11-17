using lib_entities;
namespace lib_repositories.Interfaces;

public interface ISalesRepository
{
    void Configure(string stringConnection);
    List<Sales> GetList();
    Sales Save(Sales entity);
    Sales Modify(Sales  entity);
    Sales Delete(Sales  entity);
}