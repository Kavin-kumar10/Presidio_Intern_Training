using System.ComponentModel.DataAnnotations;

namespace RequestTrackerAPIApp.Modals
{
    public class Request
    {
        [Key]
        public int RequestNumber { get; set; }
        public string RequestMessage { get; set; }
        public DateTime RequestDate { get; set; } = System.DateTime.Now;
        public DateTime? ClosedDate { get; set; } = null;
        public string RequestStatus { get; set; } = "PENDING";


        public int RequestRaisedBy { get; set; }

        public Employee? RaisedByEmployee { get; set; }

        public int? RequestClosedBy { get; set; }

        public Employee? RequestClosedByEmployee { get; set; }

        //public ICollection<RequestSolution> RequestSolutions { get; set; }


        public override string ToString()
        {
            return $"Request Number : {RequestNumber} \n" +
                $"Request Message : {RequestMessage} \n" +
                $"Request Raised By : {RequestRaisedBy}\n" +
                $"Request Status : {RequestStatus} \n" +
                $"Request Closed By : {RequestClosedBy} \n";
        }
    }
}
