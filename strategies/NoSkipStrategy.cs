class NoSkipStrategy : IStrategy
{
    public String Name => "NoSkip";
    public bool[] DecideDay(int day, IReadOnlyStudentHistory history){
        bool[] ret = new bool[6];
        Array.Fill(ret, false);
        return ret;
    }
}