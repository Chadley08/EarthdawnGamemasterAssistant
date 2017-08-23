namespace earthdawn_tabletop_player
{
    public class Durability : Talent
    {
        public int Rank { get; }

        // [NOTE]: Might want to make different types of Talent - like disciplined and not disciplined.
        public Durability(int rank)
        {
            Rank = rank;
        }
    }
}