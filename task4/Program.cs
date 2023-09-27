class Hamster : IComparable<Hamster>, IComparable
{
    public enum EHairColor
    {
        Black,
        White,
        Gray
    }

    public enum EHairType
    {
        Long,
        Short
    }

    public static Boolean operator ==(Hamster l, Hamster r)
    {
        return (l.HairColor == r.HairColor) && (l.HairType == r.HairType) && (l.Weight == r.Weight) && (l.Height == r.Height) && (l.Age == r.Age);
    }

    public static Boolean operator !=(Hamster l, Hamster r)
    {
        return !(l == r);
    }

    public static Boolean operator <(Hamster l, Hamster r)
    {
        if (l.HairColor != r.HairColor)
        {
            if (r.HairColor == EHairColor.Black)
            {
                return true;
            }
            if (l.HairColor == EHairColor.Black)
            {
                return false;
            }
            return r.HairColor == EHairColor.White;
        }

        if (l.HairType != r.HairType)
        {
            return r.HairType == EHairType.Long;
        }

        if (l.Weight != r.Weight)
        {
            return l.Weight < r.Weight;
        }

        if (l.Height != r.Height)
        {
            return l.Height < r.Height;
        }

        if (l.Age != r.Age)
        {
            return l.Age < r.Age;
        }

        return false;
    }

    public static Boolean operator >(Hamster l, Hamster r)
    {
        return (r < l) && (l != r);
    }

    public Int32 CompareTo(Object? other)
    {
        if (other == null)
        {
            return -1;
        }
        return this.CompareTo((Hamster)other);
    }

    public Int32 CompareTo(Hamster? other)
    {
        if (other is null)
        {
            return -1;
        }
        if (other == this)
        {
            return 0;
        }
        if (other < this)
        {
            return -1;
        }
        return 1;
    }

    public override string ToString()
    {
        return HairColor.ToString() + ',' + HairType + ',' + Weight + ',' + Height + ',' + Age + ';';
    }

    public EHairColor HairColor { get; set; }
    public EHairType HairType { get; set; }
    public Int32 Weight { get; set; }
    public Int32 Height { get; set; }
    public Int32 Age { get; set; }
}

class Task4
{
    static void Main()
    {
        var hamsters = new List<Hamster>(3);
        var h1 = new Hamster();
        h1.Age = 2;
        h1.Height = 20;
        h1.Weight = 120;
        h1.HairType = Hamster.EHairType.Short;
        h1.HairColor = Hamster.EHairColor.White;
        hamsters.Add(h1);
        var h2 = new Hamster();
        h2.Age = 1;
        h2.Height = 18;
        h2.Weight = 100;
        h2.HairType = Hamster.EHairType.Long;
        h2.HairColor = Hamster.EHairColor.Black;
        hamsters.Add(h2);
        var h3 = new Hamster();
        h3.Age = 3;
        h3.Height = 22;
        h3.Weight = 150;
        h3.HairType = Hamster.EHairType.Long;
        h3.HairColor = Hamster.EHairColor.Black;
        hamsters.Add(h3);
        foreach (var hamster in hamsters)
        {
            System.Console.WriteLine(hamster);
        }
        hamsters.Sort();
        foreach (var hamster in hamsters)
        {
            System.Console.WriteLine(hamster);
        }
    }
}
