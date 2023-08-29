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
            .Map(f => calc.CalcArea(f))
            .Bind(r => r)
            .MapError<double, IActionResult>(r => {
                return BadRequest(r);
            })
            .Match(
                onSuccess: r => Ok(r),
                onFailure: e => e 
            );
    }
}
