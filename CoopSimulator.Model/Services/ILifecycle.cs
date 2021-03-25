using CoopSimulator.Model.Core;
using System;
using System.Collections.Generic;

namespace CoopSimulator.Service.Services.Lifecycle
{
    public interface ILifecycle
    {
        DateTime Date { get; set; }
        void MatingOperation();
        void BirthOperation();
        void DeathOperation();
        void NextDay();
        List<IPoultry> GetCoop();
    }
}
