using SQLite;
using System;

namespace SmartDictionary.Entity
{
    /// <summary>
    /// All string will be saved in this model.
    /// </summary>
    public class Sentence
    {
        /// <summary>
        /// Id of sentence.
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }

        /// <summary>
        /// The sentence that want to save.
        /// </summary>
        [Unique]
        public string Key { get; set; }

        /// <summary>
        /// Created time.
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// Last used time.
        /// </summary>
        public DateTime LastUsedTime { get; set; }
    }
}
