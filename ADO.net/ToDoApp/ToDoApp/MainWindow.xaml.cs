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


    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (NotesListView.SelectedItems.Count > 0)
        {
            Note selectedNote = (Note)NotesListView.SelectedItem;
            bool deleted = this.noteRepository.Delete(selectedNote.Id);

            if (deleted)
            {
                this.SetAllUsers();
            }
        }
    }

    private void CreateUserButton_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(this.NoteTextBox.Text))
        {
            return;
        }

        int priorityId;
        if (ImportantCheckBox.IsChecked == true)
        {
            priorityId = 1;
        }
        else if (MiddleCheckBox.IsChecked == true)
        {
            priorityId = 2; 
        }
        else if (NotImportantCheckBox.IsChecked == true)
        {
            priorityId = 3; 
        }
        else
        {
            return;
        }

        int statusId;
        if (this.DoneCHeckBox.IsChecked == true)
        {
            statusId = 1; 
        }
        else if (DoingCheckBox.IsChecked == true)
        {
            statusId = 2; 
        }
        else if (this.WillDOCheckBox.IsChecked == true)
        {
            statusId = 3; 
        }
        else
        {
            return;
        }

        var newNote = new Note()
        {
            Name = this.NoteTextBox.Text,
            Priority = priorityId.ToString(),
            Status = statusId.ToString(),
        };

        this.noteRepository.Create(newNote);

        this.NoteTextBox.Clear();

        this.SetAllUsers();
    }

    private void ImportantCheckBox_Checked(object sender, RoutedEventArgs e)
    {
        MiddleCheckBox.IsChecked = false;
        NotImportantCheckBox.IsChecked = false;
    }

    private void MiddleCheckBox_Checked(object sender, RoutedEventArgs e)
    {
        ImportantCheckBox.IsChecked = false;
        NotImportantCheckBox.IsChecked = false;
    }

    private void NotImportantCheckBox_Checked(object sender, RoutedEventArgs e)
    {
        ImportantCheckBox.IsChecked = false;
        MiddleCheckBox.IsChecked = false;
    }

    private void DoneCheckBox_Checked(object sender, RoutedEventArgs e)
    {
        DoingCheckBox.IsChecked = false;
        this.WillDOCheckBox.IsChecked = false;
    }

    private void DoingCheckBox_Checked(object sender, RoutedEventArgs e)
    {
        this.DoneCHeckBox.IsChecked = false;
        this.WillDOCheckBox.IsChecked = false;
    }

    private void WillDoCheckBox_Checked(object sender, RoutedEventArgs e)
    {
        this.DoneCHeckBox.IsChecked = false;
        DoingCheckBox.IsChecked = false;
    }

    



}

