using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp_Inheritance_.UI;
using BankApp_Inheritance_.DL;


namespace BankApp_Inheritance_.BL
{
    class ClientClassBL : PersonClassBL
    {
        public ClientClassBL()
        {

        }
        public ClientClassBL(string userName, string password, string creditCardNo, string bills, string complaints, string clientReviews, int loans, int cash, int fundPayed, int depositions, int transactions, bool complaintCheck, bool checkBook, bool newCard, bool funds, bool reviewCheck) : base(userName,password)
        {
    
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

        private string creditCardNo;
        private string bills;
        private string complaints;
        private string clientReviews;
        private int loans;
        private int cash;
        private int fundPayed;
        private int depositions;
        private int transactions;
        private bool complaintCheck;
        private bool checkBook;
        private bool newCard;
        private bool funds;
        private bool reviewCheck;

        public string getCreditCardNo()
        {
            return creditCardNo;
        }
        public void setCreditCardNo(string creditCardNo)
        {
            this.creditCardNo = creditCardNo;
        }

        public string getBill()
        {
            return bills;
        }
        public void setBills(string bills)
        {
            this.bills = bills;
        }
        public string getComplaint()
        {
            return complaints;
        }
        public void setComplaints(string complaints)
        {
            this.complaints = complaints;
        }
        public string getClientReviews()
        {
            return clientReviews;
        }
        public void setClientReviews(string clientReviews)
        {
            this.clientReviews = clientReviews;
        }

        public int getLoans()
        {
            return loans;
        }
        public void setLoans(int loans)
        {
            this.loans = loans;
        }
        public int getCash()
        {
            return cash;
        }
        public void setCash(int cash)
        {
            this.cash = cash;
        }
        public int getFundPayed()
        {
            return fundPayed;
        }
        public void setFundPayed(int fundPayed)
        {
            this.fundPayed = fundPayed;
        }
        public int getDepositions()
        {
            return depositions;
        }
        public void setDepositions(int deposition)
        {
            this.depositions = deposition;
        }
        public int getTransactions()
        {
            return transactions;
        }
        public void setTransactions(int transactions)
        {
            this.transactions = transactions;
        }

        public bool getComplaintCheck()
        {
            return complaintCheck;
        }
        public void setComplaintCheck(bool complaintCheck)
        {
            this.complaintCheck = complaintCheck;
        }

        public bool getCheckBook()
        {
            return checkBook;
        }
        public void setCheckBook(bool checkBook)
        {
            this.checkBook = checkBook;
        }
        public bool getNewCard()
        {
            return newCard;
        }
        public void setNewCard(bool newCard)
        {
            this.newCard = newCard;
        }
        public bool getFunds()
        {
            return funds;
        }
        public void setFunds(bool funds)
        {
            this.funds = funds;
        }
        public bool getReviewCheck()
        {
            return reviewCheck;
        }
        public void setReviewCheck(bool reviewCheck)
        {
            this.reviewCheck = reviewCheck;
        }




    }
}
