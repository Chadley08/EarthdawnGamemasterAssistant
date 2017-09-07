using System;

namespace earthdawn_tabletop_player.Talents
{
    public class FreeAction : ActionType
    {
        public FreeAction()
        {
            
        }

        protected override ActionName _ActionName => ActionName.Free;
    }
}