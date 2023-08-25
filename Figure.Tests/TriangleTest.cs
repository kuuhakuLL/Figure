using Figure.Api.Domain.Figure;
using FluentAssertions;

namespace Figure.Tests; 

public class TriangleTest {
    [Fact]
    public void Get_triangle_area_should_return_valid() {
        var triangle = new Triangle(new List<double>{ 3, 4, 5 });

        triangle.CalcArea().Should().Be(6);
    }
    
    [Fact]
    public void Get_circle_is_right_triangle_should_return_valid() {
        var triangle = new Triangle(new List<double>{ 3, 4, 5 });

        triangle.IsRightTriangle().Should().BeTrue();
    }
}