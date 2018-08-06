using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using KucnaKolekcijaKnjiga_VegaIT.Model.Entities;
using KucnaKolekcijaKnjiga_VegaIT.Model.IRepositories;

namespace KucnaKolekcijaKnjiga_VegaIT.Repositories.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private string _connectionString;

        public AuthorRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["BookDBConnectionString"].ConnectionString;
        }

        public List<Author> GetAll()
        {
            List<Author> authors = new List<Author>();
            string selectQueryString = "SELECT a.AuthorId, a.Name, n.NationalityId, n.Nationality FROM Author as a LEFT JOIN Nationality as n ON a.Nationality = n.NationalityId; ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandTimeout = 120;
                command.CommandText = selectQueryString;
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Author author;
                    Nationality nationality;
                    while (reader.Read())
                    {
                        author = new Author();
                        author.Id = Convert.ToInt32(reader[0]);
                        author.Name = reader[1].ToString();

                        if (reader[2] != DBNull.Value && reader[2] != null)
                        {
                            nationality = new Nationality();
                            nationality.Id = Convert.ToInt32(reader[2]);
                            nationality.Name = reader[3].ToString();
                            author.Nationality = nationality;
                        }
                        authors.Add(author);
                    }
                }
            }
            return authors;
        }

        public Author GetById(int id)
        {
            Author author = new Author();
            string selectQueryString = "SELECT a.AuthorId, a.Name, n.NationalityId, n.Nationality FROM Author as a LEFT JOIN Nationality as n ON a.Nationality = n.NationalityId WHERE a.AuthorId = @AuthorId; ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandTimeout = 120;
                command.CommandText = selectQueryString;
                command.Parameters.Add(new SqlParameter("@AuthorId", id));
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        author.Id = Convert.ToInt32(reader[0]);
                        author.Name = reader[1].ToString();

                        if (reader[2] != DBNull.Value && reader[2] != null)
                        {
                            Nationality nationality = new Nationality();
                            nationality.Id = Convert.ToInt32(reader[2]);
                            nationality.Name = reader[3].ToString();
                            author.Nationality = nationality;
                        }
                    }
                }
            }
            return author;
        }

        public void Create(Author entity)
        {
            Author e = entity;
            string insertQueryString = "INSERT INTO Author (Name, Nationality) VALUES (@Name, @Nationality);";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandTimeout = 120;
                command.CommandText = insertQueryString;
                command.Parameters.Add(new SqlParameter("@Name", entity.Name));
                if(entity.Nationality != null)
                    command.Parameters.Add(new SqlParameter("@Nationality", entity.Nationality.Id));
                else
                    command.Parameters.Add(new SqlParameter("@Nationality", DBNull.Value));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update(Author entity)
        {
            Author e = entity;
            string updateQueryString = "UPDATE Author SET Name = @Name, Nationality = @Nationality WHERE AuthorId = @AuthorId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandTimeout = 120;
                command.CommandText = updateQueryString;
                command.Parameters.Add(new SqlParameter("@AuthorId", entity.Id));
                command.Parameters.Add(new SqlParameter("@Name", entity.Name));
                if (entity.Nationality != null)
                    command.Parameters.Add(new SqlParameter("@Nationality", entity.Nationality.Id));
                else
                    command.Parameters.Add(new SqlParameter("@Nationality", DBNull.Value));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string deleteQueryString = "DELETE FROM Author WHERE AuthorId = @AuthorId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandTimeout = 120;
                command.CommandText = deleteQueryString;
                command.Parameters.Add(new SqlParameter("@AuthorId", id));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
