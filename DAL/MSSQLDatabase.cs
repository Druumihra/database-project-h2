using Model;
using System;
using System.Data.SqlClient;

public class MSSQLDatabase : DAL.IDAL
{

    public SqlConnection connection;
    public MSSQLDatabase(string connectionstring)
    {
        this.connection = new SqlConnection(connectionstring);
    }
    private System.Collections.Generic.List<Student> StudentsFromTeacherID(int id)
    {
        string queryString =
             "SELECT ID, Name from Students WHERE FK_Teacher = @Id ";

        SqlCommand command = new SqlCommand(queryString, this.connection);
        command.Parameters.AddWithValue("@Id", id);
        var students = new System.Collections.Generic.List<Student>();

        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Student student = new Student();
                student.Id = (int)reader[0];
                student.Name = reader[1].ToString();
                students.Add(student);
            }
            reader.Close();
            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return students;
    }
    public Teacher TeacherFromID(int id)
    {
        string queryString =
            "SELECT ID, Name from Teachers WHERE ID = @Id ";

        SqlCommand command = new SqlCommand(queryString, this.connection);
        command.Parameters.AddWithValue("@Id", id);

        Teacher teacher = new Teacher();
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                teacher.Id = (int) reader[0];
                teacher.Name = reader[1].ToString();
            }
            reader.Close();
            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        teacher.Students = StudentsFromTeacherID(id);
        
        return teacher;
    }
}