using lib_entities;
using System.Linq.Expressions;

namespace lib_applications.Interfaces;

public interface ISmokersApp
{
    void Configure(string stringConnection);
    List<Smokers> GetList();
    Smokers Save(Smokers entity);
    List<Smokers> Search(Smokers entity,string type);
    Smokers Modify(Smokers entity);
    Smokers Delete(Smokers entity);
}