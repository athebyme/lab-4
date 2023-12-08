namespace lab_4.Output;

public class ConsoleOutput : OutputBase
{
    private readonly TextWriter _output = Console.Out;
    public override void Show(string text)
    {
        _output.WriteLine(text);
    }
}