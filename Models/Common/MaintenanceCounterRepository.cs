using System.Linq;
using Zedx.Data;

namespace Zedx.Models.Common
{
    public class MaintenanceCounterRepository
    {
        public static long GetId(ZedxContext _context, string colName, string tableName)
        {
            try
            {
                MaintenanceCounter maintenanceCounter = _context.MaintenanceCounter
            .SingleOrDefault(x => x.ColumnName == colName && x.TableName == tableName);
                maintenanceCounter.Counter = maintenanceCounter.Counter + 1;
                _context.MaintenanceCounter.Update(maintenanceCounter);
                return maintenanceCounter.Counter;
            }
            catch { return 0; }
        }
    }
}
