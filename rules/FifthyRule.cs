class FifthyRule : IRule
{
    public bool Decide(int day, Student student, Lesson klass)
    {
        Random rand = new Random();
        double decision = rand.NextDouble();
        return (decision > 0.5f) ? true : false;
    }
}