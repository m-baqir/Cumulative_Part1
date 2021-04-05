using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CumulativePart1.Models;
using MySql.Data.MySqlClient;

namespace CumulativePart1.Controllers
{
    public class StudentDataController : ApiController
    {
        //database context class, allows access to mysql database
        private SchooldbContext schooldb = new SchooldbContext();
        /// <summary>
        /// this controller returns a list of students from the schooldb database
        /// </summary>
        /// <example>GET api/studentdata</example>
        /// <returns>
        /// A list of student data: studentid, student first name, student last name, enrol date
        /// </returns>
        [HttpGet]
        [Route("api/StudentData")]
        public IEnumerable<Student> ListStudents()
        {
            //Create an instance of a connection
            MySqlConnection Conn = schooldb.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from students";

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Students
            List<Student> Students = new List<Student> { };

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int StudentId = Convert.ToInt32(ResultSet["studentid"]);
                string StudentFname = ResultSet["studentfname"].ToString();
                string StudentLname = ResultSet["studentlname"].ToString();
                string enrolDate = ResultSet["enroldate"].ToString();

                //assign student data to NewStudent object
                Student NewStudent = new Student();
                NewStudent.studentid = StudentId;
                NewStudent.studentfname = StudentFname;
                NewStudent.studentlname = StudentLname;
                NewStudent.enroldate = enrolDate;

                //Add the student data to the List
                Students.Add(NewStudent);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of student data
            return Students;
        }
        /// <summary>
        /// this controller returns data for a specific student from the schooldb database
        /// </summary>
        /// <example>GET api/findstudent/{id}</example>
        /// <returns>
        /// A student data: studentid, student first name, student last name, enrol date
        /// </returns>
        [HttpGet]
        [Route("api/findstudent/{id}")]
        public Student FindStudent(int id)
        {
            //create an empty variable to store student data
            Student NewStudent = new Student();

            //Create an instance of a connection
            MySqlConnection Conn = schooldb.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from students where studentid = " + id;

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int studentid = Convert.ToInt32(ResultSet["studentid"]);
                string studentfname = ResultSet["studentfname"].ToString();
                string studentlname = ResultSet["studentlname"].ToString();
                string enroldate = ResultSet["enroldate"].ToString();
                //assign data to newstudent object
                NewStudent.studentid = studentid;
                NewStudent.studentfname = studentfname;
                NewStudent.studentlname = studentlname;
                NewStudent.enroldate = enroldate;
            }
            //close database connection
            Conn.Close();
            //return specific student data
            return NewStudent;
        }

    }
}

