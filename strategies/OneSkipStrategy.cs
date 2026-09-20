class OneSkipStrategy : IStrategy
{
    public String Name => "NoSkip";
    public bool[] DecideDay(int day, IReadOnlyStudentHistory history)
    {
        bool[] ret = new bool[6];
        Array.Fill(ret, false);
        ret[0] = true;
        return ret;
    }
}