using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opgave4.Models
{
    public class Car
    {
            public int _Id;
            public string _Model;
            public int _Price;
            public string _LicensePlate;



            public Car(int id, string model, int price, string licensePlate)
            {
                Id = id;
                Model = model;
                Price = price;
                LicensePlate = licensePlate;
            }

            public Car()
            {
                //throw new NotImplementedException();
            }

            public int Id
            {
                get => _Id;
                set => _Id = value;
            }

            public string Model
            {
                get => _Model;
                set
                {
                    if (value.Length < 4) { throw new ArgumentException(); }
                    _Model = value;
                }
            }

            public int Price
            {
                get => _Price;
                set
                {
                    if (value < 0) { throw new ArgumentOutOfRangeException(); }
                    _Price = value;
                }
            }

            public string LicensePlate
            {
                get => _LicensePlate;
                set
                {
                    if (2 <= value.Length && value.Length <= 7) _LicensePlate = value;
                    else throw new ArgumentOutOfRangeException();

                }

            }
        }
    }


