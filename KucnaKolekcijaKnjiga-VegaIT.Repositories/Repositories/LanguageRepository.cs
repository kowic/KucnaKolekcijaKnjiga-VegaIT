using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using KucnaKolekcijaKnjiga_VegaIT.Model.Entities;
using KucnaKolekcijaKnjiga_VegaIT.Model.IRepositories;

namespace KucnaKolekcijaKnjiga_VegaIT.Repositories.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        private string _connectionString;

        public LanguageRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["BookDBConnectionString"].ConnectionString;
        }

        public List<Language> GetAll()
        {
            List<Language> languages = new List<Language>();
            string selectQueryString = "SELECT * FROM Language;";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandTimeout = 120;
                command.CommandText = selectQueryString;
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Language language;
                    while (reader.Read())
                    {
                        language = new Language();
                        language.Id = Convert.ToInt32(reader[0]);
                        language.Name = reader[1].ToString();
                        languages.Add(language);
                    }
                }
            }
            return languages;
        }

        public Language GetById(int id)
        {
            Language language = new Language();
            string selectQueryString = "SELECT * FROM Language WHERE LanguageId = @LanguageId;";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandTimeout = 120;
                command.CommandText = selectQueryString;
                command.Parameters.Add(new SqlParameter("@LanguageId", id));
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        language.Id = Convert.ToInt32(reader[0]);
                        language.Name = reader[1].ToString();
                    }
                }
            }
            return language;
        }

        public void Create(Language entity)
        {
            string insertQueryString = "INSERT INTO Language (Language) VALUES (@Language);";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandTimeout = 120;
                command.CommandText = insertQueryString;
                command.Parameters.Add(new SqlParameter("@Language", entity.Name));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update(Language entity)
        {
            string updateQueryString = "UPDATE Language SET Language = @Language WHERE LanguageId = @LanguageId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandTimeout = 120;
                command.CommandText = updateQueryString;
                command.Parameters.Add(new SqlParameter("@LanguageId", entity.Id));
                command.Parameters.Add(new SqlParameter("@Language", entity.Name));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string deleteQueryString = "DELETE FROM Language WHERE LanguageId = @LanguageId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandTimeout = 120;
                command.CommandText = deleteQueryString;
                command.Parameters.Add(new SqlParameter("@LanguageId", id));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
