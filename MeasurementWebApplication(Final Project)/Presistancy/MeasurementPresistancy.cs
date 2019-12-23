using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WeatherLibrary;

namespace MeasurementWebApplication_Final_Project_.Presistancy
{
    public class MeasurementPresistancy
    {
        private const string GetAll = "select * from Measurement";

        private const string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PollutionMeasurement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public IEnumerable<Weather> Get()
        {
            List<Weather> weatherList = new List<Weather>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetAll;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Weather item = new Weather();

                                item.SensorName = reader.GetString(1);
                                item.Location = reader.GetString(2);
                                item.Time = reader.GetDateTime(3);
                                item.Temperature = reader.GetDouble(4);
                                item.Pressure = reader.GetDouble(5);
                                item.Humidity = reader.GetDouble(6);


                                weatherList.Add(item);
                            }

                        }
                    }
                }
            }

            return weatherList;
        }

        //For post method
        public void Post(Weather value)
        {

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText =
                            "Insert into Measurement values(@param1,@param2,@param3,@param4,@param5,@param6)";
                        cmd.Parameters.AddWithValue("@param1", value.SensorName);
                        cmd.Parameters.AddWithValue("@param2", value.Location);
                        cmd.Parameters.AddWithValue("@param3", value.Time);
                        cmd.Parameters.AddWithValue("@Param4", value.Temperature);
                        cmd.Parameters.AddWithValue("@param5", value.Pressure);
                        cmd.Parameters.AddWithValue("@param6", value.Humidity);

                        cmd.ExecuteNonQuery();
                    }

                }

            }
        }

        public Weather Delete()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Delete From Measurement";

                        cmd.ExecuteNonQuery();

                    }

                }
            }

            return null;

        }
        //Search by Date

        public Weather GetByTime(DateTime time)
        {
            Weather weather = new Weather();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Select * from Measurement Where Time = @Param";
                        cmd.Parameters.AddWithValue("@Param", time);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                weather.SensorName = reader.GetString(1);
                                weather.Location = reader.GetString(2);
                                weather.Time = reader.GetDateTime(3);
                                weather.Temperature = reader.GetDouble(4);
                                weather.Pressure = reader.GetDouble(5);
                                weather.Humidity = reader.GetDouble(6);

                            }

                        }
                    }
                }
            }

            return weather;
        }
    }
}
