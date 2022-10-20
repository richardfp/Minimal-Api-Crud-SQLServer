using ApiWebCRUDSqlServer.Factory;
using ApiWebCRUDSqlServer.Models;
using Dapper;
using System.Data;

namespace ApiWebCRUDSqlServer.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly IDbConnection _connection;
        public CarRepository()
        {

            _connection = new SqlFactory().SqlConnection();
        }

        public bool DeleteCar(int id)
        {
            var query = "DELETE FROM [CarDataBase].[dbo].[Cars] WHERE [Id] = @carId";
            var parameters = new { carId = id };
            var result = 0;

            using(_connection)
            {
                result = _connection.Execute(query, parameters);
            }

            return (result != 0 ? true : false);
        }

        public IEnumerable<CarModel> GetCars()
        {
            var cars = new List<CarModel>();
            var query = "SELECT * FROM [CarDataBase].[dbo].[Cars]";

            using(_connection)
            {
                cars = _connection.Query<CarModel>(query).ToList();
            }

            return cars;
        }

        public bool InsertCar(CarModel car)
        {
            var query = @"INSERT INTO [CarDataBase].[dbo].[Cars]
                        VALUES
                        (
                            @modelo,
                            @fabricante,
                            @motor,
                            @cor,                          
                        )";
            var parameters = new
            {
                modelo = car.Modelo,
                fabricante = car.Fabricante,
                motor = car.Motor,
                cor = car.Cor
            };

            int result = 0;

            using(_connection)
            {
                result = _connection.Execute(query, parameters);
            }
            return (result != 0 ? true : false);
        }

        public bool UpdateCarCor(string cor, int id)
        {
            var query =
                @"UPDATE [CarDataBase].[dbo].[Cars]
                SET
                [COR] = @corCarro
                WHERE
                [Id] = @carId";
            var parameters = new
            {
                corCarro = cor,
                carId = id
            };

            int result = 0;

            using(_connection)
            {
                _connection.Execute(query, parameters);
            }

            return (result != 0 ? true : false);
        }
    }
}
