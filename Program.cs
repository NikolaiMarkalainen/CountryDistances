namespace myTest{
class Program {

    static void Main(string[] args ){
        Coordinates Helsinki = new Coordinates(60.1708, 24.9375);
        Coordinates Amsterdam = new Coordinates(52.3731, 4.8922);
        Coordinates London = new Coordinates(51.5072, -0.1275);
        double distance = Helsinki.DistanceTo(Amsterdam);
        Console.WriteLine("The distance between Helsinki and Amsterdam is: " + distance);
        distance = Amsterdam.DistanceTo(London);
        Console.WriteLine("The distance between Amsterdam and London is: " + distance);
        
        
        City helsinki = new City("Helsinki",Helsinki);
        City amsterdam = new City("Amsterdam" , Amsterdam);
        City london = new City("London", London);
        distance = helsinki.DistanceTo(amsterdam);
        Console.WriteLine("The distance between Amsterdam and Helsinki is: " + distance);
        distance = amsterdam.DistanceTo(london);
        Console.WriteLine("The distance between Amsterdam and London is: " + distance);
        Console.WriteLine("{0,20} {1,20} {2, 20}\n {0,-20} \n {1,-20} \n {2,-20}", "Helsinki", "Amsterdam", "London");

    }
}

public class City  {
    public String Name;
    public Coordinates Location;
    public override string ToString(){
        return string.Format("{0} @ {1}", Name, Location);
    }
    public City (String Name, Coordinates Location) {
        this.Location = Location;
        this.Name = Name;
    }

    public double DistanceTo(City other){
        return Location.DistanceTo(other.Location);
    }
    }



public class Coordinates{
    public double Latitude;
    public double Longitude;

    public override string ToString(){
        return string.Format("{0},{1}", Latitude, Longitude);
    }
    static double DegreesToRadians(double degrees){
        return (Math.PI / 180) * degrees;
    }
    public Coordinates (double Latitude, double Longitude){
        this.Latitude = Latitude;
        this.Longitude = Longitude;
    }

    public double DistanceTo(Coordinates other){
        const double EarthEquatorialRadius = 6378.1370; // km
        double lat1 = DegreesToRadians(this.Latitude);
        double lon1 = DegreesToRadians(this.Longitude);
        double lat2 = DegreesToRadians(other.Latitude);
        double lon2 = DegreesToRadians(other.Longitude);
        double dlon = lon2 - lon1;
        double dlat = lat2 - lat1;
        double a = Math.Pow(Math.Sin(dlat / 2), 2)
        + Math.Cos(lat1) * Math.Cos(lat2)
        * Math.Pow(Math.Sin(dlon / 2), 2);
        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        return EarthEquatorialRadius * c;
        }
}
}

/*

        City[] cities = new City[]{
            new City("Helsinki", Helsinki);
            new City("Amsterdam", Amsterdam);
            new City("London", London);
        }
        
*/