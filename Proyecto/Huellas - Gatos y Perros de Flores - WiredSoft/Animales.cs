using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BusinessRules;
using DataAccess;
using Entities;

namespace Huellas___Gatos_y_Perros_de_Flores___WiredSoft
{
    public partial class Animales : Form
    {
        readonly BR_Animal ObjBusinessRules = new BR_Animal();
        readonly E_Animal ObjEntities = new E_Animal();
        public Animales()
        {
            InitializeComponent();
        }

        private void Mascota_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnVerMas_Click(object sender, EventArgs e)
        {

        }

        private void tabDatosAnimal_Click(object sender, EventArgs e)
        {

        }

        private void llblPersona_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form VerMas = new VerMasAnimal();
            VerMas.Show();
        }
        public void MensajeConfirmacion(string Mensaje)
        {
            MessageBox.Show(Mensaje, "WiredSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "WiredSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            {
                {
                    if (txtNombre.Text.Trim() != "" && cbxEspecie.Text.Trim() != "" && dtpIngreso.Text.Trim() != "" && txtUbicacion.Text.Trim() != "" && txtEdad.Text.Trim() != "" && dtpFechaNac.Text.Trim() != "" && txtPeso.Text.Trim() != "" && txtColor.Text.Trim() != "" && cbxSexo.Text.Trim() != "" && cbxEstado.Text.Trim() != "" && dtpFechaF.Text.Trim() != "")
                    {
                        if (Program.Evento == 0)//Preguntar tema fecha de nacimiento, los datatime
                        {
                            try
                            {
                                ObjEntities.NombreAnimal = txtNombre.Text.ToUpper();
                                ObjEntities.IdEspecie = Convert.ToInt32(cbxEspecie.SelectedValue);
                                ObjEntities.FechaIngreso = dtpIngreso.Text.ToUpper();
                                ObjEntities.LugarRescate = txtUbicacion.Text.ToUpper();
                                ObjEntities.Edad = Convert.ToInt32(txtEdad.SelectedText);
                                ObjEntities.Peso = Convert.ToInt32(txtPeso.SelectedText);
                                ObjEntities.ColorPelo = txtColor.Text.ToUpper();
                                ObjEntities.Sexo = Convert.ToString(cbxSexo.SelectedValue);
                                ObjEntities.Estado = Convert.ToString(cbxEstado.SelectedValue);

                                ObjBusinessRules.AM_Animal(ObjEntities);
                                MensajeConfirmacion("Se Guardo correctamente al animal");
                                Program.Evento = 0;
                                Close();
                            }
                            catch (Exception)
                            {
                                MensajeError("No se guardo el animal");
                            }
                        }
                    }
                }
            }
        }
    }
}

            


