namespace ConsoleBoilerplate.Models
{
    public class ParentItem
    {
        public string Id { get; set; }
        public ICollection<ChildItem> ChildItems { get; set; }
        public bool IsProcessed { get; set; }
    }
}
