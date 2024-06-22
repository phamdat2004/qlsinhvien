using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentsManagement.Models
{
    public class Student
    {
        public int ID { set; get; }
        [Required(ErrorMessage ="Mời nhập họ và tên sinh viên")]
        [Display(Name = "Họ và tên:")]
        public string FullName { set; get; }
        [Required(ErrorMessage = "Mời nhập địa chỉ")]
        [Display(Name = "Địa chỉ:")]
        public string Address { set; get; }
    }
    class StudentList
    {
        DBConnection db;
        public StudentList()
        {
            db = new DBConnection();
        }
        public List<Student> getStudent(string ID)
        {
            string sql;
            if (string.IsNullOrEmpty(ID))
                sql = "SELECT * FROM Students";
            else
                sql = "SELECT * FROM Students WHERE Id = " + ID;
            List<Student> stuList = new List<Student>();
            DataTable dt = new DataTable();
            SqlConnection con = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open();
            da.Fill(dt);
            da.Dispose();
            con.Close();
            Student tmpStu;
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                tmpStu = new Student();
                tmpStu.ID = Convert.ToInt32(dt.Rows[i]["ID"].ToString());
                tmpStu.FullName = dt.Rows[i]["Fullname"].ToString();
                tmpStu.Address = dt.Rows[i]["Address"].ToString();
                stuList.Add(tmpStu);
            }
            return stuList;
        }
        public void AddStudent(Student stu)
        {
            string sql = "INSERT INTO Students(fullname, address) VALUES(N'" + stu.FullName +
                          "', N'" + stu.Address + "')";
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void UpdateStudent(Student stu)
        {
            string sql = "UPDATE Students SET Fullname = N'" + stu.FullName + "', Address = N'" +
                          stu.Address + "' WHERE ID = " + stu.ID;
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void DeleteStudent(Student stu)
        {
            string sql = "DELETE Students WHERE ID = " + stu.ID;
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
    }
}