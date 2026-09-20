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
        bool droppedOut = false;

        for (int day = 0; day < SemesterDays && !droppedOut; day++)
        {
            for (int l = 0; l < 6; l++)
            {
                Classes[l].doClass(day, student);

                //drop out
                if (student.Satisfaction == 0)
                {
                    Console.WriteLine(Enum.GetName(typeof(Subject), l) + " killed student");
                    droppedOut = true;
                    break;
                }
                totalDays = day;
            }
        }
        Console.WriteLine((int)(totalDays + 1) + " days => " + student.Satisfaction);
        Console.WriteLine("Average satusfaction => " + (float)student.Satisfaction / SemesterDays);
    }
}