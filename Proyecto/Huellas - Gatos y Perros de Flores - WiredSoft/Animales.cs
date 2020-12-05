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
        E_Mensaje msj = new E_Mensaje();
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

            cmbPersona.SelectedValueChanged -= cmbPersona_SelectedValueChanged;
            cmbPersona.DataSource = brP.ComboPersona();
            cmbPersona.DisplayMember = "Nombre";
            cmbPersona.ValueMember = "IdPersona";
            cmbPersona.SelectedValueChanged += cmbPersona_SelectedValueChanged;

            cmbSexo.DataSource = brA.ListarSexo();
            cmbSexo.DisplayMember = "Sexo";
            cmbSexo.ValueMember = "IdSexo";
        }

        private void CargarGrillas()
        {
            dgvFichaMedica.DataSource = brFM.ListarFichaMedica(E_Animal.IdAnimal);
            dgvFichaMedica.Columns["IdFichaMedica"].Visible = false;
            dgvSeguimiento.DataSource = brS.ListarSeguimiento(E_Animal.IdAnimal);
            dgvSeguimiento.Columns["IdSeguimiento"].Visible = false;
        }

        private void Animales_Load(object sender, EventArgs e)
        {
            CargarCombos();

            if (E_Animal.Editar == true)
            {
                Editar = true;
                CargarGrillas();
                lblIdAnimal.Text = E_Animal.IdAnimal.ToString();
                txtNombre.Text = E_Animal.NombreAnimal;
                cmbEspecie.SelectedValue = E_Animal.IdEspecie;
                dtpIngreso.Value = E_Animal.FechaIngreso.Date;
                txtUbicacion.Text = E_Animal.LugarRescate;
                txtEdad.Text = E_Animal.Edad.ToString();
                dtpFechaNac.Value = E_Animal.FechaNac.Date;
                txtPeso.Text = Math.Round(E_Animal.Peso, 2, MidpointRounding.ToEven).ToString();
                txtColor.Text = E_Animal.ColorPelo;
                cmbSexo.SelectedValue = E_Animal.Sexo;
                cmbEstado.SelectedValue = E_Animal.Estado;
                txtComentario.Text = E_Animal.Comentario;
                dtpCastracion.Value = E_Animal.FechaCastracion ?? DateTime.MinValue;
                picB1.ImageLocation = E_Animal.FotoIngreso;
                picB2.ImageLocation = E_Animal.FotoAdopcion;

                if (E_Animal.Castracion == true)
                {
                    chkCasSi.Checked = true;
                }

                if (cmbEstado.SelectedIndex == 2)
                {
                    dtpFechaF.Enabled = true;
                    dtpFechaF.Value = E_Animal.FechaDefuncion ?? DateTime.MinValue;
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
                btnNuevo.Enabled = false;
                btnModificar.Enabled = false;
                lklblVacunas.Enabled = false;
                dgvSeguimiento.Enabled = false;
                dtpFiltro.Enabled = false;
                txtDetalle.Enabled = false;
                dtpAcontecimiento.Enabled = false;
                btnGuardarSeg.Enabled = false;
            }

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtNombre.Text) || String.IsNullOrWhiteSpace(txtUbicacion.Text) || 
                String.IsNullOrWhiteSpace(txtEdad.Text) || String.IsNullOrWhiteSpace(txtPeso.Text) || 
                String.IsNullOrWhiteSpace(txtColor.Text))
            {
                msj.MensajeAlerta("Hay espacios vacíos.");
            }
            else if (Editar == true)
            {
                try
                {
                    comment += txtComentario.Text + Environment.NewLine;

                    brA.ModificarAnimal(E_UsuarioAcceso.IdUsuario, Convert.ToInt32(lblIdAnimal.Text), Convert.ToInt32(cmbPersona.SelectedValue), Convert.ToInt32(cmbEspecie.SelectedValue), txtUbicacion.Text, picB1.ImageLocation,
                                        E_Animal.FotoAdopcion, txtNombre.Text, Convert.ToInt32(txtEdad.Text), Convert.ToInt32(cmbSexo.SelectedValue), chkCasSi.Checked, txtColor.Text, Convert.ToDecimal(txtPeso.Text),
                                        comment, Convert.ToInt32(cmbEstado.SelectedValue), dtpCastracion.Value.Date, dtpIngreso.Value.Date, dtpFechaNac.Value.Date, dtpFechaF.Value.Date);

                    LimpiarForm();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    msj.MensajeError("Ha ocurrido un error: " + ex);
                }
            }
            else
            {
                try
                {
                    comment += txtComentario.Text + Environment.NewLine;

                    brA.AltaAnimal(E_UsuarioAcceso.IdUsuario, Convert.ToInt32(cmbPersona.SelectedValue), Convert.ToInt32(cmbEspecie.SelectedValue), txtUbicacion.Text, E_Animal.FotoIngreso,
                                    txtNombre.Text, Convert.ToInt32(txtEdad.Text), Convert.ToInt32(cmbSexo.SelectedValue), chkCasSi.Checked, txtColor.Text, Convert.ToDecimal(txtPeso.Text),
                                    comment, Convert.ToInt32(cmbEstado.SelectedValue), dtpCastracion.Value.Date, dtpIngreso.Value.Date, dtpFechaNac.Value.Date, dtpFechaF.Value.Date);
                    LimpiarForm();
                }
                catch(Exception ex)
                {
                    msj.MensajeError("Ha ocurrido un error: " + ex);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtNombre.Text) || String.IsNullOrWhiteSpace(txtUbicacion.Text) ||
                String.IsNullOrWhiteSpace(txtEdad.Text) || String.IsNullOrWhiteSpace(txtPeso.Text) ||
                String.IsNullOrWhiteSpace(txtColor.Text))
            {
                DialogResult preg = MessageBox.Show("¿Desea cerrar este formulario?", "WiredSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (preg == DialogResult.OK)
                {
                    Close();
                }
            }
        }

        private void btnGuardarSeg_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtDetalle.Text))
            {
                msj.MensajeAlerta("El campo de detalle se encuentra vacío.");
            }
            else
            {
                try
                {
                    detalle += txtDetalle.Text + Environment.NewLine;
                    brS.GuardarSeguimiento(E_Animal.IdAnimal, detalle, dtpAcontecimiento.Value.Date, E_UsuarioAcceso.IdUsuario);
                    CargarGrillas();
                    txtDetalle.Text = String.Empty;
                    detalle = String.Empty;
                    dtpAcontecimiento.Value = DateTime.Now;
                }
                catch (Exception ex)
                {
                    msj.MensajeError("Ha ocurrido un error: " + ex);
                }
            }
        }

        private void btnExportarSeg_Click(object sender, EventArgs e)
        {
            ExportarDatos(dgvSeguimiento);
        }

        private void btnEliminarSeg_Click(object sender, EventArgs e)
        {
            if (dgvSeguimiento.Rows.Count > 0)
            {
                DialogResult preg = MessageBox.Show("¿Desea eliminar este seguimiento?", "WiredSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (preg == DialogResult.OK)
                {
                    E_Seguimiento.IdSeguimiento = Convert.ToInt32(dgvSeguimiento.CurrentRow.Cells["IdSeguimiento"].Value);
                    brS.BajaSeguimiento(E_Seguimiento.IdSeguimiento, E_UsuarioAcceso.IdUsuario);
                    CargarGrillas();
                }
            }
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
                brFM.BajaFichaMedica(E_FichaMedica.IdFichaMedica, E_UsuarioAcceso.IdUsuario);
                CargarGrillas();
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarDatos(dgvFichaMedica);
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

            picB1.Image = null;
            picB2.Image = null;

            chkCasSi.Checked = false;

            dtpFechaNac.Value = DateTime.Now;
            dtpFechaF.Value = DateTime.Now;
            dtpFichaMedica.Value = DateTime.Now;
            dtpCastracion.Value = DateTime.Now;
            dtpAcontecimiento.Value = DateTime.Now;
            dtpFiltro.Value = DateTime.Now;
        }

        public void ExportarDatos(DataGridView DatoListado)
        {
            Microsoft.Office.Interop.Excel.Application exportarexcel = new Microsoft.Office.Interop.Excel.Application();
            exportarexcel.Application.Workbooks.Add(true);
            int IndiceColumna = 0;
            foreach (DataGridViewColumn columna in DatoListado.Columns)
            {
                IndiceColumna++;
                exportarexcel.Cells[1, IndiceColumna] = columna.Name;
            }
            int IndiceFila = 0;
            foreach (DataGridViewRow fila in DatoListado.Rows)
            {
                IndiceFila++;
                IndiceColumna = 0;
                foreach (DataGridViewColumn columna in DatoListado.Columns)
                {
                    IndiceColumna++;
                    exportarexcel.Cells[IndiceFila + 1, IndiceColumna] = fila.Cells[columna.Name].Value;
                }
            }
            exportarexcel.Visible = true;
        }

        private void tbcDatosMasc_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tbcDatosMasc.SelectedIndex)
            {
                case 0:
                    btnGuardarDatos.Visible = true;
                    btnCancelar.Visible = true;
                    break;
                case 1:
                    btnGuardarDatos.Visible = false;
                    btnCancelar.Visible = false;
                    break;
                case 2:
                    btnGuardarDatos.Visible = false;
                    btnCancelar.Visible = false;
                    break;
            }
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
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                picB1.Image = Image.FromFile(ofd.FileName);
                E_Animal.FotoIngreso = ofd.FileName;
            }
        }

        private void btnImagen2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                picB2.Image = Image.FromFile(ofd.FileName);
                E_Animal.FotoAdopcion = ofd.FileName;
            }
        }

        private void dtpFiltro_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFiltro.Enabled == true)
            {
                dgvSeguimiento.DataSource = brS.FiltrarSeguimiento(dtpFiltro.Value.Date);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Enabled == true && dtpFichaMedica.Enabled == true)
            {
                dgvFichaMedica.DataSource = brFM.FiltrarFichaMedica(txtBuscar.Text, dtpFichaMedica.Value.Date);
            }
        }

        private void lklblVacunas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form VacunasDespa = new DesparasitacionVacuna();
            VacunasDespa.Show();
        }

        private void chkCasSi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCasSi.Checked == true)
            {
                dtpCastracion.Enabled = true;
            }
            else
                dtpCastracion.Enabled = false;
        }

        private void cmbPersona_SelectedValueChanged(object sender, EventArgs e)
        {
            E_Animal.Persona = Convert.ToInt32(cmbPersona.SelectedValue);
        }

        private void dgvFichaMedica_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            E_FichaMedica.IdFichaMedica = Convert.ToInt32(dgvFichaMedica.CurrentRow.Cells["IdFichaMedica"].Value);
            E_FichaMedica.Fecha = Convert.ToDateTime(dgvFichaMedica.CurrentRow.Cells["Fecha atención"].Value).Date;
            E_FichaMedica.Tratamiento = dgvFichaMedica.CurrentRow.Cells["Tratamiento"].Value.ToString();
            E_FichaMedica.Informe = dgvFichaMedica.CurrentRow.Cells["Informe"].Value.ToString();
            E_FichaMedica.IdVeterinaria = Convert.ToInt32(dgvFichaMedica.CurrentRow.Cells["IdVeterinaria"].Value);
            E_FichaMedica.IdMascota = Convert.ToInt32(dgvFichaMedica.CurrentRow.Cells["IdMascota"].Value);
            E_FichaMedica.Costo = Convert.ToDecimal(dgvFichaMedica.CurrentRow.Cells["Costo"].Value);
        }

        private void dgvFichaMedica_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvFichaMedica.Columns["Costo"].DefaultCellStyle.Format = "N2";
        }

        private void dtpFichaMedica_ValueChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Enabled == true && dtpFichaMedica.Enabled == true)
            {
                dgvFichaMedica.DataSource = brFM.FiltrarFichaMedica(txtBuscar.Text, dtpFichaMedica.Value.Date);
            }
        }
    }
}
            


