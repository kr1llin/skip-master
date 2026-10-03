using System.Diagnostics.CodeAnalysis;

class Lesson
{
    public Subject subjectA { get; }
    public Subject subjectB { get; }

    private static readonly Type[] RuleTypes =
    typeof(IRule).Assembly
        .GetTypes()
        .Where(t => typeof(IRule).IsAssignableFrom(t) && !t.IsInterface)
        .ToArray();
    public required IRule rule;

    public required Subject subject { get; init; }

    [SetsRequiredMembers]
    public Lesson(Subject subj)
    {
        var ruleType = TypesResolver.ResolveRandomly<IRule>();
        rule = (IRule)Activator.CreateInstance(ruleType)!;

        subject = subj;

        if (rule is ABRule || rule is ARule)
        {
            subjectA = (Subject)Random.Shared.Next(6);
            subjectB = (Subject)Random.Shared.Next(6);

            subjectA = subjectA == subjectB ? subject : subjectA;
        }
    }

    public void doClass(int day, Student student)
    {
        student.DoDay(day); // decides to skip or not to skip
        bool isQuestioned = rule.Decide(day, student, this);
        if (!isQuestioned) return;

        if (!student.DaysPresent[day, (int)subject])
        {
            // drop out
            student.Satisfaction = 0;
        }
        student.DaysWasAsked[day, (int)subject] = true;
    }
}