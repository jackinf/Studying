﻿using NUnit.Framework;
using Study.Algo.ProblemSolvingInDataStructuresBook;

namespace Study.Algo.Tests.Exersizes
{
    public class ChapterOnSortingExersizesTests
    {
        /// <summary>
        /// Given a text file print the words with their frequency.
        /// Now print the kth word in term of frequency
        /// </summary>
        [Test]
        public void Exersize01Test()
        {
            const string words = @"
Video provides a powerful way to help you prove your point. When you click Online Video, you can paste in the embed code for the video you want to add.
You can also type a keyword to search online for the video that best fits your document. To make your document look professionally produced, Word provides header, footer, cover page, and text box designs that complement each other.
For example, you can add a matching cover page, header, and sidebar. Click Insert and then choose the elements you want from the different galleries.
";
            var wordsWithFrequencies = ChapterOnSortingExersize01.PrintWordsWithFrequency(words);
        }
    }
}