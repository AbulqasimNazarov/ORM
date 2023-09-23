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
        List<Note> notes = new List<Note>();

        using (var command = new SqlCommand(
                   cmdText: @"
            select n.[Id], n.[Name], p.[PriorityName], s.[StatusName]
            from [Notifications] n
            join [Priority] p on n.[Priority] = p.[PriorityId]
            join [Status] s on n.[Status] = s.[StatusId]",
                   this.sqlConnection))
        {
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var note = new Note()
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    Priority = (string)reader["PriorityName"],
                    Status = (string)reader["StatusName"],
                };

                notes.Add(note);
            }

            
            reader.Close();
        }

        return notes;
    }

       

    public bool Create(Note newNote)
    {
        var command = new SqlCommand(
            cmdText: @$"insert into Notifications([Name], [Priority], [Status]) 
                    values(@Name, @Priority, @Status)",
            this.sqlConnection);

        command.Parameters.Add(new SqlParameter("@Name", newNote.Name));
        command.Parameters.Add(new SqlParameter("@Priority", newNote.Priority));
        command.Parameters.Add(new SqlParameter("@Status", newNote.Status));

        return command.ExecuteNonQuery() > 0;
    }


    public bool Delete(int noteId)
    {
        var command = new SqlCommand(
            cmdText: "delete from [Notifications] where [Id] = @NoteId",
            this.sqlConnection);

        command.Parameters.Add(new SqlParameter("@NoteId", noteId));

        return command.ExecuteNonQuery() > 0;
    }

    public bool Save(int noteId)
    {
        var command = new SqlCommand(
            cmdText: "delete from [Notifications] where [Id] = @NoteId",
            this.sqlConnection);

        command.Parameters.Add(new SqlParameter("@NoteId", noteId));

        return command.ExecuteNonQuery() > 0;
    }

    public bool Update(Note updatedNote, string connectionString)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string updateQuery = "UPDATE Notifications SET Name = @Name, Priority = @Priority, Status = @Status WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", updatedNote.Name);
                    command.Parameters.AddWithValue("@Priority", updatedNote.Priority);
                    command.Parameters.AddWithValue("@Status", updatedNote.Status);
                    command.Parameters.AddWithValue("@Id", updatedNote.Id);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }
        catch (Exception ex)
        {
            
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}

