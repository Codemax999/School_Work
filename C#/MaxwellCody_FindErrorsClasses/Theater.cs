using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindErrorsClasses
{
    class Theater
    {
        //Member Variables
        string mTheaterName;
        int mNumberOfScreens;
        decimal mAverageTicketPrice;

        //Create the constructor function
        public Theater(string _theaterName, int _numberOfScreens, decimal _averageTicketPrice)
        {

            //Use the incomming parameters to inialize our original member variables
            mTheaterName = _theaterName;
            mNumberOfScreens = _numberOfScreens;
            mAverageTicketPrice = _averageTicketPrice;

        }

        //Getters
        public string GetName()
        {
            return mTheaterName;
        }

        public int GetNumScreens()
        {
            return mNumberOfScreens;
        }

        public decimal GetTicketPrice()
        {
            return mAverageTicketPrice;
        }

        //Settters
        public void SetTitle(string _theaterName)
        {
            this.mTheaterName = _theaterName;
        }

        public void SetNumScreens(int _numScreens)
        {
            this.mNumberOfScreens = _numScreens;
        }

        public void SetTicketPrice(decimal _ticketPrice)
        {
           this.mAverageTicketPrice = _ticketPrice;
        }


        //Custom function to return how much #number of tickets will be
        public decimal TotalTicketCost(int _numberOfTickets, decimal _averageTicketPrice)
        {
            decimal totalCost = _numberOfTickets * _averageTicketPrice;

            return totalCost;

        }
    }
}
