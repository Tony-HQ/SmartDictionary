using SmartDictionary.Entity;
using SQLite;
using System.Threading.Tasks;

namespace SmartDictionary.DataAccess.Persistence
{
    public sealed class SentenceDao
    {
        public SentenceDao()
        {
            _connection = DataSource.GetConnection();
        }

        public async Task<int> SaveAsync(Sentence sentence)
        {
            return await _connection.InsertAsync(sentence).ConfigureAwait(false);
        }

        public async Task<Sentence> GetByKeyAsync(string key)
        {
            var query = _connection.Table<Sentence>().Where(sentence => sentence.Key.Equals(key));
            return await query.FirstAsync().ConfigureAwait(false);
        }

        private readonly SQLiteAsyncConnection _connection;
    }
}
