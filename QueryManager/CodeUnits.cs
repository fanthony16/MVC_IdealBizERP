using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace IdealBizUI.QueryManager
{
    public class CodeUnits
    {
        private readonly IConfiguration _configuration;
        public CodeUnits(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string getCode(string _tranType)
        {
            string _transcode="";
            try {

                using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("IdealBizConnection")))
                {
                    SqlCommand cmd = new SqlCommand("sp_dml_getTransactionCode", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SourceType", _tranType);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        _transcode = Convert.ToString(reader[0]);
                        
                    }
                    conn.Close();
                }

            }
            catch (Exception ex)
            {

            }           

            return _transcode;
        }
    }
}
