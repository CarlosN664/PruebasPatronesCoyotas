using MySql.Data.MySqlClient;
using System.Data;
using TestPatronesCoyotas.Singleton;

namespace TestPatronesCoyotas.Template
{
    public class Cliente : CrudTemplate
    {
        #region Propiedades
        protected int id;
        protected string nombre, direccion, telefono, email, domiciliofiscal;
        public int ID { get { return id; } set { id = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Direccion { get { return direccion; } set { direccion = value; } }
        public string Telefono { get { return telefono; } set { telefono = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string DomicilioFiscal { get { return domiciliofiscal; } set { domiciliofiscal = value; } }
        #endregion

        #region Metodos
        public Cliente()
        {
            nombre = string.Empty;
            direccion = string.Empty;
            telefono = string.Empty;
            email = string.Empty;
            domiciliofiscal = string.Empty;
        }
        protected override void CreateMethod()
        {
            command = new MySqlCommand("sp_agregarCliente", ConexionSingleton.GetConnection());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@nombre", nombre);
            command.Parameters.AddWithValue("@direccion", direccion);
            command.Parameters.AddWithValue("@telefono", telefono);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@domiciliofiscal", domiciliofiscal);
        }
        protected override void RetriveMethod()
        {
            dataset.Clear();
            command = new MySqlCommand("sp_buscarClientes", ConexionSingleton.GetConnection());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@nombre", nombre);
            command.Parameters.AddWithValue("@tel", telefono);
            dataadapter = new MySqlDataAdapter(command);
            dataadapter.Fill(dataset);
        }
        protected override void UpdateMethod()
        {
            command = new MySqlCommand("sp_actualizarCliente", ConexionSingleton.GetConnection());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@nombre", nombre);
            command.Parameters.AddWithValue("@direccion", direccion);
            command.Parameters.AddWithValue("@telefono", telefono);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@domiciliofiscal", domiciliofiscal);
        }
        protected override void DeleteMethod()
        {
            command = new MySqlCommand("sp_eliminarCliente", ConexionSingleton.GetConnection());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
        }
        #endregion
    }
}
