using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_MusicEquipment
{
    internal class MusicInstrument
    {
        #region data
        private readonly string _name;
        private readonly string _description;
        private readonly string _sound;
        private readonly string _history;
        #endregion

        #region properties
        public string Name => _name;

        public string Description => _description;

        public string Sound => _sound;

        public string History => _history;
        #endregion

        #region constructors
        public MusicInstrument(string name, string description, string sound, string history)
        {
            _name = name;
            _description = description;
            _sound = sound;
            _history = history;
        }
        #endregion

        #region public metods
        public void sound() => Console.WriteLine(_name + " is playing: " + _sound);

        public void show() => Console.WriteLine($"The name is: {_name}");

        public void desc() => Console.WriteLine($"Description of {_name}:\n" + _description);

        public void history() => Console.WriteLine($"History of {_name}:\n" + _history);
        #endregion
    }
}
