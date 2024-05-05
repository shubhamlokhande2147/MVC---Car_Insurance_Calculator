
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Models;

namespace DAL
{
    public class InsuranceDBManager
    {
        public static string conString = @"server=localhost;port=3306;user=root;password=Shubham@2147;database=CIC_System";

       
           public static Factors GetFactorsById(int id)
            {
                Factors factors = null;

                MySqlConnection conn = new MySqlConnection(conString);
                string query = "SELECT * FROM Factors WHERE Fid = @Fid";

                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Fid", id);
                    conn.Open();
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    if (dataReader.Read())
                    {
                        factors = new Factors
                        {
                            Fid = Convert.ToInt32(dataReader["Fid"]),
                            Own_Damage_Premium_Discount_Percentage = Convert.ToDouble(dataReader["Own_Damage_Premium_Discount_Percentage"]),
                            No_Claim_Discount_Percentage = Convert.ToDouble(dataReader["No_Claim_Discount_Percentage"]),
                            Accident_Cover = Convert.ToDouble(dataReader["Accident_Cover"]),
                            Legal_Libility = Convert.ToDouble(dataReader["Legal_Libility"]),
                            Third_Party = Convert.ToDouble(dataReader["Third_Party"]),
                            Service_Tax_Percentage = Convert.ToDouble(dataReader["Service_Tax_Percentage"])
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

                return factors;
            }

               public static bool UpdateFactors(double Own_Damage_Premium_Discount_Percentage, double No_Claim_Discount_Percentage, double Accident_Cover, double Legal_Libility, double Third_Party, double Service_Tax_Percentage)
                {
                    MySqlConnection conn = new MySqlConnection(conString);
                    string query = "UPDATE Factors SET Own_Damage_Premium_Discount_Percentage = @Own_Damage_Premium_Discount_Percentage, No_Claim_Discount_Percentage = @No_Claim_Discount_Percentage, Accident_Cover = @Accident_Cover, Legal_Libility = @Legal_Libility, Third_Party = @Third_Party, Service_Tax_Percentage = @Service_Tax_Percentage WHERE FId = 1";

                    try
                    {
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Own_Damage_Premium_Discount_Percentage", Own_Damage_Premium_Discount_Percentage);
                        cmd.Parameters.AddWithValue("@No_Claim_Discount_Percentage", No_Claim_Discount_Percentage);
                        cmd.Parameters.AddWithValue("@Accident_Cover", Accident_Cover);
                        cmd.Parameters.AddWithValue("@Legal_Libility", Legal_Libility);
                        cmd.Parameters.AddWithValue("@Third_Party", Third_Party);
                        cmd.Parameters.AddWithValue("@Service_Tax_Percentage", Service_Tax_Percentage);
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

        //-----------------------


    }
}

