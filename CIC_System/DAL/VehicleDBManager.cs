using MySql.Data.MySqlClient;
using System;
using System.IO;
using Models;
using Microsoft.AspNetCore.Http;

namespace DAL
{
    public static class VehicleDBManager
    {
        public static string conString = @"server=localhost;port=3306;user=root;password=Shubham@2147;database=CIC_System";

        public static bool AddVehicle(int vid, string vno, double vprice, string vcompany, string date_of_Purchase, string engine_no, string fuel_Type,int userID)
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

        //----------------------------------------------------------
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

            //-------------------------------------------------------------


              


    }

    // public static bool UpdateBookByID(Book b)
    // {
    //     MySqlConnection conn = new MySqlConnection();
    //     conn.ConnectionString = conString;
    //     string query = "update book set bname=@Bname,author=@Auhor,price=@Price where id=@Id";
    //     // string query = "update book set bname='rt' where id=5";

    //     try
    //     {
    //         Console.WriteLine("try");
    //         MySqlCommand cmd = new MySqlCommand(query, conn);
    //         cmd.Parameters.AddWithValue("@Id", b.Id);
    //         cmd.Parameters.AddWithValue("@Bname", b.Bname);
    //         cmd.Parameters.AddWithValue("@Auhor", b.Author);
    //         cmd.Parameters.AddWithValue("@Price", b.price);
    //         cmd.Connection = conn;
    //         conn.Open();
    //         cmd.CommandText = query;
    //         cmd.ExecuteNonQuery();
    //         Console.WriteLine("Error");
    //         return true;
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
    // public static bool DeleteBookByID(int id)
    // {
    //     MySqlConnection conn = new MySqlConnection();
    //     conn.ConnectionString = conString;
    //     string query = "delete from book where id=@Id";
    //     // string query = "update book set bname='rt' where id=5";

    //     try
    //     {
    //         Console.WriteLine("try");
    //         MySqlCommand cmd = new MySqlCommand(query, conn);
    //         cmd.Parameters.AddWithValue("@Id", id);
    //         cmd.Connection = conn;
    //         conn.Open();
    //         cmd.CommandText = query;
    //         cmd.ExecuteNonQuery();
    //         return true;
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
    // public static List<Book> FindBookByID(int id)
    // {
    //     MySqlConnection conn = new MySqlConnection();
    //     conn.ConnectionString = conString;
    //     string query = "select id,bname,author,price from book where id=@Id";
    //     // string query = "update book set bname='rt' where id=5";
    //     List<Book> list = new List<Book>();
    //     try
    //     {
    //         Console.WriteLine("try");
    //         MySqlCommand cmd = new MySqlCommand(query, conn);
    //         cmd.Parameters.AddWithValue("@Id", id);
    //         cmd.Connection = conn;
    //         conn.Open();
    //         cmd.CommandText = query;
    //         MySqlDataReader reader = cmd.ExecuteReader();
    //         while (reader.Read())
    //         {
    //             int id1 = int.Parse(reader["id"].ToString());
    //             string bnm = reader["bname"].ToString();
    //             string auth = reader["author"].ToString();
    //             int pc = int.Parse(reader["price"].ToString());
    //             Book b = new Book(id1, bnm, auth, pc);
    //             if (b != null)
    //             {
    //                 list.Add(b);
    //             }
    //         }

    //         return list;
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine(e.Message);
    //     }
    //     finally
    //     {
    //         conn.Close();
    //     }
    //     return list;
    // }
    // public static List<Book> GetAllBook()
    // { 
        
    //     MySqlConnection conn = new MySqlConnection();
    //     conn.ConnectionString = conString;
    //     string query = "select id,bname,author,price from book ";
    //     // string query = "update book set bname='rt' where id=5";
    //     List<Book> list = new List<Book>();
    //     try
    //     {
    //         Console.WriteLine("try");
    //         MySqlCommand cmd = new MySqlCommand(query, conn);
    //         cmd.Connection = conn;
    //         conn.Open();
    //         cmd.CommandText = query;
    //         MySqlDataReader reader = cmd.ExecuteReader();
    //         while (reader.Read())
    //         {
    //             int id1 = int.Parse(reader["id"].ToString());
    //             string bnm = reader["bname"].ToString();
    //             string auth = reader["author"].ToString();
    //             int pc = int.Parse(reader["price"].ToString());
    //             Book b = new Book(id1, bnm, auth, pc);
    //             if (b != null)
    //             {
    //                 list.Add(b);
    //             }
    //         }

    //         return list;
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine(e.Message);
    //     }
    //     finally
    //     {
    //         conn.Close();
    //     }
    //     return list;
    // }
}