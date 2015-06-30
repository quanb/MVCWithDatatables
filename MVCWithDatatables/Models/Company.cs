namespace MVCWithDatatables.Models
{
    /// <summary>
    /// Represents a Company object.
    /// </summary>
    public class Company
    {
        public virtual int Id
        { get; set; }

        public virtual string Name
        { get; set; }

        public virtual string Address
        { get; set; }

        public virtual string Town 
        { get; set; }
    }
}