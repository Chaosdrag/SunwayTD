[System.Serializable]
public class Question
{
    public string fact;
    public bool isTrue;

    public Question(string fact, bool isTrue)
    {
        this.fact = fact;
        this.isTrue = isTrue;
    }
}