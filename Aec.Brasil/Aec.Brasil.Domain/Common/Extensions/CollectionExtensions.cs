﻿using System;
using System.Collections.Generic;

namespace Aec.Brasil.Domain.Common.Extensions
{
	public static class CollectionExtensions
	{
		public static IEnumerable<TSource> DistinctBy<TSource, TKey>
			(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			HashSet<TKey> seenKeys = new HashSet<TKey>();
			foreach (TSource element in source)
			{
				if (seenKeys.Add(keySelector(element)))
				{
					yield return element;
				}
			}
		}
	}
}
