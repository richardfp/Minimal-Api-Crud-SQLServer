using ApiWebCRUDSqlServer.Models;

namespace ApiWebCRUDSqlServer.Repositories
{
    public interface ICarRepository
    {
        IEnumerable<CarModel> GetCars();
        bool InsertCar(CarModel car);
        bool UpdateCarCor(string cor, int id);
        bool DeleteCar(int id);

    }
}
