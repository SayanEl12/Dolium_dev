using lib_entities;
namespace lib_repositories.Interfaces;

public interface ISale_ProductsRepository
{
    void Configure(string stringConnection);
    List<Sale_Productcs> GetList();
    Sale_Productcs Save(Sale_Productcs entity);
    Sale_Productcs Modify(Sale_Productcs entity);
    Sale_Productcs Delete(Sale_Productcs entity);
}