using CoopSimulator.Model.Core;
using System;

namespace CoopSimulator.Service.Concrete
{
    public class Poultry : IPoultry
    {
        public DateTime BirthDate { get; set; }
        public bool isPregnant { get; set; }
        public DateTime? PregnancyDate { get; set; }
        public int PoultryEnum { get; set; }
        public bool isMale { get; set; }
    }
}
