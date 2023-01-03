using ProjetEnnySarahLocationJeux.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEnnySarahLocationJeux.POCO
{
    public class Loan
    {        
        //TODO
        //private Player Loaner, already in copy
        private int _id;
        private Player _borrower;        
        private Copy _copy;
        private VideoGame _videoGame;
        private DateOnly _startDate;
        private DateOnly _presumedEndDate;
        private DateOnly _effectiveEndDate;
        private int _creditsValued;
        private int _total;

        public Loan()
        {
        }

        public int Id { get => _id; set => _id = value; }
        public Player Borrower { get => _borrower; set => _borrower = value; }
        public Copy Copy { get => _copy; set => _copy = value; }
        public VideoGame VideoGame { get => _videoGame; set => _videoGame = value; }
        public DateOnly StartDate { get => _startDate; set => _startDate = value; }
        public DateOnly PresumedEndDate { get => _presumedEndDate; set => _presumedEndDate = value; }
        public DateOnly EffectiveEndDate { get => _effectiveEndDate; set => _effectiveEndDate = value; }
        public int CreditsValued { get => _creditsValued; set => _creditsValued = value; }
        public int Total { get => _total; set => _total = value; }

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
    }
}
