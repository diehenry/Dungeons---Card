using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Models.Characters;

namespace Assets.Models.Monsters
{
    public abstract class Monster : IAttributes
    {
        #region Attributes
        public abstract int HP { get; set; }
        public abstract int Defense { get; }
        #endregion


        public abstract void Attack(Character monster);
    }
}

