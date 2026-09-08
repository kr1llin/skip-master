/*
    TODO: 
        - 3 rules (check last visited class)
        - to interface
*/
class Rule
{
    public bool Decide(Student student){
        Random rand = new Random();
        double decision = rand.NextDouble();
        return (decision > 0.5f)? true : false;
    }
}