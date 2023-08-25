namespace Figure.Api.Domain.Figure; 

public class Triangle : IFigure, ITriangle {
    public IList<double> Sides { get; private set; }

    public Triangle(IList<double> sides) 
        => Sides = sides;
    
    public double CalcArea() {
        var perimeter = Sides.Sum() / 2;

        return Math.Sqrt(Sides.Aggregate(perimeter, (current, side) => current * (perimeter - side)));
    }
    
    public bool IsRightTriangle() {
        var hypotenuse = Sides.Max();
        
        var sumLegs = Sides
            .Where(x => x < hypotenuse)
            .Sum(leg => Math.Pow(leg, 2));

        return Math.Pow(hypotenuse, 2) == sumLegs;
    }
}