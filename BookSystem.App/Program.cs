using BookSystem.App.Models;
using BookSystem.Lib;
using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace BookSystem.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Helpers.Init("Book System v1.0");

            Book[] books = new Book[0];

            Author[] authors = new Author[0];
             
            int len;
            int id;
            l1:
            Helpers.PrintMenu();
            MenuStates m = Helpers.ReadMenu("Birini secin: ");

            switch (m)
            {
                //show all books
                case MenuStates.BooksAll:
                    Console.WriteLine("List of books...");
                    foreach (var book in books)
                    {
                        Console.WriteLine(book);
                    }
                    goto l1;

                // show books with id
                case MenuStates.BookById:
                    id = Helpers.ReadInt("Kitabin kodu: ", 0);

                    if (id==0)
                    {
                        goto case MenuStates.BooksAll;
                    }

                    var item = books.FirstOrDefault(b=>b.Id==id);

                    if (item != null)
                    {
                        Console.Clear();
                        Helpers.PrintWarning($"Tapildi: {item}");
                        goto l1;
                    }
                   /*
                    foreach (var item in books)
                    {
                        if (item.Id==id)
                        {
                            Console.Clear();
                            Helpers.PrintWarning($"Tapildi: {item}");
                            goto l1;
                        }
                    }
                   */
                    Helpers.PrintError("Kitab tapilmadi");
                    goto case MenuStates.BookById; 


                case MenuStates.BookAdd:
                    len = books.Length;
                    Array.Resize(ref books, len + 1);

                    books[len] = new Book();
                    books[len].Name = Helpers.ReadString("Kitabin adi: ", true);
                    books[len].Author = Helpers.ReadString("Kitabin muellifi: ", true);
                    books[len].PageCount = Helpers.ReadInt("Kitabin sehife sayi: ", 1);
                    books[len].Price = Helpers.ReadDouble("Kitabin qiymeti: ", 0.50);
                    Console.Clear();
                    goto case MenuStates.BooksAll;

                    // book edit
                case MenuStates.BookEdit:

                    id = Helpers.ReadInt("Kitabin kodu: ", 0);

                    if (id == 0)
                    {
                        goto case MenuStates.BooksAll;
                    }

                    var itemByEdit = books.FirstOrDefault(b => b.Id == id);

                    if (itemByEdit != null)
                    {
                        Console.Clear();
                        Helpers.PrintWarning($"Tapildi: {itemByEdit}");

                        string nameByEdit = Helpers.ReadString("Kitabin adi: ");

                        if (!string.IsNullOrWhiteSpace(nameByEdit))
                        {
                            itemByEdit.Name = nameByEdit;
                        }

                        string authorByEdit = Helpers.ReadString("Kitabin muellifi: ");

                        if (!string.IsNullOrWhiteSpace(authorByEdit))
                        {
                            itemByEdit.Author = authorByEdit;
                        }

                        itemByEdit.PageCount = Helpers.ReadInt("Kitabin sehife sayi: ", 1);
                        itemByEdit.Price = Helpers.ReadDouble("Kitabin qiymeti: ", 0.50);
                        goto case MenuStates.BooksAll;
                    }
                    Helpers.PrintError("Kitab tapilmadi");
                    goto case MenuStates.BookEdit;

                    // book remove 

                case MenuStates.BookRemove:

                    id = Helpers.ReadInt("Kitabin kodu: ", 0);

                    if (id == 0)
                    {
                        goto case MenuStates.BooksAll;
                    }
                    var searchByRemove = new Book(id);
                    int indexByRemove = Array.IndexOf(books, searchByRemove);

                    if (indexByRemove == -1)
                    {
                        Helpers.PrintError("Kitab tapilmadi");
                        goto case MenuStates.BookRemove;
                    }
                    for (int i = indexByRemove; i < books.Length-1; i++)
                    {
                        books[i] = books[i + 1];
                    }
                    Array.Resize(ref books, books.Length - 1);
                    goto case MenuStates.BooksAll;


                case MenuStates.AuthorAll:

                    Console.WriteLine("List of authors...");
                    foreach (var author in authors)
                    {
                        Console.WriteLine(author);
                    }
                    goto l1;
                case MenuStates.AuthorById:

                    id = Helpers.ReadInt("Muellifin kodu: ", 0);

                    if (id == 0)
                    {
                        goto case MenuStates.AuthorAll;
                    }

                    var itemAuthor = authors.FirstOrDefault(b => b.Id == id);

                    if (itemAuthor != null)
                    {
                        Console.Clear();
                        Helpers.PrintWarning($"Tapildi: {itemAuthor}");
                        goto l1;
                    }
                    Helpers.PrintError("Muellif tapilmadi");
                    goto case MenuStates.AuthorById;

                case MenuStates.AuthorAdd:

                    len = authors.Length;
                    Array.Resize(ref authors, len + 1);
                    authors[len] = new Author();
                    authors[len].Name = Helpers.ReadString("Muellifin adi: ", true);
                    authors[len].Surname = Helpers.ReadString("Muellifin soyadi: ", true);
                    Console.Clear();
                    goto case MenuStates.AuthorAll;
                    

                   //author edit
                case MenuStates.AuthorEdit:

                    id = Helpers.ReadInt("Muellifin kodu: ", 0);

                    if (id == 0)
                    {
                        goto case MenuStates.AuthorAll;
                    }

                    var itemAuthorByEdit = authors.FirstOrDefault(b => b.Id == id);

                    if (itemAuthorByEdit != null)
                    {
                        Console.Clear();
                        Helpers.PrintWarning($"Tapildi: {itemAuthorByEdit}");

                        string nameAuthorByEdit = Helpers.ReadString("Muellifin adi: ");

                        if (!string.IsNullOrWhiteSpace(nameAuthorByEdit))
                        {
                            itemAuthorByEdit.Name = nameAuthorByEdit;
                        }

                        string surnamAuthorByEdit = Helpers.ReadString("Muellifin soyadi: ");

                        if (!string.IsNullOrWhiteSpace(surnamAuthorByEdit))
                        {
                            itemAuthorByEdit.Surname = surnamAuthorByEdit;
                        }
                        goto case MenuStates.AuthorAll;
                    }
                    Helpers.PrintError("Muellif tapilmadi");
                    goto case MenuStates.AuthorEdit;
                case MenuStates.AuthorRemove:
                    id = Helpers.ReadInt("Muellif kodu: ", 0);

                    if (id == 0)
                    {
                        goto case MenuStates.AuthorAll;
                    }
                    var searchAuthorByRemove = new Author(id);
                    int indexAuthorByRemove = Array.IndexOf(authors, searchAuthorByRemove);

                    if (indexAuthorByRemove == -1)
                    {
                        Helpers.PrintError("Muellif tapilmadi");
                        goto case MenuStates.AuthorRemove;
                    }
                    for (int i = indexAuthorByRemove; i < authors.Length - 1; i++)
                    {
                        authors[i] = authors[i + 1];
                    }
                    Array.Resize(ref authors, authors.Length - 1);
                    goto case MenuStates.AuthorAll;

                case MenuStates.Save:
                    break;
                case MenuStates.Exit:
                    Helpers.PrintError("Tesdiq ucun <Enter> duymesini sixin.Eks halda Menuya qayidacaq.");
                    if (Console.ReadKey().Key==ConsoleKey.Enter)
                    {
                        Environment.Exit(0);
                    }
                    Console.Clear();
                    goto l1;
                default:
                    break;
            }
        }
    }
}
