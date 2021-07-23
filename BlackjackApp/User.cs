using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackApp
{
   public class User
    {
        public Bet CurrentBet { get; set; }
        public List<Bet> AllBets { get; set; }
    }
}
