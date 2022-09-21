using dotNetify.SampleAPI.EDMX;
using dotNetify.SampleAPI.UserPersonaModels;
using DotNetify.SampleAPI.UserPersonaModels;

namespace dotNetify.SampleAPI.ViewModels
{
    public class UserPersonaVM 
    {
        private readonly IDbContextFactory<UserPersonaDbContext> _dbContextFactory;

        public UserPersonaVM(IDbContextFactory<UserPersonaDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;

          //  this.ObserveList<User>(nameof(Users), dbChangeObserver);
        }

        public void Add(CandidateTransition userInfo)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            var strategy = dbContext.Database.CreateExecutionStrategy();

            strategy.Execute(
                () =>
                {

                    using var transaction = dbContext.Database.BeginTransaction();

                    dbContext.CandidateTransitions.Add(userInfo);
                    dbContext.SaveChanges();
                    transaction.Commit();
                });
        }

        internal void AddBatch(List<CandidateTransition> users)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            var strategy = dbContext.Database.CreateExecutionStrategy();

            strategy.Execute(
                () =>
                {

                    using var transaction = dbContext.Database.BeginTransaction();

                    dbContext.CandidateTransitions.AddRange(users);
                    dbContext.SaveChanges();
                    transaction.Commit();
                });
        }

        public void Update(CandidateTransition userInfo)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            var business = dbContext.CandidateTransitions.Find(userInfo.Id);
            if (business != null)
            {
                dbContext.SaveChanges();
            }
        }

        public void Remove(CandidateTransition userInfo)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            var user = dbContext.CandidateTransitions.Find(userInfo.Id);
            if (user != null)
            {
                dbContext.CandidateTransitions.Remove(user);
                dbContext.SaveChanges();
            }
        }

        ////internal void Update(Address address)
        ////{
        ////    using var dbContext = _dbContextFactory.CreateDbContext();
        ////    var addressToUpdate = dbContext.Addresses.Find(address.Id);
        ////    if (addressToUpdate != null)
        ////    {
        ////        addressToUpdate.LastUpdatedDate = DateTime.Now;
        ////        dbContext.Addresses.Update(addressToUpdate);
        ////        dbContext.SaveChanges();
        ////    }
        ////}
    }
}
