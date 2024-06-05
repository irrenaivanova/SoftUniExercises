using System;

namespace SoftUniParking;

public class Parking
{
    private List<Car> cars;
    private int capacity;

    public Parking(int value)
    {
        capacity = value;
        cars = new List<Car>();
    }
    public int Count  { get {return cars.Count; } }

    public string AddCar(Car car) 
    {
        if (cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
        {
            return "Car with that registration number, already exists!";
        }
        if (cars.Count == capacity)
        {
            return "Parking is full!";
        }
        cars.Add(car);
        return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
    }
    public string RemoveCar (string registrationNumber)
    {
        if (cars.Any(x => x.RegistrationNumber == registrationNumber))
        {
            cars.Remove(cars.First(x => x.RegistrationNumber == registrationNumber));
            return $"Successfully removed {registrationNumber}";
        }
        else
        {
            return "Car with that registration number, doesn't exist!";
        }
    }
    public Car GetCar(string registrationNumber)
    {
        return cars.First(x=>x.RegistrationNumber==registrationNumber);
    }
    public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
    {
        foreach (string registrationNumber in registrationNumbers) 
        {
            RemoveCar(registrationNumber);
        }
    }
}
