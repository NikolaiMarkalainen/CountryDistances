namespace myTest{
class Program {

    static void Main(string[] args ){
        Coordinates Helsinki = new Coordinates(60.1708, 24.9375);
        Coordinates Amsterdam = new Coordinates(52.3731, 4.8922);
        Coordinates London = new Coordinates(51.5072, -0.1275);
        
        City[] cities = new City[] {
            new City("Helsinki", Helsinki),
            new City("Amsterdam", Amsterdam),
            new City("London", London)
        };
        // Array of cities to run through

        Console.WriteLine("{0,40} {1,20} {2,20}", "Helsinki", "Amsterdam", "London");
        double[,] distances = new double[cities.Length, cities.Length];
        for (int i  = 0; i < cities.Length; i++){
            for(int j = i + 1; j < cities.Length; j++){
                distances[i, j] = cities[i].Location.DistanceTo(cities[j].Location);
                distances[j, i] = distances[i, j];
                // avoiding unnecessary calculations by setting j to start at i + 1;
                // ensuring both matrixes stay the same value [i,j] && [j, i];
            }
        }
        for(int i = 0; i < cities.Length; i++){
            Console.Write("{0,-20}", cities[i].Name);
            // Current city
            for (int j = 0; j < cities.Length; j++){
            // and OTHER city
                Console.Write("{0,20:N2}", distances[i, j]);
            // thousand seperator N2
            }
            Console.WriteLine();
            // linebreak
        }
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