namespace Backend.Utils
{
    public static class HomePageUtils
    {
        public static int LevenshteinDistance(string source, string target)
        {
            // ako je jedan od njih prazan distance je duzina drugog
            if (string.IsNullOrEmpty(source)) return target.Length;
            if (string.IsNullOrEmpty(target)) return source.Length;

            // matrica za cuvanje udaljenosti izmedju dva stringa
            int[,] distance = new int[source.Length + 1, target.Length + 1];

            //  inicijalizacija prve kolone i vrste
            for (int i = 0; i <= source.Length; i++)
                distance[i, 0] = i;

            for (int j = 0; j <= target.Length; j++)
                distance[0, j] = j;

            // dinamicko programiranje za racunanje udaljenosti izmedju dva stringa
            for (int i = 1; i <= source.Length; i++)
            {
                for (int j = 1; j <= target.Length; j++)
                {
                    int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                    distance[i, j] = Math.Min(
                        Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1),
                        distance[i - 1, j - 1] + cost);
                }
            }

            // zadnji element u matrici skroz dole desno je distance
            return distance[source.Length, target.Length];
        }


        //za beograd i nis dobro radi, evo primer:
        //Beograd: 44.7866, 20.4489
        //  Niš: 43.3209, 21.8958
        //  Distance otp 200.0 km
        public static double HaversineDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371e3; // Radijus Zemlje u metrima

            double phi1 = lat1 * Math.PI / 180; // Pretvaranje stepeni u radijane
            double phi2 = lat2 * Math.PI / 180;
            double deltaPhi = (lat2 - lat1) * Math.PI / 180;
            double deltaLambda = (lon2 - lon1) * Math.PI / 180;

            //crna magija :)
            double a = Math.Sin(deltaPhi / 2) * Math.Sin(deltaPhi / 2) +
                    Math.Cos(phi1) * Math.Cos(phi2) *
                    Math.Sin(deltaLambda / 2) * Math.Sin(deltaLambda / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            double distance = R * c; // Rastojanje u metrima

            return distance;
        }


    public static double CalculateScoreDistance(double distance, double maxDistance)
        {
            
            // skaliranje udaljenosti u ocenu između 0 i 10
            double score = 10 - (distance / maxDistance) * 10;

            // osiguranje da ocena nije manja od 0
            return Math.Max(0, score);
        }
    public static double CalculateScoreTime(double vreme, double maxVreme)
    {
        if (vreme <= 72)
        {
            return 10;
        }
        else if (vreme <= 336) // 14 dana izraženo u satima
        {
            // Linearno opadanje score-a od 10 do 0 od 72 do 336 sati
            double score = 10 * (1 - (vreme - 72) / (336 - 72));
            return score;
        }
        else
        {
            // Vreme je veće od 336 sati, score je 0
            return 0;
        }


    }

        internal static double CalculateScoreReservation(int rezervisanaMesta, int minZa10)
        {
            if(rezervisanaMesta >= minZa10)
            {
                return 10;
            }
            else if(rezervisanaMesta == 0)
            {
                return 0;
            }
            else
            {
                double score = (double)rezervisanaMesta / (double)minZa10 * 10;// lerping za pronalazenje vr izmedju 2 tacke na liniji lerp(a, b, t) = a + t * (b - a)
                return score;
            }
        }
    }
}