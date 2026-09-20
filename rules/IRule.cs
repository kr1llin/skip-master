interface IRule
{
    // reduce arguments
    public bool Decide(int day, Student student, Lesson klass);
}