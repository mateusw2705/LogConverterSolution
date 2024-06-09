using Domain.Interfaces;
using Domain.Request;
using FluentValidation;
using FluentValidation.Results;

namespace LogConverter.Application.Services
{
    public class LogConversionService(
        ILogFetcher _logFetcher,
        ILogParser _logParser,
        ILogFormatter _logFormatter,
        ILogWriter _logWriter
    ) : ILogConverter
    {
  
        public async Task Convert(string sourceUrl, string targetPath)
        {
            var logLines = await _logFetcher.FetchLogAsync(sourceUrl);
            var logEntries = _logParser.Parse(logLines);
            var formattedLog = _logFormatter.Format(logEntries);
            _logWriter.WriteLog(targetPath, formattedLog);
        }
    }
}
