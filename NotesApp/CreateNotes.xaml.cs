using Microsoft.Maui.Controls;

namespace NotesApp
{
    public partial class NoteCreationPage : ContentPage
    {
        MainPage mainPage;

        public NoteCreationPage(MainPage mainPage)
        {
            InitializeComponent();
            this.mainPage = mainPage;
        }

        private void OnSaveClicked(object sender, EventArgs e)
        {
            // Handle the save logic here
            string title = TitleEntry.Text;
            string content = ContentEditor.Text;

            // Save the note or perform any other necessary actions
            Note newNote = new Note { Title = title, Content = content };

            // Add the new note to the MainPage's ObservableCollection
            mainPage.AddNote(newNote);

            // Navigate back to the main page
            Navigation.PopAsync();
        }
    }
}
