using System.Linq.Expressions;

namespace OnePos.Framework.DynamicLinq
{
    internal class DynamicOrdering
    {
        public bool Ascending;
        public Expression Selector;
    }
}