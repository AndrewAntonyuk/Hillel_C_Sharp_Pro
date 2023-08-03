using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task_2_MusicEquipment.MusicInstruments
{
    internal class Cello : MusicInstrument
    {
        public Cello() : base("Cello",
            "Hornbostel–Sachs classification: 321.322-71 (Composite chordophone sounded by a bow)",
            "C2, G2, D3 and A3",
            "The violin family, including cello-sized instruments, emerged  1500 as a family of instruments distinct from the viola da gamba family.")
        {
        }
    }
}
