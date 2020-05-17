using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestPatronesCoyotas.Template;
using TestPatronesCoyotas.Utilities;

namespace TestPatronesCoyotas
{
    public partial class Form1 : Form
    {
        private Cliente _cliente;
        public Form1()
        {
            InitializeComponent();
            _cliente = new Cliente();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ActualizarDataGrid();
        }

        private void ActualizarDataGrid() 
        {
            _cliente = new Cliente();
            ResponseBase<DataSet> response = new ResponseBase<DataSet>();
            _cliente.accion = QueryType.Retrive;
            response = _cliente.AlgoritmoConsultasCRUD();
            if (response.Type == ResponseType.Success)
            {
                if (response.Result != null)
                {
                    dgvClientes.DataSource = response.Result.Tables[0];
                }
            }
            else
            {
                MessageBox.Show(response.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtEmail.Clear();
            txtDomFiscal.Clear();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                _cliente.Nombre = txtNombre.Text;
                _cliente.Direccion = txtDireccion.Text;
                _cliente.Email = txtEmail.Text;
                _cliente.Telefono = txtTelefono.Text;
                _cliente.DomicilioFiscal = txtDomFiscal.Text;
                _cliente.accion = QueryType.Create;
                ResponseBase<DataSet> response = _cliente.AlgoritmoConsultasCRUD();
                if (response.Type == ResponseType.Success)
                {
                    MessageBox.Show("Registro exitoso.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(response.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else 
            {
                MessageBox.Show("Favor de llenar todos los campos", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ActualizarDataGrid();
        }

        public bool ValidarDatos() 
        {
            foreach (TextBox c in pnlDatos.Controls.Cast<TextBox>())
            {
                if (String.IsNullOrWhiteSpace(c.Text) && !(c.ReadOnly)) 
                {
                    return false;
                }
            }
            return true;
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dgvClientes.SelectedRows[0].Cells[0].Value.ToString();
            txtNombre.Text = dgvClientes.SelectedRows[0].Cells[1].Value.ToString();
            txtDireccion.Text = dgvClientes.SelectedRows[0].Cells[2].Value.ToString();
            txtTelefono.Text = dgvClientes.SelectedRows[0].Cells[3].Value.ToString();
            txtEmail.Text = dgvClientes.SelectedRows[0].Cells[4].Value.ToString();
            txtDomFiscal.Text = dgvClientes.SelectedRows[0].Cells[5].Value.ToString();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            _cliente.ID = (int)dgvClientes.SelectedRows[0].Cells[0].Value;
            _cliente.accion = QueryType.Delete;
            ResponseBase<DataSet> response = _cliente.AlgoritmoConsultasCRUD();
            if (response.Type == ResponseType.Success)
            {
                MessageBox.Show("Registro eliminado con exito.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(response.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ActualizarDataGrid();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                _cliente.ID = int.Parse(txtID.Text);
                _cliente.Nombre = txtNombre.Text;
                _cliente.Direccion = txtDireccion.Text;
                _cliente.Email = txtEmail.Text;
                _cliente.Telefono = txtTelefono.Text;
                _cliente.DomicilioFiscal = txtDomFiscal.Text;
                _cliente.accion = QueryType.Update;
                ResponseBase<DataSet> response = _cliente.AlgoritmoConsultasCRUD();
                if (response.Type == ResponseType.Success)
                {
                    MessageBox.Show("Registro actualizado con exitoso.", "Actualzado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(response.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Favor de llenar todos los campos", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ActualizarDataGrid();
        }

    }
}
