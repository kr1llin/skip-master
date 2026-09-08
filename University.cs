class University
{
    int _semesterDays = 100;
    public int SemesterDays {get; set;}

    Class[] _classes;
    public Class[] Classes{get; set;}

    Student student;

    public University(){
        _classes = new Class[6];
        _classes[0] = new Class(Class.Subject.Calculus);
        student = new Student(); 
    }

    public void RunSemester(){
        int totalDays = 0;

        for (int i = 0; i < _semesterDays; i++){
            _classes[i % 6].doClass(student);

            //drop out
            if (student.Satisfaction == 0){
                break;
            }
            totalDays = i;
        }
        Console.WriteLine(student.Satisfaction);
    }
}