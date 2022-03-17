using APIDotnetPlatzi.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIDotnetPlatzi.Controllers;

[Route("[controller]")]
public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloService;

    public HelloWorldController(IHelloWorldService helloworldService)
    {
        helloService = helloworldService;
    }

    [HttpGet]
    public IActionResult HelloWorld()
    {
        return Ok(helloService.GetHelloWorld());

    }
}