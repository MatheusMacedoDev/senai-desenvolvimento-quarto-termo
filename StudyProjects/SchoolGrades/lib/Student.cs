namespace schoolgrades.lib;

public class Student {
    public string Name { get; set; }
    public List<Discipline> Disciplines { get; private set; }

    public Student(string name)
    {
        Name = name;
        Disciplines = new List<Discipline>();
    }

    public decimal GetStudentAvarege() 
    {
        if (Disciplines.Count() == 0) 
        {
            return 0;
        }

        decimal avaragesSum = 0;

        foreach (var discipline in Disciplines)
        {
            avaragesSum += discipline.GetGradesAvarage();
        }

        return avaragesSum / Disciplines.Count();
    }

    public bool isApproved(decimal gradesAvarage) 
    {
        return gradesAvarage > 7;
    }
}