// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReflectionHelper.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ReflectionHelper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;

    public static class ReflectionHelper
    {
        #region Public Methods and Operators

        public static MethodInfo GetMethodInfo<TSource, TSignature>(
            Expression<Func<TSource, TSignature>> lambdaExpression)
        {
            var unaryExpression = lambdaExpression.Body as UnaryExpression;
            if (unaryExpression == null)
            {
                throw new InvalidOperationException();
            }

            var methodCallExpression = unaryExpression.Operand as MethodCallExpression;
            if (methodCallExpression == null)
            {
                throw new InvalidOperationException();
            }

            if (methodCallExpression.Arguments.Count < 3)
            {
                throw new InvalidOperationException();
            }

            // TODO: use methodCallExpression.Object with .NET 4.5
            var constantExpression = methodCallExpression.Arguments[2] as ConstantExpression;
            if (constantExpression == null)
            {
                throw new InvalidOperationException();
            }

            var methodInfo = constantExpression.Value as MethodInfo;
            if (methodInfo == null)
            {
                throw new InvalidOperationException();
            }

            return methodInfo;
        }

        public static PropertyInfo GetPropertyInfo<TSource>(Expression<Func<TSource, object>> propertyExpression)
        {
            var lambdaExpression = propertyExpression as LambdaExpression;
            if (lambdaExpression == null)
            {
                throw new InvalidOperationException();
            }

            MemberExpression memberExpression;
            var unaryExpression = lambdaExpression.Body as UnaryExpression;
            if (unaryExpression != null)
            {
                memberExpression = unaryExpression.Operand as MemberExpression;
            }
            else
            {
                memberExpression = lambdaExpression.Body as MemberExpression;
            }

            if (memberExpression == null)
            {
                throw new InvalidOperationException();
            }

            var propertyInfo = memberExpression.Member as PropertyInfo;
            if (propertyInfo == null)
            {
                throw new InvalidOperationException();
            }

            return propertyInfo;
        }

        public static bool IsStruct(Type type)
        {
            return type.IsValueType && type.IsPrimitive == false && type.IsEnum == false;
        }

        #endregion
    }
}