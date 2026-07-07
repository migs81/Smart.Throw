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
        /// Throws a new exception of the given type with the given arguments.
        /// </summary>
        /// <param name="message">The error message</param>
        public static void New(string message) => New(message, null, null);

        /// <summary>
        /// Throws a new exception of the given type with the given arguments.
        /// </summary>
        /// <param name="message">The error message</param>
        /// <param name="paramName">Name of the parameter. Only used for argument exceptions!</param>
        public static void New(string message, string paramName) => New(message, paramName, null);

        /// <summary>
        /// Throws a new exception of the given type with the given arguments.
        /// </summary>
        /// <param name="message">The error message</param>
        /// <param name="innerException">The inner exception.</param>
        public static void New(string message, Exception innerException) => New(message, null, innerException);

        /// <summary>
        /// Throws a new exception of the given type with the given arguments.
        /// </summary>
        /// <param name="message">The error message</param>
        /// <param name="paramName">Name of the parameter. Only used for argument exceptions!</param>
        /// <param name="innerException">The inner exception.</param>
        public static void New(string message, string? paramName, Exception? innerException) =>
            throw ExceptionHelper.Create<TException>(message, paramName, innerException);

        #endregion

        #region If

        /// <summary>
        /// Throws the specified exception if the given condition is true.
        /// </summary>
        /// <param name="condition"></param>
        public static void If([DoesNotReturnIf(true)] bool condition) =>
            If(condition, null, null, null);

        /// <summary>
        /// Throws the specified exception if the given condition is true.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="message"></param>
        public static void If([DoesNotReturnIf(true)] bool condition, string message) =>
            If(condition, message, null, null);

        /// <summary>
        /// Throws the specified exception if the given condition is true.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public static void If([DoesNotReturnIf(true)] bool condition, string message, Exception innerException) =>
            If(condition, message, null, innerException);

        /// <summary>
        /// Throws the specified exception if the given condition is true.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="message"></param>
        /// <param name="paramName">Used only if TException is of type ArgumentException</param>
        /// <param name="innerException"></param>
        public static void If([DoesNotReturnIf(true)] bool condition, string? message, string? paramName, Exception? innerException)
        {
            if (condition)
                throw ExceptionHelper.Create<TException>(message, paramName, innerException);
        }

        #endregion

        #region IfNull

        /// <summary>
        /// Throws the specified exception if the given argument is null.
        /// </summary>
        /// <param name="obj"></param>
        public static void IfNull(object? obj) => IfNull(obj, null, null, null);

        /// <summary>
        /// Throws the specified exception if the given object is null.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="message"></param>
        public static void IfNull(object? obj, string message) => IfNull(obj, message, null, null);

        /// <summary>
        /// Throws the specified exception if the given object is null.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public static void IfNull(object? obj, string message, Exception innerException) => 
            IfNull(obj, message, null, innerException);

        /// <summary>
        /// Throws the specified exception if the given object is null.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="message"></param>
        /// <param name="paramName"></param>
        /// <param name="innerException"></param>
        public static void IfNull(object? obj, string? message, string? paramName, Exception? innerException) 
            => _ = obj ?? throw ExceptionHelper.Create<TException>(message, paramName, innerException);

        #endregion

        #region IfNullOrEmpty

        /// <summary>
        /// Throws the specified exception if the given value is null or empty.
        /// </summary>
        /// <param name="value"></param>
        public static void IfNullOrEmpty(string? value) => 
            IfNullOrEmpty(value, null, null, null);

        /// <summary>
        /// Throws the specified exception if the given value is null or empty.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="message"></param>
        public static void IfNullOrEmpty(string? value, string message) => 
            IfNullOrEmpty(value, message, null, null);

        /// <summary>
        /// Throws the specified exception if the given value is null or empty.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public static void IfNullOrEmpty(string? value, string message, Exception innerException) => 
            IfNullOrEmpty(value, message, null, innerException);

        /// <summary>
        /// Throws the specified exception if the given value is null or empty.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="message"></param>
        /// <param name="paramName"></param>
        /// <param name="innerException"></param>
        public static void IfNullOrEmpty(string? value, string? message, string? paramName, Exception? innerException)
        {
            if (string.IsNullOrEmpty(value))
                throw ExceptionHelper.Create<TException>(message, paramName, innerException);
        }

        /// <summary>
        /// Throws the specified exception if the given collection is null or empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        public static void IfNullOrEmpty<T>(IEnumerable<T>? collection) => 
            IfNullOrEmpty(collection, null, null, null);

        /// <summary>
        /// Throws the specified exception if the given collection is null or empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="message"></param>
        public static void IfNullOrEmpty<T>(IEnumerable<T>? collection, string message) => 
            IfNullOrEmpty(collection, message, null, null);

        /// <summary>
        /// Throws the specified exception if the given collection is null or empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public static void IfNullOrEmpty<T>(IEnumerable<T>? collection, string message, Exception innerException) => 
            IfNullOrEmpty(collection, message, null, innerException);

        /// <summary>
        /// Throws the specified exception if the given collection is null or empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="message"></param>
        /// <param name="paramName"></param>
        /// <param name="innerException"></param>
        public static void IfNullOrEmpty<T>(IEnumerable<T>? collection, string? message, string? paramName, Exception? innerException)
        {
            if (collection is null || !collection.Any())
                throw ExceptionHelper.Create<TException>(message, paramName, innerException);
        }

        /// <summary>
        /// Throws the specified exception if the given collection is null or empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        public static void IfNullOrEmpty<T>(ICollection<T>? collection) => 
            IfNullOrEmpty(collection, null, null, null);

        /// <summary>
        /// Throws the specified exception if the given collection is null or empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="message"></param>
        public static void IfNullOrEmpty<T>(ICollection<T>? collection, string message) => 
            IfNullOrEmpty(collection, message, null, null);

        /// <summary>
        /// Throws the specified exception if the given collection is null or empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public static void IfNullOrEmpty<T>(ICollection<T>? collection, string message, Exception innerException) 
            => IfNullOrEmpty(collection, message, null, innerException);

        /// <summary>
        /// Throws the specified exception if the given collection is null or empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="message"></param>
        /// <param name="paramName"></param>
        /// <param name="innerException"></param>
        public static void IfNullOrEmpty<T>(ICollection<T>? collection, string? message, string? paramName, Exception? innerException)
        {
            if (collection is null || collection.Count == 0)
                throw ExceptionHelper.Create<TException>(message, paramName, innerException);
        }

        #endregion

        #region IfNullOrWhiteSpace

        /// <summary>
        /// Throws the specified exception if the given value is null, empty or consists only of white-space characters.
        /// </summary>
        /// <param name="value"></param>
        public static void IfNullOrWhiteSpace(string? value) => 
            IfNullOrWhiteSpace(value, null, null, null);

        /// <summary>
        /// Throws the specified exception if the given value is null, empty or consists only of white-space characters.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="message"></param>
        public static void IfNullOrWhiteSpace(string? value, string message) => 
            IfNullOrWhiteSpace(value, message, null, null);

        /// <summary>
        /// Throws the specified exception if the given value is null, empty or consists only of white-space characters.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public static void IfNullOrWhiteSpace(string? value, string message, Exception innerException) 
            => IfNullOrWhiteSpace(value, message, null, innerException);

        /// <summary>
        /// Throws the specified exception if the given value is null, empty or consists only of white-space characters.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="message"></param>
        /// <param name="paramName"></param>
        /// <param name="innerException"></param>
        public static void IfNullOrWhiteSpace(string? value, string? message, string? paramName, Exception? innerException)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw ExceptionHelper.Create<TException>(message, paramName, innerException);
        }

        #endregion

        #region IfAnyNull

        /// <summary>
        /// Throws the specified exception if any of the given objects is null.
        /// </summary>
        /// <param name="args"></param>
        /// <exception cref="ArgumentNullException"><paramref name="args"/></exception>
        public static void IfAnyNull(params object[] args)
        {
            _ = args ?? throw new ArgumentNullException(nameof(args));

            foreach (var arg in args)
                IfNull(arg, null, null, null);
        }

        /// <summary>
        /// Throws the specified exception if any of the given objects is null.
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
        /// Throws the specified exception if any of the given values is null or empty.
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
        /// Throws the specified exception if any of the given string values is null or empty.
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