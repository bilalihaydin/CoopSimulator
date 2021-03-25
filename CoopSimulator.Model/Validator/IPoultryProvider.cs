namespace CoopSimulator.Service.Validator
{
    public interface IPoultryProvider
    {
        bool isGiveBirth();
        double FindProbabilityDeath();
        bool isAdult();
        bool isPregnant();
        bool isCanMate();
        int GetNumberOffSpring();
        int GetAge();
    }
}
