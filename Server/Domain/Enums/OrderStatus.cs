namespace Server.Domain.Enums
{
    public enum OrderStatus
    {
        Pending = 10,        // Order created
        InProgress = 20,     // Stitching started
        Ready = 30,          // Ready for trial / pickup
        Delivered = 40,      // Delivered to customer
        Cancelled = 50

    }
}
