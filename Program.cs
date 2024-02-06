using System.ComponentModel;
using System.Security.AccessControl;

namespace myAdventure
{
    class CIT195
    {
        static void Main(string[] args)
        {
            int time = 0, hope = 0, confusion = 0, dir = 0, round = 0;
            Random dice = new Random();
            bool success = false;
            
            Console.WriteLine();
            Console.WriteLine("You arrived on campus to take a test.  The test is scheduled, and you cannot be late.");
            Console.WriteLine("But you are a remote student, you have never been on campus before. You must find the Test Room");
            Console.WriteLine("before your time is up!");
            Console.WriteLine();
            
            startingValues(ref time, ref hope, ref confusion, dice);

            while (time > 0 && hope > 0 && confusion < 100 && success == false)
            {
                dir = chooseDirection();

                if (dir == 1)
                    result(dice.Next(4), ref time, ref hope, ref confusion);
                else
                    result(dice.Next(10), ref time, ref hope, ref confusion);
                checkResults(ref round, ref time, ref hope, ref confusion, ref success);
            }
            if (success)
            {
                Console.WriteLine();
                Console.WriteLine("You found the Test Room!  Good luck on your test!");
            }
            else if (time <= 0)
            {
                Console.WriteLine();
                Console.WriteLine("You took too long, and missed your test appointment!");
            }
            else if (hope <= 0)
            {
                Console.WriteLine();
                Console.WriteLine("It's no use, you're hopelessy lost.  You fall to the floor, sobbing gently.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("You are totally confused now.  Even if you could find the Test Room, your brain is too fried to take a test.");
            }

        }

        private static void checkResults(ref int round, ref int time, ref int hope, ref int confusion, ref bool success)
        {
            round++;
            Console.WriteLine();
            Console.WriteLine($"At the end of round {round}, ");
            if (confusion < 0)
                confusion = 0;  
            Console.WriteLine($"you have {time} minutes left, your hope is at {hope}, and you are {confusion}% confused.");
            if (round >= 20)
                success = true;
            return;
        }

        private static void result(int v, ref int time, ref int hope, ref int confusion)
        {
            switch (v)
            {
                case 0:
                    Console.WriteLine();
                    Console.WriteLine("You go down a long hall, and at the end is the door to the Library.  This was the wrong way!");
                    Console.WriteLine("You wasted one minute, your hope sinks, and your confusion increases 10%.");
                    Console.WriteLine("There is another hallway on your left and another on your right.");
                    time -= 1;
                    hope -= 1;
                    confusion += 10;
                    break;
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("You run into a classmate! He gives you directions, but they lead you to the dormitory.");
                    Console.WriteLine("You wasted one minute, your hope sinks, and your confusion increases 10%.");
                    Console.WriteLine("Behind you, in the hallway, is a door on your left and another on your right.");
                    time -= 1;
                    hope -= 1;
                    confusion += 10;
                    break;
                case 2:
                    Console.WriteLine();
                    Console.WriteLine("That way actually lead to an elevator that only goes down.  You're in the furnace room!!");
                    Console.WriteLine("You waste three minutes down there, your hope drops, and your confusion increases 30%.");
                    Console.WriteLine("You find a stairway on your left and another on your right");
                    time -= 3;
                    hope -= 2;
                    confusion += 30;
                    break;
                case 3:
                    Console.WriteLine();
                    Console.WriteLine("You see a sign on the wall that says TEST ROOM and an arrow pointing ahead! You are getting closer!");
                    Console.WriteLine("You spent a minute, but you feel a little more hopeful and a little less confused.");
                    Console.WriteLine("At the end of the hall, you can either turn left or right");
                    time -= 1;
                    hope += 1;
                    confusion -= 10;
                    break; 
                case 4:
                    Console.WriteLine();
                    Console.WriteLine("You go up a staircase, and stop.  This looks familiar.  Wait, weren't you just here?!?");
                    Console.WriteLine("You wasted another minute, your hope drops, and your confusion goes WAY up.");
                    Console.WriteLine("Go back down the stairs on your left, or thru the door on the right.");
                    time -= 1;
                    hope -= 2;
                    confusion += 30;
                    break;
                case 5:
                    Console.WriteLine();
                    Console.WriteLine("You see a sign on the wall that says TEST ROOM and an arrow pointing ahead! You are getting closer!");
                    Console.WriteLine("You spent a minute, but you feel a little more hopeful and a little less confused.");
                    Console.WriteLine("At the end of the hall, you can either turn left or right");
                    time -= 1;
                    hope += 1;
                    confusion -= 10;
                    break;
                case 6:
                    Console.WriteLine();
                    Console.WriteLine("You see a sign on the wall that says TEST ROOM and an arrow pointing ahead! You are getting closer!");
                    Console.WriteLine("You spent a minute, but you feel a little more hopeful and a little less confused.");
                    Console.WriteLine("At the end of the hall, you can either turn left or right");
                    time -= 1;
                    hope += 1;
                    confusion -= 10;
                    break;
                case 7:
                    Console.WriteLine();
                    Console.WriteLine("You just stepped thru a time portal!");
                    Console.WriteLine("You went back in time three minutes! You feel much more hopeful.");
                    Console.WriteLine("At the end of the hall, you can either turn left or right");
                    time += 3;
                    hope += 2;
                    break;
                case 8:
                    Console.WriteLine();
                    Console.WriteLine("You see a sign on the wall that says TEST ROOM and an arrow pointing ahead! You are getting closer!");
                    Console.WriteLine("You spent a minute, but you feel a little more hopeful and a little less confused.");
                    Console.WriteLine("At the end of the hall, you can either turn left or right");
                    time -= 1;
                    hope += 1;
                    confusion -= 10;
                    break;
                case 9:
                    Console.WriteLine();
                    Console.WriteLine("You run into a classmate!  But she steers you the wrong way.  You are at the school store.");
                    Console.WriteLine("You wasted a minute, and you lose a little hope.");
                    Console.WriteLine("At the end of the hall, you can either turn left or right");
                    time -= 1;
                    hope -= 1;
                    break;
                case 10:
                    Console.WriteLine();
                    Console.WriteLine("You ran into your instructor!  She takes you directly to the Test Room.");
                    Console.WriteLine("You made it on time!");
                    break;
            }
        }

        private static int chooseDirection()
        {
            Console.WriteLine();
            Console.WriteLine("You are at the end of a hallway.  Enter 1 to go thru the door on the left, or 2 to go thru the door on the right.");

            int dir = int.Parse(Console.ReadLine());

            while (dir != 1 && dir != 2)
            {
                Console.WriteLine() ;
                Console.WriteLine("Let's try that again.  Enter either a 1 or a 2.");
                dir = int.Parse(Console.ReadLine());
            }
            return dir;
        }

        private static void startingValues(ref int time, ref int hope, ref int confusion, Random dice)
        {
            time = dice.Next(10) + 5;
            hope = dice.Next(10) + 5;
            return;
        }
    }
}