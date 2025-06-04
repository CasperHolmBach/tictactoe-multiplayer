using System.Collections.Concurrent;
using TicTacToe.API.GameLogic;
using TicTacToe.API.Hubs;
using TicTacToe.Shared.DTOs;

namespace TicTacToe.API;

public class SessionManager
{
    private ConcurrentDictionary<string, GameSession> _sessions = new();
}