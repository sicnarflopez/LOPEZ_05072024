namespace Lopez_05072024.Application.File.Command.ProcessFile;
public class ProcessFileCommandValidator : AbstractValidator<ProcessFileCommand>
{
    public ProcessFileCommandValidator()
    {
        RuleFor(c => c.CsvFile).NotEmpty().WithMessage("Csv File should not be null.");
    }
}
