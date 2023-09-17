using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ToDoList;

public class Menu
{
    public List<string> menyu = new List<string>();

    public int selection = 0;
    public Menu()
    {
        menyu.Add("All Students");
        menyu.Add("Add Students");
        menyu.Add("Change student's data");
        menyu.Add("Delete Students");
    }
    public void MenuFunction()
    {
        while (true)
        {
            Console.Clear();

            for (int i = 0; i < menyu.Count; i++)
            {
                if (i == selection)
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($@"{this.menyu[i]} {(char)6}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($@"{this.menyu[i]}");
                }
            }
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    Console.ResetColor();
                    selection = this.SelectionLocate(true, ref this.selection);
                    break;
                case ConsoleKey.DownArrow:
                    selection = this.SelectionLocate(false, ref this.selection);
                    break;
                case ConsoleKey.Enter:
                {
                    Console.Clear();
                    switch (this.selection)
                    {
                        case 0:
                            string DBname = "StudentDB";
                            string TableName = "Students";
                            string ConnectionString = "Server=localhost;Trusted_Connection=True;";
                            SqlConnection connection = new SqlConnection(ConnectionString);

                            try
                            {
                                connection.Open(); 

                                SqlCommand checkDatabaseCommand = new SqlCommand(@$"SELECT COUNT(*) FROM sys.databases WHERE name = '{DBname}'", connection);
                                int databaseCount = (int)checkDatabaseCommand.ExecuteScalar();

                                if (databaseCount == 0)
                                {
                                    SqlCommand createDatabaseCommand = new SqlCommand(@$"CREATE DATABASE {DBname};", connection);
                                    createDatabaseCommand.ExecuteNonQuery();
                                    Console.WriteLine(@$"Successfully created '{DBname}' data base.");
                                }
                                connection.Close();
                                ConnectionString = $"Server=localhost;Database={DBname};Trusted_Connection=True;";
                                connection = new SqlConnection(ConnectionString);
                                connection.Open();
                                SqlCommand createTableCommand = new SqlCommand(@$"if not exists (select * from sysobjects where name='{TableName}' and xtype='U')
create table {TableName} (Id int primary key identity, Name varchar(64) not null)", connection);
                                createTableCommand.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            finally
                            {
                                connection.Close();
                            }
                                

                            Console.ReadKey();
                                break;
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                    }

                }
                    break;
                default:
                    break;
            }
        }
    }


    public int SelectionLocate(bool UpDown, ref int Select)
    {
        if (UpDown == true)
        {
            Select = (Select <= 0) ? this.menyu.Count - 1 : Select-=1;
        }
        else
        {
            Select = (Select >= (this.menyu.Count - 1)) ? Select = 0 : Select += 1;
        }
        return Select;
    }
}

