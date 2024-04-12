namespace OopsApplication
{
    internal class Program
    {
        static void specialityFind(Doctor[] doctors,String speciality)
        {
            for(int i = 0; i < doctors.Length; i++)
            {
                if (doctors[i].Speciality == speciality)
                {
                    doctors[i].PrintDoctorDetails();
                }
            }
        }

        Doctor CreateNewDoctorUsingConsoleData(int Id)
        {
            Doctor doctor = new Doctor(Id);
            Console.WriteLine($"----------------Enter New Doctor Details----------------");
            Console.WriteLine($"Id : {Id}");
            Console.WriteLine("----------");
            Console.WriteLine("Enter Your Name : ");
            doctor.Name = Console.ReadLine();
            Console.WriteLine("Enter your Experience in Years : ");
            int experience;
            while (!int.TryParse(Console.ReadLine(), out experience))
            {
                Console.WriteLine("Invalid Data, Please provide proper Experience in year : ");
            }
            doctor.Experience = experience;
            Console.WriteLine("Enter your Age in Years : ");
            int age;
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Invalid Data, Please provide proper Experience in year : ");
            }
            doctor.Age = age;
            Console.WriteLine("Enter your Qualification : ");
            doctor.Qualification = Console.ReadLine();
            Console.WriteLine("Enter your Specialization : ");
            doctor.Speciality = Console.ReadLine();
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            return doctor;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Doctor[] doctors = new Doctor[3];
         
            Doctor doctor1 = new Doctor
            {
                Name = "kavin",
                Experience = 2,
                Age = 20,
                Qualification = "MBBS.,M.phil.",
                Speciality = "Cardio"
            };

            for (int ind = 0; ind < doctors.Length; ind++)
            {
                doctors[ind] = program.CreateNewDoctorUsingConsoleData(ind + 1);
            }
            for(int ind = 0;ind < doctors.Length; ind++)
            {
                doctors[ind].PrintDoctorDetails();
            }

            Console.WriteLine("Enter the Speciality Type to Search : ");
            string speciality = Console.ReadLine();
            specialityFind(doctors, speciality);
            Console.WriteLine();
        }
    }
}
