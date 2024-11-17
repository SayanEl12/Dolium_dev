using lib_entities;
using lib_repositories.Interfaces;

namespace lib_repositories.Implementations;
public class Sale_ProductsRepository : ISale_ProductsRepository
{
    private Connection? _connection;

    public Sale_ProductsRepository(Connection connection)
    {
        this._connection = connection;
    }

    public void Configure(string stringConnection)
    {
        this._connection!.StringConnection = stringConnection;
    }

    public List<Sale_Productcs> GetList()
    {
        return this._connection!.GetList<Sale_Productcs>();
    }

    public Sale_Productcs Save(Sale_Productcs entity)
    {
        _connection!.Save(entity);
        _connection!.Commit();
        return entity;
    }

    public Sale_Productcs Modify(Sale_Productcs entity)
    {
        _connection!.Modify(entity);
        _connection!.Commit();
        return entity;
    }

    public Sale_Productcs Delete(Sale_Productcs entity)
    {
        _connection!.Delete(entity);
        _connection!.Commit();
        return entity;
    }
}