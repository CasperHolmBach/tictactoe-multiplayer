namespace TicTacToe.Shared.DTOs;

public enum MoveValidationResult
{
    Valid,
    NotYourTurn,
    CellOccupied,
    GameNotInProgress
}