using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using ToDOLISTt.infrastructure;

namespace ToDOLISTt.Models
{
    public class CONTENT
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)//MSSQLLocalDB;Initial Catalog=ToDoContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public string Saverecord(Todolisst cONTENT)
        {
            try
            {
                SqlCommand com = new SqlCommand("SP_Context_Add", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Content", cONTENT.Content);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                return ("OK");
            }
            catch (Exception ex)
            {
                if(con.State==ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message.ToString());

                throw;
            }
            

        }
    }
}
