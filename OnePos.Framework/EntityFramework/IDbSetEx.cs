using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Collections;

namespace OnePos.Framework.EntityFramework
{
    public static class DbSetExExtensions
    {
        public static IQueryable<T> Extend<T>(this IDbSet<T> self) where T : class
        {
            return new DbSetEx<T>(self);
        }
    }

    public class DbSetEx<T> : IQueryable<T>
    {
        private readonly IQueryable<T> _source;
        private readonly QueryProviderEx _provider;

        public DbSetEx(IQueryable<T> source)
        {
            _source = source;
            _provider = new QueryProviderEx(_source.Provider);
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            return _source.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _source.GetEnumerator();
        }

        public Type ElementType { get { return _source.ElementType; } }

        public Expression Expression { get { return _source.Expression; } }

        public IQueryProvider Provider { get { return _provider; } }
    }


    public class QueryProviderEx : IQueryProvider
    {
        private readonly IQueryProvider _source;

        public QueryProviderEx(IQueryProvider source)
        {
            _source = source;
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            var newExpression = EnumRewriterVisitor.Default.Visit(expression);
            var query = _source.CreateQuery<TElement>(newExpression);
            return new DbSetEx<TElement>(query);
        }

        public IQueryable CreateQuery(Expression expression)
        {
            var newExpression = EnumRewriterVisitor.Default.Visit(expression);
            var query = _source.CreateQuery(newExpression);
            return query;
        }

        public TResult Execute<TResult>(Expression expression)
        {
            var newExpression = EnumRewriterVisitor.Default.Visit(expression);
            return _source.Execute<TResult>(newExpression);
        }

        public object Execute(Expression expression)
        {
            var newExpression = EnumRewriterVisitor.Default.Visit(expression);
            return _source.Execute(newExpression);
        }
    }
}
