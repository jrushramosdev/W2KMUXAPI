using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2KMUXDAL.Repositories;

namespace W2KMUXDAL.Data
{
    public interface IUnitOfWork
    {
        ISuperstarRepository SuperstarRepository { get; }
        IShowManagementRepository ShowManagementRepository { get; }
        IPPVManagementRepository PPVManagementRepository { get; }
        ITeamHistoryRepository TeamHistoryRepository { get; }
        ITeamManagementRepository TeamManagementRepository { get; }
  
        Task<bool> SaveAsync();
    }
}
