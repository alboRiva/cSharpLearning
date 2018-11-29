using System;
using System.Collections.Generic;
using knowledgeBaseLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using rm.Trie;

namespace KnowledgeBaseTest
{
    [TestClass]
    public class UtilitiesTestUnit
    {
        [TestMethod]
        public void GetTagsFromStringWithVariants()
        {
            string inputString = "nuova";
            List<string> expectedOutput = new List<string> {"nu", "nuo", "nuov", "nuova"};
            ExtractAndCheckTags(inputString, expectedOutput, true);
        }

        [TestMethod]
        public void GetTagsFromStringWithoutVariants()
        {
            string inputString = "nuova";
            List<string> expectedOutput = new List<string> { "nuova" };
            ExtractAndCheckTags(inputString,expectedOutput,false);
        }

        [TestMethod]
        public void GetTagsFromStringWithVariantsCheckOnDuplicates()
        {
            string inputString = "nuova nuove";
            List<string> expectedOutput = new List<string>{"nu","nuo","nuov","nuova","nuove"};
            ExtractAndCheckTags(inputString, expectedOutput, true);
        }

        private void ExtractAndCheckTags(string inputString, IEnumerable<string> expectedOutput, bool useVariants, string reason="")
        {
            var output = Utilities.GetTagsListFromString(inputString, useVariants);
            Assert.IsTrue(Enumerable.SequenceEqual(expectedOutput.OrderBy(t => t), output.OrderBy(t => t)),reason);
        }

        //Testing Trie Methods to understand behaviour

        [TestMethod]
        public void HasPrefixReturnValues()
        {
            var trie = GetTree();
            var hasPrefix = trie.HasPrefix("gatton");
            Assert.IsTrue(hasPrefix,"Prefix present in trie");
        }

        [TestMethod]
        public void HasWordReturnValues()
        {
            var trie = GetTree();
            var hasPrefix = trie.HasWord("gatto");
            Assert.IsTrue(hasPrefix, "Word present in trie");
        }

        private Trie GetTree()
        {
            var trie = new Trie();
            trie.AddWord("cane");
            trie.AddWord("gatto");
            trie.AddWord("gattone");
            return trie;
        }

        //Text processing test
        [TestMethod]
        public void TextPreprocessingInputText()
        {
            var text = "Input Text Not Processed Un";
            string[] expected = new string[] {"inpu", "tex", "no", "processe"};
            var processedText = Utilities.PreprocessInputText(text);
            CollectionAssert.AreEqual(expected, processedText);
        }

        

    }
}
