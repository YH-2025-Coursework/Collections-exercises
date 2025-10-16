namespace Collections_exercises.ListsExercise
{
    public class Book
    {
        public string Title;
        public string Author;
        public int YearPublished;

        // Include constructor so it's possible to create and initialize a Book object in a single statement.
        public Book(string title, string author, int yearPublished)
        {
            Title = title;
            Author = author;
            YearPublished = yearPublished;
        }
    }
}
