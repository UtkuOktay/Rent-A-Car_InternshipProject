namespace RentACarInternshipProject
{
    public class RandomManager
    {
        public static void RandomUniqueAssign(int random, List<Car> cars,Car car)
        {
            Random rnd = new Random();
            car.Id = rnd.Next(10000, 99000);
            foreach (var item in cars)
            {
                if ( car.Id==item.Id )
                    RandomUniqueAssign(item.Id, cars,car);
            }
        }
    }
}
