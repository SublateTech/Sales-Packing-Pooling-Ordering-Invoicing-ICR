using System;
using System.Collections.Generic;

namespace Signature.SpellChecker
{
    /// -------------------------------------------------------------------------------------------
    /// <summary>
    /// Definition:
    /// Levenshtein distance (LD) is a measure of the similarity between two strings, which we will
    /// refer to as the source string (s) and the target string (t). The distance is the number of
    /// deletions, insertions, or substitutions required to transform s into t.
    /// </summary>
    /// -------------------------------------------------------------------------------------------
    public class Levenshtein
    {
        private string _word1 = string.Empty;
        private string _word2 = string.Empty;
        private int _levenshtein = -1;

        /// -------------------------------------------------------------------------------------------
        /// <summary>
        /// Create the Levenshtein object.
        /// </summary>
        /// <param name="word1"> The first word (s). </param>
        /// <param name="word2"> The second word (t). </param>
        /// -------------------------------------------------------------------------------------------
        public Levenshtein(string word1, string word2)
        {
            this._word1 = word1;
            this._word2 = word2;
        }

        /// -------------------------------------------------------------------------------------------
        /// <summary>
        /// Calculate the Levenshtein's distance.
        /// </summary>
        /// <returns> The Levenshtein's value. </returns>
        /// -------------------------------------------------------------------------------------------
        public int LevenshteinValue()
        {
            this._levenshtein = LevenshteinValue(this._word1, this._word2);
            return this._levenshtein;
        }

        /// -------------------------------------------------------------------------------------------
        /// <summary>
        /// Calculate the Levenshtein's distance.
        /// </summary>
        /// <returns> The Levenshtein's value. </returns>
        /// <remarks>
        /// The test is CASE SENSITVE !
        /// The cell result[i,j] of the matrix equal to the minimum of:
        /// a. The cell immediately above plus 1: result[i-1,j] + 1.
        /// b. The cell immediately to the left plus 1: result[i,j-1] + 1.
        /// c. The cell diagonally above and to the left plus the cost: result[i-1,j-1] + cost[i,j]
        /// </remarks>
        /// <param name="word1"> The first word (s). </param>
        /// <param name="word2"> The second word (t). </param>
        /// -------------------------------------------------------------------------------------------
        public static int LevenshteinValue(string word1, string word2)
        {
            if (word1.Length == 0) return word2.Length;
            else if (word2.Length == 0) return word1.Length;
            else
            {
                List<int> lastColumn = new List<int>(word2.Length);
                for (int i = 1; i <= word2.Length; i++) lastColumn.Add(i);
                int lastValue = 0;
                int forLastValue = 0;

                // Get the minimum value
                for (int j = 1; j <= word1.Length; j++)
                {
                    for (int i = 0; i < word2.Length; i++)
                    {
                        int x = (i == 0 ? j : lastValue) + 1;
                        int y = lastColumn[i] + 1;
                        int z = (i == 0 ? j - 1 : lastColumn[i - 1]) + (word1[j - 1] == word2[i] ? 0 : 1);

                        forLastValue = lastValue;
                        lastValue = Math.Min(Math.Min(x, y), z);

                        if (i > 0) lastColumn[i - 1] = forLastValue;
                        if (i == word2.Length - 1) lastColumn[i] = lastValue;
                    }
                }
                return lastValue;
            }
        }

        /// -------------------------------------------------------------------------------------------
        /// <summary>
        /// The match in percent.
        /// </summary>
        /// -------------------------------------------------------------------------------------------
        public double MatchPercent
        {
            get { return (100 - this.ErrorPercent); }
        }

        /// -------------------------------------------------------------------------------------------
        /// <summary>
        /// The error in percent.
        /// </summary>
        /// -------------------------------------------------------------------------------------------
        public double ErrorPercent
        {
            get
            {
                if (this._levenshtein < 0) this._levenshtein = this.LevenshteinValue();
                int max = Math.Max(this._word1.Length, this._word2.Length);
                return Math.Round(((double)this._levenshtein / max) * 100, 2);
            }
        }
    }
}


