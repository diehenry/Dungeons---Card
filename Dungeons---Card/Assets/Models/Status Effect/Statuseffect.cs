using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

enum BUFForDEBUFF
{
    BUFF,
    DEBUFF
}

abstract class StatusEffect
{
    abstract public BUFForDEBUFF BUFForDEBUFF { get;}
    public abstract void Effect(Character character);
}

