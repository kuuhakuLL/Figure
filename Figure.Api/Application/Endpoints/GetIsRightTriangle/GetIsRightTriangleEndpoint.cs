using CSharpFunctionalExtensions;
using Figure.Api.Domain.Figure;
using Figure.Api.Logics.RightTriangle;
using Microsoft.AspNetCore.Mvc;

namespace Figure.Api.Application.Endpoints.GetIsRightTriangle; 

[ApiController]
[Route("api/v1/figure/cheking/triangle")]
public class GetIsRightTriangleEndpoint : ControllerBase {
    private readonly FigureFactory factory;
    private readonly ITriangleChecker triangleChecker;
    
    public GetIsRightTriangleEndpoint(FigureFactory factory, ITriangleChecker triangleChecker) {
        this.factory = factory;
        this.triangleChecker = triangleChecker;
    }

    [HttpGet]
    public IActionResult GetIsRightTriangle([FromQuery(Name = "parameters")] ICollection<double> parameters) {
        var triangle = factory.GetTriangle(parameters.ToList());
        
        return triangle
            .Map<IFigure, Triangle>(arg => (Triangle)arg)
            .MapError<Triangle, IActionResult>(BadRequest)
            .Match(
                onSuccess: f => Ok(triangleChecker.CheckTriangle(f)),
                onFailure: e => e 
            );
    }
}