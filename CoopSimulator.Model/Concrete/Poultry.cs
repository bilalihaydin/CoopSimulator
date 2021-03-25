using CoopSimulator.Model.Core;
using CoopSimulator.Service.Enum;
using CoopSimulator.Service.Services.Lifecycle;
using System;
using System.Collections.Generic;
using System.Text;

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
