using System;
using System.Collections.Generic;
using System.Text;

namespace CoopSimulator.Service.Constant
{
    public static class RabbitConstant
    {
        /// <summary>
        /// Gebelik Süreci
        /// </summary>
        public const int GestatinPeriod = 10;
        /// <summary>
        /// Yetişkin Yaşı (Gün)
        /// </summary>
        public const int AdultAge = 80;
        /// <summary>
        /// Dişi Doğum Oranı
        /// </summary>
        public const double FemaleBirthRate = 0.5;
        /// <summary>
        /// Emzirme Süreci (Gün)
        /// </summary>
        public const int BreastfeedingTime = 5;
        /// <summary>
        /// İdeal Yaş (Gün)
        /// </summary>
        public const int IdealAge = 150;
        /// <summary>
        /// Hamile Kalma ihtimali(Gün)
        /// </summary>
        public const double PregnancyRate = 0.76;
        /// <summary>
        /// Doğurganlık Çarpanı
        /// </summary>
        public const double FertilityMultiplier = 40;
    }
}
