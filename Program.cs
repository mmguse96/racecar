using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace raceCar
{
    class Program
    {
        static void Main(string[] args)
        {
            string player = "C", obs = "X";
            int OP = 0, P=0;
            string playagain = "yes";

            while (playagain.Equals("yes"))
            {
                string[,] Track =
                {
                {" "," "," "}, //row 0
                {" "," "," "}, //row 1
                {" "," "," "}, //row 2
                {" "," "," "} //row 3
                };

                
                Boolean loseCondition = false;
                while (loseCondition == false)
                {
                    int counter = 0;
                    
                    obsPos(ref Track, obs,ref OP);
                    while (counter < 4)
                    {
                        displayTrack(Track);
                        playerMove(ref Track, player, ref P);
                        obsMove(ref Track, obs, OP, player, counter,P);
                        
                        counter = counter + 1;
                        if (counter == 3)
                        {
                            loseCondition = checkLoss(loseCondition, counter, OP, player, Track, P);
                        }
                    }
                    if (loseCondition == true)
                    {
                        displayTrack(Track);
                        break;
                    }

                }
                Console.WriteLine("do you want to try again?");
                playagain = Console.ReadLine();
            }

            Console.ReadLine();
        }
        public static void displayTrack(string[,] Track)
        {
            Console.WriteLine("--watch for obsticles--");
            //row 1
            Console.Write("    | ");
            Console.Write(Track[0, 0]);
            Console.Write(" | ");
            Console.Write(Track[0, 1]);
            Console.Write(" | ");
            Console.Write(Track[0, 2]);
            Console.WriteLine(" | ");

           // row 2
            Console.Write("    | ");
            Console.Write(Track[1, 0]);
            Console.Write(" | ");
            Console.Write(Track[1, 1]);
            Console.Write(" | ");
            Console.Write(Track[1, 2]);
            Console.WriteLine(" | ");

            //row 3
            Console.Write("    | ");
            Console.Write(Track[2, 0]);
            Console.Write(" | ");
            Console.Write(Track[2, 1]);
            Console.Write(" | ");
            Console.Write(Track[2, 2]);
            Console.WriteLine(" | ");

            //row 4
            Console.Write("    | ");
            Console.Write(Track[3, 0]);
            Console.Write(" | ");
            Console.Write(Track[3, 1]);
            Console.Write(" | ");
            Console.Write(Track[3, 2]);
            Console.WriteLine(" | ");
        }
        public static void obsPos(ref string[,] Track, string obs, ref int OP)
        {
            //clears previous object
            Track[0, 0] = " ";
            Track[0, 1] = " ";
            Track[0, 2] = " ";
            
            Random ran = new Random();
              OP = ran.Next(-1,3);
            while (OP <0 || OP > 2)
            {              
                OP = ran.Next(-1, 3);
            }

            Track[0, OP] = obs;
            
        }
        public static void playerMove(ref string[,] Track, string player, ref int P)
        {
            //clears previous move
            Track[3, 0] = " ";
            Track[3, 1] = " ";
            Track[3, 2] = " ";

            Console.WriteLine("Please choose where you will move");
            P = Convert.ToInt32(Console.ReadLine());
            while (P < 0 || P > 2)
            {
                Console.WriteLine("please enter a value between 0 and 2");
                 P = Convert.ToInt32(Console.ReadLine());
            }

                Track[3, P] = player;
        }
        public static void obsMove(ref string[,] Track,string obs, int OP, string player, int counter, int P)
        {
            //clear row 0
            Track[0, 0] = " ";
            Track[0, 1] = " ";
            Track[0, 2] = " ";
            //clear row 1
            Track[1, 0] = " ";
            Track[1, 1] = " ";
            Track[1, 2] = " ";
            //clear row 2
            Track[2, 0] = " ";
            Track[2, 1] = " ";
            Track[2, 2] = " ";
            //clear row 3
            Track[3, 0] = " ";
            Track[3, 1] = " ";
            Track[3, 2] = " ";

            //refresh player location
            Track[3, P] = player;

            Track[counter, OP] = obs;
            
                               
        }
        public static Boolean checkLoss(Boolean loseCondition, int counter, int OP, string player, string[,] Track, int P)
        {
            if (Track[counter, OP] == Track[3, P])
            {
                loseCondition = true;
            }
            return loseCondition;
        }
    }
}
