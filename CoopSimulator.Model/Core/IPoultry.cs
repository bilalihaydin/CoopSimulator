using System;

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