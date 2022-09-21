using dotNetify.SampleAPI.EDMX;

namespace dotNetify.SampleAPI.ViewModels
{
    public class UserPIIVM 
    {
        private readonly IDbContextFactory<UserPIIDbContext> _dbContextFactory;

        public UserPIIVM(IDbContextFactory<UserPIIDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;

          //  this.ObserveList<User>(nameof(Users), dbChangeObserver);
        }

        public void Add(User userInfo)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            var strategy = dbContext.Database.CreateExecutionStrategy();

            strategy.Execute(
                () =>
                {

                    using var transaction = dbContext.Database.BeginTransaction();

                    dbContext.Users.Add(userInfo);
                    dbContext.SaveChanges();
                    transaction.Commit();
                });
        }

        internal void AddBatch(List<User> users)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            var strategy = dbContext.Database.CreateExecutionStrategy();

            strategy.Execute(
                () =>
                {

                    using var transaction = dbContext.Database.BeginTransaction();

                    dbContext.Users.AddRange(users);
                    dbContext.SaveChanges();
                    transaction.Commit();
                });
        }

        public void Update(User userInfo)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            var business = dbContext.Users.Find(userInfo.Id);
            if (business != null)
            {
                dbContext.SaveChanges();
            }
        }

        public void Remove(User userInfo)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            var user = dbContext.Users.Find(userInfo.Id);
            if (user != null)
            {
                dbContext.Users.Remove(user);
                dbContext.SaveChanges();
            }
        }

        internal void Update(Address address)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            var addressToUpdate = dbContext.Addresses.Find(address.Id);
            if (addressToUpdate != null)
            {
                addressToUpdate.LastUpdatedDate = DateTime.Now;
                dbContext.Addresses.Update(addressToUpdate);
                dbContext.SaveChanges();
            }
        }
    }
}
