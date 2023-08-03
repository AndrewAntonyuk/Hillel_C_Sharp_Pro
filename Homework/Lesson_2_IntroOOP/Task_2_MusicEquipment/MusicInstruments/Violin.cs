using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task_2_MusicEquipment.MusicInstruments
{
    internal class Violin : MusicInstrument
    {
        public Violin() : base("Violin",
            "Hornbostel–Sachs classification: 321.322-71 (Composite chordophone sounded by a bow)",
            "G3, D4, A4, E5",
            "The violin in its present form emerged in early 16th-century northern Italy.")
        {
        }
    }
}
