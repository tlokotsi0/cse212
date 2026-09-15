using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities (e.g., A:1, B:5, C:3) and dequeue once.
    // Expected Result: The item with the highest priority ("B") is dequeued first.
    // Defect(s) Found: None
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("B", result);
    }

    [TestMethod]
    // Scenario: Enqueue items where multiple items share the highest priority (e.g., A:2, B:5, C:5, D:1).
    // Expected Result: 'B' should be dequeued before 'C' to preserve FIFO ordering.
    // Defect(s) Found: PriorityQueue uses >= instead of > during comparison, returning
    // the latest item added ('C') rather than the first item added ('B').
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 5);
        priorityQueue.Enqueue("D", 1);

        var first = priorityQueue.Dequeue();
        var second = priorityQueue.Dequeue();

        Assert.AreEqual("B", first);
        Assert.AreEqual("C", second);
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty PriorityQueue.
    // Expected Result: An InvalidOperationException is thrown.
    // Defect(s) Found: None if passed (or documents if an incorrect exception type was thrown).
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }
}