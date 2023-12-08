using System.Globalization;
using lab_4.Commands;
using lab_4.Commands.CommandHandlers;
using lab_4.Output;

namespace lab_4.Run;

public static class Program
{
    public static void Main()
    {
        var configurator = new Configurator.Configuration(
            "\ud83d\udcc4",
            "📷",
            "\ud83c\udfb5",
            "\ud83d\udccb",
            "\ud83d\udcc1",
            "\t",
            5);
        var navigator = new FileNavigator.FileNavigator(new ConsoleOutput(), configurator);

        List<ICommandHandler> handlers = new List<ICommandHandler>
        {
            new CopyCommandHandler(navigator),
            new DeleteCommandHandler(navigator),
            new FileCommandHandler(navigator),
            new RenameCommandHandler(navigator),
        };
        var commandController = new CommandHandlersController(
            navigator,
            CreateChain(new ConnectCommandHandler(navigator), handlers));
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        while (true)
        {
            string? input = Console.ReadLine()?.ToLower(CultureInfo.CurrentCulture);
            if (input == null)
            {
            }
            else if (input == "exit")
            {
                break;
            }
            else
            {
                commandController.Run(input);
            }
        }
    }

    public static ICommandHandler CreateChain(ICommandHandler firstCommand, IEnumerable<ICommandHandler> handlers)
    {
        ICommandHandler previousCommand = firstCommand;
        foreach (ICommandHandler command in handlers)
        {
            previousCommand.SetNext(command);

            previousCommand = command;
        }
        return firstCommand;
    }
}