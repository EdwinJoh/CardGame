using CardGame.Presentation.ActionFilters;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts.Interfaces;
using Shared.DataTransferObjects;

namespace CardGame.Presentation.Controllers;

[Route("hand")]
[ApiController]
public class HandController :ControllerBase
{
    private readonly IServiceManager _service;
    public HandController(IServiceManager service) => _service = service;

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> SaveHand([FromBody] HandForCreationDto hand)
    {
        
        var saveHand = await _service.HandService.SaveHandAsync(hand);
        return NoContent();
    }
    
    
  
}
