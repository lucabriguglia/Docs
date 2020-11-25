using System;
using System.Collections.Generic;
using Docs.Attributes;
#pragma warning disable 1591

namespace Docs.Tests
{
    /// <summary>
    /// Description of SampleTarget.
    /// </summary>
    [DocTarget("Sample Context")]
    public class SampleTarget
    {
        /// <summary>
        /// Description of Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of constructor.
        /// </summary>
        public SampleTarget()
        {
        }

        /// <summary>
        /// Description of constructor with parameter.
        /// </summary>
        public SampleTarget(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Description of UpdateName method.
        /// </summary>
        public void UpdateName(string name)
        {
            Name = name;
        }
    }
}

namespace MyInsuranceCompany.Domain.Policies
{
    /// <summary>
    /// Description of Policy.
    /// </summary>
    [DocTarget("Products")]
    public class Policy
    {
        /// <summary>
        /// Description of Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of constructor.
        /// </summary>
        public Policy()
        {
        }

        /// <summary>
        /// Description of constructor with parameter.
        /// </summary>
        public Policy(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Description of UpdateName method.
        /// </summary>
        public void UpdateName(string name)
        {
            Name = name;
        }
    }
}

namespace MyBank.Bacs.Domain
{
    /// <summary>
    /// A Bacs Payment.
    /// </summary>
    [DocTarget("Bacs")]
    public class Payment
    {
        /// <summary>
        /// The unique identifier of the Payment.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The status of the payment.
        /// Can be either Initiated or Confirmation Received.
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// The amount of the transaction.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Creates a new Payment.
        /// A unique identifier is assigned automatically and the status is set to Initiated by default.
        /// </summary>
        public Payment(decimal amount)
        {
            Id = Guid.NewGuid();
            Status = Status.Initiated;

            Amount = amount;
        }

        /// <summary>
        /// Confirms that the Scheme has received the payment.
        /// </summary>
        public void ConfirmReceipt()
        {
            Status = Status.ConfirmationReceived;
        }
    }

    public enum Status
    {
        Initiated,
        ConfirmationReceived
    }
}

namespace MyBank.Bacs.Domain
{
    /// <summary>
    /// Creates a Bacs Payment.
    /// </summary>
    [DocRequest(typeof(Payment))]
    public class CreatePayment
    {
        /// <summary>
        /// The amount of the transaction.
        /// </summary>
        public decimal Amount { get; set; }
    }
}

namespace MyBank.Bacs.Domain
{
    /// <summary>
    /// Confirms that the Scheme has received the payment.
    /// </summary>
    [DocRequest(typeof(Payment))]
    public class ConfirmReceipt
    {
        /// <summary>
        /// The unique identifier of the Payment.
        /// </summary>
        public Guid PaymentId { get; set; }
    }
}

namespace MyGamePortal.Catalog.Domain
{
    /// <summary>
    /// A Game.
    /// </summary>
    [DocTarget("Catalog")]
    public class Game
    {
        /// <summary>
        /// The unique identifier of the Game.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The title of the Game.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The list of screenshots.
        /// </summary>
        public IList<string> Screenshots { get; set; }

        /// <summary>
        /// Creates a new Game.
        /// A unique identifier is assigned automatically and the list of screenshots is set to empty by default.
        /// </summary>
        public Game(string title)
        {
            Id = Guid.NewGuid();
            Screenshots = new List<string>();
            Title = title;
        }

        /// <summary>
        /// Adds screenshot to the collection.
        /// </summary>
        public void AddScreenshot(string screenshot)
        {
            Screenshots.Add(screenshot);
        }
    }
}

namespace MyGamePortal.Catalog.Domain
{
    /// <summary>
    /// Creates a new Game.
    /// </summary>
    [DocRequest(typeof(Game))]
    public class CreateGame
    {
        /// <summary>
        /// The title of the new Game.
        /// </summary>
        public string Title { get; set; }
    }
}

namespace MyGamePortal.Catalog.Domain
{
    /// <summary>
    /// Add a screenshot to an existing Game.
    /// </summary>
    [DocRequest(typeof(Game))]
    public class AddScreenshot
    {
        /// <summary>
        /// The unique identifier of the Game.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The path of the new screenshot.
        /// </summary>
        public string Screenshot { get; set; }
    }
}