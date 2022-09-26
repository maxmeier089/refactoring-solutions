namespace Josephus
{
    public class JosephusBad
    {

        public static int GetSolution(int z)
        {
            bool[] b = new bool[z];

            int c = 0;
            int k = 0;

            while (c < z - 1)
            {
                do
                {
                    k = (k + 1) % z;
                }
                while (b[k]);

                do
                {
                    k = (k + 1) % z;
                }
                while (b[k]);

                b[k] = true;

                c++;

                do
                {
                    k = (k + 1) % z;
                }
                while (b[k]);
            }
            return k;
        }

    }
}
