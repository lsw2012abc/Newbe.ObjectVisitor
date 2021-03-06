﻿using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace Newbe.ObjectVisitor.Validation
{
    internal static class NotMatchRegexRuleFactory
    {
        private static readonly ConcurrentDictionary<string, Regex> Regexes = new ConcurrentDictionary<string, Regex>();

        public static NotMatchRegexRule<T> Create<T>(string pattern)
        {
            var regex = Regexes.GetOrAdd(pattern, GlobalFactories.Validation.RegexFactory);
            return new NotMatchRegexRule<T>(regex);
        }

        public static NotMatchRegexRule<T> Create<T>(Regex regex)
        {
            return new NotMatchRegexRule<T>(regex);
        }
    }
}