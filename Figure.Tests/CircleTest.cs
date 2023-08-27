using Figure.Api.Domain.Figure;
using Figure.Api.Logics.CalcArea;
using FluentAssertions;

namespace Figure.Tests;

public class CircleTest {
    [Fact]
    public void Get_circle_area_should_return_valid() {
        var circle = new Сircle(5);
        var calcAreas = new CalcAreas();
        
        calcAreas.CalcArea(circle).Should().Be(78.539816339744831);
    }
}