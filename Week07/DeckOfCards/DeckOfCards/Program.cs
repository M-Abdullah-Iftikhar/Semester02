using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeckOfCards.BL;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = 0;

            do
            {
                Console.WriteLine("Enter 1 to PLay the Game");
                Console.WriteLine("Enter 2 to Exit the Game");
                option = int.Parse(Console.ReadLine());
                Console.Clear();
                if (option == 1)
                {
                    bool gameRunning = true;
                    int score = 0;
                    Deck obj = new Deck();

                    obj.shuffle();

                    Card card1 = obj.dealCard();

                    while (gameRunning)
                    {
                        int remainCheck = obj.cardsLeft();

                        Card card2 = obj.dealCard();
                        Console.WriteLine("*************************");
                        Console.WriteLine(card1.toString());
                        Console.WriteLine("");
                        Console.WriteLine("*** Remaining Cards *** : " + remainCheck);
                        Console.WriteLine("Enter 1 if Next Card is Higher. ");
                        Console.WriteLine("Enter 2 if Next Card is Lower. ");

                        int cardCheck = int.Parse(Console.ReadLine());
                        Console.Clear();

                        if (cardCheck == 1)
                        {
                            if (card2.getValue() >= card1.getValue())
                            {
                                score++;
                                card1 = card2;
                            }
                            else
                            {
                                gameRunning = false;
                                Console.WriteLine("Sorry You Lost, Press any key to continue");
                                Console.WriteLine("The card was : " + card2.toString());
                                Console.WriteLine("Your score is : " + score);
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("");
                            }
                            if (cardCheck == 2)

                            {

                                if (card2.getValue() < card1.getValue())
                                {
                                    score++;
                                    card1 = card2;
                                }
                                else
                                {
                                    gameRunning = false;
                                    Console.WriteLine("Sorry You Lost, Press any key to continue");
                                    Console.WriteLine("The card was : " + card2.toString());
                                    Console.WriteLine("Your score is : " + score);
                                    Console.ReadKey();
                                    Console.Clear();
                                    Console.WriteLine("");
                                }


                            }

                            if (obj.cardsLeft() == 0 && card2 == null)
                            {
                                gameRunning = false;
                                Console.WriteLine("Congrats, You Scored Maximum ");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                        }



                    }
                }
            } while (option != 2);
        }
    }
}
