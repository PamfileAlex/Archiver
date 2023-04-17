﻿using System.Collections.ObjectModel;

namespace Archiver.Core.Extensions;

/// <summary>
/// Extensions methods for <see cref="IEnumerable{T}"/>.
/// </summary>
public static class IEnumerableExtensions
{
	/// <summary>
	/// Gets a new collection where every item is a tuple of the initial item plus it's index in the collection.
	/// </summary>
	/// <typeparam name="T">The type of objects to enumerate.</typeparam>
	/// <param name="this"><see cref="IEnumerable{T}"/> instance.</param>
	/// <returns><see cref="IEnumerable{(T, int)}"/> instance.</returns>
	public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> @this)
	{
		return @this.Select((item, index) => (item, index));
	}

	/// <summary>
	/// Gets a new <see cref="ObservableCollection{T}"/> based on the provided input.
	/// </summary>
	/// <typeparam name="T">The type of objects to enumerate.</typeparam>
	/// <param name="this"><see cref="IEnumerable{T}"/> instance.</param>
	/// <returns><see cref="ObservableCollection{T}"/> based on the provided input.</returns>
	public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> @this)
	{
		return new ObservableCollection<T>(@this);
	}

	/// <summary>
	/// Obtains the data as a list; if it is *already* a list, the original object is returned without
	/// any duplication; otherwise, ToList() is invoked.
	/// </summary>
	/// <typeparam name="T">The type of element in the list.</typeparam>
	/// <param name="source">The enumerable to return as a list.</param>
	public static List<T>? AsList<T>(this IEnumerable<T>? source)
	{
		return (source is null || source is List<T>) ? source as List<T> : source.ToList();
	}
}