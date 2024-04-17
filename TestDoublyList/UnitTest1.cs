namespace TestDoublyList
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddToBeginning_AddsItemToBeginning()
        {
            // Arrange
            var list = new DoublyLinkedList<Cars>();

            // Act
            list.AddToBeginning(1);
            list.AddToBeginning(2);

            // Assert
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(2, list[0]);
            Assert.AreEqual(1, list[1]);
        }

        [Test]
        public void AddToEnd_AddsItemToEnd()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();

            // Act
            list.AddToEnd(1);
            list.AddToEnd(2);

            // Assert
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);
        }

        [Test]
        public void AddToOddIndex_AddsItemToOddIndexes()
        {
            // Arrange
            var list = new DoublyLinkedList<int>(new int[] { 1, 2, 3 });

            // Act
            list.AddToOddIndex();

            // Assert
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(0, list[1]);
            Assert.AreEqual(2, list[2]);
            Assert.AreEqual(0, list[3]);
            Assert.AreEqual(3, list[4]);
            Assert.AreEqual(0, list[5]);
        }

        [Test]
        public void RemoveItem_RemovesItem()
        {
            // Arrange
            var list = new DoublyLinkedList<int>(new int[] { 1, 2, 3 });

            // Act
            bool removed = list.RemoveItem(2);

            // Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(3, list[1]);
        }

        [Test]
        public void MakeDeepCopy_CreatesDeepCopy()
        {
            // Arrange
            var originalList = new DoublyLinkedList<int>(new int[] { 1, 2, 3 });

            // Act
            var copiedList = originalList.MakeDeepCopy(originalList);
            originalList.RemoveItem(2);

            // Assert
            Assert.AreEqual(3, copiedList.Count);
            Assert.AreEqual(1, copiedList[0]);
            Assert.AreEqual(2, copiedList[1]);
            Assert.AreEqual(3, copiedList[2]);
        }

        [Test]
        public void DeleteList_DeletesList()
        {
            // Arrange
            var list = new DoublyLinkedList<Cars>(9);

            // Act
            list.DeleteList();

            // Assert
            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.Beginning);
            Assert.IsNull(list.End);
        }
    }
}
}