using System;
using System.Collections.Generic;
using System.Linq;

namespace com.GitHub.Reiqen.Task3
{
    class Lost
    {
        private class Person<T>
        {
            public readonly T item;
            public Person<T> next;

            public Person(T item)
            {
                this.item = item;
            }
        }
        private static Person<T> CreateCircularList<T>(IEnumerable<T> ie)
        {
            Person<T> firstNode = null;
            Person<T> previousNode = null;
            foreach (var item in ie)
            {
                var newNode = new Person<T>(item);
                if (firstNode == null)
                {
                    firstNode = newNode;
                }
                else
                {
                    previousNode.next = newNode;
                }
                previousNode = newNode;
            }
            previousNode.next = firstNode;
            return firstNode;
        }

        public static T RemoveEachSecondItem<T>(IEnumerable<T> ie)
        {
            var elementsCount = ie.Count();
            if (elementsCount == 0)
                throw new Exception("Empty ie");

            var firstNode = CreateCircularList(ie);
            var isOdd = false;
            var currentNode = firstNode;
            Person<T> previousNode = null;
            while (elementsCount > 1)
            {
                if (isOdd)
                {
                    previousNode.next = currentNode.next;
                    elementsCount--;
                }
                else
                {
                    previousNode = currentNode;
                }
                currentNode = currentNode.next;
                isOdd = !isOdd;
            }
            return currentNode.item;
        }
    }
}