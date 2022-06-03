using Bogus;
using FakerPoc.Service;
using Moq;

namespace FakerPocTest
{
    public class Tests
    {
        private Service _sut;
        private readonly Mock<ISomeService> _someServiceMock = new();
        private readonly Faker _faker = new();
        private readonly List<string> _possibleStringOutputs = new() { "Fixed 1", "Fixed 2", "Fixed 3", "Fixed 4", "Fixed 5" };
        private readonly List<int> _possibleIntOutputs = new() { 1, 2, 3, 4, 5 };
        private List<SomeClass> _someClasses;

        [SetUp]
        public void Setup()
        {
            var someClassFake = new Faker<SomeClass>()
                .RuleFor(src => src.Name, tgt => tgt.Random.Replace("??????"))
                .RuleFor(src => src.Description, tgt => tgt.Random.String(1, 6))
                .RuleFor(src => src.DateTime, tgt => tgt.Date.Recent(0))
                .RuleFor(src => src.Age, tgt => tgt.Random.Number(0, 10));
            _someClasses = someClassFake.Generate(100);
            _sut = new Service(_someServiceMock.Object);
        }

        [Test]
        public void GetSomeInt_WhenCallIsValid_ShouldReturnSomeRandomInt()
        {
            //Arrange
            var output = _faker.Random.Int();
            _someServiceMock.Setup(s => s.GetSomeInt()).Returns(output);

            //Act
            var result = _sut.GetSomeInt();

            //Assert
            Assert.That(result, Is.EqualTo(output));
        }

        [Test]
        public void GetSomeInt_WhenCallIsValid_ShouldReturnOneDelimitedValue()
        {
            //Arrange
            var output = _faker.PickRandom(_possibleIntOutputs);
            _someServiceMock.Setup(s => s.GetSomeInt()).Returns(output);

            //Act
            var result = _sut.GetSomeInt();

            //Assert
            Assert.That(result, Is.EqualTo(output));
        }

        [Test]
        public void GetSomeString_WhenCallIsValid_ShouldReturnSomeRandomStringTxt()
        {
            //Arrange
            var output = _faker.Random.Replace("********.txt");
            _someServiceMock.Setup(s => s.GetSomeString()).Returns(output);

            //Act
            var result = _sut.GetSomeString();

            //Assert
            Assert.That(result, Is.EqualTo(output));
        }

        [Test]
        public void GetSomeString_WhenCallIsValid_ShouldReturnOneDelimitedValue()
        {
            //Arrange
            var output = _faker.PickRandom(_possibleStringOutputs);
            _someServiceMock.Setup(s => s.GetSomeString()).Returns(output);

            //Act
            var result = _sut.GetSomeString();

            //Assert
            Assert.That(result, Is.EqualTo(output));
        }

        [Test]
        public void GetSomeClass_WhenCallIsValid_ShouldReturnSomeClass()
        {
            //Arrange
            var output = _faker.PickRandom(_someClasses);
            _someServiceMock.Setup(s => s.GetSomeClass()).Returns(output);

            //Act
            var result = _sut.GetSomeClass();

            //Assert
            Assert.That(result, Is.SameAs(output));
        }
    }
}