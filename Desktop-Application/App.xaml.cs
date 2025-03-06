using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace HotelMS
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            using (var dbContext = new HotelDbContext())
            {
                dbContext.Database.Migrate(); 
            }
        }
    }
}