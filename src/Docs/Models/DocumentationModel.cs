using System;
using System.Collections.Generic;

namespace Docs.Models
{
    /// <summary>
    /// DocumentationModel
    /// </summary>
    public class DocumentationModel
    {
        /// <summary>
        /// Documentation contexts.
        /// </summary>
        public List<ContextModel> Contexts { get; set; }

        /// <summary>
        /// Date of documentation creation (UTC).
        /// </summary>
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// Total elapsed time in milliseconds for the documentation creation.
        /// </summary>
        public long ElapsedTime { get; set; }

        /// <summary>
        /// DocumentationModel
        /// </summary>
        public DocumentationModel()
        {
            
        }

        /// <summary>
        /// DocumentationModel
        /// </summary>
        /// <param name="contexts"></param>
        /// <param name="timeStamp"></param>
        /// <param name="elapsedTime"></param>
        public DocumentationModel(List<ContextModel> contexts, DateTime timeStamp, long elapsedTime)
        {
            Contexts = contexts;
            TimeStamp = timeStamp;
            ElapsedTime = elapsedTime;
        }
    }
}