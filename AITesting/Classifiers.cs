using System;

namespace AITesting
{

    public static class Classifiers
    {
        public static double CalculateGiniImpurity(int[] classCounts)
        {
            int totalSamples = 0;
            double gini = 0.0;

            foreach (int count in classCounts)
                totalSamples += count;

            if (totalSamples == 0)
                return 0;

            foreach (int count in classCounts)
            {
                double probability = (double)count / totalSamples;
                gini += probability * probability;
            }

            return 1 - gini;
        }

        public static double CalculateShannonEntropy(int[] classCounts)
        {
            int totalSamples = 0;
            double entropy = 0.0;

            foreach (int count in classCounts)
                totalSamples += count;

            if (totalSamples == 0)
                return 0;

            foreach (int count in classCounts)
            {
                double probability = (double)count / totalSamples;
                entropy += -probability * Math.Log(probability, 2);
            }

            return entropy;
        }

    }
}