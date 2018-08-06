using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using KucnaKolekcijaKnjiga_VegaIT.Model.Entities;
using KucnaKolekcijaKnjiga_VegaIT.Model.IRepositories;

namespace KucnaKolekcijaKnjiga_VegaIT.Repositories.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private string _connectionString;

        public GenreRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["BookDBConnectionString"].ConnectionString;
        }

        public List<Genre> GetAll()
        {
            List<Genre> genres = new List<Genre>();
            string selectQueryString = "SELECT * FROM Genre;";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandTimeout = 120;
                command.CommandText = selectQueryString;
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Genre genre;
                    while (reader.Read())
                    {
                        genre = new Genre();
                        genre.Id = Convert.ToInt32(reader[0]);
                        genre.Name = reader[1].ToString();
                        genres.Add(genre);
                    }
                }
            }
            return genres;
        }

        public Genre GetById(int id)
        {
            Genre genre = new Genre();
            string selectQueryString = "SELECT * FROM Genre;";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandTimeout = 120;
                command.CommandText = selectQueryString;
                command.Parameters.Add(new SqlParameter("@GenreId", id));
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        genre.Id = Convert.ToInt32(reader[0]);
                        genre.Name = reader[1].ToString();
                    }
                }
            }
            return genre;
        }

        public void Update(Genre entity)
        {
            string updateQueryString = "UPDATE Genre SET Genre = @Genre WHERE GenreId = @GenreId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandTimeout = 120;
                command.CommandText = updateQueryString;
                command.Parameters.Add(new SqlParameter("@GenreId", entity.Id));
                command.Parameters.Add(new SqlParameter("@Genre", entity.Name));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Create(Genre entity)
        {
            string insertQueryString = "INSERT INTO Genre (Genre) VALUES (@Genre);";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandTimeout = 120;
                command.CommandText = insertQueryString;
                command.Parameters.Add(new SqlParameter("@Genre", entity.Name));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string deleteQueryString = "DELETE FROM Genre WHERE GenreId = @GenreId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandTimeout = 120;
                command.CommandText = deleteQueryString;
                command.Parameters.Add(new SqlParameter("@GenreId", id));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
