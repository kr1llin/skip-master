class Student
{
    const byte SatisfactionPoint = 1;

    Strategy _strategy;

    float _satisfaction;
    public float Satisfaction{ get; set;}

    Class.Subject _lastSubj;
    public Class.Subject LastSubj{get;set;}

    // status 
    bool _wasAsked;
    public bool WasAsked{get;set;}
    bool _isPresent;
    public bool IsPresent{get; set;}

    public void DoDay(){
        if (_strategy.Decide()){
            _satisfaction += 2*SatisfactionPoint; // eat pirojok + skip class
            _isPresent = false;
        } else {
            _satisfaction += SatisfactionPoint; // eat pirojok
            _isPresent = true;
        }
    }
}