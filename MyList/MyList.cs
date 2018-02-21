/* 
 *  Implement all the methods. You can add and edit all objects in this solution except for the project with tests.
 *  You can consider this task complete when all tests run green.
 * 
 *  Optional tasks:
 *  - make the objects of this class consumable by a foreach statement (+)
 *  - add `First` and `Last` methods (+)
 *  - add and implement a generic version of MyList collection
 *  - add a new test project to the solution and add tests for the new tasks
 * 
 */

using System;
using System.Collections;

namespace MyList
{
    public class MyList : IMyList, IEnumerable, IEnumerator
    {
        public MyList(int initialCapacity)
        {
            _arr = new int[initialCapacity];
            _capacity = initialCapacity;
            index = -1;
        }

        private int[] _arr;
        public int index;
        private int _length; //number of elements
        public int Length => _length;
        private int _capacity;
        public int Capacity => _capacity;

        public int this[int index]
        {
            get
            {
                if (index >= Length || index < 0) { throw new ArgumentException(); }
                return _arr[index];
            }
            set
            {
                if (index >= Length || index < 0) { throw new ArgumentException(); }
                _arr[index] = value;
            }
        }

        public void Add(int value)
        {
            CheckCapacity();
            _arr[Length] = value;
            _length++;
        }

        public void Insert(int index, int value)
        {
            CheckCapacity();
            if (index >= Length || index < 0) { throw new ArgumentException(); }
            else
            {
                Array.Copy(_arr, index, _arr, index + 1, Length - index);
                _arr[index] = value;
                _length++;
            }
        }

        public void RemoveAt(int index)
        {
            if (index >= Length || index < 0) { throw new ArgumentException(); }
            if (Length > 0)
            {
                Array.Copy(_arr, index + 1, _arr, index, Length - (index + 1));
                _length--;
            }
        }

        public bool Contains(int value)
        {
            foreach (int el in _arr)
            {
                if (el.Equals(value)) { return true; }
            }
            return false;
        }

        private void CheckCapacity()
        {
            if (Length == Capacity)
            {
                Array.Resize(ref _arr, Capacity + 1);
                _capacity++;
            }
        }

        public int First()
        {
            if (Length > 0) { return _arr[0]; }
            else
                throw new InvalidOperationException();
        }

        public int Last()
        {
            if (Length > 0) { return _arr[Length - 1]; }
            else
                throw new InvalidOperationException();
        }

        //IEnumerable
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        //IEnumerator
        public bool MoveNext()
        {
            if (index == Length - 1)
            {
                Reset();
                return false;
            }
            index++;
            return true;
        }

        public void Reset()
        {
            index = -1;
        }

        public object Current
        {
            get
            {
                return _arr[index];
            }
        }

    }

}
