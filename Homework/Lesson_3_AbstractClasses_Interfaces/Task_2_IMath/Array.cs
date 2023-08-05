using System;
using System.Collections.Generic;

namespace Task_2_IMath
{
    public class Array : IMath
    {
        int[] _record;

        public Array(int[] record)
        {
            _record = record;
        }

        #region public methods
        public int Max()
        {
            CheckRecord(_record);

            int maxValue = int.MinValue;

            foreach (int i in _record)
            {
                if (i > maxValue) maxValue = i;
            }

            return maxValue;
        }

        public int Min()
        {
            CheckRecord(_record);

            int minValue = int.MaxValue;

            foreach (int i in _record)
            {
                if (i < minValue) minValue = i;
            }

            return minValue;
        }

        public float Avg()
        {
            CheckRecord(_record);

            float sum = 0.0f;

            foreach (int i in _record)
            {
                sum += i;
            }

            return sum / _record.Length;
        }

        public bool Search(int valueToSearch)
        {
            CheckRecord(_record);

            foreach (int i in _record)
            {
                if (valueToSearch == i) return true;
            }

            return false;
        }
        #endregion

        #region internal methods
        private IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < _record.Length; i++)
            {
                yield return _record[i];
            }
        }

        private void CheckRecord(int[] record)
        {
            if (_record == null)
            {
                throw new ArgumentNullException(nameof(record) + " can't be Null");
            }
        }
        #endregion
    }
}
