using Microsoft.AspNetCore.Mvc;
using Service.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Presentation.Controllers
{
    [Route("card")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly IServiceManager _service;
        public CardController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetCardHistory()
        {
            var cards = await _service.CardService.GetAllCardHistoryAsync(trackChanges: false);
            return Ok(cards);
        }
        [HttpGet("Deck")]
        public async Task<IActionResult> GetNewDeck()
        {
            var deck = await _service.CardService.GetNewDeck();
            return Ok(deck);
        }


    }
}
