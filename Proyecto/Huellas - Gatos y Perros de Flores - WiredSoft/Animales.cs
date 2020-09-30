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
        public bool Editar = false;
        public Animales()
        {
            InitializeComponent();
        }

        private void Mascota_Load(object sender, EventArgs e)
        {
            MostrarRegistroAnimal();
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
        public void MostrarRegistroAnimal()
        {
            dataMascotas.DataSource = BR_Animal.ListarAnimal();
        }
        public void MensajeConfirmacion(string Mensaje)
        {
            MessageBox.Show(Mensaje, "WiredSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "WiredSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void limpiarForm()
        {
            txtBuscar.Clear();
            txtColor.Text = "";
            txtUbicacion.Text = "";
            txtPeso.Clear();
            txtEdad.Clear();
            txtNombre.Clear();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            
            //if todos nulls tire alertas para que complete los campos
            //Else  ejecute el A_Animal blucle de busqueda para ver si existe dentro de la lista de programacion del datagrid, y si encuentra uno que coincida que ejecute el M_Animal
            //INSERTAR
            if (Editar == false)
            {
                try
                {
                    ObjBusinessRules.AltaAnimal(cmbEspecie.SelectedValue, txtUbicacion.Text,picB1.ImageLocation,picB2.ImageLocation,txtNombre.Text, txtEdad.Text, cmbSexo.SelectedValue,chkSi.C, txtPeso.Text, txtColor.Text, cbxEstado.Text, dtpIngreso.Text);
                    //ObjEntities.FotoIngreso = picB1.GetBuffer()
                    //ObjEntities.FotoIngreso = byte.Parse(picB1.ImageLocation) revisar de que otra forma puede realizarse                                                                                                                                                                                                   ver problema               que onda esto?                                                                            
                    //ObjBusinessRules.AltaAnimal(ObjEntities.IdEspecie= int.Parse(cmbEspecie.Value),ObjEntities.FotoIngreso=byte.Parse(picB1.ImageLocation), ObjEntities.FotoAdopcion = byte.Parse(picB2.ImageLocation),ObjEntities.NombreAnimal=txtNombre.Text,ObjEntities.Edad=Convert.ToInt32(txtEdad.Text),ObjEntities.Sexo= int.Parse(cmbSexo.string),ObjEntities.Castracion=chkCasSi.Checked,ObjEntities.ColorPelo = txtColor.Text,);
                    MessageBox.Show("se inserto correctamente");
                    MostrarRegistroAnimal();
                    limpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se pudo insertar los datos por: " + ex);
                }
            }
            //EDITAR
            if (Editar == true)
            {

                try
                {
                    ObjBusinessRules.ModificarAnimal(txtNombre.Text.Trim() != "" && cmbEspecie.Text.Trim() != "" && txtUbicacion.Text.Trim() != "" && txtEdad.Text.Trim() != "" && txtPeso.Text.Trim() != "" && txtColor.Text.Trim() != "" && cmbSexo.Text.Trim() != "" && cbxEstado.Text.Trim() != "" && dtpFechaF.Text.Trim() != "");
                    MessageBox.Show("se edito correctamente");
                    MostrarRegistroAnimal();
                    limpiarForm();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar los datos por el siguiente motivo: " + ex);
                }
            }//Errores que tuve por el momento: AM y M animal, no me toma los parametros

            //    {
            //        {
            //            if (txtNombre.Text.Trim() != "" && cbxEspecie.Text.Trim() != "" && txtUbicacion.Text.Trim() != "" && txtEdad.Text.Trim() != ""  && txtPeso.Text.Trim() != "" && txtColor.Text.Trim() != "" && cbxSexo.Text.Trim() != "" && cbxEstado.Text.Trim() != "" && dtpFechaF.Text.Trim() != "")
            //            {
            //                if (Program.Evento == 0)//Preguntar tema fecha de nacimiento, los datatime
            //                {
            //                    try
            //                    {
            //                        ObjEntities.NombreAnimal = txtNombre.Text.ToUpper();
            //                        ObjEntities.IdEspecie = Convert.ToInt32(cbxEspecie.SelectedValue);
            //                        ObjEntities.FechaIngreso = dtpIngreso.Value.Date; //string.Format("{0:d})", dtpIngreso.Value);
            //                        ObjEntities.FechaNac = dtpFechaNac.Value.Date;
            //                        ObjEntities.LugarRescate = txtUbicacion.Text.ToUpper();
            //                        //hace falta ingresar las imagenes aca? son opcionales a su vez en la BD, aunque igualmente falta resolver como vamos a mostrar las img
            //                        ObjEntities.Sexo = Convert.ToString(cbxSexo.SelectedValue);
            //                        ObjEntities.Edad = Convert.ToInt32(txtEdad.SelectedText);
            //                        ObjEntities.Peso = Convert.ToInt32(txtPeso.SelectedText);
            //                        ObjEntities.ColorPelo = txtColor.Text.ToUpper();
            //                        ObjEntities.Estado = Convert.ToString(cbxEstado.SelectedValue);

            //                        ObjBusinessRules.AM_Animal(ObjEntities);
            //                        MensajeConfirmacion("Se Guardo correctamente al animal");
            //                        Program.Evento = 0;
            //                        Close();
            //                    }
            //                    catch (Exception)
            //                    {
            //                        MensajeError("No se guardo el animal");
            //                    }
            //                }
            //            }
            //        }
            //    }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog faI = new OpenFileDialog();
            OpenFileDialog faA = new OpenFileDialog();
            DialogResult rsI = faI.ShowDialog();
            DialogResult rsA = faA.ShowDialog();
            if (rsA == DialogResult.OK && rsI == DialogResult.OK)
            {
                picB1.Image = Image.FromFile(faI.FileName);
                picB1.Image = Image.FromFile(faA.FileName);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
            


