using System;

namespace DeveloperSample.ClassRefactoring
{
    public enum SwallowType
    {
        African, European
    }

    public enum SwallowLoad
    {
        None, Coconut
    }

    public class SwallowFactory
    {
        public Swallow GetSwallow(SwallowType swallowType) => new Swallow(swallowType);
    }

    public class Swallow
    {
        public SwallowType Type { get; }
        public SwallowLoad Load { get; private set; }

        public Swallow(SwallowType swallowType)
        {
            Type = swallowType;
        }

        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

        public double GetAirspeedVelocity()
        {
            return GetAirspeedVelocityByType() + GetAirspeedVelocityByLoad();
        }

        public double GetAirspeedVelocityByType()
        {
            switch (Type)
            {
                case SwallowType.African:
                    return 18;
                case SwallowType.European:
                    return 16;
                default:
                    throw new InvalidOperationException();
            }
        }

        public double GetAirspeedVelocityByLoad()
        {
            switch (Load)
            {
                case SwallowLoad.Coconut:
                    return 0;
                case SwallowLoad.None:
                    return 4;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}