namespace IntelliDiff.Specs
{
    using System.Collections.Generic;

    public class DiffComparer : IEqualityComparer<DiffList>
    {
        public bool Equals(Diff x, Diff y)
        {
            return x.Line == y.Line && x.Type == y.Type && x.Value == y.Value;
        }

        public int GetHashCode(Diff obj)
        {
            throw new System.NotImplementedException();
        }
    }
}