using CoopSimulator.Model.Core;
using CoopSimulator.Service.Enum;
using CoopSimulator.Service.Services.Lifecycle;
using System;
using System.Collections.Generic;

namespace CoopSimulator.Service.Extension
{
    public static class PoultryExtension
    {
        public static ILifecycle GetLifecycle(this PoultryEnum poultryEnum, List<IPoultry> poultryList)
        {
            switch (poultryEnum)
            {
                case PoultryEnum.None:
                    throw new Exception("none.is.notvalid");
                case PoultryEnum.Rabbit:
                    return new RabbitLifecycle(poultryList);
                default:
                    throw new Exception("invalid.poultryenum");
            }
        }
    }
}
