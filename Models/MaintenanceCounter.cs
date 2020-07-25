using System.ComponentModel.DataAnnotations;
namespace Zedx.Models
{
    public class MaintenanceCounter
    {
        [Key]
        public int MaintenanceCounterId { get; set; }
        public string ColumnName { get; set; }
        public string TableName { get; set; }
        public int Counter { get; set; }
    }
}
