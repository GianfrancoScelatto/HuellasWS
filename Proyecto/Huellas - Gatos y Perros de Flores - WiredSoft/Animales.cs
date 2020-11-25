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
        BR_Vacunas brV = new BR_Vacunas();
        BR_Animal brA = new BR_Animal();
        BR_Seguimiento brS = new BR_Seguimiento();
        BR_FichaMedica brFM = new BR_FichaMedica();
        BR_Persona brP = new BR_Persona();
        E_Mensaje eM = new E_Mensaje();
        public bool Editar = false;
        string comment, detalle;

        public Animales()
        {
            InitializeComponent();
        }

        private void CargarCombos()
        {
            cmbEspecie.DataSource = brV.ListarEspecie();
            cmbEspecie.DisplayMember = "Especie";
            cmbEspecie.ValueMember = "IdEspecie";

            cmbEstado.DataSource = brA.ListarEstado();
            cmbEstado.DisplayMember = "Estado";
            cmbEstado.ValueMember = "IdEstado";

            cmbPersona.DataSource = brP.ComboPersona();
            cmbPersona.DisplayMember = "Nombre";
            cmbPersona.ValueMember = "IdPersona";
        }

        private void CargarGrillas()
        {
            dgvFichaMedica.DataSource = brFM.ListarFichaMedica(E_Animal.IdAnimal);
            dgvSeguimiento.DataSource = brS.ListarSeguimiento();
        }

        private void Mascota_Load(object sender, EventArgs e)
        {
            CargarCombos();

            if (E_Animal.Editar == true)
            {
                Editar = true;
                groupBox1.Enabled = false;
                CargarGrillas();
                dgvFichaMedica.Columns["IdFichaMedica"].Visible = false;
                lblIdAnimal.Text = E_Animal.IdAnimal.ToString();
                txtNombre.Text = E_Animal.NombreAnimal;
                cmbEspecie.SelectedValue = E_Animal.IdEspecie;
                dtpIngreso.Value = E_Animal.FechaIngreso.Date;
                txtUbicacion.Text = E_Animal.LugarRescate;
                txtEdad.Text = E_Animal.Edad.ToString();
                dtpFechaNac.Value = E_Animal.FechaNac.Date;
                txtPeso.Text = E_Animal.Peso.ToString();
                txtColor.Text = E_Animal.ColorPelo;
                cmbSexo.SelectedValue = E_Animal.Sexo;
                cmbEstado.SelectedValue = E_Animal.Estado;
                txtComentario.Text = E_Animal.Comentario;
                dtpCastracion.Value = Convert.ToDateTime(E_Animal.FechaCastracion).Date;

                if (E_Animal.Castracion == true)
                {
                    chkCasSi.Checked = true;
                }
                else
                    chkCasNo.Checked = true;

                if (cmbEstado.SelectedIndex == 2)
                {
                    dtpFechaF.Enabled = true;
                    dtpFechaF.Value = E_Animal.FechaDefuncion.Date;
                }
            }
            else
            {
                cmbEspecie.SelectedIndex = 0;
                cmbSexo.SelectedIndex = 0;
                cmbEstado.SelectedIndex = 0;

                txtBuscar.Enabled = false;
                dgvFichaMedica.Enabled = false;
                dtpFichaMedica.Enabled = false;
                btnEliminar.Enabled = false;
                btnExportar.Enabled = false;
                btnNuevo1.Enabled = false;
                btnModificar.Enabled = false;
                lklblVacunas.Enabled = false;
                dgvSeguimiento.Enabled = false;
                dtpFiltro.Enabled = false;
            }

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtNombre.Text) || String.IsNullOrWhiteSpace(txtUbicacion.Text) || 
                String.IsNullOrWhiteSpace(txtEdad.Text) || String.IsNullOrWhiteSpace(txtPeso.Text) || 
                String.IsNullOrWhiteSpace(txtColor.Text))
            {
                eM.MensajeAlerta("Hay espacios vacíos.");
            }
            else if (Editar == true)
            {
                try
                {
                    comment += txtComentario.Text + Environment.NewLine;

                    if (chkCasSi.Checked == true)
                    {
                        brA.ModificarAnimal(Convert.ToInt32(lblIdAnimal.Text), Convert.ToInt32(cmbEspecie.SelectedValue), Convert.ToInt32(cmbEspecie.SelectedValue), txtUbicacion.Text, String.Empty,
                                                        String.Empty, txtNombre.Text, Convert.ToInt32(txtEdad.Text), cmbSexo.SelectedText, chkCasSi.Checked, txtColor.Text, Convert.ToDecimal(txtPeso.Text),
                                                        comment, Convert.ToInt32(cmbEstado.SelectedValue), dtpIngreso.Value.Date);
                    }
                    else
                        brA.ModificarAnimal(Convert.ToInt32(lblIdAnimal.Text), Convert.ToInt32(cmbEspecie.SelectedValue), Convert.ToInt32(cmbEspecie.SelectedValue), txtUbicacion.Text, String.Empty,
                                                        String.Empty, txtNombre.Text, Convert.ToInt32(txtEdad.Text), cmbSexo.SelectedText, chkCasNo.Checked, txtColor.Text, Convert.ToDecimal(txtPeso.Text), comment,
                                                        Convert.ToInt32(cmbEstado.SelectedValue), dtpIngreso.Value.Date);

                    LimpiarForm();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    eM.MensajeError("Ha ocurrido un error: " + ex);
                }
            }
            else
            {
                try
                {
                    comment += txtComentario.Text + Environment.NewLine;

                    if (chkCasSi.Checked == true)
                    {
                        brA.AltaAnimal(E_Usuario.IdUsuario, Convert.ToInt32(cmbEspecie.SelectedValue), Convert.ToInt32(cmbPersona.SelectedValue), txtUbicacion.Text, String.Empty,
                                                        String.Empty, txtNombre.Text, Convert.ToInt32(txtEdad.Text), cmbSexo.SelectedText, chkCasSi.Checked, txtColor.Text, Convert.ToDecimal(txtPeso.Text),
                                                        comment, Convert.ToInt32(cmbEstado.SelectedValue), dtpCastracion.Value.Date, dtpIngreso.Value.Date, dtpFechaNac.Value.Date);
                    }
                    else
                        brA.AltaAnimal(E_Usuario.IdUsuario, Convert.ToInt32(cmbEspecie.SelectedValue), Convert.ToInt32(cmbPersona.SelectedValue), txtUbicacion.Text, String.Empty,
                                                        String.Empty, txtNombre.Text, Convert.ToInt32(txtEdad.Text), cmbSexo.SelectedText, chkCasNo.Checked, txtColor.Text, Convert.ToDecimal(txtPeso.Text), comment,
                                                        Convert.ToInt32(cmbEstado.SelectedValue), dtpCastracion.Value.Date, dtpIngreso.Value.Date, dtpFechaNac.Value.Date);
                    LimpiarForm();
                }
                catch(Exception ex)
                {
                    eM.MensajeError("Ha ocurrido un error: " + ex);
                }
            }
        }

        private void btnGuardarSeg_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtDetalle.Text))
            {
                eM.MensajeError("El campo de detalle se encuentra vacío.");
            }
            else
            {
                detalle += txtDetalle.Text + Environment.NewLine;
                brS.GuardarSeguimiento(detalle, dtpAcontecimiento.Value.Date);
                LimpiarForm();
            }
                
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FichaMedica fm = new FichaMedica();
            fm.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            E_FichaMedica.Editar = true;
            FichaMedica fm = new FichaMedica();
            fm.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult preg = MessageBox.Show("¿Desea eliminar esta ficha médica?", "WiredSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (preg == DialogResult.OK)
            {
                brFM.BajaFichaMedica(E_FichaMedica.IdFichaMedica, E_Usuario.IdRol);
            }
        }

        private void lklblPersona_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form VerMas = new DetalleTrAd();
            VerMas.Show();
        }

        private void LimpiarForm()
        {
            lblIdAnimal.Text = "-";
            txtNombre.Clear();
            txtUbicacion.Clear();
            txtEdad.Clear();
            txtPeso.Clear();
            txtColor.Clear();
            txtComentario.Clear();
            txtBuscar.Clear();
            txtDetalle.Clear();

            cmbEspecie.SelectedIndex = 0;
            cmbEstado.SelectedIndex = 0;
            cmbSexo.SelectedIndex = 0;
            cmbPersona.SelectedIndex = 0;

            chkCasSi.Checked = false;
            chkCasNo.Checked = false;

            dtpFechaNac.Value = DateTime.Now;
            dtpFechaF.Value = DateTime.Now;
            dtpFichaMedica.Value = DateTime.Now;
            dtpCastracion.Value = DateTime.Now;
            dtpAcontecimiento.Value = DateTime.Now;
            dtpFiltro.Value = DateTime.Now;
        }

        private void tbcDatosMasc_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tbcDatosMasc.SelectedIndex)
            {
                case 0:
                    btnGuardarDatos.Visible = true;
                    btnCancelarDatos.Visible = true;
                    break;
                case 1:
                    btnGuardarDatos.Visible = true;
                    btnCancelarDatos.Visible = true;
                    break;
                case 2:
                    btnGuardarDatos.Visible = false;
                    btnCancelarDatos.Visible = false;
                    break;
            }
        }

        private void DgvFichaMedica_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            E_FichaMedica.IdFichaMedica = Convert.ToInt32(dgvFichaMedica.CurrentRow.Cells["IdFichaMedica"].Value);
            E_FichaMedica.Fecha = Convert.ToDateTime(dgvFichaMedica.CurrentRow.Cells["Fecha"].Value).Date;
            E_FichaMedica.Tratamiento = dgvFichaMedica.CurrentRow.Cells["Tratamiento"].Value.ToString();
            E_FichaMedica.Informe = dgvFichaMedica.CurrentRow.Cells["Informe"].Value.ToString();
            E_FichaMedica.IdVeterinaria = Convert.ToInt32(dgvFichaMedica.CurrentRow.Cells["IdVeterinaria"].Value);
            E_FichaMedica.IdMascota = Convert.ToInt32(dgvFichaMedica.CurrentRow.Cells["IdMascota"].Value);
            E_FichaMedica.Costo = Convert.ToDecimal(dgvFichaMedica.CurrentRow.Cells["Costo"].Value);
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEstado.SelectedIndex == 3)
            {
                dtpFechaF.Enabled = true;
            }
            else
                dtpFechaF.Enabled = false;
        }

        private void btnImagen_Click(object sender, EventArgs e)
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

        private void btnImagen2_Click(object sender, EventArgs e)
        {
            OpenFileDialog faI = new OpenFileDialog();
            OpenFileDialog faA = new OpenFileDialog();
            DialogResult rsI = faI.ShowDialog();
            DialogResult rsA = faA.ShowDialog();
            if (rsA == DialogResult.OK && rsI == DialogResult.OK)
            {
                picB2.Image = Image.FromFile(faI.FileName);
                picB2.Image = Image.FromFile(faA.FileName);
            }
        }

        private void dtpFiltro_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFiltro.Enabled == true)
            {
                brS.FiltrarSeguimiento(dtpFiltro.Value.Date);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Enabled == true && dtpFichaMedica.Enabled == true)
            {
                brFM.FiltrarFichaMedica(txtBuscar.Text, dtpFichaMedica.Value.Date);
            }
        }

        private void lklblVacunas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form VacunasDespa = new DesparasitacionVacuna();
            VacunasDespa.Show();
        }

        private void dtpFichaMedica_ValueChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Enabled == true && dtpFichaMedica.Enabled == true)
            {
                brFM.FiltrarFichaMedica(txtBuscar.Text, dtpFichaMedica.Value.Date);
            }
        }
    }
}
            


