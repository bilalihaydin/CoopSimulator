using CoopSimulator.Service.Enum;
using CoopSimulator.Service.Services.Lifecycle;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoopSimulator.Model.Core
{
    public interface IPoultry
    {
        DateTime BirthDate { get; set; }
        int PoultryEnum { get; set; }
        bool isMale { get; set; }
        bool isPregnant { get; set; }
        DateTime? PregnancyDate { get; set; }
    }
}