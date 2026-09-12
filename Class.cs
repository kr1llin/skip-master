using System.Diagnostics.CodeAnalysis;

class Class{
    public Subject subjectA {get;}
    public Subject subjectB {get;}
    public required IRule rule;

    public required Subject subject {get; init;}

    [SetsRequiredMembers]
    public Class(Subject subj)
    {
        var rand = new Random();
        int ruleNum = rand.Next() % 3;

        switch (ruleNum)
        {
            case 0: 
                rule = new FifthyRule();
                break;
            case 1:
                rule = new ARule();
                break;
            case 2: 
                rule = new ABRule();
                break;
            default:
                rule = new FifthyRule();
                break;
        }

        subject = subj;

        if (rule is ABRule || rule is ARule)
        {
            subjectA = (Subject)(rand.Next() % 6);
            subjectB = (Subject)(rand.Next() % 6);

            if (subjectA.Equals(subjectB))
            {
                subjectA = subject;
            }
        }
    }

    public void doClass(int day, Student student){
        student.DoDay(day); // decides to skip or not to skip
        bool isQuestioned = rule.Decide(day, student, this);
        if (isQuestioned){
            if (student.DaysPresent[day, (int)subject]){
                student.DaysWasAsked[day, (int)subject] = true;
            }
            else {
                // drop out
                student.Satisfaction = 0;
            }
        }
    }
}