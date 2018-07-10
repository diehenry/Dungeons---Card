using Assets.Models.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Models.Status_Effects
{
    enum BUFForDEBUFF
    {
        BUFF,
        DEBUFF
    }

    abstract class StatusEffect
    {
        public abstract BUFForDEBUFF BUFForDEBUFF { get; }
        public abstract void Effect(IAttributes character);
    }
}



