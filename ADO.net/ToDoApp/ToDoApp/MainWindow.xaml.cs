using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToDoApp.Entities;
using ToDoApp.Repositories;

namespace ToDoApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private const string connectionString = $"Server=localhost;Database=ToDoListDB;Trusted_Connection=True;";
    private readonly NoteRepository noteRepository;
    public MainWindow()
    {
        InitializeComponent();
        this.noteRepository = new NoteRepository(connectionString);
        this.SetAllUsers();
    }

    private void SetAllUsers()
    {
        var allNotes = this.noteRepository.GetAll();

        this.NotesListView.Items.Clear();

        foreach (var user in allNotes)
        {
            this.NotesListView.Items.Add(user);
        }
    }


    private void CreateUserButton_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(this.NoteTextBox.Text))
        {
            return;
        }

        int pr = 1;
        int st = 1;
        
        var newNote = new Note()
        {
            Name = this.NoteTextBox.Text,
            Priority = Convert.ToString(pr),
            Status = Convert.ToString(st),
        };

        this.noteRepository.Create(newNote);

        this.NoteTextBox.Clear();


        this.SetAllUsers();
    }
}

