namespace OdeToFood.Services
{
    public interface IGreeter
    {
        string getMessageOfTheDay();
    }

    public class Greeter : IGreeter
    {
        public string getMessageOfTheDay()
        {
            return "Daily greet!!!";
            // throw new System.NotImplementedException();
        }
    }
}
