using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class DALUserAuth
    {

        public static async Task<string> Authenticate(string username, string password)
        {
            UserSession userProfile = new UserSession();
            try
            {
                using (SqlConnection con = DBHelper.GetConnection())
                {
                    await con.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("LoginKaro", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@email", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        using (SqlDataReader sdr = await cmd.ExecuteReaderAsync())
                        {
                            while (await sdr.ReadAsync())
                            {
                                // Ensure the name matches from your database variable storing name
                                userProfile.name = sdr["name"].ToString();
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                
            }
            return userProfile.name.ToString();
        }

    }
}




