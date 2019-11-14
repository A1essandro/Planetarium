using System;
using System.Collections.Concurrent;

namespace Planetarium
{
    internal sealed class GravityCache : IDisposable
    {

        private ConcurrentDictionary<PairKey, double> _cache = new ConcurrentDictionary<PairKey, double>();

        public bool ContainsKey(IPlanet p1, IPlanet p2) => _cache.ContainsKey(new PairKey(p1, p2));

        public void Set(IPlanet p1, IPlanet p2, double value) => _cache[new PairKey(p1, p2)] = value;

        public double Get(IPlanet p1, IPlanet p2) => _cache[new PairKey(p1, p2)];

        public void Dispose()
        {
            _cache = null;
        }

        private struct PairKey
        {

            private readonly int _hashCode;

            public PairKey(IPlanet p1, IPlanet p2)
            {
                _hashCode = p1.GetHashCode() + p2.GetHashCode();
            }

            public override int GetHashCode()
            {
                return _hashCode;
            }
        }

    }
}
