using lib_entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IImagesApp
{
    void Configure(string stringConnection);
    List<Images> GetList();
    Images Save(Images entity);
    List<Images> Search(Images entity, string type);
    Images Modify(Images entity);
    Images Delete(Images entity);
}