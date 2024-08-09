using System.Dynamic;

namespace schoolgrades.lib;

public class Discipline {
    public decimal[] Grades { get; private set; }

    public Discipline(decimal firstGrade, decimal secondGrade)
    {
        Grades = [firstGrade, secondGrade];
    }

    public decimal GetGradesAvarage() {
        return (Grades[0] + Grades[1]) / 2;
    }
}