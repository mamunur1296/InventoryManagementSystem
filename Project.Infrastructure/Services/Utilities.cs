using Project.Application.Utilities;

namespace Project.Infrastructure.Services
{
    public class Utilities : IUtilities
    {
        public bool IsValidGuid(string guidString)
        {
            return Guid.TryParse(guidString, out _);
        }

        public Guid GenerateNewGuid()
        {
            return Guid.NewGuid();
        }

        public bool IsNullOrEmpty(string input)
        {
            return string.IsNullOrEmpty(input);
        }

        public string FormatErrorMessage(Exception ex)
        {
            return $"Exception Message: {ex.Message}, StackTrace: {ex.StackTrace}";
        }

        public async Task LogMessageAsync(string message)
        {
            // This is just an example. Replace with your actual logging mechanism.
            string logFilePath = "log.txt";
            await File.AppendAllTextAsync(logFilePath, $"{DateTime.Now}: {message}{Environment.NewLine}");
        }
    }
}
