using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionSample
{
    public static class InstanceCreater<T1, T2, TInstance>
    {
        /// <summary>
        /// 二つの引数を受け取ってTInstance型のインスタンスを生成します
        /// </summary>
        public static Func<T1, T2, TInstance> Create => CreateInstance();
        public static Func<T1, T2, TInstance> CreateInstance()
        {
            var argsType = new[] { typeof(T1), typeof(T2) };
            var constructor = typeof(TInstance).GetConstructor(BindingFlags.Public | BindingFlags.Instance, Type.DefaultBinder, argsType, null);
            var args = argsType.Select(Expression.Parameter).ToList();
            return Expression.Lambda<Func<T1, T2, TInstance>>(Expression.New(constructor, args), args).Compile();
        }
    }

    public static class InstanceCreater<TParam, TInstance>
    {
        /// <summary>
        /// 一つの引数を受け取ってTInstance型のインスタンスを生成します
        /// </summary>
        public static Func<TParam, TInstance> Create => CreateInstance();
        public static Func<TParam, TInstance> CreateInstance()
        {
            var arg = Expression.Parameter(typeof(TParam));
            var argsType = new[] { typeof(TParam) };
            var constructor = typeof(TInstance).GetConstructor(argsType);
            return Expression.Lambda<Func<TParam, TInstance>>(Expression.New(constructor, arg), arg).Compile();
        }
    }

    public static class InstanceCreater<TInstance>
    {
        /// <summary>
        /// TInstance型のインスタンスを生成します
        /// </summary>
        public static Func<TInstance> Create => CreateInstance();
        public static Func<TInstance> CreateInstance()
        {
            return Expression.Lambda<Func<TInstance>>(Expression.New(typeof(TInstance))).Compile();
        }
    }
}
