/*
    TODO: 
        - 3 rules (check last visited class)
        - to interface
*/
class FifthyRule : IRule
{
    public bool Decide(int day, Student student, Class klass){
        Random rand = new Random();
        double decision = rand.NextDouble();
        return (decision > 0.5f)? true : false;
    }
}