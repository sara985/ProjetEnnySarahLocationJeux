using ProjetEnnySarahLocationJeux.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjetEnnySarahLocationJeux.POCO
{
    public class Loan
    {        
        private int _id;
        private Player _borrower;        
        private Copy _copy;
        private VideoGame _videoGame;
        private DateOnly _startDate;
        private DateOnly _presumedEndDate;
        private DateOnly? _effectiveEndDate;
        private int _creditsValued;
        private int? _total;

        public Loan()
        {
        }

        public int Id { get => _id; set => _id = value; }
        public Player Borrower { get => _borrower; set => _borrower = value; }
        public Copy Copy { get => _copy; set => _copy = value; }
        public VideoGame VideoGame { get => _videoGame; set => _videoGame = value; }
        public DateOnly StartDate { get => _startDate; set => _startDate = value; }
        public DateOnly PresumedEndDate { get => _presumedEndDate; set => _presumedEndDate = value; }
        public DateOnly? EffectiveEndDate { get => _effectiveEndDate; set => _effectiveEndDate = value; }
        public int CreditsValued { get => _creditsValued; set => _creditsValued = value; }
        public int? Total { get => _total; set => _total = value; }

        public static bool StartLoan(VideoGame v,Player borrower, int durationInWeeks)
        {
            Loan l = new();
            l.VideoGame = v;
            l.Borrower = borrower;
            //find first available copy of game
            foreach (Copy c in v.Copies)
            {
                if (c.IsAvailable)
                {
                    l.Copy = c;
                }
            }
            l.StartDate = DateOnly.FromDateTime(DateTime.Now);
            //The presumed end date is the startdate + the number of weeks 
            l.PresumedEndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(7 * durationInWeeks));
            l.CreditsValued = v.Cost;
            l.Copy.IsAvailable = false;
            new CopyDAO().Update(l.Copy);
            return new LoanDAO().Insert(l);
        }

        public void EndLoan()
        {
            this.Copy.IsAvailable = true;
            new CopyDAO().Update(this.Copy);
            this.EffectiveEndDate = DateOnly.FromDateTime(DateTime.Now);
            int compare = PresumedEndDate.CompareTo(EffectiveEndDate); //1 fev et 5 janv retourne 1
            int duration = ((PresumedEndDate.DayNumber - StartDate.DayNumber) /7); // /7
            int total = duration * CreditsValued;
            if (compare < 0)
            {
                //The loan is late
                //The total is the number of days late * 5 + the normal cost
                int daysLate = (EffectiveEndDate.Value.DayNumber - PresumedEndDate.DayNumber);
                total += daysLate * 5;
            }
            this.Total = total;
            //Update owner's balance
            this.Copy.Owner.Balance += total;
            this.Copy.Owner.Update();
            //Update borrower's balance
            this.Borrower.Balance -= total;
            this.Borrower.Update();
            new LoanDAO().Update(this);
        }

        public static List<Loan> GetOngoingLoansForUser(int userId)
        {
            List<Loan> list = new LoanDAO().List();
            return list.Where(l => l.Borrower.Id == userId && l.EffectiveEndDate == null).ToList();
        }

        public static List<Loan> GetFinishedLoansForUser(int id)
        {
            List<Loan> list = new LoanDAO().List();
            return list.Where(l => l.Borrower.Id == id && l.EffectiveEndDate != null).ToList();
        }
    }
}
