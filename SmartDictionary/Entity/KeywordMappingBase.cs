// Copyright © Qiang Huang, All rights reserved.

using SQLite;

namespace SmartDictionary.Entity
{
    /// <summary>
    /// Abstract class of keyword mapping.
    /// </summary>
    public abstract class KeywordMappingBase
    {
        /// <summary>
        /// Number of words existed in sentence.
        /// </summary>
        public int Count { get; set; }

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