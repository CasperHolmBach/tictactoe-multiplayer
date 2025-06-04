using Microsoft.AspNetCore.SignalR;
using TicTacToe.API.Hubs;
using TicTacToe.Shared.DTOs;

namespace TicTacToe.API.Services;

public class BroadcasterService : IBroadcasterService
{
    private readonly IHubContext<GameHub> _hubContext;

    public BroadcasterService(IHubContext<GameHub> hubContext)
    {
        _hubContext = hubContext;
    }
    
    public async Task BroadcastGameStatus(string gameId, GameState gameState)
    {
        throw new NotImplementedException();
    }
}