// Copyright © Qiang Huang, All rights reserved.

using System.Collections.Generic;
using SmartDictionary.Entity;

namespace SmartDictionary.DataAccess.Persistence
{
    public static class SentenceCommandHelper
    {
        public static string DeleteByIdCommand(string id)
        {
            return $"DLETE FROM sentence WHERE id = {id}";
        }

        public static string DeleteByKeyCommand(string key)
        {
            return $"DLETE FROM sentence WHERE key = {key}";
        }

        public static string GetByKeyCommand(string id)
        {
            return $"SELECT FROM sentence WHERE key={id}";
        }

        public static string GetByLastUsedTimeCommand(IEnumerable<string> ids)
        {
            var scope = string.Join(",", ids);
            return $"SELECT FROM sentence WHERE key in ({scope}) ORDER BY lastusedtime DESC";
        }

        public static string SaveCommand(Sentence sentence)
        {
            return "INSERT INTO sentence (key,createdtime,lastusedtime) values" +
                   $"({sentence.Key},{sentence.CreatedTime},{sentence.LastUsedTime}";
        }

        public static string CreateSentenceTable =
            @"DROP TABLE sentence IF EXISTS;
                CREATE TABLE sentence 
                (id INTEGER PRIMARY KEY AUTOINCREMENT,
                key TEXT,
                createdtime TEXT,
                lastusedtime TEXT)";
    }
}