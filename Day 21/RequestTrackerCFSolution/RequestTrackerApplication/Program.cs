using RequestTrackerBLLibrary;
using RequestTrackerCFModals;
using System.Linq;
using System.Net;

namespace RequestTrackerApplication
{
    public class Program
    {
        private static IEmployeeBL employeeBL = new EmployeeBL();   
        private static IRequestBL requestBL = new RequestBL();
        private static IRequestSolutionBL solutionBL = new RequestSolutionBL();
        private static ISolutionFeedback feedbackBL = new SolutionFeedbackBL();
        private static ISolutionFeedback solutionFeedbackBL = new SolutionFeedbackBL();
        private static IEmployeeLoginBL employeeLoginBL = new EmployeeLoginBL();

        //---------------------------------------------------------------------------------------------//
        // Authentication 
        //---------------------------------------------------------------------------------------------//

        async Task<bool> EmployeeLoginAsync(int id, string password)
        {
            Employee employee = new Employee() { Password = password, Id = id };
            var result = await employeeLoginBL.Login(employee);
            if (result)
            {
                await Console.Out.WriteLineAsync("Login Success");
            }
            else
            {
                Console.Out.WriteLine("Invalid username or password");
            }
            if(result) { return true; }
            return false;
        }
        async Task<Employee> GetLoginDeatils()
        {
            Console.WriteLine();
            await Console.Out.WriteLineAsync("Please enter Employee Id");
            int id = Convert.ToInt32(Console.ReadLine());
            await Console.Out.WriteLineAsync("Please enter your password");
            string password = Console.ReadLine() ?? "";
            Console.WriteLine();
            bool auth = await EmployeeLoginAsync(id, password);
            if(auth) return await employeeBL.GetEmployee(id);
            return null;
        }

        async Task<Employee> GetRegisterDetails()
        {
            Employee employee = new Employee();
            await Console.Out.WriteLineAsync("Enter User Name : ");
            employee.Name = Console.ReadLine();
            await Console.Out.WriteLineAsync("Enter Password : ");
            employee.Password = Console.ReadLine();
            employee.Role = "User";
            return await employeeLoginBL.Register(employee);
        }

        async Task<Employee> Authentication()
        {
            Console.WriteLine("Authentication");
            Console.WriteLine();
            Console.WriteLine("1. Login\n2. Register \n0. Exit");
            Console.Write("Enter option : ");
            int response = Convert.ToInt32(Console.ReadLine());
            if (response == 0) return null;
            switch (response)
            {
                case 1:
                    return await new Program().GetLoginDeatils();
                case 2:
                    return await new Program().GetRegisterDetails();
                default:
                    Console.WriteLine("Invalid Input");
                    Authentication();
                    break;       
            }
            return null;
        }

        //---------------------------------------------------------------------------------------------//
        // Request Raise 
        //---------------------------------------------------------------------------------------------//

        async Task<Request> RaiseNewRequest(Employee employee)
        {
            Request request = new Request();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Enter Your Request Message : ");
            request.RequestMessage = Console.ReadLine();
            request.RequestRaisedBy = employee.Id;
            var result =  await requestBL.AddRequest(request);
            Console.WriteLine("Your Request has been Initiated");
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------");

            return result;
        }

        //---------------------------------------------------------------------------------------------//
        // View Request Status
        //---------------------------------------------------------------------------------------------//

        async Task<IList<Request>> GetRequests(Employee employee)
        {
            Console.WriteLine(employee.Id);
            IList<Request> requests = await requestBL.GetAllRequests();
            foreach (Request request in requests)
            {
                Console.WriteLine(request.ToString());
                Console.WriteLine();
            }
            Console.WriteLine("1. Provide Solution to a Request \n2. Show Solutions of Request \n3. Close a Request \n0. Return \n");
            int Reqresponse = Convert.ToInt32(Console.ReadLine());
            switch (Reqresponse)
            {
                case 0:
                    await AdminMenu(employee);
                    break;
                case 1:
                    await provideSolution(employee, requests);
                    await GetRequests(employee);
                    break;
                case 2:
                    await showSolutions(employee, requests);
                    await GetRequests(employee);
                    break;
                case 3:
                    await CloseRequest(employee, requests);
                    await GetRequests(employee);
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    await AdminMenu(employee);
                    break;
            }
            return requests;
        }

        async Task<IList<Request>> GetMyRequests(Employee employee)
        {
            IList<Request> requests = await requestBL.GetAllRequests();
            requests = requests.Where(r => r.RequestRaisedBy == employee.Id).ToList();
            foreach (Request request in requests)
            {
                Console.WriteLine(request.ToString());
                Console.WriteLine();   
            }
            Console.WriteLine("1. Provide Solution to a Request \n 2. Show Solutions \n 0. Return");
            int Reqresponse = Convert.ToInt32(Console.ReadLine());
            switch (Reqresponse)
            {
                case 0:
                    break;
                case 1:
                    await provideSolution(employee, requests);
                    await GetMyRequests(employee);
                    break;
                case 2:
                    await showSolutions(employee,requests);
                    await GetMyRequests(employee);
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    await AdminMenu(employee);
                    break;
            }
            return requests;
        }

        //---------------------------------------------------------------------------------------------//
        // Show Solutions
        //---------------------------------------------------------------------------------------------//

        async Task CloseRequest(Employee employee, IList<Request> requests)
        {
            Console.WriteLine("Give RequestID to Close : ");
            int RequestID = Convert.ToInt32(Console.ReadLine());   
            Request request = requests.SingleOrDefault(r=>r.RequestNumber == RequestID);
            request.RequestClosedBy = employee.Id;
            request.RequestStatus = "Closed";
            request.ClosedDate = DateTime.Now;
            await requestBL.UpdateRequest(request);
        }

        //---------------------------------------------------------------------------------------------//
        // Show Solutions
        //---------------------------------------------------------------------------------------------//

        async Task showSolutions(Employee employee, IList<Request> requests)
        {
            Console.WriteLine("Enter Request Number to See the Solutions");
            int RequestId = Convert.ToInt32(Console.ReadLine());
            IList<RequestSolution> solutions = await solutionBL.GetAllRequestSolutionbyId(RequestId);
            foreach (RequestSolution solution in solutions) { Console.WriteLine(solution.ToString());}
            Console.WriteLine();
            Console.WriteLine("1. Add Feedback to the Solution. 2. Show Feedbacks 0. Return");
            int response = Convert.ToInt32(Console.ReadLine());
            switch(response)
            {
                case 0:
                    await GetMyRequests(employee);
                    break;
                case 1:
                    await AddFeedback(employee,solutions);
                    await GetMyRequests(employee);
                    break;
                case 2:
                    await ShowFeedback(employee,solutions,requests);
                    await GetMyRequests(employee);
                    break;
                default:
                    Console.WriteLine("Invalid entry");
                    await GetMyRequests(employee);
                    break;
            }
        }

        //---------------------------------------------------------------------------------------------//
        // Provide Solution
        //---------------------------------------------------------------------------------------------//

        async Task provideSolution(Employee employee,IList<Request> requests)
        {
            Console.WriteLine("Enter the Request Id");
            int RequestId = Convert.ToInt32(Console.ReadLine());    
            Request request = requests.SingleOrDefault(r=>r.RequestNumber == RequestId);
            Console.WriteLine(); 
            Console.WriteLine(request.ToString());
            Console.WriteLine();
            Console.WriteLine("Enter Your Solution");
            RequestSolution solution = new RequestSolution();
            if(request.RequestRaisedBy == employee.Id)
            {
                solution.RequestRaiserComment = Console.ReadLine();
            }
            else
            {
                solution.SolutionDescription = Console.ReadLine();
            }
            solution.RequestId = RequestId;
            solution.SolvedBy = employee.Id;
            await solutionBL.AddRequestSolution(solution);
            Console.WriteLine($"Solution Added to {request.RequestNumber}");
        }


        //---------------------------------------------------------------------------------------------//
        // Provide Feedback
        //---------------------------------------------------------------------------------------------//

        async Task AddFeedback(Employee employee,IList<RequestSolution> solutions)
        {
            Console.WriteLine();
            foreach(RequestSolution solution in solutions) { 
                Console.WriteLine(solution.ToString());
                Console.WriteLine();
            }
            Console.WriteLine("Enter Solution Id to Add Feedback : ");
            SolutionFeedback feedback = new SolutionFeedback();
            int solutionID = Convert.ToInt32(Console.ReadLine());
            feedback.SolutionId = solutionID;
            feedback.FeedbackDate = DateTime.Now;
            //feedback.FeedbackByEmployee = employee;
            feedback.FeedbackBy = employee.Id;
            Console.WriteLine("Enter Remarks/Feedback for Solutions");
            feedback.Remarks = Console.ReadLine();
            Console.WriteLine("Enter Solution Rating out of 5 : ");
            feedback.Rating = Convert.ToInt32(Console.ReadLine());  
            await feedbackBL.AddFeedback(feedback);
        }

        async Task ShowFeedback(Employee employee,IList<RequestSolution> solutions,IList<Request> requests)
        {
            Console.WriteLine("Enter SolutionID: ");
            int SolutionId = Convert.ToInt32(Console.ReadLine());
            IList<SolutionFeedback> feedbacks = await feedbackBL.GetAllfeedbackBySolutionID(SolutionId);
            foreach (SolutionFeedback feedback in feedbacks) { Console.WriteLine(feedback.ToString()); }
            await showSolutions(employee, requests);
        }


        //---------------------------------------------------------------------------------------------//
        // MenuBars
        //---------------------------------------------------------------------------------------------//

        async Task AdminMenu(Employee employee)
        {
            Console.WriteLine("Role : Admin");
            Console.WriteLine("1. Raise a Request");
            Console.WriteLine("2. View Request Status");
            Console.WriteLine("3. View All Request Status");
            Console.WriteLine("0. End");
            int response = Convert.ToInt32(Console.ReadLine());
            switch (response)
            {
                case 0:
                    Console.WriteLine("You are Logged out");
                    break;
                case 1:
                    await RaiseNewRequest(employee);
                    await AdminMenu(employee);
                    break;
                case 2:
                    await GetMyRequests(employee);
                    await AdminMenu(employee);
                    break;
                case 3:
                    IList<Request> requests = await GetRequests(employee);
                    await AdminMenu(employee);
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine("Invalid Selection");
                    await AdminMenu(employee);
                    break;

            }
        }

        async Task UserMenu(Employee employee)
        {
            Console.WriteLine("Role : User");
            Console.WriteLine("1. Raise a Request");
            Console.WriteLine("2. View Request Status");
            Console.WriteLine("0. End");
            int response = Convert.ToInt32(Console.ReadLine());
            switch (response)
            {
                case 0:
                    Console.WriteLine("You are Logged out");
                    break;
                case 1:
                    await RaiseNewRequest(employee);
                    await UserMenu(employee);
                    break;
                case 2:
                    await GetMyRequests(employee);
                    await UserMenu(employee);
                    break;
                default:
                    Console.WriteLine("Invalid Selection");
                    await UserMenu(employee);
                    break;

            }
        }


        static async Task Main(string[] args)
        {
            Program program = new Program();
            Employee employee = await program.Authentication();
            if (employee == null) {
                Console.WriteLine("You are not Authorized");
                return;
            };
            Console.WriteLine(employee.ToString());
            switch (employee.Role)
            {
                case "Admin":
                    await program.AdminMenu(employee);
                    break;
                case "User":
                    await program.UserMenu(employee);
                    break;
                default:
                    break;
            }

        }
    }
}
