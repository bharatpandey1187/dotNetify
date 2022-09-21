using dotNetify.SampleAPI.EDMX;

namespace dotNetify.SampleAPI.ViewModels
{
    public class UsersVM 
    {
        private readonly IDbContextFactory<UserPIIDbContext> _dbContextFactory;

        public UsersVM(IDbContextFactory<UserPIIDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;

        }

        public void Add(ReplicationUser businessInfo)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            dbContext.ReplicationUsers.Add(businessInfo);
            dbContext.SaveChanges();
        }

        public void Update(ReplicationUser businessInfo)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            var business = dbContext.ReplicationUsers.Find(businessInfo.Id);
            if (business != null)
            {
                //business.Name = businessInfo.Name;
                //business.Rating = businessInfo.Rating;
                dbContext.SaveChanges();
            }
        }

        public void Remove(ReplicationUser businessInfo)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            var business = dbContext.ReplicationUsers.Find(businessInfo.Id);
            if (business != null)
            {
                dbContext.ReplicationUsers.Remove(business);
                dbContext.SaveChanges();
            }
        }
    }
}
