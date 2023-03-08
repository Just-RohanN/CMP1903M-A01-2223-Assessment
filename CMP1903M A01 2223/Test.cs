using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Test
    {
        Pack testPack = new Pack(); //Creates a pack to be tested on
        public void shuffle() //Tests the shuffle functions 
        {
            
            testPack.returnPack();
            testPack.shuffleCardPack(1); //Tests the fisher-Yates shuffle
            testPack.returnPack();
            testPack.shuffleCardPack(2); //Tests the Riffle Shuffle
            testPack.returnPack();
            testPack.shuffleCardPack(3); //Tests the 'No suffle' option
            
            

        }

        public void testDeal() //Tests the card dealing methods 
        {
            Card card = testPack.dealCard(); //Deals a card and saves it as a new card
            System.Console.WriteLine("You were dealt:");
            System.Console.WriteLine(card.printValues()[0].ToString() + " " + card.printValues()[1].ToString()); //Prints out the suit and value of the card



            List<Card> cards = testPack.dealCard(20); //Deals out 20 cards - can change the number to change how many cards are dealt
            System.Console.WriteLine("You were dealt:");
            foreach(Card singleCard in cards) //For loop to iterate for each card
            {

                System.Console.WriteLine(singleCard.printValues()[0].ToString() + " " + singleCard.printValues()[1].ToString()); //Prints the suit ad value of the card
            }
            


            string h = Console.ReadLine(); //Allows the tester to read through the output instead of the window disappearing
        }

        
        

    }

}

