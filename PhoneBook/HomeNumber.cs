using System;

namespace Main
{
    class HomeNumber : ContactNumber
    {
        public HomeNumber(string number): base(number)
        {
            
        }

        public override string ToString()
        {
            return GetNumber();
        }

    }
}
