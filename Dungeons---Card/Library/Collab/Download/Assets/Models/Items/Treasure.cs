using Assets.Models.Characters;
using Assets.Models.Monsters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Models.Items
{
    public abstract class Treasure
    {
        /// <summary>
        /// 描述卡片
        /// </summary>       
        public abstract string Description { get; }
        public abstract void Effect(Character character,Monster monster);
    }
}

