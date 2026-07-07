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
        /// <param name="message"></param>
        /// <param name="paramName"></param>
        /// <param name="innerException"></param>
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
        /// Returns an object array with the given arguments for argument exceptions.
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <param name="message"></param>
        /// <param name="paramName"></param>
        /// <param name="innerException"></param>
        /// <returns></returns>
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
