namespace myfirstdotnetcore
{
    public interface ISample
    {
        string GetName();
    }
    public class Sample : ISample
    {
        public Sample()
        {

        }

        public string GetName()
        {
            return "Prabakaran";
        }
    }
}