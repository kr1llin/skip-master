class ABRule : IRule
{
    public bool Decide(int day, Student student, Class klass)
    {
        if (day == 0) return false;

        Subject subjA = klass.subjectA;
        Subject subjB = klass.subjectB;


        bool askedA = (bool) student.DaysWasAsked[day - 1, (int)subjA].GetValueOrDefault(false);
        bool askedB = (bool) student.DaysWasAsked[day - 1, (int)subjB].GetValueOrDefault(false);

        if (askedA && !askedB)
        {
            return true;
        } else if (askedB && !askedA)
        {
            return true;
        }
        return false;
    }
}