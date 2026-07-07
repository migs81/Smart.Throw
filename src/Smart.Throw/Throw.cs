using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Smart.Throw
{
    /// <summary>
    /// Contains some methods for throwing exceptions on specific conditions.
    /// </summary>
    public static class Throw
    {
        #region public methods

        /// <summary>
        /// Throws the given exception if the given condition is true.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="exception"></param>w
        /// <exception cref="ArgumentNullException"><paramref name="exception"/> is <c>null</c>.</exception>
        public static void If([DoesNotReturnIf(true)] bool condition, Exception exception)
        {
            _ = exception ?? throw new ArgumentNullException(nameof(exception));

            if (condition)
                throw exception;
        }

        /// <summary>
        /// Throws the given exception if the given object is null.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="exception"></param>
        /// <exception cref="ArgumentNullException"><paramref name="exception"/> is <c>null</c>.</exception>
        public static void IfNull(object obj, Exception exception) => If(obj is null, exception);

        /// <summary>
        /// Throws the given exception if the given value is null or empty.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="exception"></param>
        /// <exception cref="ArgumentNullException"><paramref name="exception"/> is <c>null</c>.</exception>
        public static void IfNullOrEmpty(string value, Exception exception) => If(string.IsNullOrEmpty(value), exception);

        /// <summary>
        /// Throws the given exception if the given collection is null or empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="exception"></param>
        /// <exception cref="ArgumentNullException"><paramref name="exception"/> is <c>null</c>.</exception>
        public static void IfNullOrEmpty<T>(IEnumerable<T>? collection, Exception exception) => If(collection is null || !collection.Any(), exception);

        /// <summary>
        /// Throws the given exception if the given collection is null or empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="exception"></param>
        /// <exception cref="ArgumentNullException"><paramref name="exception"/> is <c>null</c>.</exception>
        public static void IfNullOrEmpty<T>(ICollection<T>? collection, Exception exception) => If(collection is null || collection.Count == 0, exception);

        /// <summary>
        /// Throws the given exception if any of the given objects is null.
        /// </summary>
        /// <param name="args"></param>
        /// <exception cref="ArgumentNullException"><paramref name="args"/> is <c>null</c>.</exception>
        public static void IfAnyNull(params (object obj, Exception exception)[] args)
        {
            _ = args ?? throw new ArgumentNullException(nameof(args));

            foreach (var (obj, exception) in args)
                If(obj is null, exception);
        }

        /// <summary>
        /// Throws the given exception if the given value is null, empty or consists only of white-space characters.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="exception"></param>
        /// <exception cref="ArgumentNullException"><paramref name="exception"/> is <c>null</c>.</exception>
        public static void IfNullOrWhiteSpace(string value, Exception exception) => If(string.IsNullOrWhiteSpace(value), exception);

        #endregion
    }
}
