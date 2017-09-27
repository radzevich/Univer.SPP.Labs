using System;

namespace _2
{
    public class MultiThreadCounter
    {
        private readonly object _syncObject = new object();
        private int _targetValueToCompair = 0;

        public int Value { get; private set; } = 0;

        public delegate void ValueEqualToTargetEventHandler();
        public event ValueEqualToTargetEventHandler ValueEqualToTargetEvent;

        public MultiThreadCounter()
        { }

        public MultiThreadCounter(int initialValue)
        {
            _targetValueToCompair = initialValue;
        }

        public void Inc()
        {
            lock (_syncObject)
            {
                Value++;
                if (_targetValueToCompair == Value)
                {
                    ValueEqualToTargetEvent?.Invoke();
                }
            }
        }

        public void Dec()
        {
            lock (_syncObject)
            {
                Value--;
                if (_targetValueToCompair == Value)
                {
                    ValueEqualToTargetEvent?.Invoke();
                }
            }
        }
    }
}