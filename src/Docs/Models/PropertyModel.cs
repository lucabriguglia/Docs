namespace Docs.Models
{
    /// <summary>
    /// PropertyModel
    /// </summary>
    public class PropertyModel : ModelBase
    {
        /// <summary>
        /// PropertyModel
        /// </summary>
        public PropertyModel()
        {
        }

        /// <summary>
        /// PropertyModel
        /// </summary>
        /// <param name="name"></param>
        /// <param name="summary"></param>
        public PropertyModel(string name, string summary) : base(name, summary)
        {
        }
    }
}