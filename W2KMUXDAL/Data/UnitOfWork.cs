using System.Threading.Tasks;
using W2KMUXDAL.Repositories;

namespace W2KMUXDAL.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly W2KMUXContext datacontext;

        public UnitOfWork(W2KMUXContext datacontext)
        {
            this.datacontext = datacontext;
        }
        public ISuperstarRepository SuperstarRepository => new SuperstarRepository(datacontext);
        public IShowManagementRepository ShowManagementRepository => new ShowManagementRepository(datacontext);
        public IPPVManagementRepository PPVManagementRepository => new PPVManagementRepository(datacontext);
        public ITeamHistoryRepository TeamHistoryRepository => new TeamHistoryRepository(datacontext);
        public ITeamManagementRepository TeamManagementRepository => new TeamManagementRepository(datacontext);

        public async Task<bool> SaveAsync()
        {
            return await datacontext.SaveChangesAsync() > 0;
        }
    }
}
