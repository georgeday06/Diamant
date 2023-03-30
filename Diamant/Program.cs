using System.Collections.Generic;
using System.Runtime.InteropServices;
int turn = 0;
int equaldiamonds = 0;
int depth = 0;
List<Player> playerCount = new List<Player>(); // Creates player list
setup(playerCount);
runGame(playerCount, turn, depth, equaldiamonds);

static void setup(List<Player> playerCount)
{
    Console.WriteLine("How many players would you like? (2-4 Players)");
    int players = Convert.ToInt32(Console.ReadLine()); // Saves the amount of players they need
    for (int i = 1; i <= players; i++)
    {
        Console.WriteLine("Write the name for player " + i);
        string n = Console.ReadLine();
        playerCount.Add(new Player(n)); // Creates the new player. Can be accessed with playerCount[i].METHOD
        Console.Clear();
    }
    Console.WriteLine("Do you need instructions? (Y/N)");
    string inst = Console.ReadLine();
    if (inst == "Y" || inst == "y")
    {
        instructions();
    }
}

static int checkTurn(int turn, List<Player> playerCount, int equaldiamonds)
{
    if (turn >= playerCount.Count)
    {
        for (int i = 0; i < playerCount.Count; i++)
        {
            if (playerCount[i].getReturn())
            {
                Console.WriteLine("Player {0} has returned to camp", playerCount[i].getName());
            }
            else
            {
                Console.WriteLine("Player {0} has looted {1} diamonds", playerCount[i].getName(), equaldiamonds);
            }
        }
        turn = 0;
    }
    return turn;
}
static bool checkReturn(int turn, List<Player> playerCount)
{
    bool inCamp = playerCount[turn].getReturn();
    if (inCamp == true)
    {
        return true;
    }
    else 
    {
        return false;
    }
}
static void instructions()
{
    Console.Clear();
    Console.WriteLine("The game is played in turns.");
    Console.WriteLine("Each player secretly chooses whether they want to return to camp with the diamonds they have collected so far, or explore the cave further.");
    Console.WriteLine("Players that continue to explore the cave reveal a new room that contains one of the following:");
    Console.WriteLine("1) Random number of diamonds that are shared between the players.");
    Console.WriteLine("2) Random peril, i.e. spiders, snakes, a spear trap or falling rocks.");
    Console.WriteLine("If the same peril is encountered twice in the game the explorers are wounded and unable to continue with their adventure. They finish the game with nothing.");
    Console.WriteLine("Press Enter to Continue");
    Console.ReadLine();
}

static void runGame(List<Player> playerCount, int turn, int depth, int equaldiamonds)
{
    bool gameOver = false;
    if (checkReturn(turn, playerCount) == true)
    {
        Console.WriteLine("Player " + playerCount[turn].getName() + ", has been skipped as they have returned to camp.");
        turn++;
        Console.Clear();
        turn = checkTurn(turn, playerCount, equaldiamonds);
        runGame(playerCount, turn, depth, equaldiamonds);
    }
    else
    {
        Console.WriteLine("Player " + playerCount[turn].getName() + ", it is your turn.");
        Console.WriteLine("Do you want to: ");
        Console.WriteLine("1) Go Deeper");
        Console.WriteLine("2) Return to camp");
        int choice = Convert.ToInt32(Console.ReadLine());
        if (choice == 1)
        {
            Console.WriteLine("You enter depth: " + depth);
            turn++;
            depth++;
            Console.Clear();
            turn = checkTurn(turn, playerCount, equaldiamonds);
            runGame(playerCount, turn, depth, equaldiamonds);
        }
        else if (choice == 2)
        {
            playerCount[turn].setReturn();
            Console.Clear();
            turn = checkTurn(turn, playerCount, equaldiamonds);
            runGame(playerCount, turn, depth, equaldiamonds);
        }
    }
 }

class Player
{
    private string name;
    private int diamonds;
    private bool inCamp;
    private bool Return;

    public Player(string n)
    {
        name = n;
        diamonds = 0;
        inCamp = true;
        Return = false;
    }

    public int getDiamondCount()
    {
        return diamonds;
    }
    
    public string getName()
    {
        return name;
    }
   
    public bool getInCamp()
    {
        return inCamp;
    }
    public bool getReturn()
    {
        return Return;
    }
    public void setReturn()
    {
        Return = true;
        inCamp = true;
    }

}