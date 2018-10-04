using System;
using System.Threading.Tasks;

namespace EventAuditingExample.Domain.Car
{
    public interface ICarRepository
    {
        Task<Car> AddAsync(Car car);

        void Update(Car car);

        Task<Car> GetAsync(int carId);
    }
}
