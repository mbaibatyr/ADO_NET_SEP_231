﻿using Microsoft.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLClient
{
    public class Ado
    {
        //static string conStr = "Server=204-P;Database=MyDB;Trusted_Connection=True;TrustServerCertificate=true";
        public static void Select()
        {
            using (SqlConnection db = new SqlConnection(Program.config["db"]))
            {
                db.Open();
                DataTable dt = new DataTable();
                using (SqlCommand cmd = new SqlCommand("pCity", db))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    dt.Load(cmd.ExecuteReader());
                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine($"{row["id"].ToString()} - {row[1].ToString()} - {row[2].ToString()}- {row[3].ToString()}");
                    }
                }
                db.Close();
            }
        }

        public static void SelectByName(string name)
        {
            using (SqlConnection db = new SqlConnection(Program.config["db"]))
            {
                db.Open();
                DataTable dt = new DataTable();
                using (SqlCommand cmd = new SqlCommand("pCity;2", db))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", name);

                    //SqlParameter p_name = new SqlParameter("@name", name);
                    //cmd.Parameters.Add(p_name);
                    
                    //cmd.Parameters.Add(new SqlParameter("@name", name));

                    dt.Load(cmd.ExecuteReader());
                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine($"{row["id"].ToString()} - {row[1].ToString()} - {row[2].ToString()}- {row[3].ToString()}");
                    }
                }
                db.Close();
            }
        }

        public static void Insert(string name, int population, DateTime birthdate)
        {
            using (SqlConnection db = new SqlConnection(Program.config["db"]))
            {
                db.Open();
                //using (SqlCommand cmd = new SqlCommand("pCity;3", db))
                //{
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.AddWithValue("@name", name);
                //    cmd.Parameters.AddWithValue("@population", population);
                //    cmd.Parameters.AddWithValue("@birthdate", birthdate);
                //    cmd.ExecuteNonQuery();
                //}
                using (SqlCommand cmd = new SqlCommand("INSERT INTO City (name, population, birthdate) " +
                    "values('" + name + "', " + population + ", '" + birthdate.ToString("yyyy-MM-dd") + "')", db))
                {                    
                    cmd.ExecuteNonQuery();
                }
                db.Close();
            }
        }

        public static void OutParameter()
        {
            using (SqlConnection db = new SqlConnection(Program.config["db"]))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand("pCity;6", db))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter ctn = new SqlParameter("@cnt", SqlDbType.Int, 10);
                    ctn.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(ctn);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine(ctn.Value);
                }
                db.Close();
            }
        }
    }
}
