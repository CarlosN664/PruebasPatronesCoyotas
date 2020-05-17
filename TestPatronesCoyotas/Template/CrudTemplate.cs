using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPatronesCoyotas.Singleton;
using TestPatronesCoyotas.Utilities;

namespace TestPatronesCoyotas.Template
{
    public abstract class CrudTemplate
    {
        protected MySqlCommand command;
        protected MySqlDataReader datareader;
        protected MySqlDataAdapter dataadapter;
        protected DataSet dataset = new DataSet();
        public QueryType accion; 
        public ResponseBase<DataSet> AlgoritmoConsultasCRUD() 
        {
            ResponseBase<DataSet> response = new ResponseBase<DataSet>();
            try
            {
                AbrirConexion();
                DefinirAccion();
                EjecutarComando();
                response.Result = dataset;
            }
            catch (Exception ex)
            {
                response.Type = ResponseType.Error;
                response.Message = ex.Message;
            }
            finally
            {
                CerrarConexion();
            }
            return response;
        }
        private void DefinirAccion() 
        {
            switch (accion)
            {
                case QueryType.Create:
                    CreateMethod();
                    break;
                case QueryType.Retrive:
                    RetriveMethod();
                    break;
                case QueryType.Update:
                    UpdateMethod();
                    break;
                case QueryType.Delete:
                    DeleteMethod();
                    break;
            }
        }

        protected abstract void DeleteMethod();

        protected abstract void UpdateMethod();

        protected abstract void RetriveMethod();

        protected abstract void CreateMethod();

        private void EjecutarComando() 
        {
            command.ExecuteNonQuery();
        }
        private void AbrirConexion() 
        {
            ConexionSingleton.GetConnection().Open();
        }
        private void CerrarConexion() 
        {
            ConexionSingleton.GetConnection().Close();
        }

    }
}
