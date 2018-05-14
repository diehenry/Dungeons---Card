using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : IAttributes
{
    #region Attributes
    public abstract int HP { get; }

    public abstract int Energy { get; }
    public abstract int Defense { get; }
    #endregion

    #region Item
    public List<Treasure> OwnTreasures { get; set; }
    public List<Potion> OwnPotion { get; set; }
    #endregion


    public abstract void Attack(Monster monster);


    public void Death()
    {

    }
}

