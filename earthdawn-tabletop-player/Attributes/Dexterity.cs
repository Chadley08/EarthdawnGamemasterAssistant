﻿namespace earthdawn_tabletop_player.Attributes
{
    public class Dexterity
    {
        public int Value { get; }

        public Dexterity(int value)
        {
            Value = value;
        }

        public string Name => "Dexterity";
    }
}