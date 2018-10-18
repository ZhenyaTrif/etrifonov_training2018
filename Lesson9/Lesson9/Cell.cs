namespace Lesson9
{
    class Cell<T>
    {
        public Cell<T> _nextCell;
        public T _value;

        public Cell(T value)
        {
            _value = value;
            _nextCell = null;
        }

        public Cell(T value, Cell<T> next)
            : this(value)
        {
            _nextCell = next;
        }
    }
}
