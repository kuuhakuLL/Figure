using System.ComponentModel.DataAnnotations;
using Figure.Api.Domain.Figure;
using Microsoft.AspNetCore.Mvc;

namespace Figure.Api.Application.Endpoints.GetAreas; 

public class AreaRequest {
    [FromRoute(Name = "type")] 
    [EnumDataType(typeof(FigureType))]  
    public FigureType Type { get; init; }
    
    [FromQuery(Name = "parameters")]
    public ICollection<double> Parameters { get; init; }
}