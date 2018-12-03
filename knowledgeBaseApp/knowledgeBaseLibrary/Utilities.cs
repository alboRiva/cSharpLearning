using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using knowledgeBaseLibrary.Models;
using rm.Trie;
using HtmlAgilityPack;

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

        /// <summary>
        /// Generates trie from title and description and assigns it to SearchTrie field
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static void GenerateTrie(Post post)
        {
            //Extracts plain text from formatted HTML test - HTMLAgilityPack Dependency
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(post.Description);
            string result = htmlDoc.DocumentNode.InnerText;
            var searchableText = PreprocessTrieInput(post.Title + " " + result);
            var trie = new Trie();
            foreach (string s in searchableText)
            {
                trie.AddWord(s);
            }            
            post.SearchTrie = trie;
        }

        /// <summary>
        /// Preprocessa il testo: lowercase, length > 2, elimina ultima lettera
        /// </summary>
        /// <param name="inputText"></param>
        /// <returns></returns>
        public static string[] PreprocessInputText(string inputText)
        {
            var processedInputText = inputText.ToLower();
            var processedText = processedInputText.Split(' ', '\t', '\r', '\n');
            //TODO: AND is not in Article dictionary                                
            return processedText.Where(t => t.Length > 2).Select(t => t.Remove(t.Length - 1)).ToArray();
        }

        public static string[] PreprocessTrieInput(string trieInput)
        {
            trieInput = trieInput.ToLower();
            var processedInputText = trieInput.Split(' ', '\t', '\r', '\n');
            var processedText = processedInputText.Where(t => t.Length > 2).ToArray();
            return processedText;
        }

    }
}
