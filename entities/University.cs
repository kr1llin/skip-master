
class University
{
    static public int SemesterDays { get => 100; }
    public Lesson[] Classes { get; set; }

    public int Day { get; private set; }
    public bool DroppedOut { get; private set; }
    public bool Finished { get; private set; }

    public Student Student { get; private set; }

    public University(IStrategy strategy)
    {
        Classes = Enum.GetValues<Subject>()
                  .Select(subject => new Lesson(subject))
                  .ToArray();

        Student = new Student(strategy);
    }

    // dropped out or not today?
    public bool RunOneDay()
    {
        if (DroppedOut || Finished) return false;

        for (int l = 0; l < 6; l++)
        {
            Classes[l].doClass(Day, Student);

            //drop out
            if (Student.Satisfaction == 0)
            {
                Console.WriteLine(Enum.GetName(typeof(Subject), l) + " killed Student");
                DroppedOut = true;
                return false;
            }
        }
        Day++;
        if (Day >= SemesterDays) Finished = true;

        return !Finished;
    }
}