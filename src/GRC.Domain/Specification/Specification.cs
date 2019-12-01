using GRC.Domain.Models;
using System; 
using System.Linq;
using System.Linq.Expressions;

namespace GRC.Domain.Specification
{

    /// <summary>
    /// https://github.com/vkhorikov/SpecificationPattern
    /// </summary>
    public class WhenTrueSpecificationProcess : Specification<Process>
    {
        public override Expression<Func<Process, bool>> ToExpression()
        {
            return process => true;
        }
    }

    public class WhenIdIs : Specification<Process>
    {
        public WhenIdIs(int id)
        {
            _id = id;
        }

        private int _id;

        public override Expression<Func<Process, bool>> ToExpression()
        {
            return process => process.Id == _id;
        }
    }

    public interface ISpecification
    {
        bool IsSatisfiedBy(object entity); 
    }

    public abstract class Specification<T>: ISpecification
    {

        public abstract Expression<Func<T, bool>> ToExpression();


        public bool IsSatisfiedBy(T entity)
        {
            Func<T, bool> predicate = ToExpression().Compile();
            return predicate(entity);
        }


        public Specification<T> And(Specification<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }


        public Specification<T> Or(Specification<T> specification)
        {
            return new OrSpecification<T>(this, specification);
        }

        public Specification<T> Not()
        {
            return new NotSpecification<T>(this);
        }

        bool ISpecification.IsSatisfiedBy(object entity)
        {
            T ent = (T)entity; 
            return IsSatisfiedBy(ent);
        }
    }


    public class AndSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _left;
        private readonly Specification<T> _right;


        public AndSpecification(Specification<T> left, Specification<T> right)
        {
            _right = right;
            _left = left;
        }


        public override Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> leftExpression = _left.ToExpression();
            Expression<Func<T, bool>> rightExpression = _right.ToExpression();

            var paramExpr = Expression.Parameter(typeof(T));
            var exprBody = Expression.AndAlso(leftExpression.Body, rightExpression.Body);
            exprBody = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(exprBody);
            var finalExpr = Expression.Lambda<Func<T, bool>>(exprBody, paramExpr);

            return finalExpr;

            //var invokedExpression = Expression.Invoke(rightExpression, leftExpression.Parameters);

            //return (Expression<Func<T, Boolean>>)Expression.Lambda(Expression.AndAlso(leftExpression.Body, invokedExpression), leftExpression.Parameters);

        }
    }


    public class OrSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _left;
        private readonly Specification<T> _right;


        public OrSpecification(Specification<T> left, Specification<T> right)
        {
            _right = right;
            _left = left;
        }


        public override Expression<Func<T, bool>> ToExpression()
        {
            var leftExpression = _left.ToExpression();
            var rightExpression = _right.ToExpression();

            var paramExpr = Expression.Parameter(typeof(T));
            var exprBody = Expression.OrElse(leftExpression.Body, rightExpression.Body);
            exprBody = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(exprBody);
            var finalExpr = Expression.Lambda<Func<T, bool>>(exprBody, paramExpr);

            return finalExpr;

            //var invokedExpression = Expression.Invoke(rightExpression, leftExpression.Parameters);

            //return (Expression<Func<T, Boolean>>)Expression.Lambda(Expression.OrElse(leftExpression.Body, invokedExpression), leftExpression.Parameters);
        }
    }

    internal sealed class NotSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _specification;

        public NotSpecification(Specification<T> specification)
        {
            _specification = specification;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> expression = _specification.ToExpression();
            UnaryExpression notExpression = Expression.Not(expression.Body);

            return Expression.Lambda<Func<T, bool>>(notExpression, expression.Parameters.Single());
        }
    }

    internal class ParameterReplacer : ExpressionVisitor
    {

        private readonly ParameterExpression _parameter;

        protected override Expression VisitParameter(ParameterExpression node)
            => base.VisitParameter(_parameter);

        internal ParameterReplacer(ParameterExpression parameter)
        {
            _parameter = parameter;
        }
    }
}
