using Domain.Request;

namespace Application.Validators;

public class ValidateArguments
{
    public static bool ValidateArgument(string[] args, out LogConversionRequest request)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Erro: Você deve fornecer exatamente 2 argumentos: <sourceUrl> e <targetPath>.");
            request = null;
            return false;
        }

        request = new LogConversionRequest { SourceUrl = args[0], TargetPath = args[1] };
        return true;
    }
}
