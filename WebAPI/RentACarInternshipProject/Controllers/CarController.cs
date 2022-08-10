using Microsoft.AspNetCore.Mvc;
using static RentACarInternshipProject.Car;

namespace RentACarInternshipProject.Controllers
{
    [Route("api")]
    public class CarController : ControllerBase
    {
        private static List<Car> cars = new List<Car>();

        static CarController()
        {
            Car[] initialCars = new Car[4];

            initialCars[0] = new Car("Volkswagen", "Passat", 2017, 1.6, BodyStyles.Sedan, "White", FuelTypes.Diesel, TransmissionTypes.Automatic, 120);
            initialCars[1] = new Car("Ford", "Focus", 2020, 1.5, BodyStyles.StationWagon, "White", FuelTypes.Diesel, TransmissionTypes.Automatic, 120);
            initialCars[2] = new Car("Peugeot", "3008", 2022, 1.6, BodyStyles.SUV, "White", FuelTypes.Gasoline, TransmissionTypes.Automatic, 180);
            initialCars[3] = new Car("Renault", "Clio", 2018, 1.2, BodyStyles.Hatchback, "Red", FuelTypes.Gasoline, TransmissionTypes.Manual, 75);

            for (int i = 0; i < initialCars.Length; i++)
            {
                RandomManager.RandomUniqueAssign(initialCars[i].Id, cars, initialCars[i]);
                initialCars[i].Slug = SlugManager.slug(initialCars[i]);
                cars.Add(initialCars[i]);
            }
        }

        [HttpGet("list")]
        public List<Car> ListFilteredCars(string brand, string model, int productionYearMin, int productionYearMax, BodyStyles bodyStyle, FuelTypes fuelType, TransmissionTypes transmission)
        {
            List<Car> filteredResult = new List<Car>(cars);

            if (brand != null)
                filteredResult = filteredResult.FindAll(car => brand.ToLower() == car.Brand.ToLower());

            if (model != null)
                filteredResult = filteredResult.FindAll(car => model.ToLower() == car.Model.ToLower());

            if (productionYearMin != 0)
                filteredResult = filteredResult.FindAll(car => productionYearMin <= car.ProductionYear);

            if (productionYearMax != 0)
                filteredResult = filteredResult.FindAll(car => productionYearMax >= car.ProductionYear);

            if (bodyStyle != 0)
                filteredResult = filteredResult.FindAll(car => bodyStyle == car.BodyStyle);

            if (transmission != 0)
                filteredResult = filteredResult.FindAll(car => transmission == car.Transmission);

            if (fuelType != 0)
                filteredResult = filteredResult.FindAll(car => fuelType == car.FuelType);

            return filteredResult;
        }

        [HttpGet("get/{id}")]
        public IActionResult GetCarById(int id)
        {
            Car car = FindCar(id);

            if (car == null)
                return NotFound("There is no record with the provided ID.");

            return Ok(car);
        }

        [HttpGet("{slug}")]
        public IActionResult GetCarBySlug(string slug)
        {
            Car car = FindCar(slug);

            if (car == null)
                return NotFound("There is no record with the provided slug.");

            return Ok(car);
        }

        [HttpPost("add")]
        public IActionResult AddCar(string brand, string model, int productionYear, double engineDisplacement, BodyStyles bodyStyle, string color, FuelTypes fuelType, TransmissionTypes transmission, double hp)
        {
            if (brand == null || model == null || productionYear < 1900 || productionYear > DateTime.Now.Year || engineDisplacement <= 0 || bodyStyle <= 0 || color == null || fuelType <= 0 || transmission <= 0 || hp < 30)
                return BadRequest("Provided parameters are not valid.");

            Car car = new Car(brand, model, productionYear, engineDisplacement, bodyStyle, color, fuelType, transmission, hp);

            RandomManager.RandomUniqueAssign(car.Id, cars, car);

            cars.Add(car);
            string str = SlugManager.slug(car);
            car.Slug = str;
            return Ok(str);
        }

        [HttpPut("update")]
        public IActionResult UpdateCar(int id, string brand, string model, int productionYear, double engineDisplacement, BodyStyles bodyStyle, string color, FuelTypes fuelType, TransmissionTypes transmission, double hp)
        {
            if (brand == null || model == null || productionYear < 1900 || productionYear > DateTime.Now.Year || engineDisplacement <= 0 || bodyStyle <= 0 || color == null || fuelType <= 0 || transmission <= 0 || hp < 30)
                return BadRequest("Provided parameters are not valid.");

            Car car = FindCar(id);

            if (car == null)
                return NotFound("There is no record with the provided ID.");

            car.Brand = brand;
            car.Model = model;
            car.ProductionYear = productionYear;
            car.EngineDisplacement = engineDisplacement;
            car.BodyStyle = bodyStyle;
            car.Color = color;
            car.FuelType = fuelType;
            car.Transmission = transmission;
            car.HP = hp;

            string str = SlugManager.slug(car);
            car.Slug = str;

            return Ok(car);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteCar(int id)
        {
            Car car = FindCar(id);

            if (car == null)
                return NotFound("There is no record with the provided ID.");

            cars.Remove(car);
            return Ok();
        }

        private Car FindCar(int id)
        {
            return cars.Find(car => id == car.Id);
        }

        private Car FindCar(string slug)
        {
            return cars.Find(car => slug == car.Slug);
        }
    }
}