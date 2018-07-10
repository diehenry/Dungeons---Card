using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Assets.Models.Items;
using Assets.Models.Monsters;
using Assets.Models.Cards;
using UnityEngine.UI;

namespace Assets.Models.Characters
{

    interface IAttributes
    {
        int HP { get; }
        int Defense { get; }

    }
    public abstract class Character : MonoBehaviour, IAttributes 
    {
        #region Attributes
        /// <summary>
        /// 血量
        /// </summary>
        public abstract int HP { get; }
        /// <summary>
        /// 精力
        /// </summary>
        public abstract int Energy { get; }
        /// <summary>
        /// 防禦
        /// </summary>
        public abstract int Defense { get; }
        #endregion

        #region Item
        /// <summary>
        /// 擁有的寶物
        /// </summary>
        public List<Treasure> OwnTreasures { get; set; }
        /// <summary>
        /// 擁有的藥水
        /// </summary>
        public List<Potion> OwnPotion { get; set; }
        #endregion


        public abstract void PlayCard(Card card, Monster monster);


        public void Death()
        {

        }

    }
    /// <summary>
    /// 職業 :戰士
    /// </summary>
    public class Warrior : Character
    {
        public int hp = 100;
        public int energy = 20;
        public int defense = 10;
        public int damage;
        public override int HP
        {
            get
            {
                if(hp > 0)
                {
                    hp = hp - damage;
                }
                return hp;
                
            }
        }
        public override int Energy
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }
        public override int Defense
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }
        public override void PlayCard(Card card, Monster monster)
        {

        }

    }


}
