namespace TestTask
{
    public class Solution
    {
         
        public static int Process(double mass, List<Destination> stations)
        {
            int fuelTotal = 0;
            for (int i = stations.Count - 1; i >= 0; i--) {
                Destination step = stations[i];
                double gravity = 0;
                gravity = GetGravity(step.TargetSpaceObject);
                double massCurrent = mass + fuelTotal;
                int fuel = 0;
                if (step.OperationType == OperationType.Launch)
                {
                    fuel = (int)Math.Floor(massCurrent * gravity * 0.042 - 33);
                }
                else if (step.OperationType == OperationType.Land)
                {
                    fuel = (int)Math.Floor(massCurrent * gravity * 0.033 - 42);
                }
                if (fuel < 0)
                {
                    fuel = 0;
                }
                while (fuel > 0) {
                    fuelTotal += fuel;
                    if (step.OperationType == OperationType.Launch)
                    {
                        fuel = (int)Math.Floor(fuel * gravity * 0.042 - 33);
                    }
                    else if (step.OperationType == OperationType.Land)
                    {
                        fuel = (int)Math.Floor(fuel * gravity * 0.033 - 42);
                    }
                    if (fuel < 0)
                    {
                        fuel = 0;
                    }
                }

            }
            return fuelTotal;

        }
        public static double GetGravity(TargetSpaceObject obj)
        {
            if (obj == TargetSpaceObject.Earth)
            {
                return 9.807;
            }
            else if (obj == TargetSpaceObject.Moon)
            {
                return 1.62;
            }
            else if (obj == TargetSpaceObject.Mars)
            {
                return 3.711;
            }
            return 0;
        }
    }

    public enum TargetSpaceObject
    {
        Earth,
        Moon,
        Mars
    }

    public enum OperationType
    {
        Launch,
        Land
    }

    public class Destination
    {
        public OperationType OperationType { get; set; }
        public TargetSpaceObject TargetSpaceObject { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //1 test
            var route1 = new List<Destination>
            {
                new Destination{OperationType = OperationType.Launch, TargetSpaceObject = TargetSpaceObject.Earth},
                new Destination{OperationType = OperationType.Land, TargetSpaceObject = TargetSpaceObject.Moon},
                new Destination{OperationType = OperationType.Launch, TargetSpaceObject = TargetSpaceObject.Moon},
                new Destination{OperationType = OperationType.Land, TargetSpaceObject = TargetSpaceObject.Earth},
            };
            int fuel = Solution.Process(28801, route1);
            Console.WriteLine(fuel);
            //2 test
            var route2 = new List<Destination>
            {
                new Destination{OperationType = OperationType.Launch, TargetSpaceObject = TargetSpaceObject.Earth},
                new Destination{OperationType = OperationType.Land, TargetSpaceObject = TargetSpaceObject.Mars},
                new Destination{OperationType = OperationType.Launch, TargetSpaceObject = TargetSpaceObject.Mars},
                new Destination{OperationType = OperationType.Land, TargetSpaceObject = TargetSpaceObject.Earth},
            };
            fuel = Solution.Process(14606, route2);
            Console.WriteLine(fuel);
            //3 test
            var route3 = new List<Destination>
            {
                new Destination{OperationType = OperationType.Launch, TargetSpaceObject = TargetSpaceObject.Earth},
                new Destination{OperationType = OperationType.Land, TargetSpaceObject = TargetSpaceObject.Moon},
                new Destination{OperationType = OperationType.Launch, TargetSpaceObject = TargetSpaceObject.Moon},
                new Destination{OperationType = OperationType.Land, TargetSpaceObject = TargetSpaceObject.Mars},
                new Destination{OperationType = OperationType.Launch, TargetSpaceObject = TargetSpaceObject.Mars},
                new Destination{OperationType = OperationType.Land, TargetSpaceObject = TargetSpaceObject.Earth},
            };
            fuel = Solution.Process(75432, route3);
            Console.WriteLine(fuel);
        }
    }
}
