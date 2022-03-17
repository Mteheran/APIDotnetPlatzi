using APIDotnetPlatzi.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIDotnetPlatzi.Controllers;

[Route("[controller]")]
public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloService;
    ILogger<HelloWorldController> logger;
    public HelloWorldController(IHelloWorldService helloworldService, ILogger<HelloWorldController> loggerhello)
    {
        logger = loggerhello;
        helloService = helloworldService;
    }

    [HttpGet]
    public IActionResult HelloWorld()
    {
        logger.LogDebug("Retornando mensaje 'Hello World'");
        return Ok(helloService.GetHelloWorld());

    }
}