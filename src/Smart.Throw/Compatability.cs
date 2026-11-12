/*
 * For compatibility reasons with netstandard 2.0
 */
#if !NET5_0_OR_GREATER
using System;
namespace Smart.Throw
{
    [AttributeUsage(AttributeTargets.Parameter)]
    internal sealed class DoesNotReturnIfAttribute(bool parameterValue) : Attribute
    {
        public bool ParameterValue { get; } = parameterValue;
    }
}
#endif