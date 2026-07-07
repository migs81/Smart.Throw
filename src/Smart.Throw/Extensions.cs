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
        /// Throws the given exception if the expression is true.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arg"></param>
        /// <param name="expression"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
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
        /// Throws an ArgumentNullException if the given argument is null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arg"></param>
        /// <param name="message"></param>
        /// <returns>The given argument.</returns>
        public static T ThrowIfNull<T>(this T arg, string message = "Argument can not be null!")
        {
            Throw<ArgumentNullException>.IfNull(arg, message);
            return arg;
        }

        /// <summary>
        /// Throws an ArgumentException if the given value is null or empty.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="message"></param>
        /// <returns>The given value.</returns>
        public static string ThrowIfNullOrEmpty(this string value, string message = "Argument can not be null or empty!")
        {
            Throw<ArgumentException>.IfNullOrEmpty(value, message);
            return value;
        }

        /// <summary>
        /// Throws an ArgumentException if the given collection is null or empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="message"></param>
        /// <returns>The given collection.</returns>
        public static IEnumerable<T> ThrowIfNullOrEmpty<T>(this IEnumerable<T> collection, string message = "Argument can not be null or empty!")
        {
            Throw<ArgumentException>.IfNullOrEmpty(collection, message);
            return collection;
        }

        /// <summary>
        /// Throws an ArgumentException if the given collection is null or empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="message"></param>
        /// <returns>The given collection.</returns>
        public static ICollection<T> ThrowIfNullOrEmpty<T>(this ICollection<T> collection, string message = "Argument can not be null or empty!")
        {
            Throw<ArgumentException>.IfNullOrEmpty(collection, message);
            return collection;
        }
        
        /// <summary>
        /// Throws an ArgumentException if the given value is null, empty or consists only of white-space characters.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="message"></param>
        /// <returns>The given value.</returns>
        public static string ThrowIfNullOrWhiteSpace(this string value, string message = "Argument can not be null, empty or consists only of white-space characters!")
        {
            Throw<ArgumentException>.IfNullOrWhiteSpace(value, message);
            return value;
        }
    }
}
