using System;
using System.Linq;
using ConsultantData.Model;
using ConsultantService.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ConsultantTests
{
    //When testing, comment out OnConfiguring method in Context class
    public class ConsultantRepositoryTests
    {
        [Fact(DisplayName = "GetConsultants should return a list of 5 consultants")]
        public void GetConsultants_ShouldReturn5Consultants()
        {
            using (var context = GetContextWithData())
            {
                var service = new SQLConsultantRepository(context);

                Assert.True(service.GetConsultants().Count() == 5);
            }
        }

        [Fact(DisplayName = "GetConsultant should throw exception when ID <= 0")]
        public void GetConsultant_ThrowsExceptionWhenIDOutOfRange()
        {
            using (var context = GetContextWithData())
            {
                var service = new SQLConsultantRepository(context);

                Assert.Throws<ArgumentOutOfRangeException>(() => service.GetConsultant(-5));
            }
        }

        [Fact(DisplayName = "GetConsultant should return a specific resource")]
        public void GetConsultant_ShouldReturnSpecificResource()
        {
            using (var context = GetContextWithData())
            {
                var service = new SQLConsultantRepository(context);

                Assert.True(service.GetConsultant(2).FirstName == "Koen");
            }
        }

        [Fact(DisplayName = "GetConsultant should throw exception when given fake ID")]
        public void GetConsultant_ThrowsExceptionWhenFakeID()
        {
            using (var context = GetContextWithData())
            {
                var service = new SQLConsultantRepository(context);

                Assert.Throws<ArgumentOutOfRangeException>(() => service.GetConsultant(10));
            }
        }

        [Fact(DisplayName = "AddConsultant should create a resource")]
        public void AddConsultant_ShouldCreateAResource()
        {
            using (var context = GetContextWithData())
            {
                var service = new SQLConsultantRepository(context);

                var carla = new Consultant("Carla", "Nelissen", "Network Engineer", "Limburg", "carla.nelissen@first.eu", "0478965432", new DateTime(1980, 01, 01));

                service.AddConsultant(carla);

                Assert.True(service.GetConsultant(6).FirstName == "Carla");
                Assert.True(service.GetConsultant(6).LastName == "Nelissen");
                Assert.True(service.GetConsultant(6).Description == "Network Engineer");
                Assert.True(service.GetConsultant(6).Place == "Limburg");
                Assert.True(service.GetConsultant(6).EmailAddress == "carla.nelissen@first.eu");
                Assert.True(service.GetConsultant(6).PhoneNumber == "0478965432");
                Assert.True(service.GetConsultant(6).DateOfBirth == new DateTime(1980, 01, 01));
            }
        }

        [Fact(DisplayName = "UpdateConsultant should update the consultant")]
        public void UpdateConsultant_ShouldUpdateChangedProperties()
        {
            using (var context = GetContextWithData())
            {
                var service = new SQLConsultantRepository(context);

                var koen = service.GetConsultant(2);

                koen.EmailAddress = "NewEmailAddress";

                service.UpdateConsultant(koen);

                Assert.True(service.GetConsultant(2).EmailAddress == "NewEmailAddress");
            }
        }

        [Fact(DisplayName = "DeleteConsultant should delete a resource")]
        public void DeleteConsultants_GetDeletedConsultantSHouldThrowException()
        {
            using (var context = GetContextWithData())
            {
                var service = new SQLConsultantRepository(context);
                
                var seppe = service.GetConsultant(4);

                service.DeleteConsultant(seppe);

                Assert.Throws<ArgumentOutOfRangeException>(() => service.GetConsultant(4));
            }
        }

        private ConsultantContext GetContextWithData()
        {
            var options = new DbContextOptionsBuilder<ConsultantContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new ConsultantContext(options);

            context.Consultants.Add(new Consultant("Louis", "Broucke", "Junior .NET Developer", "Mechelen", "louis.broucke@first.eu", "0478529462", new DateTime(1991,09,14)));
            context.Consultants.Add(new Consultant("Koen", "Hublet", "Operations Manager", "Gent", "koen.hublet@first.eu", "0478529462", new DateTime(1991, 09, 14)));
            context.Consultants.Add(new Consultant("Nele", "Goovaerts", "HR Manager", "Mechelen", "nele.goovaerts@first.eu", "0478529462", new DateTime(1991, 09, 14)));
            context.Consultants.Add(new Consultant("Seppe", "Van Brabant", "Sales Manager", "Antwerpen", "seppe.vanbrabant@first.eu", "0478529462", new DateTime(1991, 09, 14)));
            context.Consultants.Add(new Consultant("Noortje", "Vanbutsele", "Sales Manager", "Leuven", "noortje.vanbutsele@first.eu", "0478529462", new DateTime(1991, 09, 14)));
            context.SaveChanges();

            return context;
        }
    }
}
