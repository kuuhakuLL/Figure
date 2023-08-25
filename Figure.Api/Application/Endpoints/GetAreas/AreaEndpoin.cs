using CSharpFunctionalExtensions;
using Figure.Api.Domain.Figure;
using Microsoft.AspNetCore.Mvc;

namespace Figure.Api.Application.Endpoints.GetAreas;

[ApiController]
[Route("api/v1/figure")]
public class AreaEndpoin : ControllerBase {
    private readonly FigureFactory factory;
    
    public AreaEndpoin(FigureFactory factory) {
        this.factory = factory;
    }
    
    [HttpGet("{type}")]
    public IActionResult GetArea([FromQuery] AreaRequest request) {
        var figure = factory.GetFigure(request.Type, request.Parameters.ToList());
    
        return figure.MapError<IFigure, IActionResult>(BadRequest).Match(
            onSuccess: f => Ok(f.CalcArea()),
            onFailure: e => e 
        );
    }
}
