using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using DataAccess;
using Entities;
namespace BusinessRules
{
    public class BR_Animal
    {
        readonly DA_Animal ObjAnimal = new DA_Animal();

        public List<E_Animal> ListarAnimal()
        {
            return ObjAnimal.ListarAnimal();
            //preguntar a gianfranco
        }
    }
}
