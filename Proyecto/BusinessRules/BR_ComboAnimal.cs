using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccess;
namespace BusinessRules
{
    public class BR_ComboAnimal
    {
        bool rta;
        DA_ComboAnimal comboA = new DA_ComboAnimal();

        public bool RellenarCombo(cmbEspecie combo, string campo1, string campo2, string tabla)
        {
            comboA.RellenarCombo(combo, campo1, campo2, tabla);
            return rta;
        }
    }
}
