using lib_entities;
using System.Linq.Expressions;
namespace lib_repositories.Interfaces;

public interface ISale_ProductRepository
{
    void Configure(string stringConnection);
    List<Sale_Product> GetList();
    Sale_Product Save(Sale_Product entity);
    List<Sale_Product> Search(Expression<Func<Sale_Product, bool>> conditions);

    Sale_Product Modify(Sale_Product entity);
    Sale_Product Delete(Sale_Product entity);
}