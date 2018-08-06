using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using KucnaKolekcijaKnjiga_VegaIT.Model.Entities;
using KucnaKolekcijaKnjiga_VegaIT.Model.IRepositories;

namespace KucnaKolekcijaKnjiga_VegaIT.Repositories.Repositories
{
    public class BookRepository : IBookRepository
    {
        private string _connectionString;

        public BookRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["BookDBConnectionString"].ConnectionString;
        }

        public List<Book> GetAll()
        {
            List<Book> books = new List<Book>();
            string selectBookQueryString = "SELECT b.BookId, b.Title, b.ISBN, b.Description, g.GenreId, g.Genre, l.LanguageId, l.Language FROM Book as b LEFT JOIN Genre as g ON b.Genre = g.GenreId LEFT JOIN Language as l ON b.Language = l.LanguageId; ";
            string selectAuthorQueryString = "SELECT a.AuthorId, a.Name, n.NationalityId, n.Nationality FROM Book_Author JOIN Author as a ON Book_Author.Author = a.AuthorId LEFT JOIN Nationality as n ON a.Nationality = n.NationalityId WHERE Book = @BookId; ";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand commandBook = connection.CreateCommand();
                commandBook.CommandTimeout = 120;
                commandBook.CommandText = selectBookQueryString;
                connection.Open();

                using (SqlDataReader reader = commandBook.ExecuteReader())
                {
                    Book book;
                    Genre genre;
                    Language language;

                    while (reader.Read())
                    {
                        book = new Book();
                        book.Id = Convert.ToInt32(reader[0]);
                        book.Title = reader[1].ToString();
                        book.ISBN = reader[2].ToString();
                        book.Description = reader[3].ToString();

                        if (reader[4] != null && reader[4] != DBNull.Value)
                        {
                            genre = new Genre();
                            genre.Id = Convert.ToInt32(reader[4]);
                            genre.Name = reader[5].ToString();
                            book.Genre = genre;
                        }

                        if (reader[6] != null && reader[6] != DBNull.Value)
                        {
                            language = new Language();
                            language.Id = Convert.ToInt32(reader[6]);
                            language.Name = reader[7].ToString();
                            book.Language = language;
                        }
                        books.Add(book);
                    }
                }

                foreach (Book book in books)
                {
                    book.Authors = new List<Author>();
                    SqlCommand commandAuthor = connection.CreateCommand();
                    commandAuthor.CommandTimeout = 120;
                    commandAuthor.CommandText = selectAuthorQueryString;
                    commandAuthor.Parameters.Add(new SqlParameter("@BookId", book.Id));
                    using (SqlDataReader reader = commandAuthor.ExecuteReader())
                    {
                        Author author = new Author();
                        Nationality nationality = new Nationality();
                        while (reader.Read())
                        {
                            author = new Author();
                            author.Id = Convert.ToInt32(reader[0]);
                            author.Name = reader[1].ToString();

                            if (reader[2] != null && reader[2] != DBNull.Value)
                            {
                                nationality = new Nationality();
                                nationality.Id = Convert.ToInt32(reader[2]);
                                nationality.Name = reader[3].ToString();
                                author.Nationality = nationality;
                            }
                            book.Authors.Add(author);
                        }
                    }
                }
            }
            return books;
        }

        public Book GetById(int id)
        {
            Book book = new Book();
            string selectBookQueryString = "SELECT b.BookId, b.Title, b.ISBN, b.Description, g.GenreId, g.Genre, l.LanguageId, l.Language FROM Book as b LEFT JOIN Genre as g ON b.Genre = g.GenreId LEFT JOIN Language as l ON b.Language = l.LanguageId WHERE BookId = @BookId; ";
            string selectAuthorQueryString = "SELECT a.AuthorId, a.Name, n.NationalityId, n.Nationality FROM Book_Author JOIN Author as a ON Book_Author.Author = a.AuthorId LEFT JOIN Nationality as n ON a.Nationality = n.NationalityId WHERE Book = @BookId; ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand commandBook = connection.CreateCommand();
                commandBook.CommandTimeout = 120;
                commandBook.CommandText = selectBookQueryString;
                commandBook.Parameters.Add(new SqlParameter("@BookId", id));
                connection.Open();

                using (SqlDataReader reader = commandBook.ExecuteReader())
                {
                    Genre genre;
                    Language language;

                    while (reader.Read())
                    {
                        book = new Book();
                        book.Id = Convert.ToInt32(reader[0]);
                        book.Title = reader[1].ToString();
                        book.ISBN = reader[2].ToString();
                        book.Description = reader[3].ToString();

                        if (reader[4] != null && reader[4] != DBNull.Value)
                        {
                            genre = new Genre();
                            genre.Id = Convert.ToInt32(reader[4]);
                            genre.Name = reader[5].ToString();
                            book.Genre = genre;
                        }

                        if (reader[6] != null && reader[6] != DBNull.Value)
                        {
                            language = new Language();
                            language.Id = Convert.ToInt32(reader[6]);
                            language.Name = reader[7].ToString();
                            book.Language = language;
                        }
                    }
                }

                SqlCommand commandAuthor = connection.CreateCommand();
                commandAuthor.CommandTimeout = 120;
                commandAuthor.CommandText = selectAuthorQueryString;
                commandAuthor.Parameters.Add(new SqlParameter("@BookId", book.Id));
                using (SqlDataReader reader = commandAuthor.ExecuteReader())
                {
                    Author author = new Author();
                    Nationality nationality = new Nationality();
                    book.Authors = new List<Author>();
                    while (reader.Read())
                    {
                        author = new Author();
                        author.Id = Convert.ToInt32(reader[0]);
                        author.Name = reader[1].ToString();

                        if (reader[2] != null && reader[2] != DBNull.Value)
                        {
                            nationality = new Nationality();
                            nationality.Id = Convert.ToInt32(reader[2]);
                            nationality.Name = reader[3].ToString();
                            author.Nationality = nationality;
                        }
                        book.Authors.Add(author);
                    }
                }
            }
            return book;
        }

        public List<string> GetAllISBNs()
        {
            List<string> isbnList = new List<string>();
            string selectISBNQueryString = "SELECT ISBN FROM Book;";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand commandBook = connection.CreateCommand();
                commandBook.CommandTimeout = 120;
                commandBook.CommandText = selectISBNQueryString;
                connection.Open();

                using (SqlDataReader reader = commandBook.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        isbnList.Add(reader[0].ToString());
                    }
                }
            }
            return isbnList;
        }

        public void Create(Book entity)
        {
            string insertBookQueryString = "INSERT INTO Book (Title, ISBN, Description, Genre, Language) OUTPUT INSERTED.BookId VALUES (@Title, @ISBN, @Description, @Genre, @Language);";
            string insertAuthorQueryString = "INSERT INTO Book_Author (Book, Author) VALUES (@Book, @Author);";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand commandBook = connection.CreateCommand();
                commandBook.CommandTimeout = 120;
                commandBook.CommandText = insertBookQueryString;
                commandBook.Parameters.Add(new SqlParameter("@Title", entity.Title));
                commandBook.Parameters.Add(new SqlParameter("@ISBN", entity.ISBN ?? (object)DBNull.Value));
                commandBook.Parameters.Add(new SqlParameter("@Description", entity.Description ?? (object)DBNull.Value));
                commandBook.Parameters.Add(new SqlParameter("@Language", entity.Language.Id));

                if (entity.Genre != null)
                    commandBook.Parameters.Add(new SqlParameter("@Genre", entity.Genre.Id));
                else
                    commandBook.Parameters.Add(new SqlParameter("@Genre", DBNull.Value));

                connection.Open();
                int id = (int)commandBook.ExecuteScalar();

                SqlCommand commandAuthor = connection.CreateCommand();
                commandAuthor.CommandText = insertAuthorQueryString;
                foreach (Author author in entity.Authors)
                {
                    commandAuthor.Parameters.Add(new SqlParameter("@Book", id));
                    commandAuthor.Parameters.Add(new SqlParameter("@Author", author.Id));
                    commandAuthor.ExecuteNonQuery();
                    commandAuthor.Parameters.Clear();
                }
            }
        }

        public void Update(Book entity)
        {
            Book b = entity;
            string updateBookQueryString = "UPDATE Book SET Title = @Title, ISBN = @ISBN, Description = @Description, Genre = @Genre, Language = @Language WHERE BookId = @BookId;";
            string deleteAuthorQueryString = "DELETE FROM Book_Author WHERE Book = @BookId;";
            string insertAuthorQueryString = "INSERT INTO Book_Author (Book, Author) VALUES (@Book, @Author);";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand commandBook = connection.CreateCommand();
                commandBook.CommandTimeout = 120;
                commandBook.CommandText = updateBookQueryString;
                commandBook.Parameters.Add(new SqlParameter("@BookId", entity.Id));
                commandBook.Parameters.Add(new SqlParameter("@Title", entity.Title));
                commandBook.Parameters.Add(new SqlParameter("@ISBN", entity.ISBN ?? (object)DBNull.Value));
                commandBook.Parameters.Add(new SqlParameter("@Description", entity.Description ?? (object)DBNull.Value));
                commandBook.Parameters.Add(new SqlParameter("@Language", entity.Language.Id));
                if (entity.Genre != null)
                    commandBook.Parameters.Add(new SqlParameter("@Genre", entity.Genre.Id));
                else
                    commandBook.Parameters.Add(new SqlParameter("@Genre", DBNull.Value));

                SqlCommand commandDeleteAuthor = connection.CreateCommand();
                commandDeleteAuthor.CommandTimeout = 120;
                commandDeleteAuthor.CommandText = deleteAuthorQueryString;
                commandDeleteAuthor.Parameters.Add(new SqlParameter("@BookId", entity.Id));

                connection.Open();
                commandDeleteAuthor.ExecuteNonQuery();
                commandBook.ExecuteNonQuery();

                SqlCommand commandInsertAuthor = connection.CreateCommand();
                commandInsertAuthor.CommandTimeout = 120;
                commandInsertAuthor.CommandText = insertAuthorQueryString;
                foreach (Author author in entity.Authors)
                {
                    commandInsertAuthor.Parameters.Add(new SqlParameter("@Book", entity.Id));
                    commandInsertAuthor.Parameters.Add(new SqlParameter("@Author", author.Id));
                    commandInsertAuthor.ExecuteNonQuery();
                    commandInsertAuthor.Parameters.Clear();
                }
            }
        }

        public void Delete(int id)
        {
            string deleteBookAuthorQueryString = "DELETE FROM Book_Author WHERE Book = @BookId;";
            string deleteQueryString = "DELETE FROM Book WHERE BookId = @BookId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand commandBookAuthor = connection.CreateCommand();
                commandBookAuthor.CommandTimeout = 120;
                commandBookAuthor.CommandText = deleteBookAuthorQueryString;
                commandBookAuthor.Parameters.Add(new SqlParameter("@Bookid", id));

                SqlCommand commandBook = connection.CreateCommand();
                commandBook.CommandTimeout = 120;
                commandBook.CommandText = deleteQueryString;
                commandBook.Parameters.Add(new SqlParameter("@BookId", id));

                connection.Open();
                commandBookAuthor.ExecuteNonQuery();
                commandBook.ExecuteNonQuery();
            }
        }
    }
}
