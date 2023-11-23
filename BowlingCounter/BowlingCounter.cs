namespace Bowling;

public class BowlingCounter
{
	int standingPins = 10;
	int round = 0;
	public Dictionary<string, PlayerInfo> scoreBoard = new();

	public void SetupPins()
	{
		round = 0;
	}

	public int CalculateLeftOverPins(int knockedOverPins, int standingPins)
	{
		if (knockedOverPins > standingPins || knockedOverPins < 0)
		{
			Console.WriteLine("Invalid value for knockedOverPins. The value must be between 0 and 10.");
		}
		return standingPins - knockedOverPins;
	}

	public Dictionary<string, PlayerInfo> AddPlayer(string name)
	{
        PlayerInfo playerInfo = new()
        {
            HasThrows = 2,
            LastThrowType = ThrowType.None,
            Score = 0
        };

        scoreBoard.Add(name, playerInfo);
		return scoreBoard;
	}

	public ThrowType SetLastThrowType(PlayerInfo player,ThrowType type)
	{
		player.LastThrowType = type;
		return player.LastThrowType;
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
	
	public void CalculateThrow(){
		
	}
}

public struct PlayerInfo
{
	public int Score { get; set; }
	public int HasThrows { get; set; }
	public ThrowType LastThrowType { get; set; }
}

public enum ThrowType
{
	None,
	Normal,
	Strike,
	Spare,
	Miss
}