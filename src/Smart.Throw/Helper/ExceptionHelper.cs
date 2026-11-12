using System;
using System.Collections.Generic;

namespace Smart.Throw.Helper
{
    /// <summary>
    /// Contains helper methods
    /// </summary>
    internal static class ExceptionHelper
    {
        /// <summary>
        /// Returns a new instance of the specified exception type.
        /// </summary>
        /// <param name="message">The message describing the exception.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="innerException">The inner exception that caused the current exception.</param>
        /// <returns></returns>
        internal static TException Create<TException>(string? message = null, string? paramName = null, Exception? innerException = null) 
            where TException : Exception
#if NETSTANDARD2_0
            => typeof(ArgumentException).IsAssignableFrom(typeof(TException))
#else
            => typeof(TException).IsAssignableTo(typeof(ArgumentException))
#endif
            ? (TException)Activator.CreateInstance(typeof(TException), GetArgs<TException>(message, paramName, innerException))
            : (TException)Activator.CreateInstance(typeof(TException), GetArgs<TException>(message, null, innerException));

        /// <summary>
        /// Returns an object array with the specified arguments for argument exceptions.
        /// </summary>
        /// <typeparam name="TException">The type of exception to create arguments for.</typeparam>
        /// <param name="message">The message describing the exception.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="innerException">The inner exception that caused the current exception.</param>
        /// <returns>An array of arguments suitable for constructing the specified exception type.</returns>
        private static object[] GetArgs<TException>(string? message = null, string? paramName = null, Exception? innerException = null) 
            where TException : Exception
        {
            // message
            var args = new List<object>() { message ?? $"Exception of type '{typeof(TException).FullName}' was thrown." };

            // param name
            if(!string.IsNullOrEmpty(paramName))
            {
#if NETSTANDARD2_0
                if (typeof(ArgumentException).IsAssignableFrom(typeof(TException)))
#else
                if (typeof(TException).IsAssignableTo(typeof(ArgumentException)))
#endif
                    args.Add(paramName);
                else
                    args[0] = $"{args[0]} (parameter: {paramName})";
            }

            // inner exception
            if (innerException is not null)
                args.Add(innerException);

            return args.ToArray();
        }
    }
}
