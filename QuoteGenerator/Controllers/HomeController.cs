using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuoteGenerator.Models;


namespace QuoteGenerator.Controllers
{
    public class HomeController : Controller
    {
        private readonly string connectionString = @"Data Source=DESKTOP-Q7JL2FL\SQLEXPRESS;Initial Catalog=QuoteGenerator;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public IActionResult Index()
        {
            return View();
        }

        public int QuoteGenerator(DateTime DOB, int CarYear, string CarMake, string CarModel, int DUI, int tickets, int Insurance)
        {
            //Logic for Quote Evaluation
            int Quote = CoverageRestrictions(Insurance);

            int CoverageRestrictions(int insurance)
            {
                Quote = DUIRestrictions(DUI);
                if (Insurance == 0)
                {
                    Quote = Quote + (Quote / 2);
                }
                else { }
                return Quote;
            }
            int DUIRestrictions(int DrivingUnderTheInfluence)
            {
                Quote = ticketRestrictions(tickets);
                if (DUI > 0)
                {
                    Quote = Quote + (Quote / 4);
                }
                else { }
                return Quote;
            }
            int ticketRestrictions(int Tickets)
            {
                Quote = CarRestrictions(CarMake);
                if (tickets > 0)
                {
                    Quote = Quote + (tickets * 10);
                }
                else { }
                return Quote;
            }
            int CarRestrictions(string carMake)
            {
                Quote = CarYearRestritions(CarYear);
                if (CarMake == "Porsche" || CarMake == "porsche" && CarModel == "911 Carrera" || CarModel == "911 carrera")
                {
                    Quote = Quote + 50;
                }
                else if (CarMake == "Porsche" || CarMake == "porsche")
                {
                    Quote = Quote + 50;
                }
                else
                { }
                return Quote;
            }
            int CarYearRestritions(int carYear)
            {
                Quote = AgeRestrictions(DOB);
                if (CarYear < 2000)
                {
                    Quote = Quote + 25;
                }
                else if (CarYear > 2015)
                {
                    Quote = Quote + 25;
                }
                else
                {

                }
                return Quote;
            }
            int AgeRestrictions(DateTime DateOfBirth)
            {
                Quote = 0;
                int Age = DateTime.Now.Year - DOB.Year;
                if (Age < 25 && Age > 18)
                {
                    Quote = 50 + 25;
                }
                else if (Age < 18)
                {
                    Quote = 50 + 100;
                }
                else
                {
                    Quote = 50;
                }
                return Quote;
            }
            return Quote;
        }




        [HttpPost]
        public ActionResult QuoteGenerator(string FirstName, string LastName, string EmailAddress, DateTime DOB,
                                       int CarYear, string CarMake, string CarModel, int DUI, int tickets, int Insurance)
        {
            int Quote = QuoteGenerator(DOB, CarYear, CarMake, CarModel, DUI, tickets, Insurance);
            
            string queryString = @"INSERT INTO QuoteAttributes(FirstName, LastName, EmailAddress, DOB, CarYear, CarMake, CarModel, DUI, tickets, Insurance, Quote)
                                   VALUES (@FirstName,@LastName,@EmailAddress,@DOB,@CarYear,@CarMake,@CarModel,@DUI,@tickets,@Insurance, @Quote)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@FirstName", SqlDbType.VarChar);
                command.Parameters.Add("@LastName", SqlDbType.VarChar);
                command.Parameters.Add("@EmailAddress", SqlDbType.VarChar);
                command.Parameters.Add("@DOB", SqlDbType.DateTime);
                command.Parameters.Add("@CarYear", SqlDbType.Int);
                command.Parameters.Add("@CarMake", SqlDbType.VarChar);
                command.Parameters.Add("@CarModel", SqlDbType.VarChar);
                command.Parameters.Add("@DUI", SqlDbType.Int);
                command.Parameters.Add("@tickets", SqlDbType.Int);
                command.Parameters.Add("@Insurance", SqlDbType.Int);
                command.Parameters.Add("@Quote", SqlDbType.Int);

                command.Parameters["@FirstName"].Value = FirstName;
                command.Parameters["@LastName"].Value = LastName;
                command.Parameters["@EmailAddress"].Value = EmailAddress;
                command.Parameters["@DOB"].Value = DOB;
                command.Parameters["@CarYear"].Value = CarYear;
                command.Parameters["@CarMake"].Value = CarMake;
                command.Parameters["@CarModel"].Value = CarModel;
                command.Parameters["@DUI"].Value = DUI;
                command.Parameters["@tickets"].Value = tickets;
                command.Parameters["@Insurance"].Value = Insurance;
                command.Parameters["@Quote"].Value = Quote;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            quote quoteInformation = new quote()
            {
            Quote = Quote,
            };
            ViewBag.Message = quoteInformation;
            return View();
        }
        public ActionResult Admin()
        {
            string QueryString = @"SELECT id, FirstName, LastName, EmailAddress, DOB, CarYear, CarMake, CarModel, DUI, tickets, Insurance, Quote from QuoteAttributes";
            List<quote> Quotes = new List<quote>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(QueryString, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var quote = new quote();
                    quote.id = Convert.ToInt32(reader["id"]);
                    quote.FirstName = reader["FirstName"].ToString();
                    quote.LasttName = reader["LastName"].ToString();
                    quote.EmailAddress = reader["EmailAddress"].ToString();
                    quote.DOB = Convert.ToDateTime(reader["DOB"]);
                    quote.CarMake = reader["CarMake"].ToString();
                    quote.CarModel = reader["CarModel"].ToString();
                    quote.CarYear = Convert.ToInt32(reader["CarYear"]);
                    quote.DUI = Convert.ToInt32(reader["DUI"]);
                    quote.Insurance = Convert.ToInt32(reader["Insurance"]);
                    quote.tickets = Convert.ToInt32(reader["tickets"]);
                    quote.Quote = QuoteGenerator(quote.DOB, quote.CarYear, quote.CarMake, quote.CarModel, quote.DUI, quote.tickets, quote.Insurance);
                    Quotes.Add(quote);
                }

            }
            return View(Quotes);
    }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
