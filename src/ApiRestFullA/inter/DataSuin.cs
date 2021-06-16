using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ApiRestFullA.Models;

namespace ApiRestFullA.inter
{
    public class DataSuin
    {
        string con = "";
        public DataSuin() {
            con = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=company;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public int insertCompany(Company c) {
            int r = 0;
            try
            {
                using (SqlConnection cnn = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnn;

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = @"INSERT INTO Company (IdentificationType, Identificationnumber,Companyname ,Firstname,Secondname,Firstlastname,Secondlastname,email) VALUES (@IdentificationType, @Identificationnumber,@Companyname , @Firstname,@Secondname,@Firstlastname,@Secondlastname,@email)";

                    cmd.Parameters.AddWithValue("@IdentificationType", c.IdentificationType);
                    cmd.Parameters.AddWithValue("@Identificationnumber", c.Identificationnumber);
                    cmd.Parameters.AddWithValue("@Companyname", c.Companyname);
                    cmd.Parameters.AddWithValue("@Firstname", c.Firstname);
                    cmd.Parameters.AddWithValue("@Secondname", c.Secondname);
                    cmd.Parameters.AddWithValue("@Firstlastname", c.Firstlastname);
                    cmd.Parameters.AddWithValue("@Secondlastname", c.Secondlastname);
                    cmd.Parameters.AddWithValue("@email", c.email);

                    cnn.Open();

                    r = cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
            catch (Exception e)
            {
                r = -1;
                Console.WriteLine("insertCompany: " + e.Message);
            }
            return r;
        }

        public int updateCompany(Company c) {
            int r = 0;
            try
            {
                using (SqlConnection cnn = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnn;

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = @"UPDATE Company SET IdentificationType=@IdentificationType, 
                    Identificationnumber=@Identificationnumber,
                    Companyname=@Companyname , 
                    Firstname=@Firstname,
                    Secondname=@Secondname,
                    Firstlastname=@Firstlastname,
                    Secondlastname=@Secondlastname,
                    email=@email 
                    WHERE Id=@Id";

                    cmd.Parameters.AddWithValue("@IdentificationType", c.IdentificationType);
                    cmd.Parameters.AddWithValue("@Identificationnumber", c.Identificationnumber);
                    cmd.Parameters.AddWithValue("@Companyname", c.Companyname);
                    cmd.Parameters.AddWithValue("@Firstname", c.Firstname);
                    cmd.Parameters.AddWithValue("@Secondname", c.Secondname);
                    cmd.Parameters.AddWithValue("@Firstlastname", c.Firstlastname);
                    cmd.Parameters.AddWithValue("@Secondlastname", c.Secondlastname);
                    cmd.Parameters.AddWithValue("@email", c.email);
                    cmd.Parameters.AddWithValue("@Id", c.Id);

                    cnn.Open();

                    r = cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
            catch (Exception e)
            {
                r = -1;
                Console.WriteLine("updateCompany: " + e.Message);
            }
            return r;
        }

        public Company getCompany(string identificationnumber) {
            Company c = new Company();
            try
            {
                using (SqlConnection cnn = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnn;

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = @"SELECT Id,IdentificationType, Identificationnumber,Companyname , 
Firstname,Secondname,Firstlastname,Secondlastname,email 
FROM Company WHERE Identificationnumber=@Identificationnumber";

                    cmd.Parameters.AddWithValue("@Identificationnumber", identificationnumber);
                    cnn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        c.Id = reader.GetInt32(0);
                        c.IdentificationType = reader.GetString(1);
                        c.Identificationnumber = reader.GetString(2);
                        c.Companyname = reader.GetString(3);
                        c.Firstname = reader.GetString(4);
                        c.Secondname = reader.GetString(5);
                        c.Firstlastname = reader.GetString(6);
                        c.Secondlastname = reader.GetString(7);
                        c.email = reader.GetString(8);
                    }
                    reader.Dispose();
                    cnn.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("studentAdd: " + e.Message);
            }
            return c;
        }

        public List<Company> getCompanys() {
            List<Company> c = new List<Company>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnn;

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = @"SELECT Id,IdentificationType, Identificationnumber,Companyname , 
Firstname,Secondname,Firstlastname,Secondlastname,email 
FROM Company";
                    
                    cnn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Company cs = new Company();
                        cs.Id = reader.GetInt32(0);
                        cs.IdentificationType = reader.GetString(1);
                        cs.Identificationnumber = reader.GetString(2);
                        cs.Companyname = reader.GetString(3);
                        cs.Firstname = reader.GetString(4);
                        cs.Secondname = reader.GetString(5);
                        cs.Firstlastname = reader.GetString(6);
                        cs.Secondlastname = reader.GetString(7);
                        cs.email = reader.GetString(8);
                        c.Add(cs);
                    }
                    reader.Dispose();
                    cnn.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("getCompanys: " + e.Message);
            }
            return c;
        }
    }

    
}
