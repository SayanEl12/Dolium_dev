using lib_entities;

namespace lib_applications.Interfaces;
public interface ISale_ProductApp
{
    void Configure(string stringConnection);
    List<Sale_Product> GetList();
    Sale_Product Save(Sale_Product entity);
    List<Sale_Product> Search(Sale_Product entity,string type);
    Sale_Product Modify(Sale_Product entity);
    Sale_Product Delete(Sale_Product entity);
    List<Sale_Product> DeleteProduct(int Id);
}