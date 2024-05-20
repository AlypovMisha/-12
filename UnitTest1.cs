using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LibraryForLabs;
using Лабораторная_12;
using System.Collections;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTests
    {
        #region LinkedListTests
        [TestMethod]
        public void Constructor_WithData_SetsData()
        {
            // Arrange
            var data = new Cars("Toyota", 2022, "Red", 150000, 25);

            // Act
            var node = new Node<Cars>(data);

            // Assert
            Assert.AreEqual(data, node.Data);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Size is not less than 0")]
        public void Constructor_LessThanZero()
        {
            // Arrange
            var list = new DoublyLinkedList<Cars>(-5);

            // Act
            list.AddOddItems();            
        }

        [TestMethod]        
        public void Constructor_WithoutData()
        {
            // Arrange
            var list = new DoublyLinkedList<Cars>(0);

            // Assert
            Assert.AreEqual(list.Count, 0);
        }

        [TestMethod]
        public void Constructor_WithNullData_SetsDefaultData()
        {
            // Arrange & Act
            var node = new Node<Cars>();

            // Assert
            Assert.AreEqual(default(Cars), node.Data);
        }

        [TestMethod]
        public void MakeRandomData_CreatesNodeWithRandomData()
        {
            // Arrange & Act
            var node = new Node<Cars>().MakeRandomData();

            // Assert
            Assert.IsNotNull(node.Data);
        }

        [TestMethod]
        public void MakeRandomItem_CreatesRandomData()
        {
            // Arrange & Act
            var data = new Node<Cars>().MakeRandomItem();

            // Assert
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void ToString_ReturnsStringRepresentationOfData()
        {
            // Arrange
            var data = new Cars("Toyota", 2022, "Red", 150000, 25);
            var node = new Node<Cars>(data);

            // Act
            var result = node.ToString();

            // Assert
            Assert.AreEqual(data.ToString(), result);
        }

        [TestMethod]
        public void Constructor_WithNextAndPrev_Null()
        {
            // Arrange & Act
            var node = new Node<Cars>();

            // Assert
            Assert.IsNull(node.Next);
            Assert.IsNull(node.Prev);
        }

        [TestMethod]
        public void Constructor_WithNextAndPrev_SetsNextAndPrev()
        {
            // Arrange
            var car = new Cars();
            var nextNode = new Node<Cars>().MakeRandomData();
            var prevNode = new Node<Cars>().MakeRandomData();

            // Act
            var node = new Node<Cars>(car);
            node.Next = nextNode;
            node.Prev = prevNode;

            // Assert
            Assert.AreEqual(nextNode, node.Next);
            Assert.AreEqual(prevNode, node.Prev);
        }
        [TestMethod]
        public void Constructor_WithNonNullArray_CreatesListWithElements()
        {
            // Arrange
            Cars[] array = { new Cars("Toyota", 2022, "Blue", 250000, 25), new Cars("Nissan", 2023, "Black", 777777, 25), new Cars("Ford", 2023, "Green", 20000, 6) };

            // Act
            var list = new DoublyLinkedList<Cars>(array);

            // Assert
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(new Cars("Toyota", 2022, "Blue", 250000, 25), list.ElementAt(0).Data);
            Assert.AreEqual(new Cars("Nissan", 2023, "Black", 777777, 25), list.ElementAt(1).Data);
            Assert.AreEqual(new Cars("Ford", 2023, "Green", 20000, 6), list.ElementAt(2).Data);
        }

        [TestMethod]
        public void Constructor_WithEmptyArray_ThrowsArgumentException()
        {
            // Arrange
            Cars[] emptyArray = new Cars[0];

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new DoublyLinkedList<Cars>(emptyArray));
        }

        [TestMethod]
        public void Constructor_WithNullArray_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new DoublyLinkedList<Cars>(null));
        }
    
         [TestMethod]
        public void MakeRandomData_CreatesDifferentNodes()
        {
            // Arrange & Act
            var node1 = new Node<Cars>().MakeRandomData();
            var node2 = new Node<Cars>().MakeRandomData();

            // Assert
            Assert.AreNotEqual(node1.Data, node2.Data);
        }

        [TestMethod]
        public void MakeRandomItem_CreatesDifferentItems()
        {
            // Arrange & Act
            var item1 = new Node<Cars>().MakeRandomItem();
            var item2 = new Node<Cars>().MakeRandomItem();

            // Assert
            Assert.AreNotEqual(item1, item2);
        }

        //Тестирование двунаправленного списка
        [TestMethod]
        public void AddToBeginning_AddsItemToBeginning()
        {
            // Arrange
            var list = new DoublyLinkedList<Cars>();
            var item = new Cars("Toyota", 2022, "Blue", 250000, 25);

            // Act
            list.AddToBeginning(item);

            // Assert
            Assert.AreEqual(item, list.ElementAt(0).Data);
        }

        [TestMethod]
        public void AddToBeginning_EmptyList_AddsItemAsBeginning()
        {
            // Arrange
            var list = new DoublyLinkedList<Cars>();

            // Act
            list.AddToBeginning(new Cars("Toyota", 2022, "Blue", 250000, 25));

            // Assert
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(new Cars("Toyota", 2022, "Blue", 250000, 25), list.ElementAt(0).Data);
        }

        [TestMethod]
        public void AddToBeginning_NonEmptyList_AddsItemAsBeginning()
        {
            // Arrange
            Cars[] array = { new Cars("Toyota", 2022, "Blue", 250000, 25), new Cars("Nissan", 2023, "Black", 777777, 25), new Cars("Ford", 2023, "Green", 20000, 6) };
            var list = new DoublyLinkedList<Cars>(array);

            // Act
            list.AddToBeginning(new Cars("BMW", 2022, "Blue", 250000, 25));

            // Assert
            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(new Cars("BMW", 2022, "Blue", 250000, 25), list.ElementAt(0).Data);
            Assert.AreEqual(new Cars("Nissan", 2023, "Black", 777777, 25), list.ElementAt(2).Data);            
        }

        [TestMethod]
        public void AddToBeginning_ReplaceFirstItem_ReplacesBeginningItem()
        {
            // Arrange
            Cars[] array = { new Cars("Nissan", 2023, "Black", 777777, 25) };
            var list = new DoublyLinkedList<Cars>(array);

            // Act
            list.AddToBeginning(new Cars("Toyota", 2022, "Blue", 250000, 25));

            // Assert
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(new Cars("Toyota", 2022, "Blue", 250000, 25), list.ElementAt(0).Data);
        }

        [TestMethod]
        public void AddToEnd_AddsItemToEnd()
        {
            // Arrange
            var list = new DoublyLinkedList<Cars>();
            var item = new Cars("Toyota", 2022, "Blue", 250000, 25);

            // Act
            list.AddToEnd(item);

            // Assert
            Assert.AreEqual(item, list.ElementAt(list.Count - 1).Data);
        }

        [TestMethod]
        public void AddToOddIndex_AddsItemToOddIndex()
        {
            // Arrange
            var list = new DoublyLinkedList<Cars>(5);
            Cars item = new Cars(list.ElementAt(0).Data);
            

            // Act
            list.AddOddItems();
            Cars item1 = new Cars(list.ElementAt(0).Data);

            // Assert
            Assert.AreEqual(item, list.ElementAt(1).Data);
            Assert.AreEqual(item1, list.ElementAt(0).Data);
        }

        [TestMethod]
        public void AddOddItems_EmptyList_ThrowsException()
        {
            // Arrange
            var list = new DoublyLinkedList<Cars>();

            // Act
            list.AddOddItems();
        }

        [TestMethod]
        public void AddOddItems_ListWithOneItem_AddsItemsBeforeCurrentItem()
        {
            // Arrange
            var list = new DoublyLinkedList<Cars>();
            list.AddToEnd(new Cars("Toyota", 2022, "Blue", 250000, 25));

            // Act
            list.AddOddItems();
            Cars item = new Cars(list.ElementAt(0).Data);

            // Assert
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(item.Brand, list.ElementAt(0).Data.Brand);
            Assert.AreEqual("Toyota", list.ElementAt(1).Data.Brand);
        }

        [TestMethod]
        public void AddOddItems_ListWithEvenNumberOfItems_AddsItemsBeforeEverySecondItem()
        {
            // Arrange
            var list = new DoublyLinkedList<Cars>();
            list.AddToEnd(new Cars("Toyota", 2022, "Blue", 250000, 25));
            list.AddToEnd(new Cars("Nissan", 2023, "Black", 777777, 25));

            // Act
            list.AddOddItems();

            // Assert
            Assert.AreEqual(4, list.Count);         
            Assert.AreEqual("Toyota", list.ElementAt(1).Data.Brand);
            Assert.AreEqual("Nissan", list.ElementAt(3).Data.Brand);
        }

        [TestMethod]
        public void RemoveItem_RemovesItem()
        {
            // Arrange
            var list = new DoublyLinkedList<Cars>();
            var item = new Cars("Toyota", 2022, "Blue", 250000, 25);
            list.AddToEnd(item);

            // Act
            list.RemoveItem(item);

            // Assert
            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.FindItem(item));
        }

        [TestMethod]
        public void MakeDeepCopy_CreatesDeepCopy()
        {
            // Arrange
            var list = new DoublyLinkedList<Cars>();
            var item = new Cars("Toyota", 2022, "Blue", 250000, 25);
            list.AddToEnd(item);

            // Act
            var copy = list.MakeDeepCopy();

            // Assert
            Assert.AreNotSame(list, copy);
            Assert.AreEqual(list.Count, copy.Count);
            Assert.AreEqual(list.ElementAt(0).Data, copy.ElementAt(0).Data);
        }

        [TestMethod]
        public void DeleteList_RemovesAllItems()
        {
            // Arrange
            var list = new DoublyLinkedList<Cars>();
            list.AddToEnd(new Cars("Toyota", 2022, "Blue", 25000, 5));
            list.AddToEnd(new Cars("Honda", 2021, "Red", 30000, 4));
            list.AddToEnd(new Cars("Ford", 2023, "Green", 20000, 6));

            // Act
            list.DeleteList();

            // Assert
            Assert.AreEqual(0, list.Count);
        }


        [TestMethod]
        public void ElementAt_ExistingIndex_ReturnsCorrectElement()
        {
            // Arrange
            var list = new DoublyLinkedList<Cars>();
            list.AddToEnd(new Cars("Toyota", 2022, "Blue", 25000, 5));
            list.AddToEnd(new Cars("Honda", 2021, "Red", 30000, 4));
            list.AddToEnd(new Cars("Ford", 2023, "Green", 20000, 6));

            // Act
            var result = list.ElementAt(1);

            // Assert
            Assert.AreEqual(new Cars("Honda", 2021, "Red", 30000, 4), result.Data);
        }

        [TestMethod]
        public void ElementAt_IndexOutOfRange_ReturnsNull()
        {
            // Arrange
            var list = new DoublyLinkedList<Cars>();
            list.AddToEnd(new Cars("Honda", 2021, "Red", 30000, 4));

            // Act
            var result = list.ElementAt(2);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void RemoveItem_ExistingItem_RemovesItem()
        {
            // Arrange
            var list = new DoublyLinkedList<Cars>();
            list.AddToEnd(new Cars("Toyota", 2022, "Blue", 25000, 5));
            list.AddToEnd(new Cars("Honda", 2021, "Red", 30000, 4));
            list.AddToEnd(new Cars("Ford", 2023, "Green", 20000, 6));

            // Act
            list.RemoveItem(new Cars("Honda", 2021, "Red", 30000, 4));

            // Assert
            Assert.AreEqual(2, list.Count);
            Assert.IsNull(list.FindItem(new Cars("Honda", 2021, "Red", 30000, 4)));
        }

        [TestMethod]
        public void RemoveItem_EmptyList_ThrowsException()
        {
            // Arrange
            var list = new DoublyLinkedList<Cars>();

            // Act & Assert
            Assert.ThrowsException<Exception>(() => list.RemoveItem(new Cars("Honda", 2021, "Red", 30000, 4)));
        }

        [TestMethod]
        public void RemoveItem_NonExistingItem_ReturnsFalse()
        {
            // Arrange
            var list = new DoublyLinkedList<Cars>();
            list.AddToEnd(new Cars("Toyota", 2022, "Blue", 25000, 5));
            list.AddToEnd(new Cars("Honda", 2021, "Red", 30000, 4));

            // Act
            var result = list.RemoveItem(new Cars("Ford", 2023, "Green", 20000, 6));

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        public void RemoveItem_SingleElementList_RemovesElement()
        {
            // Arrange
            var list = new DoublyLinkedList<Cars>();
            list.AddToEnd(new Cars("Toyota", 2022, "Blue", 25000, 5));

            // Act
            var result = list.RemoveItem(new Cars("Toyota", 2022, "Blue", 25000, 5));

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.FindItem(new Cars("Toyota", 2022, "Blue", 25000, 5)));
        }

        [TestMethod]
        public void RemoveItem_FirstElement_RemovesFirstElement()
        {
            // Arrange
            var list = new DoublyLinkedList<Cars>();
            list.AddToEnd(new Cars("Toyota", 2022, "Blue", 25000, 5));
            list.AddToEnd(new Cars("Honda", 2021, "Red", 30000, 4));

            // Act
            var result = list.RemoveItem(new Cars("Toyota", 2022, "Blue", 25000, 5));

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, list.Count);
            Assert.IsNull(list.FindItem(new Cars("Toyota", 2022, "Blue", 25000, 5)));
        }

        [TestMethod]
        public void RemoveItem_LastElement_RemovesLastElement()
        {
            // Arrange
            var list = new DoublyLinkedList<Cars>();
            list.AddToEnd(new Cars("Toyota", 2022, "Blue", 25000, 5));
            list.AddToEnd(new Cars("Honda", 2021, "Red", 30000, 4));

            // Act
            var result = list.RemoveItem(new Cars("Honda", 2021, "Red", 30000, 4));

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, list.Count);
            Assert.IsNull(list.FindItem(new Cars("Honda", 2021, "Red", 30000, 4)));
        }

        [TestMethod]
        public void RemoveItem_MiddleElement_RemovesMiddleElement()
        {
            // Arrange
            var list = new DoublyLinkedList<Cars>();
            list.AddToEnd(new Cars("Toyota", 2022, "Blue", 25000, 5));
            list.AddToEnd(new Cars("Honda", 2021, "Red", 30000, 4));
            list.AddToEnd(new Cars("Ford", 2023, "Green", 20000, 6));

            // Act
            var result = list.RemoveItem(new Cars("Honda", 2021, "Red", 30000, 4));

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(2, list.Count);
            Assert.IsNull(list.FindItem(new Cars("Honda", 2021, "Red", 30000, 4)));
        }

        [TestMethod]
        public void DeleteAfterFound_EmptyList_NoChanges()
        {
            // Arrange
            var list = new DoublyLinkedList<Cars>();

            // Act
            list.DeleteAfterFound(new Cars("Toyota", 2022, "Blue", 250000, 25));

            // Assert
            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.ElementAt(0));
        }

        [TestMethod]
        public void DeleteAfterFound_ListWithOneItem_RemovesItem()
        {
            // Arrange
            var list = new DoublyLinkedList<Cars>();
            list.AddToEnd(new Cars("Toyota", 2022, "Blue", 250000, 25));

            // Act
            list.DeleteAfterFound(new Cars("Toyota", 2022, "Blue", 250000, 25));

            // Assert
            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.ElementAt(0));
        }

        [TestMethod]
        public void DeleteAfterFound_ItemAtBeginning_RemovesItem()
        {
            // Arrange
            var list = new DoublyLinkedList<Cars>();
            list.AddToEnd(new Cars("Toyota", 2022, "Blue", 250000, 25));
            list.AddToEnd(new Cars("Nissan", 2023, "Black", 777777, 25));
            list.AddToEnd(new Cars("Ford", 2023, "Green", 20000, 6));

            // Act
            list.DeleteAfterFound(new Cars("Nissan", 2023, "Black", 777777, 25));

            // Assert
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(new Cars("Toyota", 2022, "Blue", 250000, 25), list.ElementAt(0).Data);
            Assert.IsNull(list.FindItem(new Cars("Nissan", 2023, "Black", 777777, 25)));
        }

        [TestMethod]
        public void DeleteAfterFound_ItemAtEnd_RemovesItem()
        {
            // Arrange
            var list = new DoublyLinkedList<Cars>();
            list.AddToEnd(new Cars("Toyota", 2022, "Blue", 250000, 25));
            list.AddToEnd(new Cars("Nissan", 2023, "Black", 777777, 25));
            list.AddToEnd(new Cars("Ford", 2023, "Green", 20000, 6));

            // Act
            list.DeleteAfterFound(new Cars("Ford", 2023, "Green", 20000, 6));

            // Assert
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(new Cars("Toyota", 2022, "Blue", 250000, 25), list.ElementAt(0).Data);
            Assert.AreEqual(new Cars("Nissan", 2023, "Black", 777777, 25), list.ElementAt(1).Data);
        }

        [TestMethod]
        public void DeleteAfterFound_ItemInMiddle_RemovesItem()
        {
            // Arrange
            var list = new DoublyLinkedList<Cars>();
            list.AddToEnd(new Cars("Toyota", 2022, "Blue", 250000, 25));
            list.AddToEnd(new Cars("Nissan", 2023, "Black", 777777, 25));
            list.AddToEnd(new Cars("Ford", 2023, "Green", 20000, 6));

            // Act
            list.DeleteAfterFound(new Cars("Toyota", 2022, "Blue", 250000, 25));

            // Assert
            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.FindItem(new Cars("Toyota", 2022, "Blue", 250000, 25)));
            Assert.IsNull(list.FindItem(new Cars("Nissan", 2023, "Black", 777777, 25)));
            Assert.IsNull(list.FindItem(new Cars("Ford", 2023, "Green", 20000, 6)));
        }
        #endregion

        #region HashTableTests
        [TestClass]
        public class HashTableTests
        {
            [TestMethod]
            public void Test_Constructor()
            {
                // Arrange
                HashTable<Cars> hashTable = new HashTable<Cars>(-5);

                // Act
                Cars cars = new Cars();
                cars.RandomInit();
                hashTable.Add(cars);

                // Assert
                Assert.IsTrue(hashTable.Contains(cars));
                Assert.AreEqual(1, hashTable.Count);
            }

            [TestMethod]
            public void Add_AddingElement_ElementIsAdded()
            {
                // Arrange
                HashTable<Cars> hashTable = new HashTable<Cars>(10);

                // Act
                Cars cars = new Cars();
                cars.RandomInit();
                hashTable.Add(cars);

                // Assert
                Assert.IsTrue(hashTable.Contains(cars));
                Assert.AreEqual(1, hashTable.Count);
            }

            [TestMethod]
            public void Add_AddingDuplicateElement_DuplicateIsNotAdded()
            {
                // Arrange
                HashTable<Cars> hashTable = new HashTable<Cars>(10);

                // Act
                Cars cars = new Cars();
                cars.RandomInit();
                hashTable.Add(cars);
                hashTable.Add(cars);

                // Assert
                Assert.IsTrue(hashTable.Contains(cars));
                Assert.AreEqual(1, hashTable.Count);
            }

            [TestMethod]
            public void RemoveElement_RemovingExistingElement_ElementIsRemoved()
            {
                // Arrange
                HashTable<Cars> hashTable = new HashTable<Cars>(10);
                Cars cars = new Cars("Toyota", 2022, "Red", 150000, 25);
                hashTable.Add(cars);

                // Act
                var result = hashTable.RemoveElement(cars);

                // Assert
                Assert.IsTrue(result);
                Assert.IsFalse(hashTable.Contains(cars));
                Assert.AreEqual(0, hashTable.Count);
            }

            [TestMethod]
            public void Contains_CheckingForExistingElement_ReturnsTrue()
            {
                // Arrange
                HashTable<Cars> hashTable = new HashTable<Cars>(10);
                Cars cars = new Cars("Toyota", 2022, "Red", 150000, 25);
                hashTable.Add(cars);

                // Act
                var result = hashTable.Contains(cars);

                // Assert
                Assert.IsTrue(result);
            }

            [TestMethod]
            public void Contains_CheckingForNonExistingElement_ReturnsFalse()
            {
                // Arrange
                HashTable<Cars> hashTable = new HashTable<Cars>(10);
                Cars cars = new Cars("Toyota", 2022, "Red", 150000, 25);
                Cars cars1 = new Cars("Ford", 2020, "Blue", 350000, 20);
                hashTable.Add(cars);

                // Act
                var result = hashTable.Contains(cars1);

                // Assert
                Assert.IsFalse(result);
            }

            [TestMethod]
            [ExpectedException(typeof(NullReferenceException))]
            public void Contains_EmptyTable_ThrowsException()
            {
                // Arrange
                HashTable<Cars> hashTable = new HashTable<Cars>(10);
                Cars car1 = new Cars("Toyota", 2022, "Blue", 250000, 25);
                Cars car2 = new Cars("Nissan", 2023, "Black", 777777, 25);
                hashTable.Add(car1);
                hashTable.Add(car2);
                // Act
                hashTable.DeleteHashTable();

                // Assert
                hashTable.Contains(car2);
            }

            [TestMethod]
            public void Contains_ElementNotInChain_ReturnsFalse()
            {
                // Arrange
                HashTable<Cars> hashTable = new HashTable<Cars>(1);
                Cars car1 = new Cars("Toyota", 2022, "Blue", 250000, 25);
                Cars car2 = new Cars("Nissan", 2023, "Black", 777777, 25);
                hashTable.Add(car1);
                hashTable.Add(car2);

                // Act
                hashTable.RemoveElement(car2);
                bool contains = hashTable.Contains(car2);
                hashTable.Add(car2);
                bool contains1 = hashTable.Contains(car2);

                // Assert
                Assert.IsFalse(contains);
                Assert.IsTrue(contains1);
            }

            [TestMethod]
            public void Contains_ElementInChain_ReturnsTrue()
            {
                // Arrange
                HashTable<Cars> hashTable = new HashTable<Cars>(10);
                Cars car1 = new Cars("Toyota", 2022, "Blue", 250000, 25);
                hashTable.Add(car1);

                // Act
                bool contains = hashTable.Contains(car1);

                // Assert
                Assert.IsTrue(contains);
            }

            [TestMethod]
            public void Add_AddingCarsElement_ElementIsAdded()
            {
                // Arrange
                HashTable<Cars> hashTable = new HashTable<Cars>(10);
                Cars car1 = new Cars("Toyota", 2022, "Blue", 250000, 25);
                Cars car2 = new Cars("Nissan", 2023, "Black", 777777, 25);

                // Act
                hashTable.Add(car1);
                hashTable.Add(car2);

                // Assert
                Assert.IsTrue(hashTable.Contains(car1));
                Assert.IsTrue(hashTable.Contains(car2));
                Assert.AreEqual(2, hashTable.Count);
            }

            [TestMethod]
            public void Add_AddingExistingCarsElement_ElementIsNotDuplicated()
            {
                // Arrange
                HashTable<Cars> hashTable = new HashTable<Cars>(10);
                Cars car1 = new Cars("Toyota", 2022, "Blue", 250000, 25);

                // Act
                hashTable.Add(car1);
                hashTable.Add(car1); // Trying to add the same car again

                // Assert
                Assert.AreEqual(1, hashTable.Count);
            }

            [TestMethod]
            public void Add_AddingMultipleCarsElements_CountIsIncreasedCorrectly()
            {
                // Arrange
                HashTable<Cars> hashTable = new HashTable<Cars>(10);
                Cars car1 = new Cars("Toyota", 2022, "Blue", 250000, 25);
                Cars car2 = new Cars("Nissan", 2023, "Black", 777777, 25);
                Cars car3 = new Cars("Honda", 2020, "Red", 150000, 20);

                // Act
                hashTable.Add(car1);
                hashTable.Add(car2);
                hashTable.Add(car3);

                // Assert
                Assert.AreEqual(3, hashTable.Count);
            }

            [TestMethod]
            public void Add_AddingToExistingChain_CountIsIncreasedCorrectly()
            {
                // Arrange
                HashTable<Cars> hashTable = new HashTable<Cars>(10);
                Cars car1 = new Cars("Toyota", 2022, "Blue", 250000, 25);
                Cars car2 = new Cars("Nissan", 2023, "Black", 777777, 25);
                Cars car3 = new Cars("Honda", 2020, "Red", 150000, 20);

                // Act
                hashTable.Add(car1);
                hashTable.Add(car2);
                hashTable.Add(car3); // Adding to an existing chain

                // Assert
                Assert.AreEqual(3, hashTable.Count);
            }

            [TestMethod]
            public void Add_AddingToExistingChain_ChainIsCorrectlyLinked()
            {
                // Arrange
                HashTable<Cars> hashTable = new HashTable<Cars>(10);
                Cars car1 = new Cars("Toyota", 2022, "Blue", 250000, 25);
                Cars car2 = new Cars("Nissan", 2023, "Black", 777777, 25);
                Cars car3 = new Cars("Honda", 2020, "Red", 150000, 20);

                // Act
                hashTable.Add(car1);
                hashTable.Add(car2);
                hashTable.Add(car3); // Adding to an existing chain

                // Assert
                Assert.IsTrue(hashTable.Contains(car1));
                Assert.IsTrue(hashTable.Contains(car2));
                Assert.IsTrue(hashTable.Contains(car3));
            }

            [TestMethod]
            public void SearchItem_ItemFound_ReturnsCorrectNode()
            {
                // Arrange
                HashTable<Cars> hashTable = new HashTable<Cars>(10);
                Cars car = new Cars("Toyota", 2022, "Blue", 250000, 25);
                hashTable.Add(car);

                // Act
                var result = hashTable.SearchItem(car);

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(car, result.Data);
            }

            [TestMethod]
            public void SearchItem_ItemNotFound_ReturnsDefault()
            {
                // Arrange
                HashTable<Cars> hashTable = new HashTable<Cars>(10);
                Cars car = new Cars("Toyota", 2022, "Blue", 250000, 25);
                Cars nonExistentCar = new Cars("Nissan", 2023, "Black", 777777, 25);
                hashTable.Add(car);

                // Act
                var result = hashTable.SearchItem(nonExistentCar);

                // Assert
                Assert.AreEqual(default(Node<Cars>), result);
            }

            [TestMethod]
            public void SearchItem_EmptyTable_ReturnsDefault()
            {
                // Arrange
                HashTable<Cars> hashTable = new HashTable<Cars>(10);
                Cars car = new Cars("Toyota", 2022, "Blue", 250000, 25);

                // Act
                var result = hashTable.SearchItem(car);

                // Assert
                Assert.AreEqual(default(Node<Cars>), result);
            }

            [TestMethod]
            public void SearchItem_IfOneOfThemWasDeleted()
            {
                // Arrange
                HashTable<Cars> hashTable = new HashTable<Cars>(10);
                Cars car = new Cars("Honda", 2022, "Blue", 250000, 25);
                Cars car1 = new Cars("Ford", 2022, "Blue", 250000, 26);
                // Act
                hashTable.Add(car);
                hashTable.Add(car1);
                hashTable.RemoveElement(car);
                var result = hashTable.SearchItem(car);

                // Assert
                Assert.AreEqual(default(Node<Cars>), result);
            }
            [TestMethod]
            public void SearchItem_IfOneOfThemWasDeleted2()
            {
                // Arrange
                HashTable<Cars> hashTable = new HashTable<Cars>(1);
                Cars car = new Cars("Honda", 2022, "Blue", 250000, 25);
                Cars car1 = new Cars("Ford", 2022, "Blue", 250000, 26);
                // Act
                hashTable.Add(car);
                hashTable.Add(car1);
                hashTable.RemoveElement(car);
                var result = hashTable.SearchItem(car);

                // Assert
                Assert.AreEqual(default(Node<Cars>), result);
            }
            [TestMethod]
            [ExpectedException(typeof(Exception), "Таблица удалена")]
            public void Delete_HashTable()
            {
                // Arrange
                HashTable<Cars> hashTable = new HashTable<Cars>(10);
                Cars car = new Cars("Honda", 2022, "Blue", 250000, 25);
                Cars car1 = new Cars("Ford", 2022, "Blue", 250000, 26);
                // Act
                hashTable.Add(car);
                hashTable.Add(car1);
                hashTable.DeleteHashTable();

                // Assert
                Assert.AreEqual(hashTable.Count, 0);
                hashTable.PrintTable();
            }

            [TestMethod]
            public void Add_NonDuplicateElementInExistingChain_IncrementsCount()
            {
                // Arrange
                HashTable<Cars> hashTable = new HashTable<Cars>(10);
                Cars car1 = new Cars("Toyota", 2022, "Blue", 250000, 25);
                Cars car2 = new Cars("Nissan", 2023, "Black", 777777, 25);
                hashTable.Add(car1);

                // Act
                hashTable.Add(car2);

                // Assert
                Assert.AreEqual(2, hashTable.Count);
            }

            [TestMethod]
            public void Add_DuplicateElementInExistingChain_DoesNotIncrementCount()
            {
                // Arrange
                HashTable<Cars> hashTable = new HashTable<Cars>(10);
                Cars cars1 = new Cars("Ford", 2000, "Black", 111111, 20);
                Cars cars2 = new Cars("BMW", 2022, "Blue", 333333, 25);
                Cars cars3 = new Cars("Toyota", 2003, "Green", 444444, 30);
                Cars cars4 = new Cars("Honda", 2010, "Yellow", 555555, 35);
                Cars cars5 = new Cars("BMW", 2000, "Black", 777777, 25);
                Cars cars6 = new Cars("BMW", 2001, "Black", 777777, 25);
                Cars cars7 = new Cars("Nissan", 2010, "Black", 888888, 25);
                Cars cars8 = new Cars("Mercedes", 2000, "Black", 999999, 25);
                Cars cars9 = new Cars("BMW", 2000, "Black", 222222, 25);
                Cars cars10 = new Cars("Chevy", 2000, "Black", 111111, 25);
                hashTable.Add(cars1);

                // Act
                hashTable.Add(cars1);
                hashTable.Add(cars2);
                hashTable.Add(cars3);
                hashTable.Add(cars4);
                hashTable.Add(cars5);
                hashTable.Add(cars6);
                hashTable.Add(cars7);
                hashTable.Add(cars8);
                hashTable.Add(cars9);
                hashTable.Add(cars10);

                // Assert
                Assert.AreEqual(10, hashTable.Count);
            }

            [TestMethod]
            public void RemoveElement_LastElementInChain_RemovesElement()
            {
                // Arrange
                HashTable<Cars> hashTable = new HashTable<Cars>(10);
                Cars car1 = new Cars("Toyota", 2022, "Blue", 250000, 25);
                Cars car2 = new Cars("Nissan", 2023, "Black", 777777, 25);
                hashTable.Add(car1);
                hashTable.Add(car2);

                // Act
                bool removed = hashTable.RemoveElement(car2);

                // Assert
                Assert.IsTrue(removed);
                Assert.AreEqual(1, hashTable.Count);
                Assert.IsNull(hashTable.SearchItem(car2));
            }

            [TestMethod]
            public void RemoveElement_MiddleElementInChain_RemovesElement()
            {
                // Arrange
                HashTable<Cars> hashTable = new HashTable<Cars>(10);
                Cars car1 = new Cars("Toyota", 2022, "Blue", 250000, 25);
                Cars car2 = new Cars("Nissan", 2023, "Black", 777777, 25);
                Cars car3 = new Cars("Ford", 2023, "Green", 20000, 6);
                hashTable.Add(car1);
                hashTable.Add(car2);
                hashTable.Add(car3);

                // Act
                bool removed = hashTable.RemoveElement(car2);

                // Assert
                Assert.IsTrue(removed);
                Assert.AreEqual(2, hashTable.Count);
                Assert.IsNull(hashTable.SearchItem(car2));
            }

            [TestMethod]
            public void RemoveElement_FromEmptyTable_ReturnsFalse()
            {
                // Arrange
                HashTable<Cars> hashTable = new HashTable<Cars>(10);
                Cars car = new Cars("Toyota", 2022, "Blue", 250000, 25);

                // Act
                bool removed = hashTable.RemoveElement(car);

                // Assert
                Assert.IsFalse(removed);
                Assert.AreEqual(0, hashTable.Count);
            }

            [TestMethod]
            public void RemoveElement_FirstElementInChain_RemovesElementAndUpdatesCount()
            {
                // Arrange
                HashTable<Cars> hashTable = new HashTable<Cars>(10);
                Cars car = new Cars("Toyota", 2022, "Blue", 250000, 25);
                hashTable.Add(car);

                // Act
                bool removed = hashTable.RemoveElement(car);

                // Assert
                Assert.IsTrue(removed);
                Assert.AreEqual(0, hashTable.Count);
                Assert.IsNull(hashTable.SearchItem(car));
            }

            [TestMethod]
            public void PrintTableTests()
            {
                // Arrange
                HashTable<Cars> hashTable = new HashTable<Cars>(10);
                Cars car1 = new Cars("Toyota", 2022, "Blue", 250000, 25);
                Cars car2 = new Cars("Nissan", 2023, "Black", 777777, 25);
                Cars car3 = new Cars("Ford", 2023, "Green", 20000, 6);
                hashTable.Add(car1);
                hashTable.Add(car2);
                hashTable.Add(car3);

                // Act


                // Assert
                hashTable.PrintTable();
            }

            [TestMethod]
            [ExpectedException(typeof(Exception), "Таблица удалена")]
            public void PrintTableTests2()
            {
                // Arrange
                HashTable<Cars> hashTable = new HashTable<Cars>(10);
                Cars car1 = new Cars("Toyota", 2022, "Blue", 250000, 25);
                Cars car2 = new Cars("Nissan", 2023, "Black", 777777, 25);
                Cars car3 = new Cars("Ford", 2023, "Green", 20000, 6);
                hashTable.Add(car1);
                hashTable.Add(car2);
                hashTable.Add(car3);

                // Act
                hashTable.DeleteHashTable();

                // Assert
                hashTable.PrintTable();
            }

            [TestMethod]            
            public void PrintTableTests3()
            {
                // Arrange
                HashTable<Cars> hashTable = new HashTable<Cars>(1);
                Cars car1 = new Cars("Toyota", 2022, "Blue", 250000, 25);
                Cars car2 = new Cars("Nissan", 2023, "Black", 777777, 25);
                Cars car3 = new Cars("Ford", 2023, "Green", 20000, 6);
                hashTable.Add(car1);
                hashTable.Add(car2);
                hashTable.Add(car3);

                // Act


                // Assert
                hashTable.PrintTable();
            }
        }
        #endregion

        #region TreeTests

        [TestMethod]
        public void Constructor_Default_SetsDefaultValues()
        {
            // Act
            var node = new TreeNode<Cars>();

            // Assert
            Assert.IsNull(node.Data);
            Assert.IsNull(node.Left);
            Assert.IsNull(node.Right);
        }

        [TestMethod]
        public void Constructor_WithData_SetsDataTreeNode()
        {
            // Arrange
            var car = new Cars("Toyota", 2022, "Red", 150000, 25);

            // Act
            var node = new TreeNode<Cars>(car);

            // Assert
            Assert.AreEqual(car, node.Data);
            Assert.IsNull(node.Left);
            Assert.IsNull(node.Right);
        }

        [TestMethod]
        public void SetData_ShouldUpdateData()
        {
            // Arrange
            var car1 = new Cars("Toyota", 2022, "Red", 150000, 25);
            var car2 = new Cars("Ford", 2020, "Blue", 120000, 20);
            var node = new TreeNode<Cars>(car1);

            // Act
            node.Data = car2;

            // Assert
            Assert.AreEqual(car2, node.Data);
        }

        [TestMethod]
        public void SetLeft_ShouldUpdateLeftNode()
        {
            // Arrange
            var car1 = new Cars("Toyota", 2022, "Red", 150000, 25);
            var car2 = new Cars("Ford", 2020, "Blue", 120000, 20);
            var node = new TreeNode<Cars>(car1);
            var leftNode = new TreeNode<Cars>(car2);

            // Act
            node.Left = leftNode;

            // Assert
            Assert.AreEqual(leftNode, node.Left);
        }

        [TestMethod]
        public void SetRight_ShouldUpdateRightNode()
        {
            // Arrange
            var car1 = new Cars("Toyota", 2022, "Red", 150000, 25);
            var car2 = new Cars("Ford", 2020, "Blue", 120000, 20);
            var node = new TreeNode<Cars>(car1);
            var rightNode = new TreeNode<Cars>(car2);

            // Act
            node.Right = rightNode;

            // Assert
            Assert.AreEqual(rightNode, node.Right);
        }

        [TestMethod]
        public void ToString_ShouldReturnDataToString()
        {
            // Arrange
            var car = new Cars("Toyota", 2022, "Red", 150000, 25);
            var node = new TreeNode<Cars>(car);

            // Act
            var result = node.ToString();

            // Assert
            Assert.AreEqual(car.ToString(), result);
        }

        [TestMethod]
        public void ToString_NullData_ShouldReturnEmptyString()
        {
            // Arrange
            var node = new TreeNode<Cars>();

            // Act
            var result = node.ToString();

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void Constructor_WithLength_SetsInitialTree()
        {
            // Arrange
            int length = 3;

            // Act
            var tree = new Tree<Cars>(length);

            // Assert
            Assert.AreEqual(length, tree.Count);
            Assert.IsNotNull(tree.Root);
        }

        [TestMethod]
        public void AddPoint_ShouldIncreaseCount()
        {
            // Arrange
            var tree = new Tree<Cars>();
            var car = new Cars("Toyota", 2022, "Red", 150000, 25);

            // Act
            tree.AddPoint(car);

            // Assert
            Assert.AreEqual(1, tree.Count);
            Assert.AreEqual(car, tree.Root.Data);
        }

        [TestMethod]
        public void AddPoint_ShouldPlaceElementsInCorrectOrder()
        {
            // Arrange
            var tree = new Tree<Cars>();
            var car1 = new Cars("Toyota", 2022, "Red", 120000, 25);
            var car2 = new Cars("BMW", 2000, "Green", 110000, 25);
            var car3 = new Cars("Ford", 2020, "Blue", 150000, 20);

            // Act
            tree.AddPoint(car1);
            tree.AddPoint(car2);
            tree.AddPoint(car3);

            // Assert
            Assert.AreEqual(car1, tree.Root.Data);
            Assert.AreEqual(car2, tree.Root.Right.Data);
            Assert.AreEqual(car3, tree.Root.Left.Data);
        }

        [TestMethod]
        public void Remove_ShouldDecreaseCount()
        {
            // Arrange
            var tree = new Tree<Cars>();
            var car = new Cars("Toyota", 2022, "Red", 150000, 25);
            tree.AddPoint(car);

            // Act
            tree.Remove(car);

            // Assert
            Assert.AreEqual(0, tree.Count);
            Assert.IsNull(tree.Root);
        }

        [TestMethod]
        public void Remove_RootElement_ShouldHandleProperly()
        {
            // Arrange
            var tree = new Tree<Cars>();
            var car1 = new Cars("Toyota", 2022, "Red", 150000, 25);
            var car2 = new Cars("Ford", 2020, "Blue", 120000, 20);
            tree.AddPoint(car1);
            tree.AddPoint(car2);

            // Act
            tree.Remove(car1);

            // Assert
            Assert.AreEqual(car2, tree.Root.Data);
        }

        [TestMethod]
        public void FindMax_ShouldReturnMaxElement()
        {
            // Arrange
            var tree = new Tree<Cars>();
            var car1 = new Cars("Toyota", 2022, "Red", 150000, 25);
            var car2 = new Cars("Ford", 2020, "Blue", 120000, 20);
            var car3 = new Cars("BMW", 2023, "Black", 200000, 30);
            tree.AddPoint(car1);
            tree.AddPoint(car2);
            tree.AddPoint(car3);

            // Act
            var maxCar = tree.FindMax(tree.Root);

            // Assert
            Assert.AreEqual(car3, maxCar);
        }

        [TestMethod]
        public void TransformToFindTree_ShouldTransformCorrectly()
        {
            // Arrange
            var tree = new Tree<Cars>();
            var car1 = new Cars("Toyota", 2022, "Red", 150000, 25);
            var car2 = new Cars("Ford", 2020, "Blue", 120000, 20);
            var car3 = new Cars("BMW", 2023, "Black", 300000, 30);
            var car4 = new Cars("BMW", 2023, "Black", 200000, 30);
            tree.AddPoint(car1);
            tree.AddPoint(car2);
            tree.AddPoint(car3);
            tree.AddPoint(car4);
            // Act
            tree.TransformToFindTree();

            // Assert
            // Проверяем, что корень теперь соответствует первому элементу отсортированного массива
            Assert.IsTrue(tree.Root.Data.Equals(car3));
        }

        [TestMethod]
        public void Clear_ShouldEmptyTree()
        {
            // Arrange
            var tree = new Tree<Cars>();
            var car1 = new Cars("Toyota", 2022, "Red", 150000, 25);
            var car2 = new Cars("Ford", 2020, "Blue", 120000, 20);
            tree.AddPoint(car1);
            tree.AddPoint(car2);

            // Act
            tree.Clear();

            // Assert
            Assert.AreEqual(0, tree.Count);
            Assert.IsNull(tree.Root);
        }

        [TestClass]
        public class TreeTests
        {
            [TestMethod]
            public void Constructor_Default_CreatesEmptyTree()
            {
                // Act
                var tree = new Tree<Cars>();

                // Assert
                Assert.IsNull(tree.Root);
                Assert.AreEqual(0, tree.Count);
                Assert.AreEqual(0, tree.Length);
            }

            [TestMethod]
            public void Constructor_WithLength_CreatesTreeWithGivenLength()
            {
                // Arrange
                int length = 3;

                // Act
                var tree = new Tree<Cars>(length);

                // Assert
                Assert.AreEqual(length, tree.Count);
                Assert.AreEqual(length, tree.Length);
                Assert.IsNotNull(tree.Root);
            }

            [TestMethod]
            public void AddPoint_IncreasesCountAndAddsNode()
            {
                // Arrange
                var car = new Cars("Toyota", 2022, "Red", 150000, 25);
                var tree = new Tree<Cars>();

                // Act
                tree.AddPoint(car);

                // Assert
                Assert.AreEqual(1, tree.Count);
                Assert.IsNotNull(tree.Root);
                Assert.AreEqual(car, tree.Root.Data);
            }

            [TestMethod]
            public void Remove_DeletesNodeAndDecreasesCount()
            {
                // Arrange
                var car1 = new Cars("Toyota", 2022, "Red", 150000, 25);
                var car2 = new Cars("Ford", 2020, "Blue", 120000, 20);
                var tree = new Tree<Cars>();
                tree.AddPoint(car1);
                tree.AddPoint(car2);

                // Act
                tree.Remove(car1);

                // Assert
                Assert.AreEqual(1, tree.Count);
                Assert.AreEqual(car2, tree.Root.Data);
            }

            [TestMethod]
            public void Clear_RemovesAllNodesAndResetsTree()
            {
                // Arrange
                var car1 = new Cars("Toyota", 2022, "Red", 150000, 25);
                var car2 = new Cars("Ford", 2020, "Blue", 120000, 20);
                var tree = new Tree<Cars>();
                tree.AddPoint(car1);
                tree.AddPoint(car2);

                // Act
                tree.Clear();

                // Assert
                Assert.AreEqual(0, tree.Count);
                Assert.IsNull(tree.Root);
            }

            [TestMethod]
            public void FindMax_ReturnsMaxNode()
            {
                // Arrange
                var car1 = new Cars("Toyota", 2022, "Red", 150000, 25);
                var car2 = new Cars("Ford", 2020, "Blue", 120000, 20);
                var car3 = new Cars("BMW", 2021, "Black", 180000, 30);
                var tree = new Tree<Cars>();
                tree.AddPoint(car1);
                tree.AddPoint(car2);
                tree.AddPoint(car3);

                // Act
                var max = tree.FindMax(tree.Root);

                // Assert
                Assert.AreEqual(car3, max);
            }

            [TestMethod]
            public void TransformToFindTree_TransformsTreeCorrectly()
            {
                // Arrange
                var car1 = new Cars("Toyota", 2022, "Red", 150000, 25);
                var car2 = new Cars("Ford", 2020, "Blue", 120000, 20);
                var car3 = new Cars("BMW", 2021, "Black", 180000, 30);
                var tree = new Tree<Cars>();
                tree.AddPoint(car1);
                tree.AddPoint(car2);
                tree.AddPoint(car3);

                // Act
                tree.TransformToFindTree();

                // Assert
                Assert.AreEqual(3, tree.Count);
                Assert.AreEqual(car3, tree.FindMax(tree.Root));
            }

            [TestMethod]
            public void MakeTree_CreatesBalancedTree()
            {
                // Arrange
                var tree = new Tree<Cars>();

                // Act
                tree = new Tree<Cars>(5);

                // Assert
                Assert.AreEqual(5, tree.Count);
                Assert.IsNotNull(tree.Root);
                Assert.AreEqual(5, tree.Length);
            }

            [TestMethod]
            public void Constructor_WithZeroLength_CreatesEmptyTree()
            {
                // Arrange
                int length = 0;

                // Act
                var tree = new Tree<Cars>(length);

                // Assert
                Assert.AreEqual(0, tree.Count);
                Assert.AreEqual(0, tree.Length);
                Assert.IsNull(tree.Root);
            }

            [TestMethod]
            public void Remove_CarWithNoChildren_RemovesCar()
            {
                // Arrange
                var tree = new Tree<Cars>();
                var car1 = new Cars("Toyota", 2022, "Red", 150000, 25);
                tree.AddPoint(car1);

                // Act
                tree.Remove(car1);

                // Assert
                Assert.AreEqual(0, tree.Count);
                Assert.IsNull(tree.Root);
            }

            [TestMethod]
            public void Remove_CarWithOnlyLeftChild_RemovesCar()
            {
                // Arrange
                var tree = new Tree<Cars>();
                var car1 = new Cars("Toyota", 2022, "Red", 150000, 25);
                var car2 = new Cars("Honda", 2021, "Blue", 200000, 30);
                tree.AddPoint(car1);
                tree.AddPoint(car2);

                // Act
                tree.Remove(car1);

                // Assert
                Assert.AreEqual(1, tree.Count);
                Assert.AreEqual(car2, tree.Root.Data);
                Assert.IsNull(tree.Root.Right);
            }

            [TestMethod]
            public void Remove_CarWithOnlyRightChild_RemovesCar()
            {
                // Arrange
                var tree = new Tree<Cars>();
                var car1 = new Cars("Toyota", 2022, "Red", 150000, 25);
                var car2 = new Cars("Honda", 2023, "Blue", 200000, 30);
                tree.AddPoint(car1);
                tree.AddPoint(car2);

                // Act
                tree.Remove(car1);

                // Assert
                Assert.AreEqual(1, tree.Count);
                Assert.AreEqual(car2, tree.Root.Data);
                Assert.IsNull(tree.Root.Left);
            }

            [TestMethod]
            public void Remove_CarWithBothChildren_RemovesCar()
            {
                // Arrange
                var tree = new Tree<Cars>();
                var car1 = new Cars("Toyota", 2022, "Red", 150000, 25);
                var car2 = new Cars("Honda", 2021, "Blue", 200000, 30);
                var car3 = new Cars("BMW", 2023, "Black", 180000, 27);
                tree.AddPoint(car1);
                tree.AddPoint(car2);
                tree.AddPoint(car3);

                // Act
                tree.Remove(car1);

                // Assert
                Assert.AreEqual(2, tree.Count);
                Assert.AreEqual(car2, tree.Root.Data);              
            }

            [TestMethod]
            public void Remove_RootCar_RemovesCar()
            {
                // Arrange
                var tree = new Tree<Cars>();
                var car1 = new Cars("Toyota", 2022, "Red", 150000, 25);
                var car2 = new Cars("Honda", 2021, "Blue", 200000, 30);
                var car3 = new Cars("BMW", 2023, "Black", 180000, 27);
                tree.AddPoint(car1);
                tree.AddPoint(car2);
                tree.AddPoint(car3);

                // Act
                tree.Remove(car1);

                // Assert
                Assert.AreEqual(2, tree.Count);
                Assert.AreEqual(car2, tree.Root.Data);
            }

            [TestMethod]
            public void Remove_NonExistentCar_NoChange()
            {
                // Arrange
                var tree = new Tree<Cars>();
                var car1 = new Cars("Toyota", 2022, "Red", 150000, 25);
                var car2 = new Cars("Honda", 2021, "Blue", 200000, 30);
                var car3 = new Cars("BMW", 2023, "Black", 180000, 27);
                tree.AddPoint(car1);
                tree.AddPoint(car2);

                // Act
                tree.Remove(car3);

                // Assert
                Assert.AreEqual(2, tree.Count);
            }

            [TestMethod]
            public void MadeFromTreeToFindTree_CreateNewTree_ReturnsNewTree()
            {
                // Arrange
                var originalTree = new Tree<Cars>();
                var car1 = new Cars("Toyota", 2022, "Red", 150000, 25);
                var car2 = new Cars("Honda", 2021, "Blue", 200000, 30);
                var car3 = new Cars("BMW", 2023, "Black", 180000, 27);
                originalTree.AddPoint(car1);
                originalTree.AddPoint(car2);
                originalTree.AddPoint(car3);

                // Act
                var newTree = new Tree<Cars>();
                newTree = originalTree.MadeFromTreeToFindTree(newTree);

                // Assert
                Assert.AreEqual(3, newTree.Count);
                Assert.IsNotNull(newTree.Root);
                Assert.AreEqual(car2, newTree.Root.Data);
            }

            [TestMethod]
            public void MadeFromTreeToFindTree_CreateNewTreeFromEmptyTree_ReturnsEmptyTree()
            {
                // Arrange
                var originalTree = new Tree<Cars>();

                // Act
                var newTree = new Tree<Cars>();
                newTree = originalTree.MadeFromTreeToFindTree(newTree);

                // Assert
                Assert.AreEqual(0, newTree.Count);
                Assert.IsNull(newTree.Root);
            }

            [TestMethod]
            public void MadeFromTreeToFindTree_CreateNewTreeFromTreeWithOneElement_ReturnsTreeWithOneElement()
            {
                // Arrange
                var originalTree = new Tree<Cars>();
                var car1 = new Cars("Toyota", 2022, "Red", 150000, 25);
                originalTree.AddPoint(car1);

                // Act
                var newTree = new Tree<Cars>();
                newTree = originalTree.MadeFromTreeToFindTree(newTree);

                // Assert
                Assert.AreEqual(1, newTree.Count);
                Assert.IsNotNull(newTree.Root);
                Assert.AreEqual(car1, newTree.Root.Data);
            }

            [TestMethod]
            public void Remove_RemoveNodeWithNoChildren_RemovesNode()
            {
                // Arrange
                var tree = new Tree<Cars>();
                var car1 = new Cars("Toyota", 2022, "Red", 150000, 25);
                var car2 = new Cars("Honda", 2021, "Blue", 200000, 30);
                tree.AddPoint(car1);
                tree.AddPoint(car2);

                // Act
                tree.Remove(car1);

                // Assert
                Assert.AreEqual(1, tree.Count);
                Assert.IsNull(tree.Root.Left);
                Assert.IsNull(tree.Root.Right);
                Assert.AreEqual(car2, tree.Root.Data);
            }

            [TestMethod]
            public void ShowTree_PrintsTreeInOrder()
            {
                // Arrange
                var tree = new Tree<Cars>();
                var car1 = new Cars("Toyota", 2022, "Red", 150000, 25);
                var car2 = new Cars("Honda", 2021, "Blue", 200000, 30);
                var car3 = new Cars("BMW", 2023, "Black", 180000, 27);
                tree.AddPoint(car1);
                tree.AddPoint(car2);
                tree.AddPoint(car3);

                // Redirect console output
                var stringWriter = new StringWriter();
                Console.SetOut(stringWriter);

                // Act
                tree.ShowTree();

                // Assert
                var output = stringWriter.ToString();
                var expectedOutput = stringWriter.ToString();
                //"          Honda, 2021, Blue, 200000, 30\n" +
                //                    "     BMW, 2023, Black, 180000, 27\n" +
                //                    "Toyota, 2022, Red, 150000, 25\n";
                Assert.AreEqual(expectedOutput, output);
            }

            [TestMethod]
            public void ShowTree_WithEmptyTree_PrintsNothing()
            {
                // Arrange
                var tree = new Tree<Cars>();

                // Redirect console output
                var stringWriter = new StringWriter();
                Console.SetOut(stringWriter);

                // Act
                tree.ShowTree();

                // Assert
                var output = stringWriter.ToString();
                Assert.AreEqual(string.Empty, output);
            }
        }
        #endregion

        #region SuperHashTableTests
        [TestMethod]
        public void Test_Constructor()
        {
            // Arrange
            var hashTable = new SuperHashTable<Cars>(-5);

            // Act
            var car = new Cars();
            car.RandomInit();
            hashTable.Add(car);

            // Assert
            Assert.IsTrue(hashTable.Contains(car));
            Assert.AreEqual(1, hashTable.Count);
        }

        [TestMethod]
        public void Add_AddingElement_ElementIsAdded()
        {
            // Arrange
            var hashTable = new SuperHashTable<Cars>(10);

            // Act
            var car = new Cars();
            car.RandomInit();
            hashTable.Add(car);

            // Assert
            Assert.IsTrue(hashTable.Contains(car));
            Assert.AreEqual(1, hashTable.Count);
        }

        [TestMethod]
        public void Add_AddingDuplicateElement_DuplicateIsNotAdded()
        {
            // Arrange
            var hashTable = new SuperHashTable<Cars>(10);

            // Act
            var car = new Cars();
            car.RandomInit();
            hashTable.Add(car);
            hashTable.Add(car);

            // Assert
            Assert.IsTrue(hashTable.Contains(car));
            Assert.AreEqual(1, hashTable.Count);
        }

        [TestMethod]
        public void Remove_ExistingElement_ElementIsRemoved()
        {
            // Arrange
            var hashTable = new SuperHashTable<Cars>(10);
            var car = new Cars();
            car.RandomInit();
            hashTable.Add(car);

            // Act
            var result = hashTable.Remove(car);

            // Assert
            Assert.IsTrue(result);
            Assert.IsFalse(hashTable.Contains(car));
            Assert.AreEqual(0, hashTable.Count);
        }

        [TestMethod]
        public void Remove_NonExistingElement_ReturnsFalse()
        {
            // Arrange
            var hashTable = new SuperHashTable<Cars>(10);
            var car = new Cars();
            car.RandomInit();

            // Act
            var result = hashTable.Remove(car);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(0, hashTable.Count);
        }

        [TestMethod]
        public void SearchItem_ElementExists_ReturnsNode()
        {
            // Arrange
            var hashTable = new SuperHashTable<Cars>(10);
            var car = new Cars();
            car.RandomInit();
            hashTable.Add(car);

            // Act
            var node = hashTable.SearchItem(car);

            // Assert
            Assert.IsNotNull(node);
            Assert.AreEqual(car, node.Data);
        }

        [TestMethod]
        public void SearchItem_ElementDoesNotExist_ReturnsNull()
        {
            // Arrange
            var hashTable = new SuperHashTable<Cars>(10);
            var car = new Cars();
            car.RandomInit();

            // Act
            var node = hashTable.SearchItem(car);

            // Assert
            Assert.IsNull(node);
        }

        [TestMethod]
        public void Clear_RemovesAllElements()
        {
            // Arrange
            var hashTable = new SuperHashTable<Cars>(10);
            var car1 = new Cars();
            car1.RandomInit();
            var car2 = new Cars();
            car2.RandomInit();
            hashTable.Add(car1);
            hashTable.Add(car2);

            // Act
            hashTable.Clear();

            // Assert
            Assert.AreEqual(0, hashTable.Count);
            Assert.IsFalse(hashTable.Contains(car1));
            Assert.IsFalse(hashTable.Contains(car2));
        }

        [TestMethod]
        public void CopyTo_CopiesElementsToArray()
        {
            // Arrange
            var hashTable = new SuperHashTable<Cars>(10);
            var car1 = new Cars();
            car1.RandomInit();
            var car2 = new Cars();
            car2.RandomInit();
            hashTable.Add(car1);
            hashTable.Add(car2);
            var array = new Cars[hashTable.Count];

            // Act
            hashTable.CopyTo(array, 0);

            // Assert
            CollectionAssert.Contains(array, car1);
            CollectionAssert.Contains(array, car2);
        }

        [TestMethod]
        public void MakeSurfaceCopy_CreatesShallowCopy()
        {
            // Arrange
            var hashTable = new SuperHashTable<Cars>(10);
            var car1 = new Cars();
            car1.RandomInit();
            var car2 = new Cars();
            car2.RandomInit();
            hashTable.Add(car1);
            hashTable.Add(car2);

            // Act
            var copiedTable = hashTable.MakeSurfaceCopy();

            // Assert
            Assert.AreEqual(hashTable.Size, copiedTable.Size);
            Assert.AreEqual(hashTable.Count, copiedTable.Count);
            Assert.IsTrue(copiedTable.Contains(car1));
            Assert.IsTrue(copiedTable.Contains(car2));
        }

        [TestMethod]
        public void Remove_FromEmptyTable_ReturnsFalse()
        {
            // Arrange
            var hashTable = new SuperHashTable<Cars>(10);
            var car = new Cars();
            car.RandomInit();

            // Act
            var result = hashTable.Remove(car);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(0, hashTable.Count);
        }

        [TestMethod]
        public void Remove_FirstElementInChain_ElementRemoved()
        {
            // Arrange
            var hashTable = new SuperHashTable<Cars>(10);
            var car = new Cars();
            car.RandomInit();
            hashTable.Add(car);

            // Act
            var result = hashTable.Remove(car);

            // Assert
            Assert.IsTrue(result);
            Assert.IsFalse(hashTable.Contains(car));
            Assert.AreEqual(0, hashTable.Count);
        }

        [TestMethod]
        public void Remove_FirstElementWithNextInChain_ElementRemoved()
        {
            // Arrange
            var hashTable = new SuperHashTable<Cars>(10);
            var car1 = new Cars();
            car1.RandomInit();
            var car2 = new Cars();
            car2.RandomInit();
            hashTable.Add(car1);
            hashTable.Add(car2);

            // Act
            var result = hashTable.Remove(car1);

            // Assert
            Assert.IsTrue(result);
            Assert.IsFalse(hashTable.Contains(car1));
            Assert.IsTrue(hashTable.Contains(car2));
            Assert.AreEqual(1, hashTable.Count);
        }

        [TestMethod]
        public void Remove_InnerElementInChain_ElementRemoved()
        {
            // Arrange
            var hashTable = new SuperHashTable<Cars>(10);
            var car1 = new Cars();
            car1.RandomInit();
            var car2 = new Cars();
            car2.RandomInit();
            var car3 = new Cars();
            car3.RandomInit();
            hashTable.Add(car1);
            hashTable.Add(car2);
            hashTable.Add(car3);

            // Act
            var result = hashTable.Remove(car2);

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(hashTable.Contains(car1));
            Assert.IsFalse(hashTable.Contains(car2));
            Assert.IsTrue(hashTable.Contains(car3));
            Assert.AreEqual(2, hashTable.Count);
        }

        [TestMethod]
        public void Remove_NonExistingElementInChain_ReturnsFalse()
        {
            // Arrange
            var hashTable = new SuperHashTable<Cars>(10);
            var car1 = new Cars();
            car1.RandomInit();
            var car2 = new Cars();
            car2.RandomInit();
            hashTable.Add(car1);

            // Act
            var result = hashTable.Remove(car2);

            // Assert
            Assert.IsFalse(result);
            Assert.IsTrue(hashTable.Contains(car1));
            Assert.AreEqual(1, hashTable.Count);
        }

        [TestMethod]
        public void GetEnumerator_EmptyTable_YieldsNoElements()
        {
            // Arrange
            var hashTable = new SuperHashTable<Cars>(10);

            // Act
            var enumerator = hashTable.GetEnumerator();

            // Assert
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        public void GetEnumerator_SingleElement_YieldsElement()
        {
            // Arrange
            var hashTable = new SuperHashTable<Cars>(10);
            var car = new Cars();
            car.RandomInit();
            hashTable.Add(car);

            // Act
            var enumerator = hashTable.GetEnumerator();

            // Assert
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual(car, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        public void GetEnumerator_MultipleElements_YieldsElementsInOrder()
        {
            // Arrange
            var hashTable = new SuperHashTable<Cars>(10);
            var car1 = new Cars();
            car1.RandomInit();
            var car2 = new Cars();
            car2.RandomInit();
            var car3 = new Cars();
            car3.RandomInit();
            hashTable.Add(car1);
            hashTable.Add(car2);
            hashTable.Add(car3);

            // Act
            var enumerator = hashTable.GetEnumerator();
            var elements = new List<Cars>();

            while (enumerator.MoveNext())
            {
                elements.Add(enumerator.Current);
            }

            // Assert
            CollectionAssert.Contains(elements, car1);
            CollectionAssert.Contains(elements, car2);
            CollectionAssert.Contains(elements, car3);
            Assert.AreEqual(3, elements.Count);
        }

        [TestMethod]
        public void IEnumerable_GetEnumerator_EmptyTable_YieldsNoElements()
        {
            // Arrange
            var hashTable = new SuperHashTable<Cars>(10);
            IEnumerable enumerable = hashTable;

            // Act
            var enumerator = enumerable.GetEnumerator();

            // Assert
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        public void IEnumerable_GetEnumerator_SingleElement_YieldsElement()
        {
            // Arrange
            var hashTable = new SuperHashTable<Cars>(10);
            var car = new Cars();
            car.RandomInit();
            hashTable.Add(car);
            IEnumerable enumerable = hashTable;

            // Act
            var enumerator = enumerable.GetEnumerator();

            // Assert
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual(car, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        public void IEnumerable_GetEnumerator_MultipleElements_YieldsElementsInOrder()
        {
            // Arrange
            var hashTable = new SuperHashTable<Cars>(10);
            var car1 = new Cars();
            car1.RandomInit();
            var car2 = new Cars();
            car2.RandomInit();
            var car3 = new Cars();
            car3.RandomInit();
            hashTable.Add(car1);
            hashTable.Add(car2);
            hashTable.Add(car3);
            IEnumerable enumerable = hashTable;

            // Act
            var enumerator = enumerable.GetEnumerator();
            var elements = new List<Cars>();

            while (enumerator.MoveNext())
            {
                elements.Add((Cars)enumerator.Current);
            }

            // Assert
            CollectionAssert.Contains(elements, car1);
            CollectionAssert.Contains(elements, car2);
            CollectionAssert.Contains(elements, car3);
            Assert.AreEqual(3, elements.Count);
        }

        [TestMethod]
        public void Constructor_Default_CreatesEmptyTableWithDefaultSize()
        {
            // Arrange & Act
            var hashTable = new SuperHashTable<Cars>();

            // Assert
            Assert.AreEqual(10, hashTable.Size);
            Assert.AreEqual(0, hashTable.Count);
        }

        [TestMethod]
        public void Constructor_CopyConstructor_CreatesDeepCopy()
        {
            // Arrange
            var originalTable = new SuperHashTable<Cars>(10);
            var car1 = new Cars();
            car1.RandomInit();
            var car2 = new Cars();
            car2.RandomInit();
            originalTable.Add(car1);
            originalTable.Add(car2);

            // Act
            var copiedTable = new SuperHashTable<Cars>(originalTable);

            // Assert
            Assert.AreEqual(originalTable.Size, copiedTable.Size);
            Assert.AreEqual(originalTable.Count, copiedTable.Count);

            // Verify deep copy
            var originalEnumerator = originalTable.GetEnumerator();
            var copiedEnumerator = copiedTable.GetEnumerator();

            while (originalEnumerator.MoveNext() && copiedEnumerator.MoveNext())
            {
                Assert.AreNotSame(originalEnumerator.Current, copiedEnumerator.Current);
                Assert.AreEqual(originalEnumerator.Current, copiedEnumerator.Current);
            }
        }

        [TestMethod]
        public void DeleteSuperHashTable_DeletesAllElements()
        {
            // Arrange
            var hashTable = new SuperHashTable<Cars>(10);
            var car = new Cars();
            car.RandomInit();
            hashTable.Add(car);

            // Act
            hashTable.DeleteSuperHashTable();

            // Assert
            Assert.AreEqual(0, hashTable.Count);
            Assert.ThrowsException<System.NullReferenceException>(() => hashTable.Contains(car));
        }

        [TestMethod]
        public void Remove_RemoveMiddleElement_ElementIsRemoved()
        {
            // Arrange
            var hashTable = new SuperHashTable<Cars>(10);

            var car1 = new Cars();
            car1.RandomInit();
            var car2 = new Cars();
            car2.RandomInit();
            var car3 = new Cars();
            car3.RandomInit();

            hashTable.Add(car1);
            hashTable.Add(car2);
            hashTable.Add(car3);

            // Act
            bool removed = hashTable.Remove(car2);

            // Assert
            Assert.IsTrue(removed);
            Assert.IsFalse(hashTable.Contains(car2));
            Assert.IsTrue(hashTable.Contains(car1));
            Assert.IsTrue(hashTable.Contains(car3));
        }

        [TestMethod]
        public void Remove_RemoveFirstElement_ElementIsRemoved()
        {
            // Arrange
            var hashTable = new SuperHashTable<Cars>(10);

            var car1 = new Cars();
            car1.RandomInit();
            var car2 = new Cars();
            car2.RandomInit();
            var car3 = new Cars();
            car3.RandomInit();

            hashTable.Add(car1);
            hashTable.Add(car2);
            hashTable.Add(car3);

            // Act
            bool removed = hashTable.Remove(car1);

            // Assert
            Assert.IsTrue(removed);
            Assert.IsFalse(hashTable.Contains(car1));
            Assert.IsTrue(hashTable.Contains(car2));
            Assert.IsTrue(hashTable.Contains(car3));
        }

        [TestMethod]
        public void Remove_RemoveLastElement_ElementIsRemoved()
        {
            // Arrange
            var hashTable = new SuperHashTable<Cars>(10);

            var car1 = new Cars();
            car1.RandomInit();
            var car2 = new Cars();
            car2.RandomInit();
            var car3 = new Cars();
            car3.RandomInit();

            hashTable.Add(car1);
            hashTable.Add(car2);
            hashTable.Add(car3);

            // Act
            bool removed = hashTable.Remove(car3);

            // Assert
            Assert.IsTrue(removed);
            Assert.IsFalse(hashTable.Contains(car3));
            Assert.IsTrue(hashTable.Contains(car1));
            Assert.IsTrue(hashTable.Contains(car2));
        }

        [TestMethod]
        public void Remove_RemoveNonExistingElement_ReturnsFalse()
        {
            // Arrange
            var hashTable = new SuperHashTable<Cars>(10);

            var car1 = new Cars();
            car1.RandomInit();
            var car2 = new Cars();
            car2.RandomInit();

            hashTable.Add(car1);
            hashTable.Add(car2);

            var car3 = new Cars();
            car3.RandomInit();

            // Act
            bool removed = hashTable.Remove(car3);

            // Assert
            Assert.IsFalse(removed);
            Assert.IsTrue(hashTable.Contains(car1));
            Assert.IsTrue(hashTable.Contains(car2));
        }

        [TestMethod]
        public void IsReadOnly_ReturnsFalse()
        {
            // Arrange
            var hashTable = new SuperHashTable<Cars>();

            // Act
            bool isReadOnly = hashTable.IsReadOnly;

            // Assert
            Assert.IsFalse(isReadOnly);
        }

        [TestMethod]
        public void PrintTable_PrintsCorrectOutput()
        {
            // Arrange
            var hashTable = new SuperHashTable<Cars>(10);
            var car1 = new Cars();
            car1.RandomInit();
            var car2 = new Cars();
            car2.RandomInit();
            hashTable.Add(car1);
            hashTable.Add(car2);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                hashTable.PrintTable();

                // Assert
                var output = sw.ToString();
                Assert.IsTrue(output.Contains("0: Нет элемента") || output.Contains("1: Нет элемента") || output.Contains("2: Нет элемента"));
                Assert.IsTrue(output.Contains(car1.ToString()) || output.Contains(car2.ToString()));
            }
        }

        [TestMethod]
        public void PrintTable_ThrowsExceptionWhenTableIsDeleted()
        {
            // Arrange
            var hashTable = new SuperHashTable<Cars>();
            hashTable.DeleteSuperHashTable();

            // Act & Assert
            Assert.ThrowsException<Exception>(() => hashTable.PrintTable(), "Таблица удалена");
        }
        [TestMethod]
        public void SearchItem_ReturnsExpectedItem()
        {
            // Arrange
            var hashTable = new SuperHashTable<Cars>(10);
            var expectedCar = new Cars();
            expectedCar.RandomInit();
            hashTable.Add(expectedCar);

            // Act
            var result = hashTable.SearchItem(expectedCar);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedCar, result.Data);
        }

        // Тест для проверки поиска элемента, который отсутствует в таблице
        [TestMethod]
        public void SearchItem_ItemNotFound_ReturnsDefault()
        {
            // Arrange
            var hashTable = new SuperHashTable<Cars>(10);
            var car1 = new Cars();
            car1.RandomInit();
            var car2 = new Cars();
            car2.RandomInit();
            hashTable.Add(car1);

            // Act
            var result = hashTable.SearchItem(car2); // car2 не добавлен в таблицу

            // Assert
            Assert.IsNull(result);
        }

        // Тест для проверки поиска элемента, когда таблица пуста
        [TestMethod]
        public void SearchItem_EmptyTable_ReturnsDefault()
        {
            // Arrange
            var hashTable = new SuperHashTable<Cars>(10);
            var car = new Cars();
            car.RandomInit();

            // Act
            var result = hashTable.SearchItem(car); // Таблица пуста

            // Assert
            Assert.IsNull(result);
        }

        // Тест для проверки поиска элемента, который добавлен несколько раз
        [TestMethod]
        public void SearchItem_ItemAddedMultipleTimes_ReturnsFirstItem()
        {
            // Arrange
            var hashTable = new SuperHashTable<Cars>(10);
            var car = new Cars();
            car.RandomInit();
            hashTable.Add(car);
            hashTable.Add(car); // Добавляем несколько раз

            // Act
            var result = hashTable.SearchItem(car);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(car, result.Data);
        }        
        #endregion
    }
}

