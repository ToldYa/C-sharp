using System;

namespace Main
{
    class MobileNumber : ContactNumber
    {
        public MobileNumber(string number) : base(number)
        {

        }

        public override string ToString()
        {
            return GetNumber();
        }

    }
}
