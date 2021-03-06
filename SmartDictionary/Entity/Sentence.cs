﻿// Copyright © Qiang Huang, All rights reserved.

using System;
using SQLite;

namespace SmartDictionary.Entity
{
    /// <summary>
    ///     All string will be saved in this model.
    /// </summary>
    public class Sentence
    {
        /// <summary>
        ///     Created time.
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        ///     Id of sentence.
        /// </summary>
        [PrimaryKey]
        [AutoIncrement]
        public long Id { get; set; }

        /// <summary>
        ///     The sentence that want to save.
        /// </summary>
        [Unique]
        public string Key { get; set; }

        /// <summary>
        ///     Last used time.
        /// </summary>
        public DateTime LastUsedTime { get; set; }
    }
}