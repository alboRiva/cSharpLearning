using System;
using System.Collections.Generic;
using knowledgeBaseLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

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

    }
}
