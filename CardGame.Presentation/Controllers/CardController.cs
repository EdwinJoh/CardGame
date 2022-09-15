using Microsoft.AspNetCore.Mvc;
using Service.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Presentation.Controllers
{
    [Route("Card")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly IServiceManager _service;
        public CardController(IServiceManager service) => _service = service;
        
    }
}
