namespace EarthdawnGamemasterAssistant
{
    public class Character
    {
        public CharacterInfo Info { get; }

        public Character(CharacterInfo info)
        {
            Info = info;
        }

        //public int CanModifyAttribute(int baseValue, int currentValue, int availableAttributePoints)
        //{
        //    var amountAlteredFromBaseValue = currentValue - baseValue;
        //    int cost;
        //    switch (amountAlteredFromBaseValue)
        //    {
        //        case -2:
        //            cost = -2;
        //            break;
        //        case -1:
        //            cost = -1;
        //            break;
        //        case 0:
        //            return;
        //        case 1:
        //            cost = 1;
        //            break;
        //        case 2:
        //            cost = 2;
        //            break;
        //        case 3:
        //            cost = 3;
        //            break;
        //        case 4:
        //            cost = 5;
        //            break;
        //        case 5:
        //            cost = 7;
        //            break;
        //        case 6:
        //            cost = 9;
        //            break;
        //        case 7:
        //            cost = 12;
        //            break;
        //        case 8:
        //            cost = 15;
        //            break;
        //        default:
        //            Debug.WriteLine("Cannot increase an attribute by more than 8 when creating a character");
        //            return;
        //    }
        //    if (availableAttributePoints - cost > 0)
        //    {
        //        availableAttributePoints -= cost;
        //    }
        //    AvailableAttributePoints = availableAttributePoints;
        //}

        //public void ApplyRacials(IRace toApply)
        //{
        //    RacialAbilities = toApply.GetRacialAbilities();
        //}
    }
}