namespace Bowling;

public class BowlingCounter
{
	int standingPins = 10;
	int round = 0;
	public Dictionary<string, PlayerInfo> scoreBoard = new();

	public void SetupPins()
	{
		standingPins = 10;
		round = 0;
	}

	public int CalculateLeftOverPins(int knockedOverPins)
	{
		if (knockedOverPins > 10 || knockedOverPins < 0)
		{
			throw new ArgumentException("Invalid value for knockedOverPins. The value must be between 0 and 10.");
		}

		return standingPins - knockedOverPins;
	}

	public Dictionary<string, PlayerInfo> AddPlayer(string name)
	{
		scoreBoard.Add(name, new PlayerInfo());
		return scoreBoard;
	}

	public bool CheckNumberOfPlayers(int numberOfPlayers)
	{
		if (numberOfPlayers < 1 || numberOfPlayers > 6)
		{
			return false;
		}
		return true;
	}

	public bool CheckPlayerNameExists(string name)
	{
		if (scoreBoard.ContainsKey(name))
		{
			Console.WriteLine("Name already exists. Please enter a different name.");
			return true;
		}
		return false;
	}
}

public struct PlayerInfo
{
	public int Score { get; set; }
	public ThrorwType LastThrowType { get; set; }
}

public enum ThrorwType
{
	Strike,
	Spare,
	Miss
}