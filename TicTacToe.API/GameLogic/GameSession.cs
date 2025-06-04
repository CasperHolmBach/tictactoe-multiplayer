using TicTacToe.API.Services;
using TicTacToe.Shared.DTOs;

namespace TicTacToe.API.GameLogic;

public class GameSession
{
    private GameState _gameState;
    private IBroadcasterService _broadcasterService;

    private Guid _playerXId;
    private Guid _playerOId;
    private Dictionary<Guid, Char> _playerIcons;

    public GameSession(string gameId, Guid playerXId, Guid playerOId, IBroadcasterService broadcasterService)
    {
        GameId = gameId;
        _playerXId = playerXId;
        _playerOId = playerOId;
        _playerIcons = new Dictionary<Guid, Char>()
        {
            {playerXId, 'X'},
            {playerOId, 'O'}
        };
        
        _gameState = new GameState();
        _gameState.Status = GameStatus.Waiting;
        
        _broadcasterService = broadcasterService;
    }
    
    public string GameId { get; private set; }

    public async Task StartGame()
    {
        _gameState.GameBoard = new char[3, 3];
        _gameState.Status = GameStatus.Playing;
        _gameState.CurrentUser = _playerXId;
        await _broadcasterService.BroadcastGameStatus(GameId, _gameState);
    }

    public async Task LeaveGame()
    {
        _gameState.Status = GameStatus.Waiting;
        await _broadcasterService.BroadcastGameStatus(GameId, _gameState);
    }

    public MoveValidationResult ValidateMove(MoveDTO move, Guid senderId)
    {
        if (_gameState.Status == GameStatus.Waiting)
        {
            return MoveValidationResult.GameNotInProgress;
        }
        
        if (_gameState.GameBoard[move.Row, move.Column] != ' ')
        {
            return MoveValidationResult.CellOccupied;
        }
        
        if (_gameState.CurrentUser != senderId)
        {
            return MoveValidationResult.NotYourTurn;
        }
        
        return MoveValidationResult.Valid;
    }

    public async Task ApplyMove(MoveDTO move, Guid senderId)
    {
        _gameState.GameBoard[move.Row, move.Column] = _playerIcons[senderId];
        await _broadcasterService.BroadcastGameStatus(GameId, _gameState);
        _gameState.CurrentUser = _gameState.CurrentUser == _playerXId ? _playerOId : _playerXId;
    }
}

