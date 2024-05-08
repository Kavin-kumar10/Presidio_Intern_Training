using SampleEFApp.Model;

namespace SampleEFApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            dbEmployeeTrackerContext context = new dbEmployeeTrackerContext();

            //Read
            //var Areas = context.Areas.ToList();
            //foreach ( var area in Areas ) { Console.WriteLine(area.Area1+" "+area.Zipcode); }

            // Add new data
            //Area area = new Area();
            //area.Area1 = "POPO";
            //area.Zipcode = "44332";
            //context.Areas.Add(area);
            //context.SaveChanges();


            var areas = context.Areas.ToList();
            var area = areas.SingleOrDefault(a => a.Area1 == "POPO");
            area.Zipcode = "00000";
            context.Areas.Update(area);
            context.SaveChanges();

            area = areas.SingleOrDefault(a => a.Area1 == "YYYY");
            context.Areas.Remove(area);
            context.SaveChanges();
            foreach (var a in areas)
            {
                Console.WriteLine(a.Area1 + " " + a.Zipcode);
            }

        }
    }
}
