using System;
using System.Collections.Generic;

namespace CarShop.Models
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAll();

        Car Get(int id);

        Car Create(Car car);

        Car Update(Car car);

        Car Delete(int id);

        IEnumerable<Car> Search(int startPrice, int endPrice);

    }
}
