namespace Josephus
{
    public class JosephusGood
    {

        readonly bool[] DeadSoldiers;

        int NumberOfDeadSoldiers = 0;

        int CurrentSoldier = 0;

        int NumberOfSoldiers { get => DeadSoldiers.Length; }

        bool StillMoreThanOneAlive { get => NumberOfDeadSoldiers < NumberOfSoldiers - 1; }

        public int GetLastLivingSoldier()
        {
            while (StillMoreThanOneAlive)
            {
                GotoNextLivingSoldier();
                KillNextSoldier();
                GotoNextLivingSoldier();
            }

            return CurrentSoldier;
        }

        private void KillNextSoldier()
        {
            GotoNextLivingSoldier();
            DeadSoldiers[CurrentSoldier] = true;
            NumberOfDeadSoldiers++;
        }

        private void GotoNextLivingSoldier()
        {
            do
            {
                CurrentSoldier = (CurrentSoldier + 1) % NumberOfSoldiers;
            }
            while (DeadSoldiers[CurrentSoldier]);
        }

        public static int GetSolution(int numberOfPersons)
        {
            return new JosephusGood(numberOfPersons).GetLastLivingSoldier();
        }

        public JosephusGood(int numberOfPersons)
        {
            DeadSoldiers = new bool[numberOfPersons];
        }
    }
}
