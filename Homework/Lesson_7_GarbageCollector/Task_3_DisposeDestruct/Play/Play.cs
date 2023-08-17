using System;

namespace Task_3_DisposeDestruct
{
    internal class Play : IDisposable
    {
        #region data
        private bool _disposed;
        public string PlayName { get; set; }
        public PlayTypes PlayType { get; set; }
        public uint PlayYear { get; set; }
        public Person Author { get; set; }
        #endregion

        #region constructors
        public Play(string playName, PlayTypes playType, uint playYear, Person author)
        {
            PlayName = playName;
            PlayType = playType;
            PlayYear = playYear;
            Author = author;
        }
        #endregion

        #region public methods
        public override string ToString()
        {
            return $"[Play: {PlayName}; type: {PlayType.ToString()}; year: {PlayYear}; author: {Author}]";
        }

        public void Run()
        {
            Console.WriteLine("Play is running:\n" + this);
        }

        public void Pause()
        {
            Console.WriteLine("Play is paused:\n" + this);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                Console.WriteLine($"Dispose controlled recourses of {this}");
            }

            Console.WriteLine($"Dispose uncontrolled recourses of {this}");

            _disposed = true;
        }

        ~Play()
        {
            Dispose(false);
        }
    }
}
