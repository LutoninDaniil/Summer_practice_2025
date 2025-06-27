namespace task03;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CustomCollection<T> : IEnumerable<T>
{
    private List<T> _items = new List<T>();

    public void Add(T item) => _items.Add(item);
    public void Remove(T item) => _items.Remove(item);
    public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerable<T> GetReverseEnumerator()
    {
        return _items.AsEnumerable().Reverse();
    }

    public static IEnumerable<int> GenerateSequence(int start, int count)
    {
        var numbers = Enumerable.Range(start, count);
        return numbers;
    }

    public IEnumerable<T> FilterAndSort(Func<T, bool> predicate, Func<T, IComparable> keySelector)
    {
        var filtered = _items.Where(predicate).ToList();
        var sorted = filtered.OrderBy(keySelector);
        return sorted;
    }

    public void PrintAll()
    {
        foreach (var item in _items)
        {
            Console.WriteLine(item);
        }
    }
}
