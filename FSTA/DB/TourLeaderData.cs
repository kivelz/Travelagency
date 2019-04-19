using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using FSTA.Models;
using FSTA.Models.ViewModel;

//er how do u add a forign key sql db haha
namespace FSTA.DB
{
    public class TourLeaderData : DB
    {
        

        public static TourLeaderDTO GetTourLeaderById(int id)
        {
             TourLeaderDTO lead = null;

            using (SqlConnection conn = new SqlConnection(DB.connectionString))
            {
                conn.Open();

                string sql = @"SELECT * from TourLeaders
                             WHERE Id = '" + id + "'";

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    lead = new TourLeaderDTO()
                    {
                        Id = (int) reader["Id"],
                        Name = (string) reader["Name"],
                        Rank = (string) reader["Rank"],
                        Email = (string) reader["Email"],
                        Phone = (int) reader["Phone"]
                        
                    };
                }
                conn.Close();
            }

            return lead;
        }
    }
}