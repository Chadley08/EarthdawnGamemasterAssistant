using earthdawn_tabletop_player.Racial;
using System;
using System.Collections.Generic;

namespace earthdawn_tabletop_player
{
    public class Character
    {
        private Discipline _Discipline { get; }
        private Race _Race { get; }
        private Circle _Circle { get; }
        public int AttributePoints { get; }


        private Character(Circle circle, Discipline discipline, Race race, int attributePoints)
        {
            _Circle = circle;
            _Discipline = discipline;
            _Race = race;
            AttributePoints = attributePoints;
        }

        public static Character CreateCharacter(Circle circle, Discipline discipline, Race race)
        {
            return new Character(circle, discipline, race, 25);
        }

        public Character ModifyCharacterAttribute(Attribute toModify, int amount)
        {
            var cost = 0;
            switch(amount)
            {
                case -2:
                    cost = -2;
                    break;
                case -1:
                    cost = -1;
                    break;
                case 0:
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
                    throw new Exception("Cannot modify an attribute value by reducing it more than 2 or increasing it more than 8.");
            }
            var availableAttributePoints = AttributePoints - cost;
            var race = new Race()
            return new Character(_Circle, _Discipline, _Race, AttributePoints - cost);                        
        }
    }
}