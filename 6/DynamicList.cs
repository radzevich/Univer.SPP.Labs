using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _6
{
    public class DynamicList<T> : ICollection<T>, IEnumerator<T>
    {
        private T[] _items;
        private int _currentIteratorPosition = -1;
        private int _count = 0;

        public int Count => _count;
        public bool IsReadOnly { get; }
        public T[] Items => _items;

        #region Constructors

        public DynamicList()
        {
        }

        public DynamicList(int capacity)
        {
            this._items = new T[capacity];
        }

        public DynamicList(IEnumerable<T> collection)
        {
            foreach (var itemToCopy in collection)
            {
                Add(itemToCopy);
            }
        }

        #endregion

        #region Iterator

        public T this[int index]
        {
            get { return _items[index]; }
            set { _items[index] = value; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        public void Dispose()
        {
            ((IEnumerator)this).Reset();
        }

        public bool MoveNext()
        {
            if (_currentIteratorPosition < Count - 1)
            {
                _currentIteratorPosition++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _currentIteratorPosition = -1;
        }

        public T Current => _items[_currentIteratorPosition];

        object IEnumerator.Current => _items[_currentIteratorPosition];

        #endregion

        #region ICollection

        public void Add(T itemToAdd)
        {
            var newItemArray = new T[_count + 1];
            for (var i = 0; i < _count; i++)
            {
                newItemArray[i] = this._items[i];
            }
            newItemArray[_count] = itemToAdd;

            this._items = newItemArray;
            this._count++;
        }

        bool ICollection<T>.Remove(T item)
        {
            for (var indexOfItemToRemove = 0; indexOfItemToRemove < _count; indexOfItemToRemove++)
            {
                if (_items[indexOfItemToRemove].Equals(item))
                {
                    RemoveAt(indexOfItemToRemove);
                    return true;
                }
            }
            return false;
        }

        public void RemoveAt(int positionOfItemToRemove)
        {
            if (positionOfItemToRemove < this._count)
            {
                for (var i = positionOfItemToRemove; i < this._count - 1; i++)
                {
                    _items[i] = _items[i + 1];
                }
                _count--;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Clear()
        {
            _count = 0;
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
    }

    #endregion
}
