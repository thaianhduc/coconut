using System;

namespace Coconut.CoreLogic
{
    public class UglyFactTeller
    {
        public UglyFactModel TellMe(DateTime dob)
        {
            var meetCreatorOn = dob.AddYears(80);
            var spent = (int)Math.Round(DateTime.Now.Subtract(dob).TotalDays / 7);
            var closed = (int)Math.Round(meetCreatorOn.Subtract(DateTime.Now).TotalDays / 7);
            return new UglyFactModel
            {
                SpentWeeks = spent,
                CloseToCreatorWeeks = closed
            };
        }
    }
}
