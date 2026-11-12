using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Smart.Throw.Generic;

namespace Smart.Throw
{
    /// <summary>
    /// Contains some extension methods for various types.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Throws the specified exception if the specified expression evaluates to <see langword="true"/>.
        /// Otherwise, returns the original argument.
        /// </summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="arg">The argument to evaluate.</param>
        /// <param name="expression">The expression used to determine whether the exception should be thrown.</param>
        /// <param name="exception">The exception to throw. Must not be <see langword="null"/>.</param>
        /// <returns>The original argument.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="expression"/> or <paramref name="exception"/> is <see langword="null"/>.</exception>
        /// <exception cref="Exception">The expression evaluates to <see langword="true"/>.</exception>
        public static T ThrowIf<T>(this T arg, Expression<Func<T, bool>> expression, Exception exception)
        {
            _ = expression ?? throw new ArgumentNullException(nameof(expression));
            _ = exception ?? throw new ArgumentNullException(nameof(exception));

            // check expression result
            if(expression.Compile().Invoke(arg))
                throw exception;

            return arg;
        }

        /// <summary>
        /// Throws an ArgumentNullException if the specified argument is <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="arg">The argument to evaluate.</param>
        /// <param name="message">The message describing the exception.</param>
        /// <returns>The original argument.</returns>
        public static T ThrowIfNull<T>(this T arg, string message = "Argument can not be null!")
        {
            Throw<ArgumentNullException>.IfNull(arg, message);
            return arg;
        }

        /// <summary>
        /// Throws an ArgumentException if the specified value is <see langword="null"/> or empty.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <param name="message">The message describing the exception.</param>
        /// <returns>The original argument.</returns>
        public static string ThrowIfNullOrEmpty(this string value, string message = "Argument can not be null or empty!")
        {
            Throw<ArgumentException>.IfNullOrEmpty(value, message);
            return value;
        }

        /// <summary>
        /// Throws an ArgumentException if the specified collection is <see langword="null"/> or empty.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection to check.</param>
        /// <param name="message">The message describing the exception.</param>
        /// <returns>The original collection.</returns>
        public static IEnumerable<T> ThrowIfNullOrEmpty<T>(this IEnumerable<T> collection, string message = "Argument can not be null or empty!")
        {
            Throw<ArgumentException>.IfNullOrEmpty(collection, message);
            return collection;
        }

        /// <summary>
        /// Throws an ArgumentException if the specified collection is <see langword="null"/> or empty.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection to check.</param>
        /// <param name="message">The message describing the exception.</param>
        /// <returns>The original collection.</returns>
        public static ICollection<T> ThrowIfNullOrEmpty<T>(this ICollection<T> collection, string message = "Argument can not be null or empty!")
        {
            Throw<ArgumentException>.IfNullOrEmpty(collection, message);
            return collection;
        }
        
        /// <summary>
        /// Throws an ArgumentException if the specified value is <see langword="null"/>, empty or consists only of white-space characters.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <param name="message">The message describing the exception.</param>
        /// <returns>The original value.</returns>
        public static string ThrowIfNullOrWhiteSpace(this string value, string message = "Argument can not be null, empty or consists only of white-space characters!")
        {
            Throw<ArgumentException>.IfNullOrWhiteSpace(value, message);
            return value;
        }
    }
}
