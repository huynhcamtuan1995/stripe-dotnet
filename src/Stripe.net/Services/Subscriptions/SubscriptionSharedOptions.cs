namespace Stripe
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Stripe.Infrastructure;

    public abstract class SubscriptionSharedOptions : BaseOptions, IHasMetadata
    {
        /// <summary>
        /// A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice subtotal that will be transferred to the application owner’s Stripe account. The request must be made with an OAuth key in order to set an application fee percentage. For more information, see the application fees <see href="https://stripe.com/docs/connect/subscriptions#collecting-fees-on-subscriptions">documentation</see>.
        /// </summary>
        [JsonProperty("application_fee_percent")]
        public decimal? ApplicationFeePercent { get; set; }

        /// <summary>
        /// Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.
        /// </summary>
        [JsonProperty("billing_thresholds")]
        public SubscriptionBillingThresholdsOptions BillingThresholds { get; set; }

        /// <summary>
        /// A timestamp at which the subscription should cancel. If set to a date before the
        /// current period ends this will cause a proration if <c>prorate=true</c>.
        /// </summary>
        [JsonProperty("cancel_at")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? CancelAt { get; set; }

        /// <summary>
        /// Boolean indicating whether this subscription should cancel at the end of the current period.
        /// </summary>
        [JsonProperty("cancel_at_period_end")]
        public bool? CancelAtPeriodEnd { get; set; }

        /// <summary>
        /// Either <c>charge_automatically</c>, or <c>send_invoice</c>. When
        /// charging automatically, Stripe will attempt to pay this invoice
        /// using the default source attached to the customer. When sending an
        /// invoice, Stripe will email invoices for this subscription to the
        /// customer with payment instructions. Defaults to
        /// <c>charge_automatically</c>.
        /// </summary>
        [JsonProperty("collection_method")]
        public string CollectionMethod { get; set; }

        /// <summary>
        /// The code of the coupon to apply to this subscription. A coupon applied to a subscription will only affect invoices created for that particular subscription.
        /// </summary>
        [JsonProperty("coupon")]
        public string Coupon { get; set; }

        /// <summary>
        /// Number of days a customer has to pay invoices generated by this subscription. Only valid for subscriptions where <c>billing=send_invoice</c>.
        /// </summary>
        [JsonProperty("days_until_due")]
        public long? DaysUntilDue { get; set; }

        /// <summary>
        /// ID of the default payment method for the subscription.
        /// </summary>
        [JsonProperty("default_payment_method")]
        public string DefaultPaymentMethod { get; set; }

        [JsonProperty("default_source")]
        public string DefaultSource { get; set; }

        /// <summary>
        /// Ids of the tax rates to apply to this subscription.
        /// </summary>
        [JsonProperty("default_tax_rates")]
        public List<string> DefaultTaxRates { get; set; }

        /// <summary>
        /// A set of key/value pairs that you can attach to a subscription object. It can be useful for storing additional information about the subscription in a structured format.
        /// </summary>
        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// Specifies an interval for how often to bill for any pending invoice items. It is
        /// analogous to creating an invoice for the given subscription at the specified interval.
        /// </summary>
        [JsonProperty("pending_invoice_item_interval")]
        public SubscriptionPendingInvoiceItemIntervalOptions PendingInvoiceItemInterval { get; set; }

        /// <summary>
        /// Indicates if a customer is on session while an invoice payment is attempted.
        /// </summary>
        [JsonProperty("off_session")]
        public bool? OffSession { get; set; }

        /// <summary>
        /// <para>
        /// Use <c>allow_incomplete</c> to create subscriptions with <c>status=incomplete</c> if its
        /// first invoice cannot be paid. Creating subscriptions with this status allows you to
        /// manage scenarios where additional user actions are needed to pay a subscription's
        /// invoice. For example, SCA regulation may require 3DS authentication to complete payment.
        /// See the <a href="https://stripe.com/docs/billing/migration/strong-customer-authentication">SCA Migration Guide</a>
        /// for Billing to learn more. This is the default behavior.
        /// </para>
        /// <para>
        /// Use <c>error_if_incomplete</c> if you want Stripe to return an HTTP 402 status code if
        /// a subscription's first invoice cannot be paid. For example, if a payment method requires
        /// 3DS authentication due to SCA regulation and further user action is needed, this
        /// parameter does not create a subscription and returns an error instead. This was the
        /// default behavior for API versions prior to 2019-03-14. See the <a href="https://stripe.com/docs/upgrades#2019-03-14">changelog</a>
        /// to learn more.
        /// </para>
        /// </summary>
        [JsonProperty("payment_behavior")]
        public string PaymentBehavior { get; set; }

        /// <summary>
        /// Boolean (default <c>true</c>). Use with a <c>billing_cycle_anchor</c> timestamp to determine whether the customer will be invoiced a prorated amount until the anchor date. If <c>false</c>, the anchor period will be free (similar to a trial).
        /// </summary>
        [JsonProperty("prorate")]
        public bool? Prorate { get; set; }

        /// <summary>
        /// A non-negative decimal (with at most four decimal places) between 0 and 100. This represents the percentage of the subscription invoice subtotal that will be calculated and added as tax to the final amount each billing period. For example, a plan which charges $10/month with a <c>tax_percent</c> of 20.0 will charge $12 per invoice.
        /// </summary>
        [Obsolete("Use DefaultTaxRates")]
        [JsonProperty("tax_percent")]
        public decimal? TaxPercent { get; set; }

        /// <summary>
        /// <see cref="DateTime"/> representing the end of the trial period the customer will get
        /// before being charged for the first time. This will always overwrite any trials that
        /// might apply via a subscribed plan. If set, <see cref="TrialEnd"/> will override the
        /// default trial period of the plan the customer is being subscribed to. The special value
        /// <see cref="SubscriptionTrialEnd.Now"/> can be provided to end the customer’s trial
        /// immediately.
        /// </summary>
        [JsonProperty("trial_end")]
        [JsonConverter(typeof(AnyOfConverter))]
        public AnyOf<DateTime?, SubscriptionTrialEnd> TrialEnd { get; set; }

        /// <summary>
        /// Boolean. Decide whether to use the default trial on the plan when creating a subscription.
        /// </summary>
        [JsonProperty("trial_from_plan")]
        public bool? TrialFromPlan { get; set; }

        [Obsolete("Use Items")]
        [JsonProperty("plan")]
        public string Plan { get; set; }

        [Obsolete("Use Items")]
        [JsonProperty("quantity")]
        public long? Quantity { get; set; }

        [JsonProperty("transfer_data")]
        public SubscriptionTransferDataOptions TransferData { get; set; }
    }
}
