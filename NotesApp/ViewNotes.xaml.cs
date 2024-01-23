using Microsoft.Maui.Controls;

namespace NotesApp
{
    public partial class NoteViewPage : ContentPage
    {
        private Note note;

        public NoteViewPage(Note note)
        {
            InitializeComponent();
            this.note = note;

            BindingContext = this.note;
        }

        private void OnEditClicked(object sender, EventArgs e)
        {
            // Navigate to the NoteEditPage for editing
            Navigation.PushAsync(new NoteEditPage(note));
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            // Ask for confirmation before deleting
            bool deleteConfirmation = await DisplayAlert("Delete Note", "Are you sure you want to delete this note?", "Yes", "No");

            if (deleteConfirmation)
            {
                // Delete the note from the database
                await App.Database.DeleteNoteAsync(note);

                // Navigate back to the main page
                await Navigation.PopAsync();
            }
        }
    }
}
