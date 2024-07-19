using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using task_2._0.Models;

namespace task_2._0.Models
{
    public class Repository
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
        public void Register(Register r)
        {
            SqlCommand cmd = new SqlCommand("proc_insert_TB_Hostel", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", r.Id);
            cmd.Parameters.AddWithValue("@Name", r.Name);
            cmd.Parameters.AddWithValue("@Password", r.Password);
            cmd.Parameters.AddWithValue("@MobileNo", r.Phone);
            cmd.Parameters.AddWithValue("@Email", r.Email);
            cmd.Parameters.AddWithValue("@CountryId", r.CountryId);
            cmd.Parameters.AddWithValue("@Gender", r.Gender);
            cmd.Parameters.AddWithValue("@Hobbies", r.Hobbies);
            cmd.Parameters.AddWithValue("@DateOfBirth", r.DateOfBirth);
          //  cmd.Parameters.AddWithValue("@IsActive", r.IsActive);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            
        }
        public bool CheckUserExists( string mobileNo, string email)
        {
           
                SqlCommand cmd = new SqlCommand("spCheckUserExists1d", con);
                cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.Parameters.AddWithValue("@MobileNo", mobileNo);
                cmd.Parameters.AddWithValue("@Email", email);

                con.Open();
                int count = (int)cmd.ExecuteScalar();
            con.Close();

                return count > 0;
            
        }
        public bool CheckMobileExists(string Phone)
        {

            SqlCommand cmd = new SqlCommand("proc_checkMobileno", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@UserName", userName);
            cmd.Parameters.AddWithValue("@MobileNo", Phone);
           // cmd.Parameters.AddWithValue("@Email", email);

            con.Open();
            int count = (int)cmd.ExecuteScalar();
            con.Close();

            return count > 0;

        }

        public bool CheckEmailExists(string email)
        {

            SqlCommand cmd = new SqlCommand("proc_checkEmail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@UserName", userName);
           // cmd.Parameters.AddWithValue("@MobileNo", mobileNo);
            cmd.Parameters.AddWithValue("@Email", email);

            con.Open();
            int count = (int)cmd.ExecuteScalar();
            con.Close();

            return count > 0;

        }

        public bool LoginStudent(string Email,string Password)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("proc_Login_Student1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Password", Password);
            con.Open();
            flag = Convert.ToBoolean(cmd.ExecuteScalar());
            con.Close();

            return flag;
        }
        public bool LoginAdmin(string Email, string Password)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("proc_TB_Admin101", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Password", Password);
            con.Open();
            flag = Convert.ToBoolean(cmd.ExecuteScalar());
            con.Close();

            return flag;
        }
        public List<Register> GetDetails(int id)
        {
            List<Register> obj = new List<Register>();
            //string QUERY = " SELECT EMPLOYEEID,EMPLOYEENAME,DESIGNATION,GENDER FROM EMPLOYEE where employeeid=EmpId";
            SqlCommand cmd = new SqlCommand("proc_GETDETAILS_id", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            //// cmd.Parameters.AddWithValue("@IsActive",r. IsActive);
            //cmd.Parameters.AddWithValue("@Email", r.Email);
            //cmd.Parameters.AddWithValue("@Password", r.Password);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                obj.Add(new Register
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = Convert.ToString(dr["Name"]),
                    Password = Convert.ToString(dr["Password"]),
                    Phone = Convert.ToString(dr["MobileNo"]),
                    Email = Convert.ToString(dr["Email"]),
                    CountryId = Convert.ToString(dr["CountryId"]),

                    Gender = Convert.ToString(dr["Gender"]),
                    Hobbies = Convert.ToString(dr["Hobbies"]),
                    DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"])

                }); ;
            }
            return obj;
        }

        public List<Register> GetDetails()
        {
            List<Register> obj = new List<Register>();
            //string QUERY = " SELECT EMPLOYEEID,EMPLOYEENAME,DESIGNATION,GENDER FROM EMPLOYEE where employeeid=EmpId";
            SqlCommand cmd = new SqlCommand("pro_SELECT_STUDENT110", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Id", r.Id);
            //// cmd.Parameters.AddWithValue("@IsActive",r. IsActive);
            //cmd.Parameters.AddWithValue("@Email", r.Email);
            //cmd.Parameters.AddWithValue("@Password", r.Password);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                obj.Add(new Register
                {
                    Id=Convert.ToInt32(dr["Id"]),
                    Name = Convert.ToString(dr["Name"]),
                    Password = Convert.ToString(dr["Password"]),
                    Phone = Convert.ToString(dr["MobileNo"]),
                    Email = Convert.ToString(dr["Email"]),
                    CountryId = Convert.ToString(dr["CountryId"]),

                    Gender = Convert.ToString(dr["Gender"]),
                    Hobbies = Convert.ToString(dr["Hobbies"]),
                    DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"])

                }); ;
            }
            return obj;
        }
        //public List<Profile> prof(Profile p1)
        //{

        //}
        public List<Register> Details(Register r)
        {
            List<Register> obj = new List<Register>();
            
            SqlCommand cmd = new SqlCommand("pro_SELECT_STUDENT11h", con);
            cmd.CommandType = CommandType.StoredProcedure;
           // cmd.Parameters.AddWithValue("@Id", r.Id);
          // cmd.Parameters.AddWithValue("@IsActive",r. IsActive);
            cmd.Parameters.AddWithValue("@Email", r.Email);
            cmd.Parameters.AddWithValue("@Password", r.Password);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                obj.Add(new Register
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = Convert.ToString(dr["Name"]),
                    Password = Convert.ToString(dr["Password"]),
                    Phone = Convert.ToString(dr["MobileNo"]),
                    Email = Convert.ToString(dr["Email"]),
                    CountryId = Convert.ToString(dr["CountryId"]),

                    Gender = Convert.ToString(dr["Gender"]),
                    Hobbies = Convert.ToString(dr["Hobbies"]),
                    DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"])

                }); ;
            }
            return obj;
        }
      
        public void Edit(Register r)
        {
            SqlCommand cmd = new SqlCommand("proc_Update_Student111", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", r.Id);
            cmd.Parameters.AddWithValue("@Name", r.Name);
         //  cmd.Parameters.AddWithValue("@Password", r.Password);
            cmd.Parameters.AddWithValue("@MobileNo", r.Phone);
            cmd.Parameters.AddWithValue("@Email", r.Email);
            cmd.Parameters.AddWithValue("@CountryId", r.CountryId);
            cmd.Parameters.AddWithValue("@Gender", r.Gender);
            cmd.Parameters.AddWithValue("@Hobbies", r.Hobbies);
            cmd.Parameters.AddWithValue("@DateOfBirth", r.DateOfBirth);
          //  cmd.Parameters.AddWithValue("@IsActive", r.IsActive);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void SEdit(Register r)
        {
            SqlCommand cmd = new SqlCommand("proc_Update_Student1B", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", r.Id);
            cmd.Parameters.AddWithValue("@Name", r.Name);
            cmd.Parameters.AddWithValue("@Password", r.Password);
            cmd.Parameters.AddWithValue("@MobileNo", r.Phone);
            cmd.Parameters.AddWithValue("@Email", r.Email);
            cmd.Parameters.AddWithValue("@CountryId", r.CountryId);
            cmd.Parameters.AddWithValue("@Gender", r.Gender);
            cmd.Parameters.AddWithValue("@Hobbies", r.Hobbies);
            cmd.Parameters.AddWithValue("@DateOfBirth", r.DateOfBirth);
           // cmd.Parameters.AddWithValue("@IsActive", r.IsActive);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("DeleteUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }


    }
}