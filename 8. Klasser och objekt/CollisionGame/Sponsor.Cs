using System;
using System.Collections.Generic;
using System.Text;

namespace CollisionGame
{
    class Sponsor
    {
        // Member variables
        private string sponsorName;

        private int sponsorPayment;

        // Constructor
        public Sponsor(string name, int payment)
        {
            sponsorName = name;

            sponsorPayment = payment;
        }

        // Methods
        public string Name
        {
            get
            {
                return sponsorName;
            }
        }

        public int Payment
        {
            get
            {
                return sponsorPayment;
            }
        }


    }
}
