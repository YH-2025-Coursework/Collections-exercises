using Spectre.Console;
namespace Collections_exercises.ListsExercise
{
    internal class Lists
    {
        public static void Run()
        {
            // Skapa en konsolapplikation som hanterar en samling böcker.

            // 1. Skapa en klass Bok med egenskaper:
            //    - Titel(string)
            //    - Författare(string)
            //    - YearPublished(int)
            // 2. Skapa en List<Bok> för att lagra böcker.
            // 3. I menyn ska användaren kunna:
            //    - Lägga till en bok(be om titel, författare och årtal).
            //    - Visa alla böcker i samlingen.
            //    - Söka efter en bok genom titel och visa dess detaljer.

            List<Book> books = new List<Book>();

            // Infinite loop to keep the menu running until the user chooses to exit.
            while (true)
            {
                // Display menu and get user choice using Spectre.Console.
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .AddChoices(
                            "Create book",
                            "View books",
                            "Search books",
                            "Exit"
                        ));
                switch (choice)
                {
                    case "Create book":
                        var title = AnsiConsole.Ask<string>("Enter the [yellow]title[/]:");
                        var author = AnsiConsole.Ask<string>("Enter the [yellow]author[/]:");
                        var yearPublished = AnsiConsole.Ask<int>("Enter the [yellow]year published[/]:");
                        books.Add(new Book(title, author, yearPublished));
                        AnsiConsole.MarkupLine("[green]Book added![/]");
                        break;
                    case "View books":
                        if (books.Count == 0)
                        {
                            AnsiConsole.MarkupLine("[red]No books in the collection.[/]");
                        }
                        else
                        {
                            // Using Spectre.Console to create a table for better visualization.
                            var table = new Table();
                            table.AddColumn("Title");
                            table.AddColumn("Author");
                            table.AddColumn("Year Published");
                            foreach (var book in books)
                            {
                                table.AddRow(book.Title, book.Author, book.YearPublished.ToString());
                            }
                            AnsiConsole.Write(table);
                        }
                        break;
                    case "Search books":
                        var searchTitle = AnsiConsole.Ask<string>("Enter the [green]title[/] to search for:");
                        // Case-insensitive search for books with the given title.
                        var foundBooks = books.Where(b => b.Title.Contains(searchTitle, StringComparison.OrdinalIgnoreCase)).ToList();
                        if (foundBooks.Count == 0)
                        {
                            AnsiConsole.MarkupLine("[red]No books found with that title.[/]");
                        }
                        else
                        {
                            foreach (var book in foundBooks)
                            {
                                AnsiConsole.MarkupLine($"[yellow]Title:[/] {book.Title}, [yellow]Author:[/] {book.Author}, [yellow]Year Published:[/] {book.YearPublished}");
                            }
                        }
                        break;
                    case "Exit":
                        return;

                        /*
                        var foundBooks = books.Where(b => b.Title.Contains(searchTitle, StringComparison.OrdinalIgnoreCase)).ToList();

                        Is same as:

                        var foundBooks = books.Where(delegate (Book b)
                        {
                            return b.Title.Contains(searchTitle, StringComparison.OrdinalIgnoreCase);
                        }).ToList();

                        delegate (Book b) is an older C# syntax that came before lambda expressions.
                        delegate introduces an inline method definition.

                        In (Book b):
                            - Book = the type of the parameter.
                            - b = the variable name used inside the method to refer to that parameter.

                        The whole delegate (...) { ... } expression creates a function object
                        compatible with the delegate type expected by Where() — in this case, Func<Book, bool>.

                        b => b.Title.Contains(searchTitle, StringComparison.OrdinalIgnoreCase) can be mentally read as:
                        “For each b (which is a Book), check if b.Title contains searchTitle, ignoring case.”

                        Ordinal in OrdinalIgnoreCase means the comparison is done purely by the binary values (Unicode code points) of characters
                        — it does not use linguistic or culture-specific rules.
                        */
                }
            }
        }
    }
}
