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
    }
}
