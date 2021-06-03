using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    public class HashTagGenerator
    {
        Dictionary<char, List<string>> dictionary;
        String germanNouns;
        String frenchNouns;
        public HashTagGenerator()
        {
            dictionary = new Dictionary<char, List<string>>();
            germanNouns = File.ReadAllText("Dictionary\\german_nouns.csv").ToLower().Replace(" ", "");
            frenchNouns = File.ReadAllText("Dictionary\\french_nouns.csv").ToLower().Replace(" ", "");
            //Load dictionary
            for (char i = 'A'; i <= 'Z'; i++)
            {
                dictionary[i] = File.ReadAllLines("Dictionary\\" + i.ToString() + ".csv").Where(w => w.Trim().Length > 0).ToList();
            }
            Debug.WriteLine("Done loading dictionary");
        }
        // Handle word (v.n. ??, handle word -ed,-ing
        public bool isNoun(string word)
        {
            word = word.Replace(" ", "");
            List<string> toBes = new List<string>() { "am", "is", "are", "was", "were", "aint", "ain't", "have", "has", "stay" };
            if (toBes.Contains(word.ToLower()))
                return false;
            if (word.IndexOf("ing") != -1 && word.IndexOf("ing") == word.Length - 3)
                return true;
            if (germanNouns.Contains($",{word.ToLower()},"))
                return true;
            if (frenchNouns.Contains($"\n{word.ToLower()};s;"))
                return true;
            bool isSlang = true;
            string nounWord = word.ToLower() + "(n.)";
            if (word.Length > 0)
            {
                string subNounWord = word.Length > 2 ? word.ToLower().Substring(0, word.Length - 1) + "(n.)" : nounWord;
                string subNounWord2 = word.Length > 2 ? word.ToLower().Substring(0, word.Length - 2) + "(n.)" : nounWord;
                char w = word[0].ToString().ToUpper()[0];
                if (w <= 'Z' && w >= 'A')
                {
                    bool isNounInDictionary = dictionary[w].FindIndex(record =>
                                                {
                                                    string handledRecord = record.ToLower().Replace(" ", "");
                                                    if (isSlang && (handledRecord.IndexOf(word.ToLower()) == 0 || handledRecord.IndexOf(word.ToLower()) == 1))
                                                    {
                                                        isSlang = false;
                                                    }
                                                    if (handledRecord.IndexOf(nounWord) == 0 || handledRecord.IndexOf(nounWord) == 1
                                                            || handledRecord.IndexOf(subNounWord) == 0 || handledRecord.IndexOf(subNounWord) == 1
                                                            || handledRecord.IndexOf(subNounWord2) == 0 || handledRecord.IndexOf(subNounWord2) == 1)
                                                    {
                                                        Debug.WriteLine(record);
                                                        Debug.WriteLine(handledRecord);
                                                        return true;
                                                    }
                                                    else return false;
                                                }
                    ) != -1;
                    return isSlang || isNounInDictionary;
                }
                else if (w < '9' && w > '0') return true;
                else return false;
            }
            else return false;
        }
        public bool isVerb(string word)
        {
            word = word.Replace(" ", "");
            List<string> toBes = new List<string>() { "am", "is", "are", "was", "were", "aint", "ain't", "have", "has", "stay" };
            if (toBes.Contains(word.ToLower()))
                return true;
            string verbWord = word.ToLower() + "(v.)";
            if (word.Length > 0)
            {
                string subVerbWord = word.Length > 2 ? word.ToLower().Substring(0, word.Length - 1) + "(v.)" : verbWord;
                string subVerbWord2 = word.Length > 2 ? word.ToLower().Substring(0, word.Length - 2) + "(v.)" : verbWord;
                char w = word[0].ToString().ToUpper()[0];
                if (w <= 'Z' && w >= 'A')
                {
                    bool isVerbInDictionary = dictionary[w].FindIndex(record =>
                    {
                        string handledRecord = record.ToLower().Replace(" ", "");
                        if (handledRecord.IndexOf(verbWord) == 0 || handledRecord.IndexOf(verbWord) == 1
                                || handledRecord.IndexOf(subVerbWord) == 0 || handledRecord.IndexOf(subVerbWord) == 1
                                || handledRecord.IndexOf(subVerbWord2) == 0 || handledRecord.IndexOf(subVerbWord2) == 1)
                        {
                            Debug.WriteLine(record);
                            Debug.WriteLine(handledRecord);
                            return true;
                        }
                        else return false;
                    }
                    ) != -1;
                    return isVerbInDictionary;
                }
                else return false;
            }
            else return false;
        }
        public List<string> generate(string title, string keyword, List<string> relevantKeywords, List<string> insertedKeywords)
        {
            keyword = keyword.Trim();
            relevantKeywords = relevantKeywords.Select(k => k.Trim().ToLower()).ToList();
            List<string> result = new List<string>();
            List<KeyValuePair<string, int>> nouns = new List<KeyValuePair<string, int>>();
            List<string> words = title.Split(' ').Where(w => w.Trim().Length > 0).Distinct().ToList();
            //Extract all nouns
            for (int i = 0; i < words.Count; i++)
            {
                string word = words[i];
                if (isNoun(word))
                {
                    nouns.Add(new KeyValuePair<string, int>(word, i));
                }
            }
            //One word hashtag
            result.Add(String.Join(";", nouns.Select(n => n.Key).Where(n => n.ToLower() != keyword.ToLower())));
            //Two word hashtag
            //Keyword + noun
            result.Add(String.Join(";", nouns.Select(n => n.Key).Where(n => n.ToLower() != keyword.ToLower() && !relevantKeywords.Contains(n.ToLower())).Select(n => keyword + " " + n)));
            //noun + noun
            List<string> doubleNouns = new List<string>();
            for (int i = 0; i < nouns.Count - 1; i++)
            {
                var noun = nouns[i];
                var nextNoun = nouns[i + 1];
                if (nextNoun.Key.ToLower() != keyword.ToLower() && noun.Key.ToLower() != keyword.ToLower() && !relevantKeywords.Contains(noun.Key.ToLower()) && !relevantKeywords.Contains(nextNoun.Key.ToLower()) && nextNoun.Value - noun.Value == 1)
                {
                    doubleNouns.Add(noun.Key + " " + nextNoun.Key);
                }
            }
            result.Add(String.Join(";", doubleNouns));
            //Three word hashtag 
            //Keyword + noun  + noun
            result.Add(String.Join(";", doubleNouns.Select(d => keyword + " " + d)));
            //noun + funny + noun
            List<string> doubleFunnyNouns = new List<string>();
            if (insertedKeywords.Count == 0)
            {
                insertedKeywords.Add("Funny");
                insertedKeywords.Add("Vintage");
            }
            Random random = new Random();
            for (int i = 0; i < nouns.Count - 1; i++)
            {
                for (int j = i + 1; j < nouns.Count; j++)
                {
                    var noun = nouns[i];
                    var nextNoun = nouns[j];
                    if (relevantKeywords.Contains(noun.Key.ToLower()) && relevantKeywords.Contains(nextNoun.Key.ToLower()))
                    {
                        doubleFunnyNouns.Add(noun.Key + " " + insertedKeywords[random.Next(insertedKeywords.Count)].Trim() + " " + nextNoun.Key);
                    }
                }
            }
            result.Add(String.Join(";", doubleFunnyNouns));
            //S+V+N
            List<string> subjects = new List<string>() { "i", "you", "he", "she", "it", "they", "we" };
            List<string> svn = new List<string>();
            for (int i = 0; i < words.Count - 2; i++)
            {
                string word = words[i];
                if (subjects.Contains(word.ToLower().Trim()))
                {
                    if (isVerb(words[i + 1]))
                    {
                        int nextNoun = nouns.FindIndex(n => n.Value > i + 1);
                        if (nextNoun != -1)
                        {
                            svn.Add(word + " " + words[i + 1] + " " + nouns[nextNoun].Key);
                        }
                    }
                }
            }
            result.Add(String.Join(";", svn));
            return result;
        }
    }
}
