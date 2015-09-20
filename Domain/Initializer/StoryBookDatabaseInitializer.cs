using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Context;

namespace Domain.Initializer
{
    class StoryBookDatabaseInitializer : MigrateDatabaseToLatestVersion<StoryBookContext, Domain.Migrations.Configuration>
    {
       
    }
}
