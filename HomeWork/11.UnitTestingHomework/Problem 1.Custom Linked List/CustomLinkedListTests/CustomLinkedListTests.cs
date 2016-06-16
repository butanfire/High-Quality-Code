using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomLinkedList;

namespace CustomLinkedListTests
{
    [TestClass]
    public class CustomLinkedListTests
    {
        private DynamicList<int> itemList;

        [TestInitialize]
        public void InitializeList()
        {
            itemList = new DynamicList<int>();
        }
        
        //Check count
        [TestMethod]
        public void Count_EmptyList_ReturnZeroForEmptyList()
        {
            Assert.AreEqual(0, this.itemList.Count, "Count is not initialized properly!");
        }
     
        //List Indexing
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Index_EmptyList_SetItemToInvalidIndex()
        {
            this.itemList[10] = 15;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Index_EmptyList_GetItemFromInvalidIndex()
        {
            this.itemList[10] = 15;
            var item = this.itemList[10];
            Assert.AreEqual(15, item, "Invalid number!");
        }

        [TestMethod]
        public void Index_NonEmptyList_SetItemCorrectlyViaIndex()
        {
            this.itemList.Add(5); //add an element
            this.itemList[0] = 10; //change an element
            Assert.AreEqual(10, this.itemList[0], "The requested element should be 10!");
        }

        [TestMethod]
        public void Index_NonEmptyList_GetItemCorrectlyViaIndex()
        {
            this.itemList.Add(10);
            var item = itemList[0];
            Assert.AreEqual(10, item, "The requested element should be 10!");
        }

        //AddItem
        [TestMethod]
        public void AddItem_EmptyList_AddItemToListAndCheckCount()
        {
            this.itemList.Add(10);
            Assert.AreEqual(1, itemList.Count, "The list does not contain 1 item!");
        }

        //RemoveAt
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAt_EmptyList_ThrowExceptionForInvalidItem()
        {
            this.itemList.RemoveAt(10);
        }

        [TestMethod]
        public void RemoveAt_NonEmptyList_RemoveAtIndexCorrectly()
        {
            //add two items and remove one of them
            this.itemList.Add(5);
            this.itemList.Add(10);
            this.itemList.RemoveAt(0);
            Assert.AreEqual(1, this.itemList.Count, "The RemoveAt is not working correctly!");
        }

        //Remove
        [TestMethod]
        public void Remove_EmptyList_ReturnMinus1ForInvalidItem()
        {
            int output = this.itemList.Remove(10);
            Assert.AreEqual(-1, output, "The remove did not return -1 for invalid item!");
        }

        [TestMethod]
        public void Remove_NonEmptyList_RemoveItemCorrectlyAndReturnIndex()
        {
            this.itemList.Add(10);
            this.itemList.Add(5);
            int output = this.itemList.Remove(5);
            Assert.AreEqual(1, output, "The index of the removed item is not correct!");
        }

        //IndexOf
        [TestMethod]
        public void IndexOf_EmptyList_ReturnMinu1ForInvalidItem()
        {
            int output = this.itemList.IndexOf(15);
            Assert.AreEqual(-1, output, "The indexOf operation did not return -1!");
        }

        [TestMethod]
        public void IndexOf_NonEmptyList_ReturnCorrectIndexForSearchedItem()
        {
            this.itemList.Add(30);
            this.itemList.Add(15);
            this.itemList.Add(10);
            int output = this.itemList.IndexOf(10);
            Assert.AreEqual(2, output, "The indexOf did not return the correct index!");
        }

        //Contains
        [TestMethod]
        public void Contains_EmptyList_ReturnFalseForSearchedItem()
        {            
            Assert.IsFalse(this.itemList.Contains(5),"The list should not contain any items!");
        }

        [TestMethod]
        public void Contains_NonEmptyList_ReturnTrueForSearchedItem()
        {
            this.itemList.Add(10);
            Assert.IsTrue(this.itemList.Contains(10),"The list should contain value of 10!");
        }

    }
}
