using Figure.Api.Domain.Figure;
using Figure.Api.Logics.CalcArea;
using Figure.Api.Logics.RightTriangle;
using FluentAssertions;

namespace Figure.Tests; 

public class TriangleTest {
    [Fact]
    public void Get_triangle_area_should_return_valid() {
        var triangle = new Triangle(new List<double>{ 3, 4, 5 });
        var calcAreas = new CalcAreas();

        calcAreas.CalcArea(triangle).Should().Be(6);
    }
    
    [Fact]
    public void Get_circle_is_right_triangle_should_return_valid() {
        var triangle = new Triangle(new List<double>{ 3, 4, 5 });
        var triangleChecker = new RightTriangleChecker();
        
        triangleChecker.CheckTriangle(triangle).Should().Be("Треугольник является правильным");
    }
}