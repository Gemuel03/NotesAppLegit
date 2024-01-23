using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace NotesApp
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Note> notes;

        public MainPage()
        {
            InitializeComponent();
            notes = new ObservableCollection<Note>();
            NotesListView.ItemsSource = notes;
            NotesListView.ItemTapped += OnNoteTapped; // Use ItemTapped event for item selection
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var dbNotes = await App.Database.GetNotesAsync();
            notes.Clear();
            foreach (var note in dbNotes)
            {
                notes.Add(note);
            }
        }

        private void OnAddButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NoteCreationPage(this));
        }

        private void OnNoteTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            // Get the selected note
            Note selectedNote = e.Item as Note;

            // Navigate to the NoteViewPage for viewing
            Navigation.PushAsync(new NoteViewPage(selectedNote));

            // Unselect the item
            ((ListView)sender).SelectedItem = null;
        }


        public async void AddNote(Note note)
        {
            notes.Add(note);
            await App.Database.SaveNoteAsync(note);
        }
    }
}
