using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp_3_Tier_Classes_.DL;
using BankApp_3_Tier_Classes_.UI;


namespace BankApp_3_Tier_Classes_.BL
{
    public class ClientClassBL
    {
        public ClientClassBL()
        {

        }
        public ClientClassBL(string userName,string password, string creditCardNo, string bills, string complaints, string clientReviews, int loans, int cash, int fundPayed, int depositions, int transactions, bool complaintCheck, bool checkBook, bool newCard, bool funds, bool reviewCheck)
        {
            this.userName = userName;
            this.password = password;
            this.creditCardNo = creditCardNo;
            this.bills = bills;
            this.complaints = complaints;
            this.clientReviews = clientReviews;
            this.loans = loans;
            this.cash = cash;
            this.fundPayed = fundPayed;
            this.depositions = depositions;
            this.transactions = transactions;
            this.complaintCheck = complaintCheck;
            this.checkBook = checkBook;
            this.newCard = newCard;
            this.funds = funds;
            this.reviewCheck = reviewCheck;

        }



        public string userName;
        public string password;
        public string creditCardNo;
        public string bills;
        public string complaints;
        public string clientReviews;
        public int loans;
        public int cash;
        public int fundPayed;
        public int depositions;
        public int transactions;
        public bool complaintCheck;
        public bool checkBook;
        public bool newCard;
        public bool funds;
        public bool reviewCheck;

    }
}
