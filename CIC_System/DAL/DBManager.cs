// namespace DAL;
// using MySql.Data.MySqlClient;

// public static class DBManager
// {
//     public static string conString = @"server=localhost;port=3306;user=root;password=Shubham@2147;database=CIC_System";

// public static bool AddUser(int id, string name, int age, int mobile, int aadhar_no, string licence_no, string address, string gender, string password, IFormFile image)
// {
//     MySqlConnection conn = new MySqlConnection();
//     conn.ConnectionString = conString;
//     string query = "INSERT INTO user_registration (Id, Name, Age, Mobile, Aadhar_no, Licence_no, Address, Gender, Password, Image) VALUES (@Id, @Name, @Age, @Mobile, @Aadhar_no, @Licence_no, @Address, @Gender, @Password, @Image)";
    
//     try
//     {
//         byte[] imageBytes = null;
//         if (image != null && image.Length > 0)
//         {
//             using (var memoryStream = new MemoryStream())
//             {
//                 image.CopyTo(memoryStream);
//                 imageBytes = memoryStream.ToArray();
//             }
//         }

//         MySqlCommand cmd = new MySqlCommand(query, conn);
//         cmd.Parameters.AddWithValue("@Id", id);
//         cmd.Parameters.AddWithValue("@Name", name);
//         cmd.Parameters.AddWithValue("@Age", age);
//         cmd.Parameters.AddWithValue("@Mobile", mobile);
//         cmd.Parameters.AddWithValue("@Aadhar_no", aadhar_no);
//         cmd.Parameters.AddWithValue("@Licence_no", licence_no);
//         cmd.Parameters.AddWithValue("@Address", address);
//         cmd.Parameters.AddWithValue("@Gender", gender);
//         cmd.Parameters.AddWithValue("@Password", password);
//         cmd.Parameters.AddWithValue("@Image", imageBytes); // Store image as byte array

//         conn.Open();
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

using MySql.Data.MySqlClient;
using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace DAL
{
    public static class DBManager
    {
        public static string conString = @"server=localhost;port=3306;user=root;password=Shubham@2147;database=CIC_System";

        public static bool AddUser(int id, string name, int age, int mobile, int aadhar_no, string licence_no, string address, string gender, string password, IFormFile image)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = conString;
            string query = "INSERT INTO user_registration (Id, Name, Age, Mobile, Aadhar_no, Licence_no, Address, Gender, Password, Image) VALUES (@Id, @Name, @Age, @Mobile, @Aadhar_no, @Licence_no, @Address, @Gender, @Password, @Image)";

            try
            {
                byte[] imageBytes = null;
                if (image != null && image.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        image.CopyTo(memoryStream);
                        imageBytes = memoryStream.ToArray();
                    }
                }

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("@Mobile", mobile);
                cmd.Parameters.AddWithValue("@Aadhar_no", aadhar_no);
                cmd.Parameters.AddWithValue("@Licence_no", licence_no);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Image", imageBytes); // Store image as byte array

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