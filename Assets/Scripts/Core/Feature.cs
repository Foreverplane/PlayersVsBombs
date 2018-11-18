using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Core
{
    public abstract class Feature
    {
        private readonly Context _context;

        protected Feature(Context context)
        {
            _context = context;
        }

        protected void AddSystem(ContextSystem system)
        {
            _context.AddSystem(system);
        }
    }
}
