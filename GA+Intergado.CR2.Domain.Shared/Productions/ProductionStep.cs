using System;
using System.Collections.Generic;
using System.Text;

namespace GA_Intergado.CR2.Domain.Shared.Productions
{
    public enum ProductionStep
    {
        Waiting = 0,
        Dosing = 1,
        Paused = 2, 
        Mixing = 3,
        Loaded = 4
    }
}
