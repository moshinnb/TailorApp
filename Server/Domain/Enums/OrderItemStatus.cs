namespace Server.Domain.Enums
{
    public enum OrderItemStatus
    {
        Pending = 10,      // Order placed
        Cutting = 20,      // Cloth cutting
        Stitching = 30,    // Under stitching
        TrialReady = 40,   // Ready for trial
        Alteration = 50,   // Changes requested
        Ready = 60,        // Final ready
        Delivered = 70,
        Cancelled = 80
    }
}
