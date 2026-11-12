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
        /// Throws the specified exception if the condition is <see langword="true"/>.
        /// </summary>
        /// <param name="condition">The condition that determines whether the exception is thrown.</param>
        /// <param name="exception">The exception to throw. Must not be <see langword="null"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="exception"/> is <see langword="null"/>.</exception>
        /// <exception cref="Exception"><paramref name="condition"/> is <see langword="true"/>.</exception>
        public static void If([DoesNotReturnIf(true)] bool condition, Exception exception)
        {
            _ = exception ?? throw new ArgumentNullException(nameof(exception));

            if (condition)
                throw exception;
        }

        /// <summary>
        /// Throws the specified exception if the specified object is <see langword="null"/>.
        /// </summary>
        /// <param name="obj">The object to check for <see langword="null"/>.</param>
        /// <param name="exception">The exception to throw. Must not be <see langword="null"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="exception"/> is <see langword="null"/>.</exception>
        public static void IfNull(object obj, Exception exception) => If(obj is null, exception);

        /// <summary>
        /// Throws the specified exception if the specified string is <see langword="null"/> or empty.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <param name="exception">The exception to throw. Must not be <see langword="null"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="exception"/> is <see langword="null"/>.</exception>
        public static void IfNullOrEmpty(string value, Exception exception) => If(string.IsNullOrEmpty(value), exception);

        /// <summary>
        /// Throws the specified exception if the specified collection is <see langword="null"/> or empty.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection to check.</param>
        /// <param name="exception">The exception to throw. Must not be <see langword="null"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="exception"/> is <see langword="null"/>.</exception>
        public static void IfNullOrEmpty<T>(IEnumerable<T>? collection, Exception exception) => If(collection is null || !collection.Any(), exception);

        /// <summary>
        /// Throws the specified exception if the specified collection is <see langword="null"/> or empty.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection to check.</param>
        /// <param name="exception">The exception to throw. Must not be <see langword="null"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="exception"/> is <see langword="null"/>.</exception>
        public static void IfNullOrEmpty<T>(ICollection<T>? collection, Exception exception) => If(collection is null || collection.Count == 0, exception);

        /// <summary>
        /// Throws the corresponding exception for each specified object that is <see langword="null"/>.
        /// </summary>
        /// <param name="args">The objects and their corresponding exceptions to check.</param>
        /// <exception cref="ArgumentNullException"><paramref name="args"/> is <see langword="null"/>.</exception>
        public static void IfAnyNull(params (object obj, Exception exception)[] args)
        {
            _ = args ?? throw new ArgumentNullException(nameof(args));

            foreach (var (obj, exception) in args)
                If(obj is null, exception);
        }

        /// <summary>
        /// Throws the specified exception if the specified string is <see langword="null"/>, empty, or consists only of white-space characters.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <param name="exception">The exception to throw. Must not be <see langword="null"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="exception"/> is <see langword="null"/>.</exception>
        public static void IfNullOrWhiteSpace(string value, Exception exception) => If(string.IsNullOrWhiteSpace(value), exception);

        #endregion
    }
}
