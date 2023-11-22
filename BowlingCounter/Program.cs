using Bowling;

public class Program
{
    static readonly BowlingCounter BC = new();
    public static void Main(string[] args)
    {

        Console.WriteLine("Welcome to the Bowling Counter!");
        AddPlayerDisplay();
        GameLoop();
    }

    private static void AddPlayerDisplay()
    {
        Console.WriteLine("Please enter the number of players between 1 and 6:");
        int numberOfPlayers;
        while (!int.TryParse(Console.ReadLine(), out numberOfPlayers) || !BC.CheckNumberOfPlayers(numberOfPlayers))
        {
            Console.WriteLine("Invalid number of players. Please enter a valid number.");
        }

        for (int i = 0; i < numberOfPlayers; i++)
        {
            string? name;
            do
            {
                Console.WriteLine("Please enter the name of player " + (i + 1) + ":");
                name = Console.ReadLine();

                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Name cannot be empty. Please enter a valid name.");
                }
            } while (string.IsNullOrEmpty(name) || BC.CheckPlayerNameExists(name));

            BC.AddPlayer(name);
        }
        Console.WriteLine("Players added successfully: " + string.Join(", ", BC.scoreBoard.Keys));
    }

    private static void GameLoop()
    {
        while (true)
        {
            foreach (var player in BC.scoreBoard)
            {
                Console.WriteLine("It's " + player.Key + "'s turn.");
                Console.WriteLine("Please enter the number of pins knocked over:");
                int knockedOverPins;
                while (!int.TryParse(Console.ReadLine(), out knockedOverPins) || knockedOverPins > 10 || knockedOverPins < 0)
                {
                    Console.WriteLine("Invalid number of pins knocked over. Please enter a valid number.");
                }

                int leftOverPins = BC.CalculateLeftOverPins(knockedOverPins);
                Console.WriteLine("Number of pins left over: " + leftOverPins);
                if (leftOverPins == 0)
                {
                    Console.WriteLine("Strike!");
                }
                else if (leftOverPins == 10)
                {
                    Console.WriteLine("Spare!");
                }
                else
                {
                }
            }
        }
    }
}