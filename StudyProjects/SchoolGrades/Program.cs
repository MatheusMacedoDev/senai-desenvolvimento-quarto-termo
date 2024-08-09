//// Exercício 5 - Você vai criar um programa que armazena as notas de vários alunos em diferentes disciplinas. O programa deve calcular a média de cada aluno e determinar quais alunos têm médias acima de 7.0 (aprovados) e quais têm médias abaixo de 7.0 (reprovados). O programa deve usar foreach para iterar sobre as coleções de alunos e suas notas.

using schoolgrades.lib;

/// Especificações:
/// - Armazene as notas de 3 disciplinas para cada aluno.
/// - Calcule a média de cada aluno.
/// - Exiba a média e o status (aprovado/reprovado) de cada aluno.
/// - Use foreach para iterar sobre os alunos e as disciplinas.

List<Student> students = new List<Student>();

Student student1 = new Student("Matheus");

student1.Disciplines.Add(new Discipline(4, 8.2m));
student1.Disciplines.Add(new Discipline(7.2m, 2m));
student1.Disciplines.Add(new Discipline(6.5m, 9.8m));

students.Add(student1);

Student student2 = new Student("Gabriel");

student2.Disciplines.Add(new Discipline(10, 8.2m));
student2.Disciplines.Add(new Discipline(7.2m, 2m));
student2.Disciplines.Add(new Discipline(6.5m, 9.8m));

students.Add(student2);

Student student3 = new Student("Henrique");

student3.Disciplines.Add(new Discipline(4, 8.2m));
student3.Disciplines.Add(new Discipline(7.2m, 2m));
student3.Disciplines.Add(new Discipline(6.5m, 9.8m));

students.Add(student3);

Student student4 = new Student("João");

student4.Disciplines.Add(new Discipline(4, 8.2m));
student4.Disciplines.Add(new Discipline(7.2m, 2m));
student4.Disciplines.Add(new Discipline(6.5m, 9.8m));

students.Add(student4);

Console.WriteLine("Students Grade");
foreach (var student in students)
{
    decimal studentAvarage = student.GetStudentAvarege();

    Console.WriteLine($"{student.Name} - {studentAvarage.ToString("#.##")} - {(student.isApproved(studentAvarage) ? "Aprovado" : "Reprovado")}");
}