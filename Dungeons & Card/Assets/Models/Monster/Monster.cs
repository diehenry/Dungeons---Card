using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : IAttributes
{
    #region Attributes
    public abstract int HP { get; set; }
    public abstract int Defense { get; }
    #endregion


    public abstract void Attack(Character monster);
}
