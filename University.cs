using System.Linq;

class University
{
    static public int SemesterDays { get => 100; }
    public Lesson[] Classes { get; set; }

    readonly Student student;

    public University()
    {
        Classes = Enum.GetValues<Subject>()
                  .Select(subject => new Lesson(subject))
                  .ToArray();

        student = new Student(new OneSkipStrategy());
    }

    public void RunSemester()
    {
        int totalDays = 0;

        for (int day = 0; day < SemesterDays; day++)
        {
            Classes[day % 6].doClass(day, student);

            //drop out
            if (student.Satisfaction == 0)
            {
                break;
            }
            totalDays = day;
        }
        Console.WriteLine((int)(totalDays + 1) + " days => " + student.Satisfaction);
        Console.WriteLine("Average satusfaction => " + (float)student.Satisfaction / SemesterDays);
    }
}