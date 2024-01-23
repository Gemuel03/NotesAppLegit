using Microsoft.Maui.Controls;

namespace NotesApp
{
    public partial class NoteEditPage : ContentPage
    {
        private Note note;

        public NoteEditPage(Note note)
        {
            InitializeComponent();
            this.note = note;

            TitleEntry.Text = note.Title;
            ContentEditor.Text = note.Content;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            // Update the note with new values
            note.Title = TitleEntry.Text;
            note.Content = ContentEditor.Text;

            // Save the updated note to the database
            await App.Database.SaveNoteAsync(note);

            // Navigate back to the main page
            await Navigation.PopAsync();
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
