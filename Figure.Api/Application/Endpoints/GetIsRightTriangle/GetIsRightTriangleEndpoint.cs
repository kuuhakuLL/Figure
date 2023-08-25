using CSharpFunctionalExtensions;
using Figure.Api.Domain.Figure;
using Microsoft.AspNetCore.Mvc;

namespace Figure.Api.Application.Endpoints.GetIsRightTriangle; 

[ApiController]
[Route("api/v1/figure/Triangle")]
public class GetIsRightTriangleEndpoint : ControllerBase {
    private readonly FigureFactory factory;
    
    public GetIsRightTriangleEndpoint(FigureFactory factory) {
        this.factory = factory;
    }

    [HttpGet]
    public IActionResult GetIsRightTriangle([FromQuery(Name = "parameters")] ICollection<double> parameters) {
        var triangle = factory.GetTriangle(parameters.ToList());
        
        return triangle.MapError<ITriangle, IActionResult>(BadRequest).Match(
            onSuccess: f => Ok(f.IsRightTriangle()),
            onFailure: e => e 
        );
    }
}