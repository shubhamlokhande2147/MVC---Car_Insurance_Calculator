
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Models;

namespace DAL
{
    public class VehicleDBManager
    {
        public static string conString = @"server=localhost;port=3306;user=root;password=Shubham@2147;database=CIC_System";

        public static bool AddVehicle(int vid, string vno, double vprice, string vcompany, string date_of_Purchase, string engine_no, string fuel_Type, int userID)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = conString;
            string query = "INSERT INTO vehicle (Vid, Vno, Vprice, Vcompany, Date_of_Purchase, Engine_no, Fuel_Type, UserId) VALUES (@VId, @Vno, @Vprice, @Vcompany, @Date_of_Purchase, @Engine_no, @Fuel_Type, @UserID)";

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@VId", vid);
                cmd.Parameters.AddWithValue("@Vno", vno);
                cmd.Parameters.AddWithValue("@Vprice", vprice);
                cmd.Parameters.AddWithValue("@Vcompany", vcompany);
                cmd.Parameters.AddWithValue("@Date_of_Purchase", date_of_Purchase);
                cmd.Parameters.AddWithValue("@Engine_no", engine_no);
                cmd.Parameters.AddWithValue("@Fuel_Type", fuel_Type);
                cmd.Parameters.AddWithValue("@UserID", userID);

                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public static List<Vehicle> GetAllVehicles(int ID)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            MySqlConnection conn = new MySqlConnection(conString);
            string query = "SELECT * FROM vehicle WHERE UserId = @ID";

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", ID);
                conn.Open();
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Vehicle vehicle = new Vehicle
                    {
                        Vid = Convert.ToInt32(dataReader["Vid"]),
                        Vno = dataReader["Vno"].ToString(),
                        Vprice = Convert.ToDouble(dataReader["Vprice"]),
                        Vcompany = dataReader["Vcompany"].ToString(),
                        Date_of_Purchase = dataReader["Date_of_Purchase"].ToString(),
                        Engine_no = dataReader["Engine_no"].ToString(),
                        Fuel_Type = dataReader["Fuel_Type"].ToString(),
                        UserId = Convert.ToInt32(dataReader["UserId"])
                    };

                    vehicles.Add(vehicle);
                }

                dataReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return vehicles;
        }

        public static Vehicle GetVehicleById(int id)
        {
            Vehicle vehicle = null;

            MySqlConnection conn = new MySqlConnection(conString);
            string query = "SELECT * FROM vehicle WHERE Vid = @Vid";

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Vid", id);
                conn.Open();
                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.Read())
                {
                    vehicle = new Vehicle
                    {
                        Vid = Convert.ToInt32(dataReader["Vid"]),
                        Vno = dataReader["Vno"].ToString(),
                        Vprice = Convert.ToDouble(dataReader["Vprice"]),
                        Vcompany = dataReader["Vcompany"].ToString(),
                        Date_of_Purchase = dataReader["Date_of_Purchase"].ToString(),
                        Engine_no = dataReader["Engine_no"].ToString(),
                        Fuel_Type = dataReader["Fuel_Type"].ToString(),
                        UserId = Convert.ToInt32(dataReader["UserId"])
                    };
                }

                dataReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return vehicle;
        }

        // public static bool UpdateVehicle(Vehicle vehicle)
        // {
        //     MySqlConnection conn = new MySqlConnection(conString);
        //     string query = "UPDATE vehicle SET Vno = @Vno, Vprice = @Vprice, Vcompany = @Vcompany, Date_of_Purchase = @Date_of_Purchase, Engine_no = @Engine_no, Fuel_Type = @Fuel_Type WHERE Vid = @Vid";

        //     try
        //     {
        //         MySqlCommand cmd = new MySqlCommand(query, conn);
        //         cmd.Parameters.AddWithValue("@Vid", vehicle.Vid);
        //         cmd.Parameters.AddWithValue("@Vno", vehicle.Vno);
        //         cmd.Parameters.AddWithValue("@Vprice", vehicle.Vprice);
        //         cmd.Parameters.AddWithValue("@Vcompany", vehicle.Vcompany);
        //         cmd.Parameters.AddWithValue("@Date_of_Purchase", vehicle.Date_of_Purchase);
        //         cmd.Parameters.AddWithValue("@Engine_no", vehicle.Engine_no);
        //         cmd.Parameters.AddWithValue("@Fuel_Type", vehicle.Fuel_Type);

        //         conn.Open();
        //         int rowsAffected = cmd.ExecuteNonQuery();
        //         if (rowsAffected > 0)
        //         {
        //             return true;
        //         }
        //     }
        //     catch (Exception e)
        //     {
        //         Console.WriteLine(e.Message);
        //     }
        //     finally
        //     {
        //         conn.Close();
        //     }

        //     return false;
        // }
        //-----------------------
         public static bool UpdateVehicle(int vid, string vno, double vprice, string vcompany, string date_of_Purchase, string engine_no, string fuel_Type)
        {
            MySqlConnection conn = new MySqlConnection(conString);
            string query = "UPDATE vehicle SET Vprice = @Vprice, Vcompany = @Vcompany, Date_of_Purchase = @Date_of_Purchase, Engine_no = @Engine_no, Fuel_Type = @Fuel_Type WHERE VId = @VId";

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@VId", vid);
                cmd.Parameters.AddWithValue("@Vno", vno);
                cmd.Parameters.AddWithValue("@Vprice", vprice);
                cmd.Parameters.AddWithValue("@Vcompany", vcompany);
                cmd.Parameters.AddWithValue("@Date_of_Purchase", date_of_Purchase);
                cmd.Parameters.AddWithValue("@Engine_no", engine_no);
                cmd.Parameters.AddWithValue("@Fuel_Type", fuel_Type);
              //  cmd.Parameters.AddWithValue("@userID", userID);


                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return false;
        }

//----------------------------------------------------------------------------------------------
         
      public static bool DeleteVehicle(int id)
{
    MySqlConnection conn = new MySqlConnection(conString);
    string query = "DELETE FROM vehicle WHERE Vid = @Vid";

    try
    {
        MySqlCommand cmd = new MySqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@Vid", id);
        conn.Open();
        int rowsAffected = cmd.ExecuteNonQuery();
        return rowsAffected > 0;
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        return false;
    }
    finally
    {
        conn.Close();
    }
}


    }
}

