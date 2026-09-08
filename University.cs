class University
{
    static public int SemesterDays {get => 100;}
    public Class[] Classes{get; set;}

    Student student;

    public University(){
        Classes = new Class[6];
        Classes[0] = new Class(Subject.Calculus);
        Classes[1] = new Class(Subject.DiscreteMath);
        Classes[2] = new Class(Subject.English);
        Classes[3] = new Class(Subject.LinearAlgebra);
        Classes[4] = new Class(Subject.Physics);
        Classes[5] = new Class(Subject.Programming);

        student = new Student(new NoSkipStrategy()); 
    }

    public void RunSemester(){  
        int totalDays = 0;

        for (int day = 0; day < SemesterDays; day++){
            Classes[day % 6].doClass(day, student);

            //drop out
            if (student.Satisfaction == 0){
                break;
            }
            totalDays = day;
        }
        Console.WriteLine((int)(totalDays+1) + " days => " + student.Satisfaction);
    }
}