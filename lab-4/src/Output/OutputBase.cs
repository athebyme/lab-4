namespace lab_4.Output;

public abstract class OutputBase : IOutput
{
    protected TextWriter? OutputWriter { get; private set; }
    public abstract void Show(string text);
    public void SetOutputWriter(TextWriter writer)
    {
        OutputWriter = writer ?? throw new ArgumentNullException(nameof(writer));
    }
}