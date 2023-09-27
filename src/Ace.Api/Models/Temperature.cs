namespace Tcraft.Ace.Api.Models
{
    public class Temperature
    {
        public double Kelvin { get; set; }
        public double Celsius { get; set; }

        public Temperature(double kelvin, double celsius)
        {
            Kelvin = kelvin;
            Celsius = celsius;
        }

        public static Temperature FromCelsius(double celsius)
        {
            var kelvin = celsius + 273.15;
            return new Temperature(kelvin, celsius);
        }

        public static Temperature FromKelvin(double kelvin)
        {
            var celsius = kelvin - 273.15;
            return new Temperature(kelvin, celsius);
        }

    }
}
