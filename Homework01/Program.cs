using System;

namespace Homework01
{

    public interface IIntegerList
    {
        void Add(int item);

        bool Remove(int item);

        bool RemoveAt(int index);

        int GetElement(int index);

        int IndexOf(int item);

        int Count { get;  }

        void Clear();

        bool Contains(int item);
    }

    public class IntegerList : IIntegerList
    {
        private int[] _internalStorage;

        private int _currentSize = 0;

        public int Count => _currentSize;

        public IntegerList()
        {
            _internalStorage = new int[4];
        }

        public IntegerList(int initialSize)
        {
            if (initialSize < 0)
            {
                throw new ArgumentException("Initial size can't be negative");
            }

            _internalStorage = new int[4];
        }

        public void Add(int item)
        {
            if (_currentSize == _internalStorage.Length)
            {
                Expand();
            }

            _internalStorage[Count] = item;
            ++_currentSize;
        }

        public bool Remove(int item)
        {
            for (int i = 0; i < _currentSize; ++i)
            {
                if (item == _internalStorage[i])
                {
                    RemoveAt(i);
                    return true;
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

        public int GetElement(int index)
        {
            if (index < 0 || index >= _currentSize)
            {
                throw new IndexOutOfRangeException();
            }

            return _internalStorage[index];
        }

        public int IndexOf(int item)
        {
            for (int i = 0; i < _currentSize; ++i)
            {
                if (item == _internalStorage[i])
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

        public bool Contains(int item)
        {
            return IndexOf(item) != -1;
        }

        private void Expand()
        {
            int[] tempStorage = new int[_internalStorage.Length * 2];

            for (int i = 0; i < _internalStorage.Length; ++i)
            {
                tempStorage[i] = _internalStorage[i];
            }

            _internalStorage = tempStorage;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> listOfIntegers = new GenericList<int>();

            listOfIntegers.Add(1); // [1]
            listOfIntegers.Add(2); // [1 ,2]
            listOfIntegers.Add(3); // [1 ,2 ,3]
            listOfIntegers.Add(4); // [1 ,2 ,3 ,4]
            listOfIntegers.Add(5); // [1 ,2 ,3 ,4 ,5]
            listOfIntegers.RemoveAt(0); // [2 ,3 ,4 ,5]
            listOfIntegers.Remove(5);
            Console.WriteLine(listOfIntegers.Count); // 3
            Console.WriteLine(listOfIntegers.Remove(100) ) ; // false
            Console.WriteLine(listOfIntegers.RemoveAt(5) ) ; // false
            listOfIntegers.Clear() ; // []
            Console.WriteLine(listOfIntegers.Count) ; // 0
        }
    }
}
