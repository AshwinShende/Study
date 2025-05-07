using AbstractFactoryPattern;

public sealed class singletone
{
    public static  singletone singleinstance;
    private static readonly object _object = new object();
    private singletone() {

        lock (_object)
        {
            if (singleinstance == null)
            {
                singleinstance = new singletone();
            }
        
        }
    }
    public void dosomething() {
    
    
    }
}

public sealed class singletone<T> where T: class,new () {
    public static Lazy<T> _singleInstance = new  Lazy<T>(() => new T());
    public static T instance = _singleInstance.Value;
    private singletone() 
    { 
    
    }

}

public interface Ivehicle
{

   public void run();
}

public class car:Ivehicle
{
    public void run()
{ 

}
}

public class bike : Ivehicle
{

    public void run() { }
}

public static class vehicleFactory {
    public static Ivehicle GetVehicleInstance( string type)
    {
        if (type.Equals("car"))
        {
            return new car();
        }
        else
        {
            return new bike();
        }
    
    }

}

public class Programme
{
    public static void main()
    {
        Ivehicle vehicle = vehicleFactory.GetVehicleInstance("car");
         vehicle.run();

    
    }

}


public interface Itable
{
    public void dosome();
}

public interface Ichair
{
    public void dosome();
}

public class victorianchair : Ichair
{
    public void dosome()
    { 
    
    }
}

public class modernchair : Ichair {

    public void dosome() { }

}

public class victoriantable : Itable
{

    public void dosome() { }
}

public class moderntable : Itable
{
    public void dosome() { }

}



public interface Ifurniture
{
    public Itable createtable();

    public Ichair createchair();
}

public class ModernFurniturefactory : Ifurniture
{
    public Itable createtable() {
        return new moderntable();
    }

    public Ichair createchaie()
    {
        return new modernchair();
    }

}
public class VictorianFurniturefactory : Ifurniture
{
    public Itable createtable()
    {
        return new victoriantable();
    }

    public Ichair createchair()
    {
        return new victorianchair();
    }

}

public class Programmesd
{
    public static void main() {

        Ifurniture furniture = new ModernFurniturefactory();
        Itable obj = furniture.createtable();

        obj.dosome();
    }
}

public interface Itext
{
    public void writetext();
}

public class createText: Itext
{

    public string writetext() {

        Console.WriteLine("adadsadsada");
    }

}

public class Decorator : Itext
{

     Itext _text;
    public Decorator(Itext text) { 
        _text=text;

    }

    public void writetext()
    {

        _text.writetext()+"sadsdsad";
    }

}