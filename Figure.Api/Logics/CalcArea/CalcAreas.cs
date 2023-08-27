using CSharpFunctionalExtensions;
using Figure.Api.Domain.Figure;

namespace Figure.Api.Logics.CalcArea; 

public class CalcAreas {
    public Result<double> CalcArea(IFigure figure) {
        return figure switch {
            Сircle сircle => CalcСircleArea(сircle),
            Triangle triangle => CalcTriangleArea(triangle),
            _ => Result.Failure<double>("Расчет площади еще не реализованн для данной фигуры")
        };
    }
    
    private double CalcСircleArea(Сircle circle) => 
        Math.PI * Math.Pow(circle.Radius, 2);
    
    public double CalcTriangleArea(Triangle triangle) {
        var perimeter = triangle.Sides.Sum() / 2;

        return Math.Sqrt(
            triangle.Sides.Aggregate(perimeter, (current, side) => current * (perimeter - side))
        );
    }
}