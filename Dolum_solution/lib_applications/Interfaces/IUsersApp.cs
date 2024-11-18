using lib_entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IUsersApp
{
    void Configure(string stringConnection);
    List<Users> GetList();
    Users Save(Users entity);
    List<Users> Search(Users entity, string type);
    Users Modify(Users entity);
    Users Delete(Users entity);
}