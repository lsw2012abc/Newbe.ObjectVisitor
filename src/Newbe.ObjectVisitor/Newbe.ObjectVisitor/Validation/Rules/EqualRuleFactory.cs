﻿using System;
using System.Collections.Generic;

namespace Newbe.ObjectVisitor.Validation
{
    internal static class EqualRuleFactory
    {
        public static EqualRule<T, TValue> Create<T, TValue>(TValue expected)
            where TValue : IEquatable<TValue>
        {
            return new EqualRule<T, TValue>(expected, RuleExpressionHelper.Equal(expected));
        }

        public static EqualRule<T, TValue?> Create<T, TValue>(TValue? expected)
            where TValue : struct, IEquatable<TValue>
        {
            return new EqualRule<T, TValue?>(expected, RuleExpressionHelper.Equal(expected));
        }

        public static EqualRule<T, TValue> Create<T, TValue>(TValue expected, IEqualityComparer<TValue> comparer)
        {
            return new EqualRule<T, TValue>(expected, RuleExpressionHelper.Equal(expected, comparer));
        }
        
        public static EqualRule<T, TValue?> Create<T, TValue>(TValue? expected, IEqualityComparer<TValue?> comparer)
            where TValue : struct
        {
            return new EqualRule<T, TValue?>(expected, RuleExpressionHelper.Equal(expected, comparer));
        }
    }
}