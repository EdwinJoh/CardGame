using Microsoft.AspNetCore.Mvc;
using Service.Contracts.Interfaces;

namespace TestApi.Presentation.Controllers;

[Route("Api/test")]
[ApiController]
public class TestModelController : ControllerBase
{
    private readonly IServiceManager _service;
    public TestModelController(IServiceManager service) =>
        _service = service;

    [HttpGet]
    public IActionResult GetTestModels()
    {
        var testModels = _service.TestModelService.GetTestModels(trackChanges: false);

        return Ok(testModels);

    }
    [HttpGet("{id:int}")]
    public IActionResult GetTestModel(int id)
    {
        var testModel = _service.TestModelService.GetTestModel(id, trackChanges: false);
        return Ok(testModel);
    }

}
