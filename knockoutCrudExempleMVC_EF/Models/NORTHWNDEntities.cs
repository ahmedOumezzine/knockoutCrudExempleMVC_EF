  using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
namespace knockoutCrudExempleMVC_EF.Models
{

    
    public partial class NORTHWNDEntities : DbContext
    {
        public NORTHWNDEntities()
            : base("DefaultConnection")
        {
        }
    
        
    
        public virtual DbSet<Employee> Employees { get; set; }
    }
}
