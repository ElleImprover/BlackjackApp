using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackApp
{
   public enum Regular {
        Two   = 2,
        Three = 3,
        Four  = 4,
        Five  = 5,
        Six   = 6,
        Seven = 7,
        Eight = 8,
        Nine  = 9,
        Ten   = 10
    }
    //use if modulus %10=0{} else
    public enum Face { 
        Queen = 10,
        King  = 20,
        Jack  = 30,
        Ace1  = 40,
        Ace11 = 50
    }


}
