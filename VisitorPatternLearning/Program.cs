using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPatternLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            var heroStructure = new CardCollection();
            heroStructure.Add(new Character { Name = "Junkrat", Fraction = "Ogres", Damage = 5, Health = 2 });
            heroStructure.Add(new Spell { Name = "Big bomb", Cost = 3, Description = "Destroyed all cards on a table"});
            heroStructure.Accept(new HeroVisitor());
            Console.WriteLine();

            var unitStructure = new CardCollection();
            unitStructure.Add(new Character { Name = "Big Rat", Fraction = "Ogres", Damage = 2, Health = 4 });
            unitStructure.Add(new Spell { Name = "Sacrifice", Cost = 4, Description = "Add 2 health to your hero and destroy Big Rat card" });
            unitStructure.Accept(new UnitVisitor());

            Console.Read();
        }
    }

    //Visitor
    interface ICardVIsitor
    {
        void VisitCharacterCard(Character character);
        void VisitSpellCard(Spell spell);
    }

    // Concrete Visitor
    class HeroVisitor : ICardVIsitor
    {
        public void VisitCharacterCard(Character character)
        {
            string result = $"Character card | {character.Name} " +
                $"\n Fraction | {character.Fraction} \n Damage | {character.Damage} \n Health | {character.Health} ";
            
            Console.WriteLine(result);
        }

        public void VisitSpellCard(Spell spell)
        {
            string result = $"Spell card || {spell.Name} " +
                $"\n Cost || {spell.Cost} \n Desctiption || {spell.Description} ";
            Console.WriteLine(result);
        }
    }

    // Concrete Visitor
    class UnitVisitor : ICardVIsitor
    {
        public void VisitCharacterCard(Character character)
        {
            string result = $"Unit Character card // {character.Name} " +
                $"\n Fraction // {character.Fraction} \n Damage // {character.Damage} \n Health // {character.Health} ";

            Console.WriteLine(result);
        }

        public void VisitSpellCard(Spell spell)
        {
            string result = $"Spell card |||| {spell.Name} " +
                $"\n Cost |||| {spell.Cost} \n Desctiption |||| {spell.Description} ";
            Console.WriteLine(result);
        }
    }

    //Object structure
    class CardCollection
    {
        List<ICard> cardCollectionList = new List<ICard>();
        public void Add(ICard card)
        {
            cardCollectionList.Add(card);
        }
        public void Remove(ICard card)
        {
            cardCollectionList.Remove(card);
        }
        public void Accept(ICardVIsitor cardVisitor)
        {
            foreach (ICard card in cardCollectionList)
                card.Accept(cardVisitor);
        }
    }

    //Element
    interface ICard
    {
        void Accept(ICardVIsitor visitor);
    }

    //Concrete Element
    class Character : ICard
    {
        public string Name { get; set; }
        public string Fraction { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public void Accept(ICardVIsitor visitor)
        {
            visitor.VisitCharacterCard(this);
        }
    }

    //Concrete Element
    class Spell : ICard
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public string Description { get; set; }

        public void Accept(ICardVIsitor visitor)
        {
            visitor.VisitSpellCard(this);
        }
    }
}
