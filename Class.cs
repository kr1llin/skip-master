using System.Diagnostics.CodeAnalysis;
class Class{
    public enum Subject
    {
        Calculus,
        LinAlgebra,
        DiscreteMath,
        Programming,
        Physics,
        English
    }

    Rule rule;
    
    public Class()
    {
        rule = new Rule();
    }

    [SetsRequiredMembers]
    public Class(Subject subj) => subject = subj;

    public required Subject subject {get; init;}

    public void doClass(Student student){
        student.DoDay(); // decides to skip or not to skip
        bool isQuestioned = rule.Decide(student);
        if (isQuestioned){
            if (student.IsPresent){
                student.WasAsked = true;
                student.LastSubj = subject;
            }
            else {
                // drop out
                student.Satisfaction = 0;
            }
        }
    }
}