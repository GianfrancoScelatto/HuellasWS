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
using Entities;


namespace Huellas___Gatos_y_Perros_de_Flores___WiredSoft
{
    public partial class Establecimiento : Form

    {
        BR_Establecimiento brE = new BR_Establecimiento();
        E_Mensaje msj = new E_Mensaje();
        public bool Editar = false; 

        public Establecimiento()
        {
            InitializeComponent();
        }

        private void ListarCombos()
        {
            cmbEstablecimiento.DataSource = brE.ComboEstablecimiento();
            cmbEstablecimiento.DisplayMember = "TipoEstablecimiento";
            cmbEstablecimiento.ValueMember = "IdTipoEstablecimiento";
        }

        private void Establecimiento_Load(object sender, EventArgs e)
        {
            ListarCombos();


            if (E_Establecimiento.Editar == true)
            {
                
                Editar = true;
                lblD.Text = E_Establecimiento.IdEstablecimiento.ToString();
                txtNombre.Text = E_Establecimiento.Nombre;
                txtHoraAtencion.Text = E_Establecimiento.HorarioAtencion;
                txtLocalidad.Text = E_Establecimiento.Localidad;
                txtCP.Text = E_Establecimiento.CodigoPostal;
                txtCalle.Text = E_Establecimiento.Calle;
                txtAltura.Text = E_Establecimiento.Altura.ToString();
                chkInternacion.Checked = E_Establecimiento.Internacion;
                
            }

            cmbEstablecimiento.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           
            
            if (String.IsNullOrWhiteSpace(txtNombre.Text))
            {
                msj.MensajeAlerta("Hay campos vacios");
            }

            if (Editar == true)
            {
                try
                {
                    
                    brE.ModifcarEstablecimiento(E_Establecimiento.IdEstablecimiento, Convert.ToInt32(cmbEstablecimiento.SelectedValue), txtNombre.Text, txtHoraAtencion.Text, txtLocalidad.Text, txtCP.Text, txtCalle.Text , Convert.ToInt32(txtAltura.Text), chkInternacion.Checked, E_UsuarioAcceso.IdUsuario);
                }

                catch (Exception ex)
                {
                    msj.MensajeError("Ha ocurrido un error." + ex);
                }

            }

            else
            {
                try
                {
                    brE.AltaEstablecimiento(Convert.ToInt32(cmbEstablecimiento.SelectedValue), txtNombre.Text, txtHoraAtencion.Text, txtLocalidad.Text, txtCP.Text, txtCalle.Text, Convert.ToInt32(txtAltura.Text), chkInternacion.Checked, E_UsuarioAcceso.IdUsuario);
                }


                catch (Exception ex)
                {
                    msj.MensajeError("Ha ocurrido un error" + ex);
                }
            }


            Close();
         
            

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
           
            
              DialogResult preg = MessageBox.Show("¿Desea cerrar este formulario?", "WiredSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
              if (preg == DialogResult.Yes)
              {
                 Close();
              }

             
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            E_Validaciones.SoloLetras(e);
        }
        private void txtAltura_KeyPress(object sender, KeyPressEventArgs e)
        {
            E_Validaciones.SoloNumeros(e);
        }

        private void txtHoraAtencion_KeyPress(object sender, KeyPressEventArgs e)
        {
            E_Validaciones.LetrasNumeros(e);
        }

        private void txtLocalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            E_Validaciones.LetrasNumeros(e);
        }

        private void txtCP_KeyPress(object sender, KeyPressEventArgs e)
        {
            E_Validaciones.LetrasNumeros(e);
        }

        private void txtCalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            E_Validaciones.LetrasNumeros(e);
        }
    }
}
