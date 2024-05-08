using System.Data;

namespace DoctorTrackerModel
{
    public class Doctor
    {


        /// <summary>
        /// Here The Getters and Setters were Implemented for secured data
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }
        public int Experience { get; set; }
        public int Age { get; set; }
        public string Qualification { get; set; }
        public string Speciality { get; set; }

        /// <summary>
        /// Initial constructor consists of default values when empty constructor is called
        /// </summary>
        public Doctor()
        {
            Id = 0;
            Name = string.Empty;
            Age = 0;
            Experience = 0;
            Qualification = string.Empty;
            Speciality = string.Empty;
        }

        /// <summary>
        /// Constructor called when Id alone is defined by the user 
        /// </summary>
        /// <param name="id">Id of Doctor</param>
        public Doctor(int id) { Id = id; }

        /// <summary>
        /// This Constructor is called when all the details about the Doctors were passed through parameters 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="experience"></param>
        /// <param name="age"></param>
        /// <param name="qualification"></param>
        /// <param name="speciality"></param>
        public Doctor(int id, string name, int experience, int age, string qualification, string speciality) : this(id)
        {
            Name = name;
            Experience = experience;
            Age = age;
            Qualification = qualification;
            Speciality = speciality;
        }




        /// <summary>
        /// Function to print the Details of Every Doctors Registered so far.
        /// </summary>
        //public void PrintDoctorDetails()
        //{
        //    Console.WriteLine($"Doctor Id\t \t \t \t:\t{this.Id}");
        //    Console.WriteLine($"Doctor name\t \t \t \t:\t{this.Name}");
        //    Console.WriteLine($"Doctor Qualification\t \t \t:\t{this.Qualification}");
        //    Console.WriteLine($"Doctor Age \t \t \t \t :\t{this.Age}");
        //    Console.WriteLine($"Doctor Experience \t \t \t :\t{this.Experience}");
        //    Console.WriteLine($"Doctor Speciality\t \t \t:\t{this.Speciality}");
        //    Console.WriteLine();
        //    Console.WriteLine();
        //}

        public override string ToString()
        {
            return 
         $@"Doctor Id: {this.Id}
            Doctor name: {this.Name} 
            Doctor Qualification: {this.Qualification}
            Doctor Age :{this.Age} 
            Doctor Experience : {this.Experience} 
            Doctor Speciality:{this.Speciality}";

        }
        public override bool Equals(object? obj)
        {
            Doctor d1, d2;
            d1 = this;
            //d2 = (Doctor)obj;//Casting
            d2 = obj as Doctor;//Casting in a more symanctic way
            return d1.Id.Equals(d2.Id);
        }
        //public static bool operator ==(Doctor a, Doctor b)
        //{
        //    return a.Id == b.Id;

        //}
        //public static bool operator !=(Doctor a, Doctor b)
        //{
        //    return a.Id != b.Id;
        //}
    }
}
