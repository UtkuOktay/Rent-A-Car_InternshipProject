namespace RentACarInternshipProject;

using System;
using System.Text;

    public static class SlugManager
    {
        public static string slug(Car car)
        {
            var sluggedlink = new StringBuilder();

            foreach (var item in car.Brand)
            {
                if (char.IsLetterOrDigit(item))
                    sluggedlink.Append(item);

                else if (item == ' ')
                    sluggedlink.Append('-');
            }
            
            sluggedlink.Append('-');

            foreach (var item in car.Model)
            {
                if (char.IsLetterOrDigit(item))
                    sluggedlink.Append(item);

                else if (item == ' ')
                sluggedlink.Append('-');
            }

            sluggedlink.Append('-');
            sluggedlink.Append(car.EngineDisplacement);
            sluggedlink.Append('-');
            sluggedlink.Append(car.BodyStyle);
            sluggedlink.Append('-');
            sluggedlink.Append(car.Transmission);
            sluggedlink.Append('-');
            sluggedlink.Append(car.HP);
            sluggedlink.Append('-');
            sluggedlink.Append(car.Id);

            return sluggedlink.ToString().ToLower(); 
        }
    }