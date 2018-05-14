using Assets.Models.Characters;
using Assets.Models.Monsters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Models.Items
{
    public abstract class Potion
    {
        /// <summary>
        /// 描述卡片
        /// </summary>       
        public abstract string Description { get; }
        public abstract void Use(Character character);
        public abstract void Use(Monster monster);
    }
}

