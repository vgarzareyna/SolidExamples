namespace SOLIDExamples.Session1.Common.Data
{
    public record struct IntakeItem
    {
        public int Id;
        public string ClientName;
        public DateTime ItemDateTime;
        public decimal Value;
    }

    public record IntakeData
    {
        public IntakeData() { Items = []; }
        public List<IntakeItem> Items;
        public void PushItem(IntakeItem item)
        {
            Items.Add(item);
        }
    }
}
