namespace IntelliDiff
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class TextFileComparer
    {
        public IList<Diff> Compare(string firstFile, string secondFile)
        {
            var diffs = new List<Diff>();

            var lines1 = firstFile.Split('\n').Select(s => s.TrimEnd('\r')).ToArray();
            var lines2 = secondFile.Split('\n').Select(s => s.TrimEnd('\r')).ToArray();

            var i = 0;
            var j = 0;
            var startj = 0;

            while (i < lines1.Length && j < lines2.Length)
            {
                if (lines1[i] == lines2[j])
                {
                    i++;
                    j++;
                    startj = j;
                }
                else if (j < lines2.Length)
                {
                    diffs.Add(new Diff());
                    j++;
                }
                else
                {
                    diffs.Add(new Diff());
                    i++;
                    j = startj;
                }
            }

            while (i < lines1.Length)
            {
                diffs.Add(new Diff() { Line = i + 1, Type = DiffType.Del, Value = lines1[i] });
                i++;
            }

            while (j < lines2.Length)
            {
                diffs.Add(new Diff() { Line = i + 1, Type = DiffType.Add, Value = lines2[j] });
                j++;
            }

            return diffs;
        }
    }
}