using Assets.Models.Characters;
using Assets.Models.Monsters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Models.Cards
{
    public enum Rarity
    {
        Common,
        Rare,
        Epic
    }

    public abstract class Card
    {
        /// <summary>
        /// 名稱
        /// </summary>
        public abstract string Name { get; }
        /// <summary>
        /// 卡片稀有度
        /// </summary>
        public abstract Rarity CardRarity { get; }
        /// <summary>
        /// 花費
        /// </summary>
        public abstract int Cost { get; }
        public abstract void Abilities(Character characters,Monster monster);
        public abstract string Description();

    }

	
	
}

