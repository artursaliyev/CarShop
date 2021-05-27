using System;
using System.Collections.Generic;
using System.Linq;

namespace CarShop.Models
{
    public class CarRepository : ICarRepository
    {
        private AppDbContext _dbContext;

        public CarRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IEnumerable<Car> GetAll()
        {
            return _dbContext.Cars;
        }

        public Car Get(int id)
        {
            return _dbContext.Cars.Find(id);
        }


        public Car Create(Car car)
        {
            _dbContext.Cars.Add(car);
            _dbContext.SaveChanges();
            return car;
        }

        public Car Update(Car updateCar)
        {
            var car = _dbContext.Cars.Attach(updateCar);
            car.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();

            return updateCar;
            
        }

        public Car Delete(int id)
        {
            var car = _dbContext.Cars.Find(id);

            if(car != null)
            {
                _dbContext.Cars.Remove(car);
                _dbContext.SaveChanges();
            }

            return car;
        }

        public IEnumerable<Car> Search(int startPrice, int endPrice)
        {
            return _dbContext.Cars
                .Where(car => car.Price >= startPrice)
                .Where(car => car.Price <= endPrice);
        }
    }
}
