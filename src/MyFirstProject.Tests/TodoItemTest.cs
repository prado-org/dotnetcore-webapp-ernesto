using System.Net;

namespace MyFirstProject.Tests
{
    [TestClass]
    public class TodoItemsControllerTests
    {
        private HttpClient _client;
        private static string _url = "http://localhost:5017/";
        
        [TestInitialize]
        public void Initialize()
        {
            _client = new HttpClient();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _client.Dispose();
        }

        [TestMethod]
        public async Task GetTodo_ReturnsOk()
        {
            // Arrange
            _client.BaseAddress = new Uri(_url);

            // Act
            var response = await _client.GetAsync("/api/TodoItem");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
