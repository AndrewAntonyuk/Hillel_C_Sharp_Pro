using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task_2_MusicEquipment.MusicInstruments
{
    internal class Trombone : MusicInstrument
    {
        public Trombone() : base("Trombone",
            "Hornbostel–Sachs classification: 423.22 (Sliding aerophone sounded by lip vibration)",
            "Tu-tu-tu   tu-tu-tu-tu-TU",
            "The word first appears in court records in 1495.")
        {
        }
    }
}
