using System;
using System.Diagnostics;

namespace EarthdawnGamemasterAssistant.Attributes
{
    public class Attribute
    {
        public int Value { get; }

        public Attribute(int value)
        {
            Value = value;
        }

        public bool ShowWarning { get; private set; }

        public int Modify(int baseValue, int currentValue, int availableAttributePoints)
        {
            var amountAlteredFromBaseValue = currentValue - baseValue;
            
            // [NOTE]: Compiler is complaining that cost may not be initialized, but all
            // possible cases are covered in the switch statement below.
            var cost = -99999;
            switch (amountAlteredFromBaseValue)
            {
                case -2:
                    cost = -2;
                    break;

                case -1:
                    cost = -1;
                    break;

                case 0:
                    return availableAttributePoints;

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
                    if (amountAlteredFromBaseValue < -2)
                    {
                        ShowWarning = true;
                        cost = -2;
                    }
                    Debug.WriteLine("Attribute is outside expected normal value range.");
                    if (amountAlteredFromBaseValue > 8)
                    {
                        throw new Exception("Attribute value cannot be more than 8 of the race's base attribute value");
                    }
                    break;
            }
            ShowWarning = false;
            availableAttributePoints -= cost;
            if (availableAttributePoints < 0)
            {
                ShowWarning = true;
            }
            return availableAttributePoints;
        }
    }
}