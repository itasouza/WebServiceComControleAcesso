using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using System.Text;

namespace WebControleDados
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http:/itaprojetos.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {


        //declarando a variável Credencial
        public SegurancaConsulta Credencial = new SegurancaConsulta();


        //declarando a váriavel usuário e senha
        public class SegurancaConsulta : SoapHeader
        {
            public string Usuario;
            public string Senha;
        }


        //metodo para validar a senha e usuário
        private Boolean Autenticou()
        {
            Boolean Autenticou = false;
            string Usuario = "Controle";
            string Senha = "123456";
            if (Credencial.Usuario == Usuario && Credencial.Senha == Senha)
            {
                Autenticou = true;
            }
            return Autenticou;
        }


        [SoapHeader("Credencial")]
        [WebMethod(Description = "Retorna informação de validação de operação")]
        public DataSet ValidaOperacao(string WebServiceLogin, string WebServiceSenha, 
                                      string CodMaquinaCliente, string CodCartaoConsumidor, 
                                      string Operacao, int QtdParcelas, string SenhaAcesso)
        {

            Credencial.Usuario = WebServiceLogin;
            Credencial.Senha = WebServiceSenha;

            if (!Autenticou())
            {
                throw new Exception("Erro: Usuário não autenticado.");
            }

            DataSet dsRetorno = null;
           // string connectioString = "Data Source=nt02sql;User Id=os;Password='';Initial Catalog='';";

            StringBuilder sqlString = new StringBuilder();
           // sqlString.Append("select * from teste");


            //using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectioString))
            //{

            //    connection.Open();
            //    using (System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand())
            //    {
            //        command.Connection = connection;
            //        command.CommandText = sqlString.ToString();

            //        using (System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(command))
            //        {
            //            adapter.Fill(dsRetorno);
            //        }
            //    }
            //}

            return dsRetorno;

        }



    }
}