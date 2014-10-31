namespace IntelliDiff.Specs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    using Xunit;

    [Binding]
    public class CompareTextFilesSteps
    {
        private string firstFile;

        private string secondFile;

        private IList<Diff> result;

        [Given(@"I have the first file:")]
        public void GivenIHaveTheFirstFile(string textfile)
        {
            this.firstFile = textfile;
        }

        [Given(@"I have the seconde file :")]
        public void GivenIHaveTheSecondeFile(string textfile)
        {
            this.secondFile = textfile;
        }

        [When(@"I press compare")]
        public void WhenIPressCompare()
        {
            var textFileComparer = new TextFileComparer();

            this.result = textFileComparer.Compare(this.firstFile, this.secondFile);
        }

        [Then(@"the result is equal")]
        public void ThenTheResultIsEqual()
        {
            Assert.Empty(this.result);
        }

        [Then(@"the result is not equal")]
        public void ThenTheResultIsNotEqual()
        {
            Assert.NotEmpty(this.result);
        }

        [Then(@"the result is :")]
        public void ThenTheResultIs(Table table)
        {
            var diffs = new DiffList(this.ConvertToDiff(table));

            Assert.Equal(diffs, new DiffList(this.result), new DiffComparer());
        }

        private IList<Diff> ConvertToDiff(Table table)
        {
            return table.Rows.Select(this.ConvertToDiff).ToList();
        }

        private Diff ConvertToDiff(TableRow row)
        {
            return new Diff()
                       {
                           Line = Convert.ToInt32(row["Line"]),
                           Type = EnumHelper.Parse<DiffType>(row["Type"]),
                           Value = row["Value"],
                       };
        }
    }

    internal class DiffList
    {
        private readonly IList<Diff> convertToDiff;

        public DiffList(IList<Diff> convertToDiff)
        {
            this.convertToDiff = convertToDiff;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var item in convertToDiff)
            {
                sb.AppendLine(string.Format("| {0} | {1} | {2} |", item.Line, item.Type, item.Value));
            }

            return sb.ToString();
        }
    }
}
