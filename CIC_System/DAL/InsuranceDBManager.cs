
// using MySql.Data.MySqlClient;
// using System;
// using System.Collections.Generic;
// using Models;

// namespace DAL
// {
//     public class VehicleDBManager
//     {
//         public static string conString = @"server=localhost;port=3306;user=root;password=Shubham@2147;database=CIC_System";

       
//         public static Vehicle GetVehicleById(int id)
//         {
//             Vehicle vehicle = null;

//             MySqlConnection conn = new MySqlConnection(conString);
//             string query = "SELECT * FROM vehicle WHERE Vid = @Vid";

//             try
//             {
//                 MySqlCommand cmd = new MySqlCommand(query, conn);
//                 cmd.Parameters.AddWithValue("@Vid", id);
//                 conn.Open();
//                 MySqlDataReader dataReader = cmd.ExecuteReader();

//                 if (dataReader.Read())
//                 {
//                     vehicle = new Vehicle
//                     {
//                         Vid = Convert.ToInt32(dataReader["Vid"]),
//                         Vno = dataReader["Vno"].ToString(),
//                         Vprice = Convert.ToDouble(dataReader["Vprice"]),
//                         Vcompany = dataReader["Vcompany"].ToString(),
//                         Date_of_Purchase = dataReader["Date_of_Purchase"].ToString(),
//                         Engine_no = dataReader["Engine_no"].ToString(),
//                         Fuel_Type = dataReader["Fuel_Type"].ToString(),
//                         UserId = Convert.ToInt32(dataReader["UserId"])
//                     };
//                 }

//                 dataReader.Close();
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine(e.Message);
//             }
//             finally
//             {
//                 conn.Close();
//             }

//             return vehicle;
//         }

//         //-----------------------
//          public static bool UpdateVehicle(int vid, string vno, double vprice, string vcompany, string date_of_Purchase, string engine_no, string fuel_Type)
//         {
//             MySqlConnection conn = new MySqlConnection(conString);
//             string query = "UPDATE vehicle SET Vprice = @Vprice, Vcompany = @Vcompany, Date_of_Purchase = @Date_of_Purchase, Engine_no = @Engine_no, Fuel_Type = @Fuel_Type WHERE VId = @VId";

//             try
//             {
//                 MySqlCommand cmd = new MySqlCommand(query, conn);
//                 cmd.Parameters.AddWithValue("@VId", vid);
//                 cmd.Parameters.AddWithValue("@Vno", vno);
//                 cmd.Parameters.AddWithValue("@Vprice", vprice);
//                 cmd.Parameters.AddWithValue("@Vcompany", vcompany);
//                 cmd.Parameters.AddWithValue("@Date_of_Purchase", date_of_Purchase);
//                 cmd.Parameters.AddWithValue("@Engine_no", engine_no);
//                 cmd.Parameters.AddWithValue("@Fuel_Type", fuel_Type);
//               //  cmd.Parameters.AddWithValue("@userID", userID);


//                 conn.Open();
//                 int rowsAffected = cmd.ExecuteNonQuery();
//                 if (rowsAffected > 0)
//                 {
//                     return true;
//                 }
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine(e.Message);
//             }
//             finally
//             {
//                 conn.Close();
//             }

//             return false;
//         }


//     }
// }

