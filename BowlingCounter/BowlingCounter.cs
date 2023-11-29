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
		PlayerInfo playerInfo = new PlayerInfo
		{
			HasThrows = 2,
			LastThrowType = ThrowType.None,
			Score = 0
		};

		scoreBoard.Add(name, playerInfo);
		return scoreBoard;
	}


	public ThrowType SetLastThrowType(string player, ThrowType type)
	{
		if (scoreBoard.TryGetValue(player, out PlayerInfo playerInfo))
		{
			playerInfo.LastThrowType = type;
			return playerInfo.LastThrowType;
		}

		return ThrowType.None; // Fallback, wenn der Spieler nicht gefunden wird
	}

	public ThrowType GetLastThrowType(string player)
	{
		if (scoreBoard.TryGetValue(player, out PlayerInfo playerInfo))
		{
			return playerInfo.LastThrowType;
		}
		return ThrowType.None; // Fallback, if player is not found
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

	public void CalculateThrow(string playerName, int knockedOverPins)
	{
		if (scoreBoard.TryGetValue(playerName, out PlayerInfo player))
		{
			if (player.HasThrows > 0)
			{
				player.HasThrows--;

				if (knockedOverPins == standingPins)
				{
					// Strike
					SetLastThrowType(playerName, ThrowType.Strike);
					CalculateStrikeBonus(playerName);
				}
				else
				{
					standingPins = CalculateLeftOverPins(knockedOverPins, standingPins);

					if (player.HasThrows == 0)
					{
						if (standingPins == 0)
						{
							// Spare
							SetLastThrowType(playerName, ThrowType.Spare);
							CalculateSpareBonus(playerName);
						}
						else
						{
							// Normal throw
							SetLastThrowType(playerName, ThrowType.Normal);
						}
					}
				}
			}
		}
	}

	private void CalculateStrikeBonus(string playerName)
	{
		// Implement logic to add bonus points for a strike
	}

	private void CalculateSpareBonus(string playerName)
	{
		// Implement logic to add bonus points for a spare
	}

	public void CalculateScore(string playerName)
	{
		if (scoreBoard.TryGetValue(playerName, out PlayerInfo player))
		{
			// Implement logic to calculate the total score for the player
		}
	}
}

public class PlayerInfo
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