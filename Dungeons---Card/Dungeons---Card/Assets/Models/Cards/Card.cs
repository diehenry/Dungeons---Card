using Assets.Models.Characters;
using Assets.Models.Monsters;
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

    public abstract class Card : MonoBehaviour
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
    
    public class DoCard : Card
    {
        public string cardName;
        public int cost;
        public string description;
        public DoCard(string cardName , int cost, string description , Rarity rarity)
        {
            this.cardName = cardName;
            this.cost = cost;
            this.description = description;
   
        }
        public List<DoCard> Initialization()
        {
            List<DoCard> cardList = new List<DoCard>();
            cardList.Add(new DoCard("Little Attack",  1, "敵人遭受2點傷害", Rarity.Common));
            cardList.Add(new DoCard("Middle Attack",  3, "敵人遭受5點傷害", Rarity.Epic));
            cardList.Add(new DoCard("Big Attack",     5, "敵人遭受10點傷害", Rarity.Rare));
            cardList.Add(new DoCard("Little Defense", 1, "增加自身防禦2點", Rarity.Common));
            cardList.Add(new DoCard("Middle Defense", 3, "增加自身防禦5點", Rarity.Epic));
            cardList.Add(new DoCard("Big Defense",    5, "增加自身防禦10點", Rarity.Rare));
            return cardList;
        }

         
        public override string Name
        {
            get { return cardName; }
        }
        public override int Cost
        {
            get { return cost ; }
        }
        public override Rarity CardRarity {
            get { return Rarity.Common; }
        }
        public override void Abilities(Character characters, Monster monster) { }
        public override string Description()
        {
           return "Description : " + description    ;
        }

   /*     Dictionary<string, DoCard> dic = new Dictionary<string, DoCard>()
        {
             {"Little Attack" ,new DoCard(1,"敵人遭受2點傷害")}, {"Middle Attack", new DoCard(3,"敵人遭受5點傷害") } , {"Big Attack",new DoCard(5,"敵人遭受10點傷害") } ,
             {"Little Defense",new DoCard(1,"增加自身防禦2點")}, {"Middle Defense",new DoCard(3,"增加自身防禦5點") } , {"Big Defense",new DoCard(5,"增加自身防禦10點") }
        };*/

        public void Start()
        {

        }
        public void Update()
        {
            
        }
    }
}


