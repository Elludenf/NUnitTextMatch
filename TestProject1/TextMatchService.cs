using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject1
{
    public class TextMatchService
    {
        /// <summary>
        /// Gets All Indexes Of a text given a subtext
        /// </summary>
        /// <param name="text"></param>
        /// <param name="subtext"></param>
        /// <param name="startFrom"></param>
        /// <returns>List Of Indexes separated by commas</returns>
        public  string GetIndexesOf(string text, string subtext, int startFrom = 0)
        {
            var indexes = new List<int>();

            if (String.IsNullOrEmpty(text) || String.IsNullOrEmpty(subtext) || (subtext.Length > text.Length)) {
                return "";
            }

            text = text.ToLower();
            subtext = subtext.ToLower();
            var index = startFrom;
            var process = true;
            while (process) {
                index = CustomIndexOf(text, subtext, index);
                if (index == -1) {
                    process = false;
                }
                else
                {
                    indexes.Add(index +1); 
                }
                index += subtext.Length;
            }

            return FormatResult(indexes);
        }  
        
        /// <summary>
        /// Gets the first index of a given text and a subtext to search
        /// Also it supports a start index to search on the text string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="substr"></param>
        /// <param name="startFrom"></param>
        /// <returns>index</returns>
        private static int CustomIndexOf(string str, string substr, int startFrom = 0)
        {
            bool match;
            for (var i = startFrom; i < str.Length - substr.Length + 1; ++i)
            {
                match = !substr.Where((t, j) => str[i + j] != t).Any();
                if (match) return i;
            }

            return -1;
        }
        
        /// <summary>
        /// Formats the results of the index each element separated by comma
        /// </summary>
        /// <param name="list"></param>
        /// <returns>result string</returns>
        private static string FormatResult(List<int> list) {
            var result = "";
            for (var i = 0; i < list.Count; i++)
            {
                result += (i == list.Count - 1) ? list[i].ToString(): list[i]  + ",";

            }
            return result;
        }
    }
}