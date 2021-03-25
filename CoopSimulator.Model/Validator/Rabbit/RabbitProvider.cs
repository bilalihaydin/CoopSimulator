using CoopSimulator.Model.Core;
using CoopSimulator.Service.Constant;
using CoopSimulator.Service.Extension;
using System;

namespace CoopSimulator.Service.Validator.Rabbit
{
    public class RabbitProvider : IPoultryProvider
    {
        private readonly IPoultry _poultry;
        private readonly DateTime _time;

        public RabbitProvider(IPoultry poultry, DateTime time)
        {
            _poultry = poultry;
            _time = time;
        }
        public bool isAdult()
        {
            if (GetAge() >= RabbitConstant.AdultAge)
            {
                return true;
            }

            return false;
        }

        public double FindProbabilityDeath()
        {
            int rate = FindRateEfficiency();
            return rate.GetOdds(true) / CommonConstant._daysNumberInYear;
        }

        public bool isGiveBirth()
        {
            if (_poultry.isMale == true) return false;

            return _poultry.isPregnant == true && _time.Subtract(_poultry.PregnancyDate.Value).TotalDays >= RabbitConstant.GestatinPeriod;
        }

        public bool isPregnant()
        {
            if (_poultry.isMale == true) return false;

            return RabbitConstant.PregnancyRate > FindProbabilityPregnant();
        }
        
        private double FindProbabilityPregnant()
        {
            int rate = FindRateEfficiency();

            return rate.GetOdds(false);
        }

        //Emzirme Döneminde mi?
        private bool isPuerperal()
        {
            if (_poultry.PregnancyDate != null)
            {
                if (_time.Subtract(_poultry.PregnancyDate.Value).TotalDays < (RabbitConstant.GestatinPeriod + RabbitConstant.BreastfeedingTime) == true)
                {
                    return true;
                }
            }

            return false;
        }

        //Çiftleşebilir mi?
        public bool isCanMate()
        {
            if (isAdult() == false)
            {
                return false;
            }

            if (_poultry.isMale == false)
            {

                if (_poultry.isPregnant == true)
                {
                    return false;
                }

                if (isPuerperal() == true)
                {
                    return false;
                }
            }

            return true;
        }

        public int GetNumberOffSpring()
        {
            int rate = FindRateEfficiency();

            return Convert.ToInt32(Math.Round(rate.GetOdds(false) * RabbitConstant.FertilityMultiplier));
        }

        private int FindRateEfficiency()
        {
            return Convert.ToInt32(Math.Round((decimal)((GetAge() - RabbitConstant.IdealAge) / CommonConstant._daysNumberInYear)));
        }

        public int GetAge()
        {
            return Convert.ToInt32(Math.Round(_time.Subtract(_poultry.BirthDate).TotalDays));
        }
    }
}
