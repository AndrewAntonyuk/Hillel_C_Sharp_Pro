using System;

namespace Task_1_Play
{
    internal class Play
    {
        #region data
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
        public override string? ToString()
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
        #endregion

        ~Play()
        {
            Console.WriteLine("Play was destroyed:\n" + this);
        }
    }
}
