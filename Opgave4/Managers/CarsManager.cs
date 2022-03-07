using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Opgave4.Models;

namespace Opgave4.Managers
{
    public class CarsManager
    {
        private static int _nextId = 1;
        private static readonly List<Car> data = new List<Car>()
        {
            new Car {_Id = _nextId++, _Model = "Audi", _Price = 1000000, _LicensePlate = "AB12345" },
            new Car {_Id = _nextId++, _Model = "Skoda", _Price = 100000, _LicensePlate = "BC12345" },
            new Car {_Id = _nextId++, _Model = "Tesla", _Price = 900000, _LicensePlate = "CD12345" },
            new Car {_Id = _nextId++, _Model = "Peugot", _Price = 50000, _LicensePlate = "DE12345" },
        };

        public List<Car> GetAll(string modelFilter, int? priceFilter, string licenseFilter)
        {
            List<Car> result = new List<Car>(data);
            if (!string.IsNullOrWhiteSpace(modelFilter))
            {
                result = result.FindAll(filterCar => filterCar._Model.Contains(modelFilter, StringComparison.OrdinalIgnoreCase));
            }

            if (priceFilter != null)
            {
                result = result.FindAll(filterCar => filterCar._Price <= priceFilter);
            }

            if (!string.IsNullOrWhiteSpace(licenseFilter))
            {
                result = result.FindAll(filterCar => filterCar._LicensePlate.Contains(licenseFilter, StringComparison.OrdinalIgnoreCase));
            }

            return result;
        }

        public Car GetById(int _Id)
        {
            return data.Find(car => car._Id == _Id);
        }

        public Car Add(Car newCar)
        {
            newCar._Id = _nextId++;
            data.Add(newCar);
            return newCar;
        }

        public Car Delete(int _Id)
        {
            Car car = data.Find(car1 => car1._Id == _Id);
            if (car == null) return null;
            data.Remove(car);
            return car;
        }


        //public Car Update(int _Id, Car updates)
        //{
        //    Car car = data.Find(car1 => car1._Id == _Id);
        //    if (car == null) return null;
        //    car._Model = updates._Model;
        //    car._Price = updates._Price;
        //    car._LicensePlate = updates._LicensePlate;
        //    return car;
        //}

    }
}

    