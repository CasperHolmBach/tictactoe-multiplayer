using Microsoft.AspNetCore.Mvc;
using TicTacToe.Shared.DTOs;

namespace TicTacToe.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    public async Task<IActionResult> CreateGame()
    {
        return Ok();
    }

    public async Task<IActionResult> StartGame()
    {
        return Ok();
    }

    public async Task<IActionResult> JoinGame()
    {
        return Ok();
    }

    public async Task<IActionResult> LeaveGame()
    {
        return Ok();
    }

    public async Task<IActionResult> MakeMove(MoveDTO move)
    {
        return Ok();
    }
}