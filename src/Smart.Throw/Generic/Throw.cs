using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Smart.Throw.Helper;

namespace Smart.Throw.Generic
{
    /// <summary>
    /// Contains some methods for throwing exceptions on specific conditions.
    /// </summary>
    /// <typeparam name="TException"></typeparam>
    public static class Throw<TException> where TException : Exception
    {
        #region New

        /// <summary>
        /// Throws a new exception of the specified type with the specified arguments.
        /// </summary>
        /// <param name="message">The error message</param>
        public static void New(string message) => New(message, null, null);

        /// <summary>
        /// Throws a new exception of the specified type with the specified arguments.
        /// </summary>
        /// <param name="message">The error message</param>
        /// <param name="paramName">Name of the parameter. Only used for argument exceptions!</param>
        public static void New(string message, string paramName) => New(message, paramName, null);

        /// <summary>
        /// Throws a new exception of the specified type with the specified arguments.
        /// </summary>
        /// <param name="message">The error message</param>
        /// <param name="innerException">The inner exception.</param>
        public static void New(string message, Exception innerException) => New(message, null, innerException);

        /// <summary>
        /// Throws a new exception of the specified type with the specified arguments.
        /// </summary>
        /// <param name="message">The error message</param>
        /// <param name="paramName">Name of the parameter. Only used for argument exceptions!</param>
        /// <param name="innerException">The inner exception.</param>
        public static void New(string message, string? paramName, Exception? innerException) =>
            throw ExceptionHelper.Create<TException>(message, paramName, innerException);

        #endregion
        
        #region If

        /// <summary>
        /// Throws the specified exception if the condition is <see langword="true"/>.
        /// </summary>
        /// <param name="condition">The condition that determines whether the exception is thrown.</param>
        public static void If([DoesNotReturnIf(true)] bool condition) =>
            If(condition, null, null, null);

        /// <summary>
        /// Throws an <see cref="Exception"/> with the specified message if the condition is <see langword="true"/>.
        /// </summary>
        /// <param name="condition">The condition that determines whether the exception is thrown.</param>
        /// <param name="message">The message describing the exception.</param>
        public static void If([DoesNotReturnIf(true)] bool condition, string message) =>
            If(condition, message, null, null);

        /// <summary>
        /// Throws the specified exception if the condition is <see langword="true"/>.
        /// </summary>
        /// <param name="condition">The condition that determines whether the exception is thrown.</param>
        /// <param name="message">The message describing the exception.</param>
        /// <param name="innerException">The inner exception that caused the current exception.</param>
        public static void If([DoesNotReturnIf(true)] bool condition, string message, Exception innerException) =>
            If(condition, message, null, innerException);

        /// <summary>
        /// Throws the specified exception if the condition is <see langword="true"/>.
        /// </summary>
        /// <param name="condition">The condition that determines whether the exception is thrown.</param>
        /// <param name="message">The message describing the exception.</param>
        /// <param name="paramName">Used only if TException is of type ArgumentException</param>
        /// <param name="innerException">The inner exception that caused the current exception.</param>
        public static void If([DoesNotReturnIf(true)] bool condition, string? message, string? paramName,
            Exception? innerException)
        {
            if (condition)
                throw ExceptionHelper.Create<TException>(message, paramName, innerException);
        }

        #endregion

        #region IfNull

        /// <summary>
        /// Throws the specified exception if the specified argument is <see langword="null"/>.
        /// </summary>
        /// <param name="obj">The object to check for <see langword="null"/>.</param>
        public static void IfNull(object? obj) => IfNull(obj, null, null, null);

        /// <summary>
        /// Throws the specified exception if the specified object is <see langword="null"/>.
        /// </summary>
        /// <param name="obj">The object to check for <see langword="null"/>.</param>
        /// <param name="message">The message describing the exception.</param>
        public static void IfNull(object? obj, string message) => IfNull(obj, message, null, null);

        /// <summary>
        /// Throws the specified exception if the specified object is <see langword="null"/>.
        /// </summary>
        /// <param name="obj">The object to check for <see langword="null"/>.</param>
        /// <param name="message">The message describing the exception.</param>
        /// <param name="innerException">The inner exception that caused the current exception.</param>
        public static void IfNull(object? obj, string message, Exception innerException) => 
            IfNull(obj, message, null, innerException);

        /// <summary>
        /// Throws the specified exception if the specified object is <see langword="null"/>.
        /// </summary>
        /// <param name="obj">The object to check for <see langword="null"/>.</param>
        /// <param name="message">The message describing the exception.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="innerException">The inner exception that caused the current exception.</param>
        public static void IfNull(object? obj, string? message, string? paramName, Exception? innerException) 
            => _ = obj ?? throw ExceptionHelper.Create<TException>(message, paramName, innerException);

        #endregion

        #region IfNullOrEmpty

        /// <summary>
        /// Throws the specified exception if the specified value is <see langword="null"/> or empty.
        /// </summary>
        /// <param name="value">The string to check.</param>
        public static void IfNullOrEmpty(string? value) => 
            IfNullOrEmpty(value, null, null, null);

        /// <summary>
        /// Throws the specified exception if the specified value is <see langword="null"/> or empty.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <param name="message">The message describing the exception.</param>
        public static void IfNullOrEmpty(string? value, string message) => 
            IfNullOrEmpty(value, message, null, null);

        /// <summary>
        /// Throws the specified exception if the specified value is <see langword="null"/> or empty.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <param name="message">The message describing the exception.</param>
        /// <param name="innerException">The inner exception that caused the current exception.</param>
        public static void IfNullOrEmpty(string? value, string message, Exception innerException) => 
            IfNullOrEmpty(value, message, null, innerException);

        /// <summary>
        /// Throws the specified exception if the specified value is <see langword="null"/> or empty.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <param name="message">The message describing the exception.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="innerException">The inner exception that caused the current exception.</param>
        public static void IfNullOrEmpty(string? value, string? message, string? paramName, Exception? innerException)
        {
            if (string.IsNullOrEmpty(value))
                throw ExceptionHelper.Create<TException>(message, paramName, innerException);
        }

        /// <summary>
        /// Throws the specified exception if the specified collection is <see langword="null"/> or empty.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection to check.</param>
        public static void IfNullOrEmpty<T>(IEnumerable<T>? collection) => 
            IfNullOrEmpty(collection, null, null, null);

        /// <summary>
        /// Throws the specified exception if the specified collection is <see langword="null"/> or empty.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection to check.</param>
        /// <param name="message">The message describing the exception.</param>
        public static void IfNullOrEmpty<T>(IEnumerable<T>? collection, string message) => 
            IfNullOrEmpty(collection, message, null, null);

        /// <summary>
        /// Throws the specified exception if the specified collection is <see langword="null"/> or empty.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection to check.</param>
        /// <param name="message">The message describing the exception.</param>
        /// <param name="innerException">The inner exception that caused the current exception.</param>
        public static void IfNullOrEmpty<T>(IEnumerable<T>? collection, string message, Exception innerException) => 
            IfNullOrEmpty(collection, message, null, innerException);

        /// <summary>
        /// Throws the specified exception if the specified collection is <see langword="null"/> or empty.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection to check.</param>
        /// <param name="message">The message describing the exception.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="innerException">The inner exception that caused the current exception.</param>
        public static void IfNullOrEmpty<T>(IEnumerable<T>? collection, string? message, string? paramName, 
            Exception? innerException)
        {
            if (collection is null || !collection.Any())
                throw ExceptionHelper.Create<TException>(message, paramName, innerException);
        }

        /// <summary>
        /// Throws the specified exception if the specified collection is <see langword="null"/> or empty.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection to check.</param>
        public static void IfNullOrEmpty<T>(ICollection<T>? collection) => 
            IfNullOrEmpty(collection, null, null, null);

        /// <summary>
        /// Throws the specified exception if the specified collection is <see langword="null"/> or empty.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection to check.</param>
        /// <param name="message">The message describing the exception.</param>
        public static void IfNullOrEmpty<T>(ICollection<T>? collection, string message) => 
            IfNullOrEmpty(collection, message, null, null);

        /// <summary>
        /// Throws the specified exception if the specified collection is <see langword="null"/> or empty.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection to check.</param>
        /// <param name="message">The message describing the exception.</param>
        /// <param name="innerException">The inner exception that caused the current exception.</param>
        public static void IfNullOrEmpty<T>(ICollection<T>? collection, string message, Exception innerException) 
            => IfNullOrEmpty(collection, message, null, innerException);

        /// <summary>
        /// Throws the specified exception if the specified collection is <see langword="null"/> or empty.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection to check.</param>
        /// <param name="message">The message describing the exception.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="innerException">The inner exception that caused the current exception.</param>
        public static void IfNullOrEmpty<T>(ICollection<T>? collection, string? message, string? paramName, 
            Exception? innerException)
        {
            if (collection is null || collection.Count == 0)
                throw ExceptionHelper.Create<TException>(message, paramName, innerException);
        }

        #endregion

        #region IfNullOrWhiteSpace

        /// <summary>
        /// Throws the specified exception if the specified value is <see langword="null"/>, empty or consists only of white-space characters.
        /// </summary>
        /// <param name="value">The string to check.</param>
        public static void IfNullOrWhiteSpace(string? value) => 
            IfNullOrWhiteSpace(value, null, null, null);

        /// <summary>
        /// Throws the specified exception if the specified value is <see langword="null"/>, empty or consists only of white-space characters.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <param name="message">The message describing the exception.</param>
        public static void IfNullOrWhiteSpace(string? value, string message) => 
            IfNullOrWhiteSpace(value, message, null, null);

        /// <summary>
        /// Throws the specified exception if the specified value is <see langword="null"/>, empty or consists only of white-space characters.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <param name="message">The message describing the exception.</param>
        /// <param name="innerException">The inner exception that caused the current exception.</param>
        public static void IfNullOrWhiteSpace(string? value, string message, Exception innerException) 
            => IfNullOrWhiteSpace(value, message, null, innerException);

        /// <summary>
        /// Throws the specified exception if the specified value is <see langword="null"/>, empty or consists only of white-space characters.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <param name="message">The message describing the exception.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="innerException">The inner exception that caused the current exception.</param>
        public static void IfNullOrWhiteSpace(string? value, string? message, string? paramName, 
            Exception? innerException)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw ExceptionHelper.Create<TException>(message, paramName, innerException);
        }

        #endregion

        #region IfAnyNull

        /// <summary>
        /// Throws the specified exception if any of the specified objects is <see langword="null"/>.
        /// </summary>
        /// <param name="args">The objects and their corresponding exceptions to check.</param>
        /// <exception cref="ArgumentNullException"><paramref name="args"/></exception>
        public static void IfAnyNull(params object[] args)
        {
            _ = args ?? throw new ArgumentNullException(nameof(args));

            foreach (var arg in args)
                IfNull(arg, null, null, null);
        }

        /// <summary>
        /// Throws the specified exception if any of the specified objects is <see langword="null"/>.
        /// </summary>
        /// <param name="args">tuple with object and message</param>
        /// <exception cref="ArgumentNullException"><paramref name="args"/></exception>
        public static void IfAnyNull(params (object obj, string message)[] args)
        {
            _ = args ?? throw new ArgumentNullException(nameof(args));

            foreach (var (obj, message) in args)
                IfNull(obj, message);
        }

        #endregion

        #region IfAnyNullOrEmpty

        /// <summary>
        /// Throws the specified exception if any of the specified values is <see langword="null"/> or empty.
        /// </summary>
        /// <param name="values"></param>
        /// <exception cref="ArgumentNullException"><paramref name="values"/></exception>
        public static void IfAnyNullOrEmpty(params string[] values)
        {
            _ = values ?? throw new ArgumentNullException(nameof(values));

            foreach (var value in values)
                IfNullOrEmpty(value, null, null, null);
        }

        /// <summary>
        /// Throws the specified exception if any of the specified string values is <see langword="null"/> or empty.
        /// </summary>
        /// <param name="args">tuple with </param>
        /// <exception cref="ArgumentNullException"><paramref name="args"/></exception>
        public static void IfAnyNullOrEmpty(params (string value, string message)[] args)
        {
            _ = args ?? throw new ArgumentNullException(nameof(args));

            foreach (var (value, message) in args)
                IfNullOrEmpty(value, message);
        }

        #endregion
    }
}