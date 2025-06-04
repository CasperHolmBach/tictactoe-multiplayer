namespace TicTacToe.Shared.DTOs;

public class GameState
{
    /// <summary>
    /// The game board
    /// </summary>
    public char[,] GameBoard { get; set; }
    /// <summary>
    /// The user who is playing their turn
    /// </summary>
    public Guid CurrentUser { get; set; }   
    /// <summary>
    /// The given games current status
    /// </summary>
    public GameStatus Status { get; set; }
}