using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace WebApplication1.Controllers
{
    public class ReceiverApiController : Controller
    {

        [HttpPost("/InitiateApiCall", Name = "InitiateApiCall")]
        public string InitiateApiCall() {

            string identifier = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffffff");
            try {

                string spName = "AddDetailLog2";
                string ConnectionString = @"Server=192.168.100.54;Database=BankDB;User ID=sa;password=Techvision123@;";
                //string ConnectionString = @"Server=59.152.61.37,35433;Database=BankDB;User ID=sa;password=Techvision123@;";

                using (SqlConnection connection = new SqlConnection(ConnectionString)) {
                    connection.Open();
                    SqlCommand sql_cmnd = new SqlCommand(spName, connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@RefNoSendingBank", SqlDbType.VarChar).Value = identifier;
                    sql_cmnd.Parameters.AddWithValue("@RefNoReceivingBank", SqlDbType.VarChar).Value = "";
                    sql_cmnd.Parameters.AddWithValue("@RefNo_IDTP", SqlDbType.VarChar).Value = "";
                    sql_cmnd.Parameters.AddWithValue("@Layer", SqlDbType.VarChar).Value = "";
                    sql_cmnd.Parameters.AddWithValue("@StepTitle", SqlDbType.VarChar).Value = "";
                    sql_cmnd.Parameters.AddWithValue("@RequestFrom", SqlDbType.VarChar).Value = "T2";
                    sql_cmnd.Parameters.AddWithValue("@RequestTo", SqlDbType.VarChar).Value = "";
                    sql_cmnd.Parameters.AddWithValue("@RequestMessage", SqlDbType.VarChar).Value = "";
                    sql_cmnd.Parameters.AddWithValue("@ErrorCode", SqlDbType.VarChar).Value = "";
                    sql_cmnd.Parameters.AddWithValue("@ErrorTitle", SqlDbType.VarChar).Value = "";
                    sql_cmnd.Parameters.AddWithValue("@ErrorDescription", SqlDbType.VarChar).Value = "";
                    sql_cmnd.Parameters.AddWithValue("@ReferenceNo", SqlDbType.VarChar).Value = "";


                    sql_cmnd.Parameters.AddWithValue("@Order", SqlDbType.Int).Value = 0;
                    sql_cmnd.Parameters.AddWithValue("@LogType", SqlDbType.Int).Value = 4;

                    sql_cmnd.ExecuteNonQuery();
                    connection.Close();
                }

                string url = @"http://192.168.100.13:9000/" + "CallParticipantFI";
                //url = @"http://59.152.61.37:39000/" + "CallParticipantFI";

                CommunicationService communicationService = new CommunicationService();
                identifier = communicationService.CallParticipantFIUsingStaticHttpClientInstance(url, identifier).Result;

            }
            catch (Exception ex) {
                return ex.Message;
            }
            return identifier;
        }

        [HttpPost("/CallParticipantFI", Name = "CallParticipantFI")]
        public string CallParticipantFI([FromBody] string identifier) {
            try {

                string spName = "AddDetailLog2";
                string ConnectionString = @"Server=192.168.100.54;Database=BankDB;User ID=sa;password=Techvision123@;";
                //string ConnectionString = @"Server=59.152.61.37,35433;Database=BankDB;User ID=sa;password=Techvision123@;";

                using (SqlConnection connection = new SqlConnection(ConnectionString)) {
                    connection.Open();
                    SqlCommand sql_cmnd = new SqlCommand(spName, connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@RefNoSendingBank", SqlDbType.VarChar).Value = identifier;
                    sql_cmnd.Parameters.AddWithValue("@RefNoReceivingBank", SqlDbType.VarChar).Value = "";
                    sql_cmnd.Parameters.AddWithValue("@RefNo_IDTP", SqlDbType.VarChar).Value = "";
                    sql_cmnd.Parameters.AddWithValue("@Layer", SqlDbType.VarChar).Value = "";
                    sql_cmnd.Parameters.AddWithValue("@StepTitle", SqlDbType.VarChar).Value = "";
                    sql_cmnd.Parameters.AddWithValue("@RequestFrom", SqlDbType.VarChar).Value = "T3";
                    sql_cmnd.Parameters.AddWithValue("@RequestTo", SqlDbType.VarChar).Value = "";
                    sql_cmnd.Parameters.AddWithValue("@RequestMessage", SqlDbType.VarChar).Value = "";
                    sql_cmnd.Parameters.AddWithValue("@ErrorCode", SqlDbType.VarChar).Value = "";
                    sql_cmnd.Parameters.AddWithValue("@ErrorTitle", SqlDbType.VarChar).Value = "";
                    sql_cmnd.Parameters.AddWithValue("@ErrorDescription", SqlDbType.VarChar).Value = "";
                    sql_cmnd.Parameters.AddWithValue("@ReferenceNo", SqlDbType.VarChar).Value = "";


                    sql_cmnd.Parameters.AddWithValue("@Order", SqlDbType.Int).Value = 0;
                    sql_cmnd.Parameters.AddWithValue("@LogType", SqlDbType.Int).Value = 4;

                    sql_cmnd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex) {
                return ex.Message;
            }
            return identifier;
        }

    }
}
