using System;
using System.Threading.Tasks;

namespace EventAuditingExample.Domain.Car
{
    public interface ICarRepository
    {
        Car Add(Car car);

        void Update(Car car);

        Task<Car> GetAsync(int carId);
    }
}
