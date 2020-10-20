using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entities
{
    public class E_Mensaje
    {
        public void MensajeAlerta(string Mensaje)
        {
            MessageBox.Show(Mensaje, "WiredSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "WiredSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool MensajeAcceso(string Rol)
        {
            if (Rol != "Administrador")
            {
                MessageBox.Show("No tiene acceso para realizar esta acción.", "WiredSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
                return true;
        }
    }
}
