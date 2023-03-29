using System.Runtime.InteropServices;
int turn = 0;
int depth = 0;
List<Player> playerCount = new List<Player>(); // Creates player list
setup(playerCount);
runGame(playerCount, turn, depth);

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

static void runGame(List<Player> playerCount, int turn, int depth)
{
    bool gameOver = false;
    Console.WriteLine("Do you need instructions? (Y/N)");
    string inst = Console.ReadLine();
    if (inst == "Y" || inst == "y")
    {
        instructions();
    }
    while (gameOver == false)
    {
        Console.WriteLine("Player " + playerCount[turn].getName() + ", it is your turn.");
        Console.WriteLine()
        Console.WriteLine("You enter depth: " + depth);
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

}