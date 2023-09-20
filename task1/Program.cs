using System.Diagnostics;

class Horse
{
    public enum EType
    {
        Race,
        Draft,
        Pony,
    }

    public UInt16 Age { get; set; }
    public UInt16 Height { get; set; }
    public Boolean IsSavvy { get; set; }
    public EType Type { get; set; }

    public static explicit operator Horse(Car car)
    {
        var horse = new Horse();
        horse.Age = car.Age;
        horse.Height = car.Height;
        horse.IsSavvy = car.IsStudded;
        switch (car.Type)
        {
            case Car.EType.Racing:
                horse.Type = EType.Race;
                break;
            case Car.EType.Truck:
                horse.Type = EType.Draft;
                break;
            case Car.EType.Micro:
                horse.Type = EType.Pony;
                break;
        }
        return horse;
    }

    public static Boolean operator ==(Horse h1, Horse h2)
    {
        return (h1.Age == h2.Age) && (h1.Height == h2.Height) && (h1.Type == h2.Type) && ((h1.IsSavvy && h2.IsSavvy) || !(h1.IsSavvy || h2.IsSavvy));
    }

    public static Boolean operator !=(Horse h1, Horse h2)
    {
        return !(h1 == h2);
    }

    public static Boolean operator <(Horse h1, Horse h2)
    {
        if (h1.Age < h2.Age)
        {
            return true;
        }
        else if (h1.Age > h2.Age)
        {
            return false;
        }

        if (h1.Height < h2.Height)
        {
            return true;
        }
        else if (h1.Height > h2.Height)
        {
            return false;
        }

        if (h1.Type == h2.Type)
        {
            if (h2.IsSavvy)
            {
                return !h1.IsSavvy;
            }
            return false;
        }

        if (h2.Type == EType.Draft)
        {
            return true;
        }
        if (h1.Type == EType.Draft)
        {
            return false;
        }

        if (h2.Type == EType.Race)
        {
            return true;
        }
        if (h1.Type == EType.Race)
        {
            return false;
        }

        return false;
    }

    public static Boolean operator >(Horse h1, Horse h2)
    {

        return h2 < h1;
    }
}

class Car
{
    public enum EType
    {
        Racing,
        Truck,
        Micro
    }

    public UInt16 Age { get; set; }
    public UInt16 Height { get; set; }
    public Boolean IsStudded { get; set; }
    public EType Type { get; set; }


    public static implicit operator Car(Horse horse)
    {
        var car = new Car();
        car.Age = horse.Age;
        car.Height = horse.Height;
        car.IsStudded = horse.IsSavvy;
        switch (horse.Type)
        {
            case Horse.EType.Race:
                car.Type = EType.Racing;
                break;
            case Horse.EType.Draft:
                car.Type = EType.Truck;
                break;
            case Horse.EType.Pony:
                car.Type = EType.Micro;
                break;
        }
        return car;
    }

    public static Boolean operator ==(Car c1, Car c2)
    {
        return (c1.Age == c2.Age) && (c1.Height == c2.Height) && (c1.Type == c2.Type) && ((c1.IsStudded && c2.IsStudded) || !(c1.IsStudded || c2.IsStudded));
    }

    public static Boolean operator !=(Car c1, Car c2)
    {
        return !(c1 == c2);
    }
}

class Task1
{
    static void Main()
    {
        var horse = new Horse();
        horse.Age = 10;
        horse.Height = 150;
        horse.Type = Horse.EType.Race;
        horse.IsSavvy = false;
        Car carFromHorse = horse;

        var car = new Car();
        car.Age = 10;
        car.Height = 150;
        car.Type = Car.EType.Racing;
        car.IsStudded = false;
        var horseFromCar = (Horse)car;

        Debug.Assert(carFromHorse == car);
        Debug.Assert(horseFromCar == horse);

        var horse1 = new Horse();
        horse1.Age = 5;
        horse1.Height = 100;
        horse1.Type = Horse.EType.Pony;
        horse1.IsSavvy = false;
        Debug.Assert(horse1 < horse);

        var horse2 = new Horse();
        horse2.Age = 10;
        horse2.Height = 150;
        horse2.Type = Horse.EType.Draft;
        horse2.IsSavvy = true;
        Debug.Assert(horse < horse2);
        Debug.Assert(horse != horse2);
        Debug.Assert(horse != horse1);
        Console.WriteLine("Success");
    }
}
