namespace RequestTrackerAPIApp.Modals
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public string Role { get; set; }

        public override string ToString()
        {
            return Id + " " + Name + " " + Role;
        }

        public ICollection<Request> RequestsRaised { get; set; }//No effect on the table
        public ICollection<Request> RequestsClosed { get; set; }//No effect on the table

        //For later use 

        //public ICollection<RequestSolution> SolutionsProvided { get; set; }
        //public ICollection<SolutionFeedback> FeedbacksGiven { get; set; }
    }
}
