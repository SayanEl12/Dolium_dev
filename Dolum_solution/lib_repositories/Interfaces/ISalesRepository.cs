using lib_entities;
using System.Linq.Expressions;
namespace lib_repositories.Interfaces;

public interface ISalesRepository
{
    void Configure(string stringConnection);
    List<Sales> GetList();
    Sales Save(Sales entity);
    List<Sales> Search(Expression<Func<Sales, bool>> conditions);
    Sales Modify(Sales  entity);
    Sales Delete(Sales  entity);
}