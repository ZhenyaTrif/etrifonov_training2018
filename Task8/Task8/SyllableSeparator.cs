using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    class SyllableSeparator
    {
        static private char[] _vomels = { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };
        static private char[] _separators = { ' ', ',', ':', '.', '!', '?', '-', '\n' };
        private string[] _words;
        private string[] _separatedWords;

        public SyllableSeparator(string text)
        {
            text.ToLower();
            _words = text.Split(_separators, StringSplitOptions.RemoveEmptyEntries);
            SeparateWords();
        }

        private void SeparateWords()
        {
            _separatedWords = new string[_words.Length];
            for (int i = 0; i < _words.Length; i++)
            {
                int numberOfSyllables = 0;
                for (int letterIndex = 0; letterIndex < _words[i].Length; letterIndex++)
                {
                    if (_vomels.Contains(_words[i][letterIndex]))
                    {
                        numberOfSyllables++;
                    }
                }
                if (numberOfSyllables == 1 || numberOfSyllables == 0)
                {
                    _separatedWords[i] = _words[i];
                }
                else
                {
                    int letterIndex = 0;
                    for (int j = 0; j < numberOfSyllables; j++)
                    {
                        string separatedWord = "" + _words[i][letterIndex];
                        if (_vomels.Contains(_words[i][letterIndex]))
                        {
                            if (j != numberOfSyllables - 1)
                            {
                                if (!_vomels.Contains(_words[i][letterIndex + 2]))
                                {
                                    separatedWord += _words[i][letterIndex + 1];
                                    letterIndex += 2;
                                }
                                else
                                {
                                    letterIndex++;
                                }
                            }
                        }
                        else
                        {
                            for (int index = letterIndex + 1; index < _words[i].Length;)
                            {
                                separatedWord += _words[i][index];
                                index++;
                                if (j != numberOfSyllables - 1)
                                {
                                    if (index + 1 < _words[i].Length)
                                    {
                                        if (_words[i][index + 1] == 'ь')
                                        {
                                            separatedWord += _words[i][index];
                                            separatedWord += _words[i][index + 1];
                                            letterIndex = index + 2;
                                            break;
                                        }
                                    }
                                    if (_vomels.Contains(_words[i][index - 1]))
                                    {
                                        letterIndex = index;
                                        break;
                                    }
                                }
                            }
                        }
                        if (j != numberOfSyllables - 1)
                        {
                            separatedWord += '-';
                        }
                        _separatedWords[i] += separatedWord;
                    }
                }
            }
        }

        public string GetSeparatedWords()
        {
            StringBuilder result = new StringBuilder();
            result.Append(_separatedWords[0] + " ");
            for (int index = 1; index < _separatedWords.Length; index++)
            {
                result.Append(_separatedWords[index] + " ");
            }
            return result.ToString();
        }
    }
}
