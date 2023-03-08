using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    public class Pack
    {
        List<Card> pack = new List<Card>(); //Creates a new pack

        public Pack()
        {

            //New pack is initialized


            foreach (int suit in Enumerable.Range(1,4)) //For each of the 4 suits, iterates 13 times
            {
                foreach(int value in Enumerable.Range(1,13))
                {
                    Card newCard = new Card(); //New card is created
                    newCard.Suit = suit; //Suit is assigned
                    newCard.Value = value; //Value is assigned
                    pack.Add(newCard); //New card is added to the pack

                }
            }
            
        }

        public void returnPack() //Prints out each cards suit and value in the pack
        {
            foreach(Card card in pack)
            {
                System.Console.WriteLine(card.Suit.ToString() + " " + card.Value.ToString());
            }
        }

        public bool shuffleCardPack(int typeOfShuffle)
        {
            //Shuffles the pack based on the type of shuffle

            if (pack.Count <= 1) //If the pack is too small, the pack wont be shuffled
            {
                Console.WriteLine("Cannot Shuffle - Not enough cards");
                return false;
            }


            else if (typeOfShuffle == 1) //If 1 is selected, the Fisher-Yates shuffle runs
            {
                Console.WriteLine("Option 1: Fisher-Yates");
                int packSize = pack.Count; //Count and position are defined
                int packPosition = 0;
                Card tempCard; //Temporary card is created

                foreach(Card card in pack.ToList())
                {
                    if (packPosition == (packSize - 1)) //If the position is the final card, it will not run
                    {
                        break;
                    }
                    else
                    {
                        //A random number is generated between the position and end, and the card is swapped with the card at that index
                        Random randomNum = new Random();
                        var rnd = randomNum.Next(packPosition, packSize);
                        tempCard = card;
                        pack[packPosition] = pack[rnd];
                        pack[rnd] = tempCard; 
                    }

                    packPosition++;
                    

                }
                return true;
            }

            else if (typeOfShuffle == 2) //Riffle shuffle runs if 2 is selected

                //Pack is split in two, into two seperate lists, and then cards are added back into the pack alternatively 
            {
                Console.WriteLine("Option 2: Riffle");

                int half = (pack.Count / 2);
                List<Card> firstHalf = new List<Card>();
                List<Card> secondHalf = new List<Card>();
                int firstCount = firstHalf.Count();
                int secondCount = secondHalf.Count();

                for (int i = 0; i < half; i++)
                {
                    firstHalf.Add(pack[i]);
                }
                for(int i = half; i < (pack.Count()); i++)
                {
                    secondHalf.Add(pack[i]);
                }
                pack.Clear();
                for(int i = 0; i < half; i++)
                {
                    pack.Add(firstHalf[i]);
                    pack.Add(secondHalf[i]);
                    

                }
                return true;
            }

            else if (typeOfShuffle == 3) //Pack wont be shuffled if 3 is selected
            {
                Console.WriteLine("Option 3: Pack not shuffled");
                return true;
            }

            else
            {

                //If any other input other than 1,2 or 3 is put in, the pack will not be shuffled 

                Console.WriteLine("No valid option selected, pack was not shuffled");
                return false;
            }

        }
        public Card dealCard()
        {
            //Deals one card
            Card cardToDeal = pack[0];
            pack.RemoveAt(0); //Removes card from the pack
            return cardToDeal;

        }
        public List<Card> dealCard(int amount)
        {
            //Deals the number of cards specified by 'amount'
            List<Card> dealtCards = new List<Card>();
            foreach(int card in Enumerable.Range(0, amount))
            {
                dealtCards.Add(pack[0]);
                pack.RemoveAt(0);
            }
            return dealtCards;
        }
    }
}
