namespace ToDoApp.Repositories;

using ToDoApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;






public class NoteRepository
{
    private SqlConnection sqlConnection;

    public NoteRepository(string connectionString)
    {
        this.sqlConnection = new SqlConnection(connectionString);

        this.sqlConnection.Open();
    }

    public IEnumerable<Note> GetAll()
    {
        List<Note> users = new List<Note>();

        var command = new SqlCommand(
            cmdText: @$"select * from Notifications n
join Status st on n.Id = st.[StatusId]
join Priority pr on n.Id = pr.[PriorityId]",
            this.sqlConnection);

        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var user = new Note()
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                Priority = (string)reader["PriorityName"],
                Status = (string)reader["StatusName"],
            };

            users.Add(user);
            
        }

        return users;
    }

    public bool Create(Note newNote)
    {
           

        var command = new SqlCommand(
            cmdText: @$"insert into Notifications(Name, Priority, Status) 
                        values(@Name, @Priority, @Status)",
            this.sqlConnection);

        command.Parameters.Add(new SqlParameter(nameof(newNote.Name), newNote.Name));
        command.Parameters.Add(new SqlParameter(nameof(newNote.Priority), newNote.Priority));
        command.Parameters.Add(new SqlParameter(nameof(newNote.Status), newNote.Status));

        return command.ExecuteNonQuery() > 0;
    }
}

