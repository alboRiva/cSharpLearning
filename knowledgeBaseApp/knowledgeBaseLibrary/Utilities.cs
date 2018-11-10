using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace knowledgeBaseLibrary
{
    public static class Utilities
    {
        public static IEnumerable<string> GetTagsListFromString(string text, bool useStringVariations = false)
        {
            List<string> tags = new List<string>();
            var extractedTags = text.Split(' ', '\t', '\r', '\n' /*, ...*/).Where(t => !string.IsNullOrEmpty(t));
            tags.AddRange(extractedTags);
            if (useStringVariations)
            {
                extractedTags = tags.Where(t => t.Length >= 3).SelectMany(t => GetStringVariations(t)).Distinct().ToList();
                tags.AddRange(extractedTags);
            }
            return tags;
        }

        private static IEnumerable<string> GetStringVariations(string inputString)
        {
            if (inputString.Length < 3)
                yield break;
            do
            {
                inputString = inputString.Substring(0, inputString.Length - 1);
                yield return inputString;
            } while (inputString.Length >= 3);
        }

        /// <summary>
        /// Generates LoremIpsumText
        /// </summary>
        /// <param name="minWords"></param>
        /// <param name="maxWords"></param>
        /// <param name="minSentences"></param>
        /// <param name="maxSentences"></param>
        /// <param name="numParagraphs"></param>
        /// <returns></returns>
        public static string LoremIpsum(int minWords, int maxWords,
            int minSentences, int maxSentences,
            int numParagraphs)
        {

            var words = new[]
            {
                "lorem", "ipsum", "dolor", "sit", "amet", "consectetuer",
                "adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod",
                "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam", "erat"
            };

            var rand = new Random();
            int numSentences = rand.Next(maxSentences - minSentences)
                               + minSentences + 1;
            int numWords = rand.Next(maxWords - minWords) + minWords + 1;

            StringBuilder result = new StringBuilder();


            for (int s = 0; s < numSentences; s++)
            {
                for (int w = 0; w < numWords; w++)
                {
                    if (w > 0)
                    {
                        result.Append(" ");
                    }

                    result.Append(words[rand.Next(words.Length)]);
                }

                result.Append(". ");
            }

            return result.ToString();
        }
    }
}
