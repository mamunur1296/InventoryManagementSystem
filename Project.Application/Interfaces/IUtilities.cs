using System;
using System.Threading.Tasks;

namespace Project.Application.Utilities
{
    public interface IUtilities
    {
        /// <summary>
        /// Validates if the given string is a valid GUID.
        /// </summary>
        /// <param name="guidString">The string to validate.</param>
        /// <returns>True if valid GUID, otherwise false.</returns>
        bool IsValidGuid(string guidString);

        /// <summary>
        /// Generates a new GUID.
        /// </summary>
        /// <returns>A new GUID.</returns>
        Guid GenerateNewGuid();

        /// <summary>
        /// Validates if the given string is null or empty.
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <returns>True if null or empty, otherwise false.</returns>
        bool IsNullOrEmpty(string input);

        /// <summary>
        /// Formats the error messages for the given exception.
        /// </summary>
        /// <param name="ex">The exception to format.</param>
        /// <returns>A formatted error message string.</returns>
        string FormatErrorMessage(Exception ex);

        /// <summary>
        /// Asynchronously logs the given message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task LogMessageAsync(string message);
    }
}
