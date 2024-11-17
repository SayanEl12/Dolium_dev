using lib_entities;
using lib_repositories.Interfaces;
using System.Linq.Expressions;

namespace lib_repositories.Implementations
{
    public class Sale_ProductRepository : ISale_ProductRepository
    {
        private readonly Connection _connection;

        public Sale_ProductRepository(Connection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public void Configure(string stringConnection)
        {
            if (string.IsNullOrWhiteSpace(stringConnection))
                throw new ArgumentException("La cadena de conexión no puede ser nula o vacía.", nameof(stringConnection));

            _connection.StringConnection = stringConnection;
        }

        public List<Sale_Product> GetList()
        {
            return _connection.GetList<Sale_Product>();
        }

        public Sale_Product Save(Sale_Product entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _connection.Save(entity);
            _connection.Commit();
            return entity;
        }


        public Sale_Product Modify(Sale_Product entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _connection.Modify(entity);
            _connection.Commit();
            return entity;
        }

        public List<Sale_Product> Search(Expression<Func<Sale_Product, bool>> conditions)
        {
            return _connection!.Search(conditions);
        }
        public Sale_Product Delete(Sale_Product entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _connection.Delete(entity);
            _connection.Commit();
            return entity;
        }
    }
}
