class Student : IReadOnlyStudentHistory
{
    const byte SatisfactionPoint = 1;

    IStrategy _strategy;

    public float Satisfaction{ get; set;}

    // status 
    public bool?[,] DaysWasAsked{get;set;}
    public bool[,] DaysPresent{get; set;}

    public Student(IStrategy strategy)
    {
        _strategy = strategy;
        DaysWasAsked = new bool?[University.SemesterDays, 6];
        DaysPresent = new bool[University.SemesterDays, 6];
    }

    public void DoDay(int day){
        Satisfaction += SatisfactionPoint; // eat pirojok

        bool[] skipChoice =_strategy.DecideDay(day, this);

        for (int i = 0; i < skipChoice.Length; i++)
        {
        Console.WriteLine("I will " + "[" + skipChoice[i] + "] to " + (Subject)i);
            if (skipChoice[i])
            {
                Satisfaction += SatisfactionPoint;
                DaysPresent[day, i] = false;
            } else
            {
                DaysPresent[day, i] = true;
            }
        }
    }

    bool? IReadOnlyStudentHistory.WasAsked(int day, Subject subject)
    {
        return DaysWasAsked[day, (int)subject];
    }

    public bool Attended(int day, Subject subject)
    {
        return DaysPresent[day, (int)subject];
    }
}