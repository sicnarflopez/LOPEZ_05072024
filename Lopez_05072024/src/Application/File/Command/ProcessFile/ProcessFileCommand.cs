using Lopez_05072024.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Lopez_05072024.Application.File.Command.ProcessFile;
public record class ProcessFileCommand : IRequest<string>
{
    public required IFormFileCollection CsvFile { get; set; }
}
public class ProcessFileCommandHandler : IRequestHandler<ProcessFileCommand, string>
{
    private readonly ICsvFileService _csvFileService;
    private readonly IMapper _mapper;

    public ProcessFileCommandHandler(ICsvFileService csvFileService,
                                     IMapper mapper)
    {
        _csvFileService = csvFileService;
        _mapper = mapper;
    }

    public async Task<string> Handle(ProcessFileCommand request, CancellationToken cancellationToken)
    {
        if (request.CsvFile[0].ContentType != "text/csv") throw new InvalidDataException("File should be in CSV.");

        Log.Logger.Information($"Starting file processing: {request.CsvFile[0].FileName}");
        Log.Logger.Information($"Started at {DateTime.Now}");

        var users = _csvFileService.ReadCSV<CsvData>(request.CsvFile[0].OpenReadStream());

        var totalScore = 0;

        if (users == null) return "No data found in the current file";

        foreach (var user in users)
        {
            totalScore += user.Score;
        }

        var usersCount = users.Count();
        var aveScore = totalScore / usersCount;

        Log.Logger.Information($"Ending file processing: {request.CsvFile[0].FileName}");
        Log.Logger.Information($"Ended at {DateTime.Now}");

        await Task.Delay(1000);

        return $"Average score of {usersCount} users is: {aveScore}";
    }
}
