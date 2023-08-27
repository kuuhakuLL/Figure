using Figure.Api.Domain.Figure;

namespace Figure.Api.Logics.RightTriangle; 

public class RightTriangleChecker : ITriangleChecker {
    public string CheckTriangle(Triangle triangle) {
        var hypotenuse = triangle.Sides.Max();
        
        var sumLegs = triangle.Sides
            .Where(x => x < hypotenuse)
            .Sum(leg => Math.Pow(leg, 2));

        return Math.Pow(hypotenuse, 2) == sumLegs 
            ? "Треугольник является правильным"
            : "Треугольник не является правильным";
    }
}