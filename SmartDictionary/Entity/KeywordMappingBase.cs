using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SmartDictionary.Entity
{
    /// <summary>
    /// Abstract class of keyword mapping.
    /// </summary>
    public abstract class KeywordMappingBase
    {
        /// <summary>
        /// Sentence id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Keyword of sentences.
        /// </summary>
        [Indexed]
        public string Key { get; set; }
    }
}
