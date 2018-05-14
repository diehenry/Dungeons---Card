using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Potion
{
    public abstract void Effect(Character character);
    public abstract string Description();
}
