using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthdawnGamemasterAssistant.Attributes
{
    public class NullAttribute : EarthdawnAttribute
    {
        public NullAttribute() : base(0)
        {
        }

        public override string Name => "";
    }
}
