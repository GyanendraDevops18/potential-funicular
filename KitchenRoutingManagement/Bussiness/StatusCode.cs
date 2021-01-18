namespace KitchenRoutingManagement.Bussiness
{
    public static class StatusCodeMetadata
    {
        static StatusCodeMetadata() { 
        }

        public const string Checkout = "checkout";
        public const string OrderPaid = "orderpaid";
        public const string Prepration = "prepration";
        public const string PreprationStarted = "started";
        public const string Inprogress = "inprogress";
        public const string Prepared = "prepared";
        public const string Served = "served";
        public const string Completed = "completed";

    }
}
