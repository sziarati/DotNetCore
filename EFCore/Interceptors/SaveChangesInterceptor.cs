using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infra.Interceptors
{
    public class mySaveChangesInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            if (eventData.Context is null)
            {
                return result;
            }

            var entries = eventData.Context.ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry is { State: EntityState.Deleted, Entity: IArchived entity })
                {
                    entity.IsArchived = true;
                    entry.State = EntityState.Modified;
                }
            }
            return result;
        }
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {

            var task = new ValueTask<InterceptionResult<int>>(result);

            if (eventData.Context is null)
            {
                return task;
            }

            var entries = eventData.Context.ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry is { State: EntityState.Deleted, Entity: IArchived entity })
                {
                    entity.IsArchived = true;
                    entry.State = EntityState.Modified;
                }
            }

            return task;
        }
    }
}