namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        [Test]
        public void ConstructorShouldWorkProperlyWithProperties()
        {
            Book book = new Book("b1", "a1");
            Assert.AreEqual("b1", book.BookName);
            Assert.AreEqual("a1", book.Author);           
        }
        [Test]
        public void NullBookNamePropertyShouldThrowsAnException()
        {
            Assert.Throws<ArgumentException>(() => new Book(null, "a1"));
        }
        [Test]
        public void NullAuthorShouldThrowsAnException()
        {
            Assert.Throws<ArgumentException>(() => new Book("b1", ""));
        }
        [Test]
        public void AddFootnoteShouldWorkproperly()
        {
            Book book = new Book("b1", "a1");
            book.AddFootnote(5, "gosho");
            Assert.AreEqual(1, book.FootnoteCount);
        }
        [Test]
        public void AddFootnoteShouldThrowsAnExceptionWhenNumberIsAlreadyAdded()
        {
            Book book = new Book("b1", "a1");
            book.AddFootnote(5, "gosho");
            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(5, "gosho"));
        }
        [Test]
        public void FindFootnoteShouldWOrkProperly()
        {
            Book book = new Book("b1", "a1");
            book.AddFootnote(5, "gosho");            
            string output = "Footnote #5: gosho";
            Assert.AreEqual(output, book.FindFootnote(5));
        }
        [Test]
        public void FindFootnoteShouldThrowsAnExceptionWhenFootNoteDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(() => new Book("b1", "a1").FindFootnote(5));
        }
        [Test]
        public void AlterFootnoteShouldThrowsAnExceptionWhenFootNoteIsNotFound()
        {                    
            Assert.Throws<InvalidOperationException>(() => new Book("b1", "a1").AlterFootnote(6, "pesho"));
        }
        [Test]
        public void AlterFootnoteShouldWorkProperly()
        {
            Book book = new Book("b1", "a1");
            book.AddFootnote(5, "gosho");
            book.AlterFootnote(5, "pesho");
            string output = "Footnote #5: pesho";
            Assert.AreEqual(output, book.FindFootnote(5));
        }
    }
}