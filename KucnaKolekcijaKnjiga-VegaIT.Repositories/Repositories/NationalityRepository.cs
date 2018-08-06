using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using KucnaKolekcijaKnjiga_VegaIT.Model.Entities;
using KucnaKolekcijaKnjiga_VegaIT.Model.IRepositories;

namespace KucnaKolekcijaKnjiga_VegaIT.Repositories.Repositories
{
    public class NationalityRepository : INationalityRepository
    {
        private string _connectionString;

        public NationalityRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["BookDBConnectionString"].ConnectionString;
        }

        public List<Nationality> GetAll()
        {
            List<Nationality> nationalities = new List<Nationality>();
            string selectQueryString = "SELECT * FROM Nationality;";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandTimeout = 120;
                command.CommandText = selectQueryString;
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Nationality nationality;
                    while (reader.Read())
                    {
                        nationality = new Nationality();
                        nationality.Id = Convert.ToInt32(reader[0]);
                        nationality.Name = reader[1].ToString();
                        nationalities.Add(nationality);
                    }
                }
            }
            return nationalities;
        }

        public Nationality GetById(int id)
        {
            Nationality nationality = new Nationality();
            string selectQueryString = "SELECT * FROM Nationality WHERE NationalityId = @NationalityId;";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandTimeout = 120;
                command.CommandText = selectQueryString;
                command.Parameters.Add(new SqlParameter("@NationalityId", id));
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        nationality.Id = Convert.ToInt32(reader[0]);
                        nationality.Name = reader[1].ToString();
                    }
                }
            }
            return nationality;
        }

        public void Create(Nationality entity)
        {
            string insertQueryString = "INSERT INTO Nationality (Nationality) VALUES (@Nationality);";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandTimeout = 120;
                command.CommandText = insertQueryString;
                command.Parameters.Add(new SqlParameter("@Nationality", entity.Name));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        
        public void Update(Nationality entity)
        {
            string updateQueryString = "UPDATE Nationality SET Nationality = @Nationality WHERE NationalityId = @NationalityId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandTimeout = 120;
                command.CommandText = updateQueryString;
                command.Parameters.Add(new SqlParameter("@NationalityId", entity.Id));
                command.Parameters.Add(new SqlParameter("@Nationality", entity.Name));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string deleteQueryString = "DELETE FROM Nationality WHERE NationalityId = @NationalityId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandTimeout = 120;
                command.CommandText = deleteQueryString;
                command.Parameters.Add(new SqlParameter("@NationalityId", id));
                connection.Open();
                command.ExecuteNonQuery();
            }

        }
    }
}
