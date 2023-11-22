namespace Bowling.Test;
using Bowling;

public class BowlingCounterTest
{

  [Theory]
  [InlineData(1, 9)]
  [InlineData(5, 5)]
  [InlineData(10, 0)]
  public void Test_CalculateLeftOverPins_ValidValues(int knockedOverPins, int expectedLeftOverPins)
  {
    BowlingCounter bowlingCounter = new();
    int actual = bowlingCounter.CalculateLeftOverPins(knockedOverPins);
    Assert.Equal(expectedLeftOverPins, actual);
  }

  [Fact]
  public void Test_CalculateLeftOverPins_InvalidValue()
  {
    BowlingCounter bowlingCounter = new();
    Assert.Throws<ArgumentException>(() => bowlingCounter.CalculateLeftOverPins(11));
  }

  [Theory]
  [InlineData(1, true)]
  [InlineData(3, true)]
  public void Test_CheckNumberOfPlayers_ValidValues(int numberOfPlayers, bool expected)
  {
    BowlingCounter bowlingCounter = new();
    bool actual = bowlingCounter.CheckNumberOfPlayers(numberOfPlayers);
    Assert.Equal(expected, actual);
  }

  [Theory]
  [InlineData(0, false)]
  [InlineData(7, false)]
  public void Test_CheckNumberOfPlayers_InvalidValues(int numberOfPlayers, bool expected)
  {
    BowlingCounter bowlingCounter = new();
    bool actual = bowlingCounter.CheckNumberOfPlayers(numberOfPlayers);
    Assert.Equal(expected, actual);
  }

  [Fact]
  public void Test_AddOnePlayer()
  {
    BowlingCounter bowlingCounter = new();
    Dictionary<string, PlayerInfo> actual = bowlingCounter.AddPlayer("Player1");
    Assert.Equal(1, actual.Count);
  }

  [Fact]
  public void Test_CheckIfPlayerAlreadyExists()
  {
    BowlingCounter bowlingCounter = new();
    bowlingCounter.AddPlayer("Player1");
    bool actual = bowlingCounter.CheckPlayerNameExists("Player1");
    Assert.Equal(true, actual);
  }

}