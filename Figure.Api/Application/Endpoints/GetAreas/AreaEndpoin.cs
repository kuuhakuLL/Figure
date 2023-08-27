using CSharpFunctionalExtensions;
using Figure.Api.Domain.Figure;
using Figure.Api.Logics.CalcArea;
using Microsoft.AspNetCore.Mvc;

namespace Figure.Api.Application.Endpoints.GetAreas;

[ApiController]
[Route("api/v1/figure")]
public class AreaEndpoin : ControllerBase {
    private readonly FigureFactory factory;
    private readonly CalcAreas calc;
    
    public AreaEndpoin(FigureFactory factory, CalcAreas calc) {
        this.factory = factory;
        this.calc = calc;
    }
    
    [HttpGet("{type}")]
    public IActionResult GetArea([FromQuery] AreaRequest request) {
        var figure = factory.GetFigure(request.Type, request.Parameters.ToList());
    
        return figure
            .MapError<IFigure, IActionResult>(BadRequest)
            .Tap(f => calc.CalcArea(f) )
            .Match(
                onSuccess: f => Ok(),
                onFailure: e => e 
            );
    }
}
