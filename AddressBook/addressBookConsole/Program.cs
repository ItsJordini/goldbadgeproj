namespace addressBookRepo;
public class Program
{
    static void Main(string[] args)
    {
        //Create an instance of ProgramUI 
        ProgramUI programUI = new ProgramUI();

        // Call method on ProgramUI to start interaction
        programUI.Run();

        //Prevents console from closing imediately
        Console.ReadLine();
    }
}