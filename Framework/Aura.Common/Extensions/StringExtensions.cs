using System.IO;

namespace Aura.Common.Extensions
{
    /// <summary>
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Determines whether this instance has value.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns><c>true</c> if the specified string has value; otherwise, <c>false</c>.</returns>
        public static bool HasValue(this string str)
        {
            return !string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// Determines whether [is valid file path].
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns><c>true</c> if [is valid file path] [the specified path]; otherwise, <c>false</c>.</returns>
        public static bool IsValidFilePath(this string path)
        {
            return path.HasValue() && File.Exists(path);
        }

        /// <summary>
        /// Determines whether [is valid folder path].
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns><c>true</c> if [is valid folder path] [the specified path]; otherwise, <c>false</c>.</returns>
        public static bool IsValidFolderPath(this string path)
        {
            return Directory.Exists(path);
        }
    }
}