﻿
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;       
        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
            this.books.OrderByDescending(x => x.Year);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private List<Book> books;
            private int currentIndex;
            public LibraryIterator(List<Book> books)
            {
                this.books = books;
                currentIndex = -1;
            }
            public Book Current => books[currentIndex];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }     

            public bool MoveNext()
            {
                currentIndex++;
                if (books.Count > currentIndex)
                    return true;
                return false;
            }

            public void Reset()
            {
                currentIndex = -1;
            }
        }
    }
}
