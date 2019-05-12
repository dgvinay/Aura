using System;

namespace Aura.Common.Extensions
{
    /// <summary>
    /// </summary>
    public static class GenericExtensions
    {
        public static void EnsureNotNull<T>(this T obj, string parameterName = "") where T : class
        {
            if (obj.IsNull())
            {
                if (parameterName.HasValue())
                {
                    throw new ArgumentNullException(parameterName);
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        /// <summary>
        /// Determines whether [is not null] [the specified object].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <returns><c>true</c> if [is not null] [the specified object]; otherwise, <c>false</c>.</returns>
        public static bool IsNotNull<T>(this T obj) where T : class, new()
        {
            return obj != null;
        }

        /// <summary>
        /// Determines whether the specified object is null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <returns><c>true</c> if the specified object is null; otherwise, <c>false</c>.</returns>
        public static bool IsNull<T>(this T obj) where T : class
        {
            return obj == null;
        }
    }
}