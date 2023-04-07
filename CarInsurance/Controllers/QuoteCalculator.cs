using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarInsurance.Controllers
{
    public class QuoteCalculator
    {
        //create variables to be used
        
        
        //create quote generator method to be called within the CREATE method 
        public decimal GetQuote(DateTime dateOfBirth, int carYear, string carMake, string carModel, bool DUI, int speedingTickets, bool coverageType)
        {
            //start with 50 a month
            decimal newQuote = 50;

            //figure out age, needs to be accurate so use if statement to adjust bday with respect to days of the year
            int age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
            {
                age = age - 1;
            }
            //if user age is <= 18, add 100 to quote
            if (age <= 18)
            {
                newQuote += 100;
            }
            //if user is 19-25, add 50 to quote
            else if (age >= 19 && age <= 25)
            {
                newQuote += 50;
            }
            //if user is neither younger than 18, or between 19-25, add 25 (covers all bdays)
            else
            {
                newQuote += 25;
            }
            //if car year is less than 2000 or greater than 2015 add 25
            if (carYear < 2000 || carYear > 2015)
            {
                newQuote += 25;
            }
            //if the carmake is a porsche, add 25
            if (carMake.ToLower() == "porsche")
            {
                newQuote += 25;
            }
            //if the car make is porsche AND the model is 911 carerra, add 25
            if (carMake.ToLower() == "porsche" && carModel.ToLower() == "911 carrera")
            {
                newQuote += 25;
            }
            //add 10$ for each speeding ticket
            newQuote += speedingTickets * 10;
            //add 25% if the user has ever had a dui
            if (DUI)
            {
                newQuote *= 1.25m;
                //add 50% if the user wants full coverage. Instructions unclear whether to use
                //post or pre DUI quote. Ill use post because I want more money

            }
            if (coverageType)
            {
                newQuote *= 1.5m;
                
            }
            return newQuote;
            
        }
    }
}   
