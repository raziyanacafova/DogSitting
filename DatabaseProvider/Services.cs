//namespace DogSitting_.DatabaseProvider
//{
//    public class Services
//    {
//    }
//}
using DogSitter.Models;
using DogSitter.Models.RequestModels;
using DogSitter.Models.ResponseModels;
using System.Data;
using System.Data.SqlClient;

namespace DogSitter.DatabaseProvider
{
    public static class Services
    {
        private static readonly string connectionstring = "Data Source=80.78.240.16;Initial Catalog=BakuDevEduBE.Group1;User ID=Student;Password=qwe!23;";

        public static void CreateSitter(RequestSitter sitter)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand("CreateSitter", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@firstname", sitter.FirstName);
                    command.Parameters.AddWithValue("@lastname", sitter.LastName);
                    connection.Open();
                    command.ExecuteNonQuery();

                }

   
            }

        }
        public static void CreateClient(RequestClient client)
        {
            //Call to stored procedure to add a client with client.FirstName and client.LastName in Clients table
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand("CreateClient", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@firstname", client.FirstName);
                    command.Parameters.AddWithValue("@lastname", client.LastName);
                    connection.Open();
                    command.ExecuteNonQuery();

                }
            }
        }
        public static int GetSitterId(RequestSitter sitter)
        {
            int sitterid = 0;//Call to stored procedure to get the id of the sitter with sitter.FirstName and sitter.LastName
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand("GetSitterId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@firstname", sitter.FirstName);
                    command.Parameters.AddWithValue("@lastname", sitter.LastName);
                    connection.Open();
                    sitterid = (Int32)command.ExecuteScalar();


                }
            }
            return sitterid;
        }
        public static int GetClientId(RequestClient client)
        {
            int clientid = 0;//Call to stored procedure to get the id of the client with client.FirstName and client.LastName
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand("GetClientId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@firstname", client.FirstName);
                    command.Parameters.AddWithValue("@lastname", client.LastName);
                    connection.Open();
                    clientid=(int)command.ExecuteScalar();

                }
            }
            return clientid;
        }
        public static int CreateHiring(ResponseHiring hiring)
        {
            int hireid;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand("CreateHiring", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@sitterid", hiring.SitterId);
                    command.Parameters.AddWithValue("@clientid", hiring.ClientId);
                    connection.Open();
                    hireid = (int)command.ExecuteScalar();

                }
            }
            return hireid;
        }
        public static void CreateHiringDetails(ResponseHiring hiring)
        {

            //Call to s.p to create a hiringdetail with given arguments(hiring.Id,hiring.ClientId,hiring.SitterId,hiring.NumberOfDogs) in hiringdetails table
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand("CreateHiringDetails", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@hireid", hiring.HireId);
                    command.Parameters.AddWithValue("@numberofdogs", hiring.NumberOfDogs);
                    command.Parameters.AddWithValue("@starttime", hiring.StartTime);
                    command.Parameters.AddWithValue("@endtime",hiring.EndTime);
                    connection.Open();
                    command.ExecuteNonQuery();

                }
            }
        }
        public static bool CheckTimeOverLap(DateTime starttime,DateTime endtime,int sitterid)
        {
            bool answer = false;

            //Call to Support.CheckTimeOverLaps(DateTime starta,DateTime startb,DateTime enda,DateTime endb)
            //for each start and endtime for sitter with id
            //using (SqlConnection connection = new SqlConnection(connectionstring))
            //{
            //    connection.Open();
            //    SqlCommand command = new SqlCommand("SELECT * FROM SITTERS", connection);
            //    using (SqlDataReader reader = command.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            sitters.Add(new SitterDisplay
            //            {
            //                FirstName = (string)reader[1],
            //                LastName = (string)reader[2],
            //                PaymentPerHour = reader[3] != DBNull.Value ? (decimal)reader[3] : 0
            //            });

            //        }
            //    }
            //}
            return answer;
        }
        public static void CreateFeedback(ResponseFeedback responsefeedback)
        {
            //Call to s.p. to add a new feedback with responsefeedback.SitterId, responsefeedback.SitterId,responsefeedback.Feedback
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand("CreateFeedback", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@sitterid", responsefeedback.SitterId);
                    command.Parameters.AddWithValue("@clientid", responsefeedback.ClientId);
                    command.Parameters.AddWithValue("feedback", responsefeedback.Feedback);
                    connection.Open();
                    command.ExecuteNonQuery();

                }
            }
        }
        public static List<SitterDisplay> GetSitters()
        {
            List<SitterDisplay> sitters = new List<SitterDisplay>();
            //not completed
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM SITTERS",connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sitters.Add(new SitterDisplay
                        {
                            FirstName = (string)reader[1],
                            LastName = (string)reader[2],
                            PaymentPerHour = reader[3]!=DBNull.Value? (decimal)reader[3] : 0
                        });
            
                    }
                }
            }
            return sitters;
        }
        public static void DeleteSitter(RequestSitter sitter)
        {
            //Call to GetSitterId->id
            //Call to s.p to delete the sitter with id from sitters, feedbacks,hirings,hirindetails
        }
    }
}