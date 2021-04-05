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
    public class ClassesDataController : ApiController
    {
        //database context class, allows access to mysql database
        private SchooldbContext schooldb = new SchooldbContext();
        /// <summary>
        /// this controller returns a list of classes from the schooldb database
        /// </summary>
        /// <example>GET api/Classesdata</example>
        /// <returns>
        /// A list of classes data: classid, classcode, classname, startdate, finishdate
        /// </returns>

        [HttpGet]
        [Route("api/ClassesData")]
        public IEnumerable<Classes> ListClasses()
        {
            //Create instance of a connection
            MySqlConnection Conn = schooldb.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from classes";

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Classes
            List<Classes> NewClasses = new List<Classes> { };

            //Loop Through Each Row of the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int  ClassId = Convert.ToInt32(ResultSet["classid"]);
                string classcode = ResultSet["classcode"].ToString();
                string classname = ResultSet["classname"].ToString();
                string startdate = ResultSet["startdate"].ToString();
                string finishdate = ResultSet["finishdate"].ToString();
                //assign db data to newcourse object
                Classes NewCourse = new Classes();
                NewCourse.classid = ClassId;
                NewCourse.classcode = classcode;
                NewCourse.classname = classname;
                NewCourse.startdate = startdate;
                NewCourse.finishdate = finishdate;

                //Add the Class data to the list
                NewClasses.Add(NewCourse);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of class data
            return NewClasses;
        }

        /// <summary>
        /// this controller returns class data for a specific class from the schooldb database
        /// </summary>
        /// <example>GET api/findclass/{id}</example>
        /// <returns>
        /// class data: classid, classcode, classname, startdate, finishdate
        /// </returns>
        [HttpGet]
        [Route("api/findclass/{id}")]
        public Classes FindClass(int id)
        {
            //create newcourse object to store class data
            Classes NewCourse = new Classes();

            //Create an instance of a connection
            MySqlConnection Conn = schooldb.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from classes where classid = " + id;

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int ClassId = Convert.ToInt32(ResultSet["classid"]);
                string classcode = ResultSet["classcode"].ToString();
                string classname = ResultSet["classname"].ToString();
                string startdate = ResultSet["startdate"].ToString();
                string finishdate = ResultSet["finishdate"].ToString();
                //assign class data to empty variable
                NewCourse.classid = ClassId;
                NewCourse.classcode = classcode;
                NewCourse.classname = classname;
                NewCourse.startdate = startdate;
                NewCourse.finishdate = finishdate;
            }
            //close database connection
            Conn.Close();
            //return the specific class data for a single class
            return NewCourse;
        }

    }
}

