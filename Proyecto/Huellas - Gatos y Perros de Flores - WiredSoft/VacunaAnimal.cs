using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using BusinessRules;

namespace Huellas___Gatos_y_Perros_de_Flores___WiredSoft
{
    public partial class VacunaAnimal : Form
    {
        BR_Vacunas brV = new BR_Vacunas();
        public VacunaAnimal()
        {
            InitializeComponent();
        }

        private void ListarVacunas()
        {
            cmbVacunas.DataSource = brV.ListarComboVacunas(E_Animal.IdEspecie);
            cmbVacunas.DisplayMember = "Vacuna";
            cmbVacunas.ValueMember = "IdVacuna";
        }

        private void VacunaAnimal_Load(object sender, EventArgs e)
        {
            cmbVacunas.SelectedValueChanged -= cmbVacunas_SelectedValueChanged;
            ListarVacunas();
            cmbVacunas.SelectedValueChanged += cmbVacunas_SelectedValueChanged;

            if (E_Vacuna.Editar == true)
            {
                cmbVacunas.SelectedValue = E_Vacuna.IdVacuna;
                dtpAplicacion.Value = E_Vacuna.FechaVacunacion;
            }
            else
            {
                cmbVacunas.SelectedIndex = 0;
                dtpAplicacion.Value = DateTime.Now;
            }    
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            brV.AltaVacunaAnimal(Convert.ToInt32(cmbVacunas.SelectedValue), E_Animal.IdAnimal, dtpAplicacion.Value.Date, dtpAplicacion.Value.AddDays(E_Vacuna.FrecuenciaRevacunacion), E_UsuarioAcceso.IdUsuario);
        }

        private void cmbVacunas_SelectedValueChanged(object sender, EventArgs e)
        {
            
            brV.TraerRevacunacion(Convert.ToInt32(cmbVacunas.SelectedValue));
        }
    }
}
