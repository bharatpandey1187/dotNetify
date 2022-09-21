using dotNetify.SampleAPI.EDMX;
using Bogus;
using static Bogus.DataSets.Name;
using dotNetify.SampleAPI.UserPersonaModels;
using dotNetify.SampleAPI.Entity;

namespace dotNetify.SampleAPI.Faker
{
    public static class FakerService
    {

        public static List<User> GetFakeUsers(int totalRecords)
        {

            var fakerGenerator = new Faker<User>()
                                    .RuleFor(x => x.Id, (faker, user) => Guid.NewGuid())
                                    .RuleFor(x => x.BirthCountryId, (faker, user) => 9)
                                    .RuleFor(x => x.CountryId, (faker, user) => user.BirthCountryId)
                                    .RuleFor(x => x.DateMasked, (faker, user) => default)
                                    .RuleFor(x => x.DateOfBirth, (faker, user) => new DateOnly(faker.Random.Int(1970, 2000), faker.Random.Int(1, 12), faker.Random.Int(1, 28)))
                                    .RuleFor(x => x.FirstName, (faker, user) => faker.Person.FirstName)
                                    .RuleFor(x => x.LastName, (faker, user) => faker.Person.LastName)
                                    .RuleFor(x => x.MiddleName, (faker, user) => string.Empty)
                                    .RuleFor(x => x.Nickname, (faker, user) => faker.Person.FullName)
                                    .RuleFor(x => x.CreatedDate, (faker, user) => DateTime.UtcNow)
                                    .RuleFor(x => x.LastUpdatedDate, (faker, user) => DateTime.UtcNow)
                                    .RuleFor(x => x.TimezoneId, (faker, user) => 127)
                                    .RuleFor(x => x.Gender, (faker, user) => faker.Person.Gender == Gender.Male ? 1 : 2)
                                    .RuleFor(x => x.LanguageId, (faker, user) => faker.PickRandom<int>(1033, 127, 9))
                                    .RuleFor(x => x.LastUpdatedBy, (faker, user) => faker.Random.Uuid())
                                    .RuleFor(x => x.Addresses, (faker, user) => GetFakeAddresses(user.Id))
                                    .RuleFor(x => x.Emails, (faker, user) => GetFakeEmails(user.Id))
                                    .RuleFor(x => x.Websites, (faker, user) => GetFakeWebSites(user.Id))
                                    .RuleFor(x => x.Phones, (faker, user) => GetFakePhones(user.Id));

            return fakerGenerator.Generate(totalRecords);

        }

        public static List<CandidateTransitionEntity> GetFakeCandidateTransitions(int totalRecords)
        {

            var fakerGenerator = new Faker<CandidateTransitionEntity>()
                                    .RuleFor(x => x.Id, (faker, user) => 0)
                                     .RuleFor(x => x.CandidateStatusReasonId, (faker, user) => 26)
                                    .RuleFor(x => x.Active, (faker, user) => true)
                                    .RuleFor(x => x.EmployeeId, (faker, user) => "2200992")
                                    .RuleFor(x => x.CompanyId, (faker, user) => faker.Random.Uuid())
                                    .RuleFor(x => x.ContractId, (faker, user) => faker.Random.Int(1000000,2000000))
                                    .RuleFor(x => x.ProgramCompletionDate, (faker, user) => faker.Date.Future(1))
                                    .RuleFor(x => x.GracePeriodEndDate, (faker, user) => faker.Date.Future(1))
                                    .RuleFor(x => x.LastUpdatedDate, (faker, user) => DateTime.UtcNow)
                                    .RuleFor(x => x.CreatedDate, (faker, user) => DateTime.UtcNow)
                                    .RuleFor(x => x.CountryExpirationDate, (faker, user) => faker.Date.Future(1))
                                    .RuleFor(x => x.LastUpdatedByUserId, (faker, user) => faker.Random.Uuid())
                                    .RuleFor(x => x.ResumeExpirationDate, (faker, user) => faker.Date.Future(1))
                                    .RuleFor(x => x.ProgramId, (faker, user) => faker.Random.Int(1000000, 2000000))
                                    .RuleFor(x => x.ProjectName, (faker, user) => faker.Random.AlphaNumeric(50))
                                    .RuleFor(x => x.UserId, (faker, user) => faker.Random.Uuid());

            return fakerGenerator.Generate(totalRecords);

        }

        private static List<Website> GetFakeWebSites(Guid userId)
        {
            var fakeGenerator = new Faker<Website>()
                .RuleFor(x => x.Id, f => 0)
                .RuleFor(x => x.Active, f => true)
                .RuleFor(x => x.UserId, f => userId)
                .RuleFor(x => x.WebsiteTypeId, f => f.PickRandom<int>(1, 2))
                .RuleFor(x => x.Active, f => true)
                .RuleFor(x => x.Value, f => f.Internet.Url())
                .RuleFor(x => x.CreatedDate, f => DateTime.UtcNow)
                .RuleFor(x => x.LastUpdatedDate, faker => DateTime.UtcNow);
            return fakeGenerator.Generate(4);
        }

        private static List<Email> GetFakeEmails(Guid userId)
        {
            var fakeGenerator = new Faker<Email>()
                 .RuleFor(x => x.Id, f => 0)
                 .RuleFor(x => x.Active, f => true)
                 .RuleFor(x => x.UserId, f => userId)
                 .RuleFor(x => x.UserEmailTypeId, f => f.PickRandom<int>(1, 2))
                 .RuleFor(x => x.Active, f => true)
                 .RuleFor(x => x.Value, f => f.Internet.Email())
                 .RuleFor(x => x.CreatedDate, f => DateTime.UtcNow)
                 .RuleFor(x => x.LastUpdatedDate, faker => DateTime.UtcNow);
            return fakeGenerator.Generate(4);
        }

        private static List<Phone> GetFakePhones(Guid userId)
        {
            var fakeGenerator = new Faker<Phone>()
                 .RuleFor(x => x.Id, f => 0)
                 .RuleFor(x => x.Active, f => true)
                 .RuleFor(x => x.UserId, f => userId)
                 .RuleFor(x => x.UserPhoneTypeId, f => f.PickRandom<int>(1, 2))
                 .RuleFor(x => x.Active, f => true)
                 .RuleFor(x => x.Value, f => f.Phone.PhoneNumber("###-###-#####"))
                 .RuleFor(x => x.CreatedDate, f => DateTime.UtcNow)
                 .RuleFor(x => x.LastUpdatedDate, faker => DateTime.UtcNow);
            return fakeGenerator.Generate(4);
        }

        private static List<Address> GetFakeAddresses(Guid userId)
        {
            var fakeGenerator = new Faker<Address>()
                 .RuleFor(x => x.Id, f => 0)
                 .RuleFor(x => x.Active, f => true)
                 .RuleFor(x => x.UserId, f => userId)
                 .RuleFor(x => x.UserAddressTypeId, f => f.PickRandom<int>(1, 2))
                 .RuleFor(x => x.StreetAddress1, f => f.Address.StreetAddress())
                 .RuleFor(x => x.StreetAddress2, f => f.Address.BuildingNumber())
                 .RuleFor(x => x.City, f => f.Address.City())
                 .RuleFor(x => x.StateProvince, f => f.Address.State())
                 .RuleFor(x => x.CountryId, f => 9)
                 .RuleFor(x => x.PostalCode, f => f.Address.ZipCode())
                 .RuleFor(x => x.Active, f => true)
                 .RuleFor(x => x.Latitude, f => (decimal?)f.Address.Latitude())
                 .RuleFor(x => x.Longitude, f => (decimal?)f.Address.Longitude())
                 .RuleFor(x => x.CreatedDate, f => DateTime.UtcNow)
                 .RuleFor(x => x.LastUpdatedDate, faker => DateTime.UtcNow);
            return fakeGenerator.Generate(4);
        }
    }
}
