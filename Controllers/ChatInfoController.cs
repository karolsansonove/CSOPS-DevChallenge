using System.Reflection.Metadata.Ecma335;
using CSOPS.DevChallenge.Clients;
using CSOPS.DevChallenge.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSOPS.DevChallenge.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api/v1/[controller]")]
public class ChatInfoController(IChatInfoService chatInfoService) : ControllerBase
{
    /// <summary>
    /// This endpoint makes a request to Talk, searching for the chat with the specified <paramref name="chatId"/> and tells us if any attendant is assigned.
    /// </summary>
    [HttpGet(nameof(IsChatWithSomeone))]
    public async Task<ActionResult<bool>> IsChatWithSomeone(string chatId)
    {
        try
        {
            var chatInfo = await chatInfoService.GetAsync(chatId);

            if (chatInfo == null)
                return BadRequest("We could not find any chat for provided Id!");

            return Ok(chatInfo.IsAnyAttendantAssigned);
        } catch (Exception e)
        {
            return StatusCode(500, $"Unexpected error occurred while trying to conclude request: {e.Message}");
        }
    }
}
