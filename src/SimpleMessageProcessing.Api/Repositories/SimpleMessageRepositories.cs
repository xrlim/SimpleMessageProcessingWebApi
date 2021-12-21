using SimpleMessageProcessing.Api.Databases;
using SimpleMessageProcessing.Library.Abstractions;
using SimpleMessageProcessing.Library.Models;

namespace SimpleMessageProcessing.Api.Repositories {
    public class SimpleMessageRepositories : ISimpleMessageRepositories {
        private readonly SimpleMessegeDbContext _dbContext;

        public SimpleMessageRepositories(SimpleMessegeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> SaveSimpleMessage(SimpleMessage simpleMessage)
        {
            await _dbContext.AddAsync(simpleMessage);
            return (await _dbContext.SaveChangesAsync() > 0);
        }
    }
}
