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
        public IChampionshipManagementRepository ChampionshipManagementRepository => new ChampionshipManagementRepository(datacontext);
        public IChampionshipTypeManagementRepository ChampionshipTypeManagementRepository => new ChampionshipTypeManagementRepository(datacontext);
        public IMatchTitleManagementRepository MatchTitleManagementRepository => new MatchTitleManagementRepository(datacontext);
        public IMatchTypeManagementRepository MatchTypeManagementRepository => new MatchTypeManagementRepository(datacontext);
        public IMatchFormatManagementRepository MatchFormatManagementRepository => new MatchFormatManagementRepository(datacontext);
        public IPPVMatchRepository PPVMatchRepository => new PPVMatchRepository(datacontext);

        public async Task<bool> SaveAsync()
        {
            return await datacontext.SaveChangesAsync() > 0;
        }
    }
}
