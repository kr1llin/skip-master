class ARule : IRule
{
    public bool Decide(int day, Student student, Class klass)
    {
        if (day == 0) return false;
        return student.DaysWasAsked[day - 1, (int)klass.subject] == true ? true : false;
    }
}