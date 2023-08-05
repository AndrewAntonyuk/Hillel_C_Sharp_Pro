using System;

namespace Task_3_ISort
{
    internal class Array : ISort
    {
        int[] _record;

        public Array(int[] record)
        {
            _record = record;
        }

        #region public methods
        public void SortAsc()
        {
            CheckRecord(_record);

            for (int i = _record.Length - 1; i >= 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (_record[j - 1] > _record[j])
                    {
                        var temp = _record[j - 1];
                        _record[j - 1] = _record[j];
                        _record[j] = temp;
                    }
                }
            }
        }

        public void SortDesc()
        {
            for (int i = _record.Length - 1; i >= 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (_record[j - 1] < _record[j])
                    {
                        var temp = _record[j - 1];
                        _record[j - 1] = _record[j];
                        _record[j] = temp;
                    }
                }
            }
        }

        public void SortByParam(bool isAsc)
        {
            if (isAsc)
            {
                SortAsc();
            }
            else
            {
                SortDesc();
            }
        }
        #endregion

        #region internal methods
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
