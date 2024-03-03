using Data.Context;
using Data.Repositories.Base;
using EntityModels.Interfaces;
using EntityModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class FileRepository : BaseRepository<ItemInfo>, IFileRepository
    {
        public FileRepository(LibraryDbContext dbContext) : base(dbContext)
        {

        }
    }
}
