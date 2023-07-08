using System.Reflection;
using TranslateLiblary;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void AddWordsTest()
        {
            // arrange
            Dictionary<string, string> arrange = new();
            arrange.Add("brother", "брат");

            // act
            Translate translate = new();
            Type myType = typeof(Translate);

            translate.AddWords("brother", "брат");
            var dict = myType.GetField("_dict", BindingFlags.Instance | BindingFlags.NonPublic);
            var actual = dict?.GetValue(translate);

            // assert
            Assert.Equal(arrange, actual);
        }
        [Fact]
        public void CheckWordTest()
        {
            // arrange
            // act
            // assert
        }
        [Fact]
        public void TranslatingTest()
        {
            // arrange
            // act
            // assert
        }

    }
}