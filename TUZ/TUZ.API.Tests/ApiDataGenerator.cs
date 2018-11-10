using System;
using System.Collections.Generic;
using TUZ.Entities;

namespace TUZ.API.Tests
{
    public class ApiDataGenerator
    {
        private readonly Random _random = new Random();

        public Train GenerateTrain()
        {
            // Init values
            var hourOffset = _random.Next(0, 3);
            var departure = DateTime.Now.AddHours(-hourOffset);
            var arrive = DateTime.Now.AddHours(hourOffset);
            var truckType = (TruckType) _random.Next(0, Enum.GetNames(typeof(TruckType)).Length - 1);
            
            //Result value
            var train = new Train
            {
                Id = _random.Next(100, 1000),
                Departure = departure,
                Arrive = arrive,
                Duration = arrive - departure,
                Trucks = GenerateTrucks(truckType)
            };

            return train;
        }

        private List<Truck> GenerateTrucks(TruckType type)
        {
            var trucks = new List<Truck>();
            for (var i = 0; i < 5; i++)
            {
                var truck = new Truck {Places = new List<Place>()};

                for (var j = 0; j < 50; j++)
                {
                    truck.Places.Add(new Place
                    {
                        Id = j,
                        Reserved = _random.Next(0, 2) == 1
                    });
                }
                trucks.Add(truck);
            }
            return trucks;
        }
    }
}