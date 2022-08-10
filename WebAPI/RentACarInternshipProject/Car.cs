namespace RentACarInternshipProject
{
    public class Car
    {
        public int Id { get; set; }
        public string Slug { get; set; }

        public enum BodyStyles { Sedan = 1, Hatchback, StationWagon, SUV};
        public enum FuelTypes { Gasoline = 1, Diesel };

        public enum TransmissionTypes { Manual = 1, Automatic };

        public string Brand {get;set;}
        public string Model { get;set;}

        public int ProductionYear {get;set;}

        public double EngineDisplacement {get;set;}
        public BodyStyles BodyStyle {get;set;}

        public string Color {get;set;}

        public FuelTypes FuelType { get;set;}

        public TransmissionTypes Transmission { get;set;}

        public double HP {get;set;}

        public Car(string brand, string model, int productionYear, double engineDisplacement, BodyStyles bodyStyle, string color, FuelTypes fuelType, TransmissionTypes transmission, double hp)
        {
            Brand = brand;
            Model = model;
            ProductionYear = productionYear;
            EngineDisplacement = engineDisplacement;
            BodyStyle = bodyStyle;
            Color = color;
            FuelType = fuelType;
            Transmission = transmission;
            HP = hp;
        }
    }
}
