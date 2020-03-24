using NUnit.Framework;

namespace TestProject1
{
    public class Tests
    {
        private TextMatchService _textMatchService;
        //private string baseText = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea";
        [SetUp]
        public void Setup()
        {
            _textMatchService = new TextMatchService();
        }

        [TestCase("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea","polly")]
        [TestCase("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "Polly")]
        [TestCase("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "PoLly")]

        public void GetIndexesOf_SubTextInputIsPolly(string text, string subtext)
        {
            var x = _textMatchService.GetIndexesOf(text, subtext);
            if (x == "1,26,51")
            {
                Assert.Pass();
            }
            Assert.Fail();
        }
        
        [TestCase("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea","Ll")]
        [TestCase("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "ll")]
        public void GetIndexesOf_SubTextInputIsLl(string text,string subtext)
        {
            var x = _textMatchService.GetIndexesOf(text, subtext);
            if (x == "3,28,53,78,82")
            {
                Assert.Pass();
            }
            Assert.Fail();
        }
        [TestCase("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "")]
        public void GetIndexesOf_SubTextInputIsEmpty(string text, string subtext)
        {
            var x = _textMatchService.GetIndexesOf(text, subtext);
            if (x != "")
            {
                Assert.Fail();
            }
            Assert.Pass();
        }
        
        [TestCase("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "X")]
        [TestCase("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "Polx")]

        public void GetIndexesOf_SubTextInputDoesNotExit(string text, string subtext)
        {
            var x = _textMatchService.GetIndexesOf(text, subtext);
            if (x != "")
            {
                Assert.Fail();
            }
            Assert.Pass();
        }
    }
}