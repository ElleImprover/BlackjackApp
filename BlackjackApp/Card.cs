using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackApp
{
    public class  Card
    {
        //makes it null
    public int ID { get; set; }
    }
    public class RegularCard : Card
    {
        public Suit Suit { get; set; }
        public Regular Regular { get; set; }

    }
    public class FaceCard : Card
    {
        public Suit Suit { get; set; }

        public Face Face { get; set; }

    }
}
