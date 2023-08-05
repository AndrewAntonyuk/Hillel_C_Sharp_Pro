using System;
using System.Collections.Generic;

namespace Task_1_IOutput
{
    public class Array : IOutput
    {
        int[] _record;

        public Array(int[] record)
        {
            _record = record;
        }

        #region public methods
        public void Show()
        {
            CheckRecord(_record);

            foreach (int i in _record)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
        }

        public void Show(string info)
        {
            CheckRecord(_record);

            Console.WriteLine(info);

            foreach (int i in _record)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
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
