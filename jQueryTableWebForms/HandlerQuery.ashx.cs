using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace jQueryTableWebForms
{
    /// <summary>
    /// Summary description for HandlerQuery
    /// </summary>
    public class HandlerQuery : IHttpHandler
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["neo"].ConnectionString);

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            List<object> lstDoc = new List<object>();

            SqlCommand commDoc = new SqlCommand();
            commDoc.Connection = con;
            commDoc.CommandText = @"SELECT top 100 do.IdDoc, do.IdTipoDoc, ti.NomeTipoDoc, do.IdEmpresa, e.NomeEmpresa, do.IdContato, c.NomeContato, do.IdUsuario, u.NomeUsuario, 
                                  do.DataCadastro, do.DataVencimento, do.SemVencimento, do.Vencimento,  
                                  do.Remessa, do.Observacao, do.NumeroDoc, do.IdSituacaoDoc, sd.NomeSituacaoDoc

                                  FROM Doc do
                                  join Empresa e on do.IdEmpresa = e.IdEmpresa
                                  join Contato c on do.IdContato = c.IdContato
                                  join TipoDoc ti on do.IdTipoDoc = ti.IdTipoDoc 
                                  join SituacaoDoc sd on do.IdSituacaoDoc = sd.IdSituacaoDoc
                                  join Usuario u on do.IdUsuario = u.IdUsuario";                                  

            con.Open();
            SqlDataReader readerDoc = commDoc.ExecuteReader();

            while (readerDoc.Read())
            {
                lstDoc.Add(new
                {
                    IdDoc = readerDoc["IdDoc"],
                    NumeroDoc = readerDoc["NumeroDoc"],
                    DataCadastro = Convert.ToDateTime(readerDoc["DataCadastro"]).ToShortDateString(),
                    IdTipoDoc = readerDoc["IdTipoDoc"],
                    NomeTipoDoc = readerDoc["NomeTipoDoc"],
                    IdEmpresa = readerDoc["IdEmpresa"],
                    NomeEmpresa = readerDoc["NomeEmpresa"],
                    IdContato = readerDoc["IdContato"],
                    NomeContato = readerDoc["NomeContato"],
                    IdSituacaoDoc = readerDoc["IdSituacaoDoc"],
                    NomeSituacaoDoc = readerDoc["NomeSituacaoDoc"],
                    DataVencimento = readerDoc["DataVencimento"] != DBNull.Value ? Convert.ToDateTime(readerDoc["DataVencimento"]).ToShortDateString() : "",
                    SemVencimento = readerDoc["SemVencimento"],
                    Vencimento = readerDoc["Vencimento"],
                    IdUsuario = readerDoc["IdUsuario"],
                    NomeUsuario = readerDoc["NomeUsuario"],
                    Remessa = readerDoc["Remessa"],
                    Observacao = readerDoc["Observacao"]
                });
            }
            con.Close();

            //List<object> lstItem = new List<object>();

            //SqlCommand commItem = new SqlCommand();
            //commItem.Connection = con;
            //commItem.CommandText = @"SELECT i.IdItemDoc, i.IdDoc, i.IdItem, i.Ordem, i.Quantidade, cast(i.Valor as decimal(10,2)) as Valor, cast(i.Total as decimal(10,2)) as Total, e.NomeItem

            //                       FROM ItemDoc i
            //                       join Item e on i.IdItem = e.IdItem                                

            //                       where i.IdDoc = " + IdDoc;

            //con.Open();
            //SqlDataReader readerItem = commItem.ExecuteReader();

            //while (readerItem.Read())
            //{
            //    lstItem.Add(new
            //    {
            //        IdItemDoc = readerItem["IdItemDoc"],
            //        IdDoc = readerItem["IdDoc"],
            //        IdItem = readerItem["IdItem"],
            //        Ordem = readerItem["Ordem"],
            //        Quantidade = readerItem["Quantidade"],
            //        Valor = readerItem["Valor"],
            //        Total = readerItem["Total"],
            //        NomeItem = readerItem["NomeItem"]
            //    });
            //}
            //con.Close();

            context.Response.Write(new JavaScriptSerializer().Serialize(lstDoc));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}