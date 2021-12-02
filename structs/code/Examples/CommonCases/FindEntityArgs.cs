using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Examples.CommonCases
{
    public interface IEntitySearchService
    {
        Task<TEntity> Find<TEntity>(FindEntityArgs<TEntity> args);
    }

    public readonly struct FindEntityArgs<TEntity>
    {
        public readonly string SearchQuery;
        public readonly Paging Paging;
        public readonly SearchCondition<TEntity> Condition;

        public FindEntityArgs(string searchQuery, SearchCondition<TEntity> condition, Paging paging = default)
        {
            SearchQuery = searchQuery;
            Condition = condition;
            Paging = paging;
        }

        public FindEntityArgs(string searchQuery, Paging paging = default) : this(searchQuery, default, paging)
        {
        }
    }

    public readonly struct Paging
    {
        public readonly int Skip;
        public readonly int Take;

        public Paging(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }
    }

    public readonly struct SearchCondition<TEntity>
    {
        private readonly Expression<Func<TEntity, bool>> _predicate;

        // В C# 10 можно сделать так:
        // public SearchCondition() => 
        //     _predicate = DefaultPredicate;

        public SearchCondition(Expression<Func<TEntity, bool>> condition) =>
            _predicate = condition;

        public Expression<Func<TEntity, bool>> Predicate =>
            _predicate ?? DefaultPredicate;

        public static readonly Expression<Func<TEntity, bool>> DefaultPredicate = _ => true;
    }
}