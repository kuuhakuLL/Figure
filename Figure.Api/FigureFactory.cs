using CSharpFunctionalExtensions;
using Figure.Api.Domain.Figure;

namespace Figure.Api; 

public class FigureFactory {
    public Result<IFigure> GetFigure(FigureType type, IList<double> parameters) {
        if (parameters.Any() == false) {
            return Result.Failure<IFigure>("Не достаточно параметров.");
        }

        return type switch {
            FigureType.Triangle => GetTriangle(parameters).ConvertFailure<IFigure>(),
            FigureType.Сircle => GetСircle(parameters.First()),
            _ => Result.Failure<IFigure>("Такой фигуры еще не существует." )
        };
    }

    public Result<IFigure> GetСircle(double radius) 
        => new Сircle(radius);

    public Result<ITriangle> GetTriangle(IList<double> parameters) 
        => parameters.Count != 3
            ? Result.Failure<ITriangle>("Задано не верное количество сторон треугольника.") 
            : new Triangle(parameters);
}

