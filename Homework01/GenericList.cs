using System;
using System.Collections;
using System.Collections.Generic;

namespace Homework01
{
    public class GenericList <X> : IGenericList<X>
    {

        private X[] _internalStorage;

        private int _currentSize;

        public int Count => _currentSize;

        public GenericList()
        {
            _internalStorage = new X[4];
        }

        public GenericList(int initialSize)
        {
            if (initialSize < 0)
            {
                throw new ArgumentException("Initial size can't be negative");
            }

            _internalStorage = new X[4];
        }

        public void Add(X item)
        {
            if (_currentSize == _internalStorage.Length)
            {
                Expand();
            }

            _internalStorage[Count] = item;
            ++_currentSize;
        }

        public bool Remove(X item)
        {
            for (int i = 0; i < _currentSize; ++i)
            {
                if (item.Equals(_internalStorage[i]))
                {
                    if (RemoveAt(i))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                        
                }
            }

            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= _currentSize)
            {
                return false;
            }

            for (int i = index; i < _currentSize - 1; ++i)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }

            --_currentSize;
            return true;
        }

        public X GetElement(int index)
        {
            if (index < 0 || index >= _currentSize)
            {
                throw new IndexOutOfRangeException();
            }

            return _internalStorage[index];
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i < _currentSize; ++i)
            {
                if (item.Equals(_internalStorage[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Clear()
        {
            _currentSize = 0;
        }

        public bool Contains(X item)
        {
            return IndexOf(item) != -1;
        }

        private void Expand()
        {
            X[] tempStorage = new X[_internalStorage.Length * 2];

            for (int i = 0; i < _internalStorage.Length; ++i)
            {
                tempStorage[i] = _internalStorage[i];
            }

            _internalStorage = tempStorage;
        }

        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class GenericListEnumerator<X> : IEnumerator<X>
    {
        private GenericList<X> _list;

        private int _currentIndex = -1;

        public GenericListEnumerator(GenericList<X> list)
        {
            _list = list;
        }

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            ++_currentIndex;
            return _currentIndex < _list.Count;
        }

        public void Reset()
        {
            _currentIndex = -1;
        }

        public X Current => _list.GetElement(_currentIndex);

        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
}
