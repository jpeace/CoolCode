using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CoolCode.Fx
{
    /// <summary>
    /// Provides access to information about a property expression for a type
    /// </summary>
    /// <typeparam name="T">The type containing the property this expression describes</typeparam>
    public class PropertyExpression<T>
    {
        private readonly Expression<Func<T, object>> _propertyExpression;
        private readonly PropertyInfo[] _propertyChain;
        private readonly object[] _customAttributes;
        private readonly Type _propertyType;

        /// <summary>
        /// Constructs a new property expression
        /// </summary>
        /// <param name="propertyExpression">An expression describing this property</param>
        public PropertyExpression(Expression<Func<T, object>> propertyExpression)
        {
            _propertyExpression = propertyExpression;

            var chain = new List<PropertyInfo>();
            var memberExpression = MemberExpression;

            while (memberExpression != null)
            {
                chain.Add((PropertyInfo)memberExpression.Member);
                memberExpression = memberExpression.Expression as MemberExpression;
            }
            _customAttributes = chain.First().GetCustomAttributes(false);
            _propertyType = chain.First().PropertyType;

            chain.Reverse();
            _propertyChain = chain.ToArray();
        }

        /// <summary>
        /// Given a target, retrieves the value pointed to by this expression
        /// </summary>
        /// <param name="target">The target to use for value resolution</param>
        /// <returns>The value of this property held by target</returns>
        public object GetValue(T target)
        {
            return BuildValue(target);
        }

        /// <summary>
        /// Given a target, retrieves the strongly-typed value pointed to by this expression
        /// </summary>
        /// <typeparam name="TReturnType">The type to cast the result to</typeparam>
        /// <param name="target">The target to use for value resolution</param>
        /// <returns>The value of this property held by target</returns>
        public TReturnType GetValue<TReturnType>(T target)
        {
            return (TReturnType)BuildValue(target);
        }

        /// <summary>
        /// The full name of the property described by this expression, separated by periods
        /// </summary>
        public string Name
        {
            get
            {
                return string.Join(".", _propertyChain.Select(p => p.Name).ToArray());
            }
        }

        /// <summary>
        /// The type of the property described by this expression
        /// </summary>
        public Type PropertyType
        {
            get { return _propertyType; }
        }

        /// <summary>
        /// Determines whether the property described by this expression is decorated by a given attribute
        /// </summary>
        /// <typeparam name="TAttribute">The type of the attribute to ask about</typeparam>
        /// <returns>True if the property described by this expression is decorated by TAttribute, false otherwise</returns>
        public bool HasAttribute<TAttribute>() where TAttribute : Attribute
        {
            return _customAttributes.Any(a => a.GetType() == typeof(TAttribute));
        }

        /// <summary>
        /// Determines whether the property described by this expression can by assigned to from a given type
        /// </summary>
        /// <typeparam name="TType">The type to check for assignment compatibility</typeparam>
        /// <returns>True if the property described by this expression can be assigned to from TType, false otherwise</returns>
        public bool IsOfType<TType>()
        {
            return _propertyType.IsAssignableFrom(typeof(TType));
        }

        private object BuildValue(object target)
        {
            foreach (var propertyInfo in _propertyChain)
            {
                target = propertyInfo.GetValue(target, null);
                if (target == null)
                {
                    return null;
                }
            }
            return target;
        }

        private MemberExpression MemberExpression
        {
            get
            {
                if (_propertyExpression == null)
                {
                    throw new ArgumentException("Property expression is null.");
                }

                var memberExpression = _propertyExpression.Body as MemberExpression;
                if (memberExpression == null)
                {
                    var convertExpression = _propertyExpression.Body as UnaryExpression;
                    if (convertExpression != null)
                    {
                        memberExpression = convertExpression.Operand as MemberExpression;
                    }

                    if (memberExpression == null)
                    {
                        throw new ArgumentException("Property expression does not represent member access.");
                    }
                }

                return memberExpression;
            }
        }
    }
}