using CoopSimulator.Service.Constant;
using System;

namespace CoopSimulator.Service.Extension
{
    public static class HelperExtensions
    {
        public static double GetOdds(this int rate, bool isInverseProportion)
        {
            double[] possibilities = CommonConstant.possibilities;

            if (isInverseProportion)
            {
                Array.Reverse(possibilities);
            }

            int posibilitiesLength = possibilities.Length;

            if (rate < CommonConstant._zero || rate > posibilitiesLength)
            {
                return possibilities[posibilitiesLength - CommonConstant._one];
            }

            return possibilities[rate];
        }
    }
}
