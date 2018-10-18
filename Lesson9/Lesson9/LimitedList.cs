namespace Lesson9
{
    class LimitedList<T>
    {
        const int DEFAULT_LIMIT = 10;

        private Cell<T> _firstElem;
        private Cell<T> _lastElem;
        private int _limit;
        public int Length
        {
            get
            {
                Cell<T> tempElem = _firstElem;
                int i;
                for (i = 0; tempElem != null; i++)
                {
                    tempElem = tempElem._nextCell;
                }
                return i;
            }
        }

        public LimitedList() : this(DEFAULT_LIMIT) { }

        public LimitedList(int limit)
        {
            if (limit < 0)
            {
                throw new IncorrectInputException("Incorrent input value.");
            }

            _limit = limit - 1;
        }

        public void Add(T value)
        {
            if (Length == _limit)
            {
                throw new LimitedListOverflowException("This list is overflowed.");
            }

            Cell<T> newElm = new Cell<T>(value);
            if (_firstElem == null)
                _firstElem = _lastElem = newElm;
            else
            {
                _lastElem._nextCell = newElm;
                _lastElem = newElm;
            }
        }

        public void Insert(T value, int insertAfterThisIndex)
        {
            if(insertAfterThisIndex >= _limit || insertAfterThisIndex >= Length)
            {
                throw new IncorrectInputException("Incorrect index of insertion.");
            }
            if (Length == _limit)
            {
                throw new LimitedListOverflowException("This list is overflowed.");
            }

            Cell<T> newElem = new Cell<T>(value, null);
            if (_firstElem == null)
            {
                _firstElem = _lastElem = newElem;
            }
            else
            {
                Cell<T> tempElem = _firstElem;
                for (int index = 1; tempElem._nextCell != null && index < insertAfterThisIndex; index++)
                {
                    tempElem = tempElem._nextCell;
                }
                newElem._nextCell = tempElem._nextCell;
                tempElem._nextCell = newElem;
                if (newElem._nextCell == null)
                {
                    _firstElem = newElem;
                }
            }
        }

        public void Remove(int indexToRemove)
        {
            if (indexToRemove < 0 || indexToRemove > Length)
            {
                throw new IncorrectInputException("Incorrent input value.");
            }
            
            if (indexToRemove == 0)
            {
                Cell<T> tempElem;
                tempElem = _firstElem._nextCell;
                _firstElem = tempElem;
            }
            else if(indexToRemove<Length)
            {
                Cell<T> tempElem = _firstElem;
                for (int index = 1; index < indexToRemove; index++)
                {
                    tempElem = tempElem._nextCell;
                }
                if(tempElem._nextCell._nextCell != null)
                {
                    tempElem._nextCell = tempElem._nextCell._nextCell;
                }
                else
                {
                    tempElem._nextCell = null;
                }
            }
        }

        public T[] ToArray()
        {
            T[] result = new T[Length];
            Cell<T> tempElem = _firstElem; 
            for(int index = 0; index < Length; index++)
            {
                result[index] = tempElem._value;
                tempElem = tempElem._nextCell;
            }
            return result;
        }
    }
}
