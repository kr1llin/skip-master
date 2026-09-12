using System.Linq;

// TODO: Random class generation
class University
{
    static public int SemesterDays {get => 100;}
    public Class[] Classes{get; set;}

    Student student;

    public University(){
        Classes = Enum.GetValues<Subject>()
                  .Select(subject => new Class(subject))
                  .ToArray();

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
        Console.WriteLine("Average satusfaction => " + (float) student.Satisfaction / SemesterDays);
    }
}