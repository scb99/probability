﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Probability
{
    // Miscellaneous extension methods
    static class Extensions
    {
        public static string Histogram(
            this IEnumerable<double> d, double low, double high)
        {
            const int width = 40;
            const int height = 20;
            const int sampleCount = 100000;
            int[] buckets = new int[width];

            foreach (double c in d.Take(sampleCount))
            {
                int bucket = (int)(buckets.Length * (c - low) / (high - low));

                if (0 <= bucket && bucket < buckets.Length)
                {
                    buckets[bucket] += 1;
                }
            }

            int max = buckets.Max();
            double scale = max < height ? 1.0 : ((double)height) / max;

            return Enumerable.Range(0, height)
                             .Select(r => buckets.Select(b => b * scale > (height - r) ? '*' : ' ').Concatenated() + "\n")
                             .Concatenated()
                + new string('-', width) + "\n";
        }

        public static string DiscreteHistogram<T>(
            this IEnumerable<T> d)
        {
            const int sampleCount = 100000;
            const int width = 40;

            var dict = d.Take(sampleCount)
                .GroupBy(x => x)
                .ToDictionary(g => g.Key, g => g.Count());

            int labelMax = dict.Keys
                .Select(x => x.ToString().Length)
                .Max();

            var sup = dict.Keys.OrderBy(ToLabel).ToList();

            int max = dict.Values.Max();

            double scale = max < width ? 1.0 : ((double)width) / max;

            return sup.Select(s => $"{ToLabel(s)}|{Bar(s)}").NewlineSeparated();

            string ToLabel(T t) => t.ToString().PadLeft(labelMax);

            string Bar(T t) => new string('*', (int)(dict[t] * scale));
        }

        public static string Separated<T>(
            this IEnumerable<T> items, string s) => string.Join(s, items);

        public static string Concatenated<T>(
            this IEnumerable<T> items) => string.Join("", items);

        public static string CommaSeparated<T>(
            this IEnumerable<T> items) => items.Separated(",");

        public static string NewlineSeparated<T>(
            this IEnumerable<T> items) => items.Separated("\n");

        public static string SpaceSeparated<T>(
            this IEnumerable<T> items) => items.Separated(" ");

        public static int Product(
            this IEnumerable<int> numbers) => numbers.Aggregate(1, (a, b) => a * b);

        public static int GCD(int a, int b) =>
            b == 0 ? a : GCD(b, a % b);

        public static int GCD(
            this IEnumerable<int> numbers) => numbers.Aggregate(GCD);

        public static int LCM(int a, int b) =>
            a * b / GCD(a, b);

        public static int LCM(
            this IEnumerable<int> numbers) => numbers.Aggregate(1, LCM);

        static readonly char[] punct = "<>,*-()[#]@:%\"/';_&}".ToCharArray();

        public static IEnumerable<string> Words(
            this IEnumerable<string> lines) =>
                from line in lines
                from word in line.Split()
                let raw = word.Trim(punct)
                where raw != string.Empty
                select raw;

        public static IEnumerable<List<string>> Sentences(
            this IEnumerable<string> words) =>
                words.Split(w => 
                {
                    char c = w[w.Length - 1];

                    return c == '.' || c == '!' || c == '?';
                });

        public static IEnumerable<List<T>> Split<T>(
            this IEnumerable<T> items, Func<T, bool> last)
        {
            var list = new List<T>();

            foreach (T item in items)
            {
                list.Add(item);

                if (last(item))
                {
                    yield return list;

                    list = new List<T>();
                }
            }

            if (list.Any())
            {
                yield return list;
            }
        }
    }
}