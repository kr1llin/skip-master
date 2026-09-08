/*
    TODO:
        - to interface
*/
class Strategy
{
    double _skipProbability = 0.0f;

    // skip or not to skip?
    public bool Decide(){
        Random rand = new Random();
        double decision = rand.NextDouble();
        return decision > _skipProbability? false : true;
    }
}