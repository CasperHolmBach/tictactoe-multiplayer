using TicTacToe.Shared.DTOs;

namespace TicTacToe.API.Services;

public interface IBroadcasterService
{
    Task BroadcastGameStatus(string gameId, GameState gameState);
}