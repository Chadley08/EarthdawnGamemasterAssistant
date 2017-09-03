using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EarthdawnGamemasterAssistant
{
    public static class CharacteristicTables
    {
        private static readonly List<string> StepLookup = new List<string>();
        private static readonly Dictionary<int, int> CarryingCapacity = new Dictionary<int, int>();

        static CharacteristicTables()
        {
            CreateStepTableList();
            CreateCarryingCapacityDictionary();
        }

        private static void CreateCarryingCapacityDictionary()
        {
            int carryingCapacity;
            var key = 0;
            // 5, 10, 15, 20, 25
            for (var i = 0; i < 5; i++)
            {
                key++;
                carryingCapacity = 5 + 5 * i;
                CarryingCapacity.Add(key, carryingCapacity);
            }
            // 30, 40, 50, 60, 70
            for (var i = 0; i < 5; i++)
            {
                key++;
                carryingCapacity = 30 + 10 * i;
                CarryingCapacity.Add(key, carryingCapacity);
            }
            // 80, 95, 110, 125
            for (var i = 0; i < 4; i++)
            {
                key++;
                carryingCapacity = 80 + 15 * i;
                CarryingCapacity.Add(key, carryingCapacity);
            }
            // 140, 160, 180
            for (var i = 0; i < 3; i++)
            {
                key++;
                carryingCapacity = 140 + 20 * i;
                CarryingCapacity.Add(key, carryingCapacity);
            }
            // 200, 230, 260, 290
            for (var i = 0; i < 4; i++)
            {
                key++;
                carryingCapacity = 200 + 30 * i;
                CarryingCapacity.Add(key, carryingCapacity);
            }
            // 330, 370, 410
            for (var i = 0; i < 2; i++)
            {
                key++;
                carryingCapacity = 330 + 40 * i;
                CarryingCapacity.Add(key, carryingCapacity);
            }
            // 460
            CarryingCapacity.Add(25, 460);
        }

        public static int GetAttributePointCost(int difference)
        {
            var cost = -99999;
            switch (difference)
            {
                case -2:
                    cost = -2;
                    break;

                case -1:
                    cost = -1;
                    break;

                case 0:
                    cost = 0;
                    break;

                case 1:
                    cost = 1;
                    break;

                case 2:
                    cost = 2;
                    break;

                case 3:
                    cost = 3;
                    break;

                case 4:
                    cost = 5;
                    break;

                case 5:
                    cost = 7;
                    break;

                case 6:
                    cost = 9;
                    break;

                case 7:
                    cost = 12;
                    break;

                case 8:
                    cost = 15;
                    break;

                default:
                    if (difference < -2)
                    {
                        cost = -2;
                    }
                    Debug.WriteLine("Attribute is outside expected normal value range.");
                    if (difference > 8)
                    {
                        throw new Exception("Attribute value cannot be more than 8 of the race's base attribute value");
                    }
                    break;
            }
            return cost;
        }

        private static void CreateStepTableList()
        {
            StepLookup.Add("0d0");                  // Step Number  // Max possible on dice rolled (no explosion)   // Number of dice rolled
            StepLookup.Add("1d2");                  // 1    2       1
            StepLookup.Add("1d3");                  // 2    3       1
            StepLookup.Add("1d4");                  // 3    4       1
            StepLookup.Add("1d6");                  // 4    6       1
            StepLookup.Add("1d8");                  // 5    8       1
            StepLookup.Add("1d10");                 // 6    10      1
            StepLookup.Add("1d12");                 // 7    12      1
            StepLookup.Add("2d6");                  // 8    12      2
            StepLookup.Add("1d8+1d6");              // 9    14      2
            StepLookup.Add("2d8");                  // 10   16      2
            StepLookup.Add("1d10+1d8");             // 11   18      2
            StepLookup.Add("2d10");                 // 12   20      2
            StepLookup.Add("1d12+1d10");            // 13   22      2
            StepLookup.Add("2d12");                 // 14   24      2
            StepLookup.Add("1d12+2d6");             // 15   24      3
            StepLookup.Add("1d12+1d8+1d6");         // 16   26      3
            StepLookup.Add("1d12+2d8");             // 17   28      3
            StepLookup.Add("1d12+1d10+1d8");        // 18   30      3
            StepLookup.Add("1d20+2d6");             // 19   32      3
            StepLookup.Add("1d20+1d8+1d6");         // 20   34      3
            StepLookup.Add("1d20+2d8");             // 21   36      3
            StepLookup.Add("1d20+1d10+1d8");        // 22   38      3
            StepLookup.Add("1d20+2d10");            // 23   40      3
            StepLookup.Add("1d20+1d12+1d10");       // 24   42      3
            StepLookup.Add("1d20+2d12");            // 25   42      3
            StepLookup.Add("1d20+1d12+2d6");        // 26   44      4
            StepLookup.Add("1d20+1d12+1d8+1d6");    // 27   46      4
            StepLookup.Add("1d20+1d12+2d8");        // 28   48      4
            StepLookup.Add("1d20+1d12+1d10+1d8");   // 29   50      4
            StepLookup.Add("2d20+2d6");             // 30   52      4
            StepLookup.Add("2d20+1d8+1d6");         // 31   54      4
            StepLookup.Add("2d20+2d8");             // 32   56      4
            StepLookup.Add("2d20+1d10+1d8");        // 33   58      4
            StepLookup.Add("2d20+2d10");            // 34   60      4
            StepLookup.Add("2d20+1d12+1d10");       // 35   62      4
            StepLookup.Add("2d20+2d12");            // 36   64      4
            StepLookup.Add("2d20+1d12+2d6");        // 37   64      5
            StepLookup.Add("2d20+1d12+1d8+1d6");    // 38   66      5
            StepLookup.Add("2d20+1d12+2d8");        // 39   68      5
            StepLookup.Add("2d20+1d12+1d10+1d8");   // 40   70      5
        }

        public static List<int> ParseActionDice(int stepNumber)
        {
            var actionDice = new List<int>();
            var differentDice = StepLookup[stepNumber].Split('+');
            foreach (var differentDie in differentDice)
            {
                var actualDie = differentDie.Split('d');
                var count = Convert.ToInt32(actualDie[0]);
                var value = Convert.ToInt32(actualDie[1]);
                for (var i = 0; i < count; i++)
                {
                    actionDice.Add(value);
                }
            }
            return actionDice;
        }

        public static string GetStepDice(int stepNumber)
        {
            return StepLookup[stepNumber];
        }

        public static int GetStepFromValue(int baseValue)
        {
            if (baseValue >= 0 && baseValue <= 40)
            {
                return Convert.ToInt32(Math.Round(Convert.ToDouble(baseValue) / 3 + 1, MidpointRounding.AwayFromZero));
            }
            throw new ArgumentException("Step values must be between 0 and 40.");
        }

        public static int GetCarryingCapacityFromAttributeValue(int baseValue)
        {
            if (baseValue >= 1 && baseValue <= 25)
            {
                return CarryingCapacity[baseValue];
            }
            throw new ArgumentException("BaseValue is outside attribute range.");
        }
    }
}