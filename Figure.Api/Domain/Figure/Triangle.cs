namespace Figure.Api.Domain.Figure; 

public class Triangle : IFigure {
    public FigureType Type { get; }

    public IList<double> Sides { get; private set; }

    public Triangle(IList<double> sides) 
        => Sides = sides;
}