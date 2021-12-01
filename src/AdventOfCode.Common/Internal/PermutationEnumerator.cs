#region License and Terms
/**
 * Sources:
 *  * https://github.com/morelinq/MoreLINQ/blob/master/MoreLinq/Permutations.cs
 *  * https://github.com/morelinq/MoreLINQ/blob/master/MoreLinq/NestedLoops.cs
 *
 * MoreLINQ - Extensions to LINQ to Objects
 * Copyright (c) 2010 Leopold Bushkin. All rights reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 * Modifications:
 *  * Removed comments
 *  * Removed exension
 *  * Cleaned-up code with CodeMaid
 *  * Included NestedLoops extension in file
 *  * Removed Assert() extension call from NestedLoops
 *  * Adapted code style to project style (var to int, etc.)
 */
#endregion License and Terms

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Common.Internal;

internal class PermutationEnumerator<T> : IEnumerator<IList<T>>
{
	private readonly IEnumerable<Action> _generator;
	private readonly int[] _permutation;
	private readonly IList<T> _valueSet;
	private IEnumerator<Action>? _generatorIterator;
	private bool _hasMoreResults;

	public PermutationEnumerator(IEnumerable<T> valueSet)
	{
		_valueSet = valueSet.ToArray();
		_permutation = new int[_valueSet.Count];

		_generator = NestedLoops(NextPermutation, Enumerable.Range(2, Math.Max(0, _valueSet.Count - 1)));

		Current = null!; // Temp value. Will be set in next call.
		Reset();
	}

	public IList<T> Current { get; private set; }

	object IEnumerator.Current => Current;

	void IDisposable.Dispose() { }

	public bool MoveNext()
	{
		Current = PermuteValueSet();

		bool prevResult = _hasMoreResults;
		_hasMoreResults = _generatorIterator!.MoveNext();
		if (_hasMoreResults)
			_generatorIterator.Current();

		return prevResult;
	}

	public void Reset()
	{
		_generatorIterator?.Dispose();

		for (int i = 0; i < _permutation.Length; i++)
			_permutation[i] = i;

		_generatorIterator = _generator.GetEnumerator();

		_generatorIterator.MoveNext();
		_hasMoreResults = true;
	}

	private static IEnumerable<Action> NestedLoops(Action action, IEnumerable<int> loopCounts)
	{
		int count = loopCounts
			.DefaultIfEmpty()
			.Aggregate((acc, x) =>
			{
				if (x < 0)
					new InvalidOperationException("Invalid loop count (must be greater than or equal to zero).");
				return acc * x;
			});

		for (int i = 0; i < count; i++)
			yield return action;
	}

	private void NextPermutation()
	{
		int j = _permutation.Length - 2;
		while (_permutation[j] > _permutation[j + 1])
			j--;

		int k = _permutation.Length - 1;
		while (_permutation[j] > _permutation[k])
			k--;

		int oldValue = _permutation[k];
		_permutation[k] = _permutation[j];
		_permutation[j] = oldValue;

		int x = _permutation.Length - 1;
		int y = j + 1;

		while (x > y)
		{
			oldValue = _permutation[y];
			_permutation[y] = _permutation[x];
			_permutation[x] = oldValue;
			x--;
			y++;
		}
	}

	private IList<T> PermuteValueSet()
	{
		var permutedSet = new T[_permutation.Length];
		for (int i = 0; i < _permutation.Length; i++)
			permutedSet[i] = _valueSet[_permutation[i]];
		return permutedSet;
	}
}
