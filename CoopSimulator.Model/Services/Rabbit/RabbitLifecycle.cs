using CoopSimulator.Model.Core;
using CoopSimulator.Service.Concrete;
using CoopSimulator.Service.Constant;
using CoopSimulator.Service.Enum;
using CoopSimulator.Service.Validator.Rabbit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoopSimulator.Service.Services.Lifecycle
{
    public class RabbitLifecycle : ILifecycle
    {
        Random _random;
        List<IPoultry> _poultryList;
        public RabbitLifecycle(List<IPoultry> poultryList)
        {
            _random = new Random();
            _poultryList = poultryList;
        }
        public DateTime Date { get; set; }

        #region Mating
        public void MatingOperation()
        {
            List<IPoultry> rabbitList = _poultryList.Where(condition => condition.PoultryEnum == (int)Enum.PoultryEnum.Rabbit).ToList();
            List<IPoultry> femalePoultryWillingMate = rabbitList.Where(condition => condition.isMale == false).ToList();
            List<IPoultry> malePoultryWillingMate = rabbitList.Where(condition => condition.isMale == true).ToList();

            if (femalePoultryWillingMate.Count == CommonConstant._zero || malePoultryWillingMate.Count == CommonConstant._zero)
            {
                return;
            }

            Mating(femalePoultryWillingMate, malePoultryWillingMate);
        }

        private void Mating(List<IPoultry> femalePoultryList, List<IPoultry> malePoultryList)
        {
            foreach (IPoultry femalePoultry in femalePoultryList)
            {
                //Önce dişi tavşanın çiftleşme kurallarına uyup uymadığına bakıyorum
                RabbitProvider rabbitValidator = new RabbitProvider(femalePoultry, Date);
                if (rabbitValidator.isCanMate())
                {
                    //Burada eş olan erkek tavşanı buluyorum.
                    IPoultry male = GetWillingToMateMaleRabbit(malePoultryList);


                    ImpregnateTheRabbit(femalePoultry);
                }
            }
        }

        //Sıradaki dişi tavşana karşı en istekli erkek tavşanı alıyorum.
        private IPoultry GetWillingToMateMaleRabbit(List<IPoultry> malePoultryList)
        {
            IPoultry most = null;
            double mostDesire = CommonConstant._zero;

            foreach (IPoultry malePoultry in malePoultryList)
            {
                double desire = _random.NextDouble();

                if (desire >= mostDesire)
                {
                    RabbitProvider rabbitValidatorForMaleRabbit = new RabbitProvider(malePoultry, Date);
                    //Erkek tavşanın çiftleşme kurallarına uyuyormu
                    if (rabbitValidatorForMaleRabbit.isCanMate())
                    {
                        most = malePoultry;
                    }
                }
            }

            return most;
        }

        private void ImpregnateTheRabbit(IPoultry femalePoultry)
        {
            RabbitProvider rabbitValidator = new RabbitProvider(femalePoultry, Date);
            if (rabbitValidator.isPregnant() == true)
            {
                femalePoultry.isPregnant = true;
                femalePoultry.PregnancyDate = Date;
            }
        }
        #endregion

        #region Birth
        public void BirthOperation()
        {
            List<IPoultry> rabbitList = _poultryList.Where(condition => condition.PoultryEnum == (int)Enum.PoultryEnum.Rabbit).ToList();
            List<IPoultry> femalePoultryList = rabbitList.Where(condition => condition.isMale == false).ToList();

            foreach (IPoultry femalePoultry in femalePoultryList)
            {
                RabbitProvider rabbitValidator = new RabbitProvider(femalePoultry, Date);
                if (rabbitValidator.isGiveBirth())
                {
                    GiveBirth(femalePoultry);
                    femalePoultry.isPregnant = false;
                }
            }
        }

        private void GiveBirth(IPoultry femalePoultry)
        {
            RabbitProvider rabbitValidator = new RabbitProvider(femalePoultry, Date);
            int childLength = rabbitValidator.GetNumberOffSpring();
            for (int i = 0; i < childLength; i++)
            {
                double randomValue = _random.NextDouble();

                Poultry child = new Poultry();
                if (randomValue > RabbitConstant.FemaleBirthRate)
                {
                    child.isMale = false;
                }
                else
                {
                    child.isMale = true;
                }

                child.isPregnant = false;
                child.BirthDate = Date;
                child.PoultryEnum = (int)PoultryEnum.Rabbit;
                _poultryList.Add(child);
            }
        }
        #endregion

        #region Death
        public void DeathOperation()
        {
            List<IPoultry> rabbitList = _poultryList.Where(condition => condition.PoultryEnum == (int)Enum.PoultryEnum.Rabbit).ToList();

            foreach (IPoultry poultry in rabbitList)
            {
                RabbitProvider rabbitValidator = new RabbitProvider(poultry, Date);

                if (_random.NextDouble() <= rabbitValidator.FindProbabilityDeath())
                {
                    _poultryList.Remove(poultry);
                }

            }
        }
        #endregion

        public void NextDay()
        {
            MatingOperation();

            BirthOperation();

            DeathOperation();
        }

        public List<IPoultry> GetCoop()
        {
            return _poultryList;
        }
    }
}
