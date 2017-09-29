using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthdawnGamemasterAssistant.Actions
{
    public class NullAction : ActionType
    {
        protected override ActionName _ActionName => ActionName.NotApplicable;
    }
}
