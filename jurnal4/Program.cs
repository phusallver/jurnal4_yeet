// See https://aka.ms/new-console-template for more information


internal class Program
{

}

class KodeBuah
{
    public enum Buah
    {
        Apel, Aprikot,
        Alpukat, Pisang,
        Paprika, Blackberry,
        Ceri, Kelapa, Jagung,
        Kurma, Durian, Anggur,
        Melon, Semangka
    }
    private static String getKodeBUah(Buah buah)
    {
        String[] kodeBuah =
        {
            "A00","B00","C00",
            "D00","E00","F00",
            "H00","I00",
            "J00","K00","L00",
            "M00","N00","O00"
        };
        return kodeBuah[(int)buah];
    }
    /*private static void Main(string[] args)
    {
        System.Console.WriteLine(getKodeBUah(Buah.Kelapa));
    }*/
    public enum PosisiGame{Tengkurap, Jongkok, Berdiri, Terbang};
    public enum Trigger {TombolS, TombolW, TombolX };
    class PosisiKarakterGame
    {
        class transition
        {
            public PosisiGame CurrentState;
            public PosisiGame CharEndState;
            public Trigger trigger;
            public transition(PosisiGame CurrentState, PosisiGame CharEndState, Trigger trigger)
            {
                this.CurrentState = CurrentState;
                this.CharEndState = CharEndState;
                this.trigger = trigger; 
            }
        }
        transition[] transitions =
        {
            new transition(PosisiGame.Tengkurap,PosisiGame.Jongkok,Trigger.TombolW),
            new transition(PosisiGame.Jongkok,PosisiGame.Berdiri,Trigger.TombolW),
            new transition(PosisiGame.Berdiri,PosisiGame.Terbang,Trigger.TombolW),
            new transition(PosisiGame.Terbang,PosisiGame.Berdiri,Trigger.TombolS),
            new transition(PosisiGame.Berdiri,PosisiGame.Jongkok,Trigger.TombolS),
            new transition(PosisiGame.Jongkok,PosisiGame.Tengkurap,Trigger.TombolS),
            new transition(PosisiGame.Terbang,PosisiGame.Jongkok,Trigger.TombolX)
        };
        public PosisiGame getNextPosisi(PosisiGame PosisiSekarang, Trigger trigger)
        {
            PosisiGame PosisiAkhir = PosisiSekarang;
            for (int i = 0; i< transitions.Length; i++)
            {
                if (transitions[i].trigger == trigger && transitions[i].CurrentState == PosisiSekarang)
                {
                    PosisiAkhir = transitions[i].CharEndState;
                    if (PosisiAkhir == PosisiGame.Berdiri)
                    {
                        System.Console.WriteLine("posisi standby");
                    }
                    else if (PosisiAkhir == PosisiGame.Tengkurap)
                    {
                        System.Console.WriteLine("posisi istirahat");
                    }
                }
            }
            return PosisiAkhir;
        }
        public PosisiGame PosisiSekarang = PosisiGame.Jongkok;
        public void activateTrigger(Trigger trigger)
        {
            PosisiSekarang = getNextPosisi(PosisiSekarang, trigger);
        }
        
        
    }
    private static void Main(string[] args)
    {
        PosisiKarakterGame PosisiSaya = new PosisiKarakterGame();
        System.Console.WriteLine("Sekarang saya " + PosisiSaya.PosisiSekarang);
        System.Console.WriteLine("Menekan Tombol S");
        PosisiSaya.PosisiSekarang = PosisiSaya.getNextPosisi(PosisiSaya.PosisiSekarang, Trigger.TombolS);
        System.Console.WriteLine("Sekarang saya " + PosisiSaya.PosisiSekarang);

    }
}