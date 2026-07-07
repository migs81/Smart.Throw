using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using Smart.Throw.Generic;

namespace Smart.Throw.Benchmarks
{
    [MemoryDiagnoser]
    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Alphabetical)]
    [SimpleJob(RuntimeMoniker.Net80)]
    [SimpleJob(RuntimeMoniker.Net10_0, baseline: true)]
    public class ThrowBenchmarks
    {
        private readonly string _testString = "test";
        private readonly string _testString2 = "test2";

        [Benchmark]
        public void Throw_TException_If_Null()
        {
            Throw<ArgumentNullException>.If(_testString is null);
        }

        [Benchmark]
        public void Throw_TException_If_NullOrEmpty()
        {
            Throw<ArgumentNullException>.If(string.IsNullOrEmpty(_testString));
        }
        
        [Benchmark]
        public void Throw_TException_IfNull()
        {
            Throw<ArgumentNullException>.IfNull(_testString);
        }
        
        [Benchmark]
        public void Throw_TException_IfNullOrEmpty()
        {
            Throw<ArgumentNullException>.IfNullOrEmpty(_testString);
        }
        
        [Benchmark]
        public void Throw_TException_Params_IfAnyNull()
        {
            Throw<ArgumentNullException>.IfAnyNull(_testString, _testString2);
        }
    }
}
