using Domain.Entities;
using Domain.Interfaces;
using LogConverter.Application.Services;
using Moq;

namespace LogConverter.Tests.Services
{
    public class LogConversionServiceTests
    {
        private readonly Mock<ILogFetcher> _mockLogFetcher;
        private readonly Mock<ILogParser> _mockLogParser;
        private readonly Mock<ILogFormatter> _mockLogFormatter;
        private readonly Mock<ILogWriter> _mockLogWriter;
        private readonly LogConversionService _logConversionService;

        public LogConversionServiceTests()
        {
            _mockLogFetcher = new Mock<ILogFetcher>();
            _mockLogParser = new Mock<ILogParser>();
            _mockLogFormatter = new Mock<ILogFormatter>();
            _mockLogWriter = new Mock<ILogWriter>();

            _logConversionService = new LogConversionService(
                _mockLogFetcher.Object,
                _mockLogParser.Object,
                _mockLogFormatter.Object,
                _mockLogWriter.Object
            );
        }
        [Fact]
        public async Task Convert_ShouldCallDependenciesInOrder()
        {
            var sourceUrl = "https://example.com/log.txt";
            var targetPath = "output.txt";
            var logLines = new[] { "log line 1", "log line 2" };
            var logEntries = new List<LogEntry> { new LogEntry() };
            var formattedLog = "formatted log";

            _mockLogFetcher.Setup(x => x.FetchLogAsync(sourceUrl)).ReturnsAsync(logLines);
            _mockLogParser.Setup(x => x.Parse(logLines)).Returns(logEntries);
            _mockLogFormatter.Setup(x => x.Format(logEntries)).Returns(formattedLog);
            _mockLogWriter.Setup(x => x.WriteLog(targetPath, formattedLog));

            // Act
            await _logConversionService.Convert(sourceUrl, targetPath);

            // Assert
            _mockLogFetcher.Verify(x => x.FetchLogAsync(sourceUrl), Times.Once);
            _mockLogParser.Verify(x => x.Parse(logLines), Times.Once);
            _mockLogFormatter.Verify(x => x.Format(logEntries), Times.Once);
            _mockLogWriter.Verify(x => x.WriteLog(targetPath, formattedLog), Times.Once);
        }
    }
}
