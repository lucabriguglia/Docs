using System;
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