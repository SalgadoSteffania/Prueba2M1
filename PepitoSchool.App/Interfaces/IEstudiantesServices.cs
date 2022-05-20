using PepitoSchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepitoSchool.App.Interfaces
{
    public interface IEstudiantesServices: IService<Estudiante>
    {
        Estudiante FindByCarnet(string carnet);
        List<Estudiante> FindByNames(string names);
        List<Estudiante> FindByLastnames(string lastnames);
    }
}
