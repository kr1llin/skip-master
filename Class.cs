using System.Diagnostics.CodeAnalysis;

class Class{
    public required Rule rule;

    public required Subject subject {get; init;}

    [SetsRequiredMembers]
    public Class(Subject subj)
    {
        rule = new Rule();
        subject = subj;
    }

    public void doClass(int day, Student student){
        student.DoDay(day); // decides to skip or not to skip
        bool isQuestioned = rule.Decide(student);
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