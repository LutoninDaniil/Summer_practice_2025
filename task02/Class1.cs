namespace task02;
public class Student
{
    public string Name { get; set; } = null!;
    public string Faculty { get; set; } = null!;
    public List<int> Grades { get; set; } = null!;
}

public class StudentService
{
    private readonly List<Student> _students;

    public StudentService(List<Student> students) => _students = students;

    public IEnumerable<Student> GetStudentsByFaculty(string faculty)
        => _students.Where(s => s.Faculty.Equals(faculty)).ToList();

    public IEnumerable<Student> GetStudentsWithMinAverageGrade(double minAverageGrade)
        => _students.Where(s => s.Grades.Average() >= minAverageGrade);

    public IEnumerable<Student> GetStudentsOrderedByName()
        => _students.OrderBy(s => s.Name).ToList();

    public ILookup<string, Student> GroupStudentsByFaculty()
        => _students.ToLookup(s => s.Faculty, s => s);

    public string GetFacultyWithHighestAverageGrade()
        => _students
            .GroupBy(s => s.Faculty)
            .Select(g => new
            {
                Faculty = g.Key,
                Avg = g.SelectMany(s => s.Grades).Average()
            })
            .OrderByDescending(x => x.Avg)
            .FirstOrDefault()
            ?.Faculty ?? string.Empty;
}
