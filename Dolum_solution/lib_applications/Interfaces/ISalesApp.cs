using lib_entities;

namespace lib_applications.Interfaces;
public interface ISalesApp
{
    void Configure(string stringConnection);
    List<Sales> GetList();
    Sales Save(Sales entity);
    List<Sales> Search(Sales entity,string type);
    Sales Modify(Sales entity);
    Sales Delete(Sales entity);
}