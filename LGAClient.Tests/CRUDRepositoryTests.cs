using LGAClient.Controllers;
using LGAClient.Models;
using LGAClient.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LGAClient.Tests
{
    public class CRUDRepositoryTests : InMemoryDatabaseBase
    {
        private readonly string _firstName = "UserName";
        private readonly string _lastName = "LastName";
        private readonly string _email = "testuser@gmail.com";
        private readonly string _updateLastName = "UpdatedLastName";

        public CRUDRepositoryTests() : base(
            new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=LGACLientTest;Trusted_Connection=True;MultipleActiveResultSets=True").Options)
        {

        }
       
        [Fact(Skip ="Will use mocks later.")]

        public void GetById_ReturnsPerson()
        {
            var dbContextMock = new Mock<ApplicationDbContext>();
            var dbSetMock = new Mock<DbSet<Person>>();
            dbSetMock.Setup(s => s.Find(It.IsAny<int>())).Returns(new Person());
            dbContextMock.Setup(s => s.Set<Person>()).Returns(dbSetMock.Object);

            //Execute method of SUT (CRUDRepository)
            var crudRepository = new CRUDRepository<Person>(dbContextMock.Object);
            var person = crudRepository.FindById(0);

            //Assert
            Assert.NotNull(person);
            Assert.IsAssignableFrom<Person>(person);
        }

        [Fact]
        public async Task Can_Insert_Person()
        {
            using (var dbContext = new ApplicationDbContext(base.ContextOptions))
            {
                var repository = new CRUDRepository<Person>(dbContext);
                var expected = new Person {FirstName = _firstName, LastName = _lastName, Email = _email };
                repository.Insert(expected);

                var result = dbContext.Person.Where(x=>x.Email== _email).FirstOrDefault();
                Assert.NotNull(result);
                Assert.Equal(expected, result);
                await repository.DeleteAsync(result.Id);
            }
        }



        [Fact]
        public async Task Verify_Update_PersonEntity()
        {
            using (var dbContext = new ApplicationDbContext(base.ContextOptions))
            {
                var repository = new CRUDRepository<Person>(dbContext);
                //Create Test Entry
                var expected = new Person { FirstName = _firstName, LastName = _lastName, Email = _email };
                repository.Insert(expected);
                //Retrieve Created Entry
                var result = dbContext.Person.Where(x => x.Email == _email).FirstOrDefault();
                
                //Update LastName
                result.LastName = _updateLastName;
                repository.Update(result);
                
                //Verify Updated
                result = dbContext.Person.Where(x => x.Email == _email).FirstOrDefault();
                Assert.Equal(result.LastName, _updateLastName);
                await repository.DeleteAsync(result.Id);
            }
        }

        [Fact]
        public async Task Verify_Delete_PersonEntity()
        {
            using (var dbContext = new ApplicationDbContext(base.ContextOptions))
            {
                var repository = new CRUDRepository<Person>(dbContext);
                //Create Test Entry
                var expected = new Person { FirstName = _firstName, LastName = _lastName, Email = _email };
                repository.Insert(expected);
                //Retrieve Created Entry
                var result = dbContext.Person.Where(x => x.Email == _email).FirstOrDefault();
                
                Assert.True(await repository.DeleteAsync(result.Id));
            }
        }

        [Fact]
        public async Task Verify_GetList()
        {
            using (var dbContext = new ApplicationDbContext(base.ContextOptions))
            {
                var repository = new CRUDRepository<Person>(dbContext);
                //Create Test Entry
                var expected = new Person { FirstName = _firstName, LastName = _lastName, Email = _email };
                repository.Insert(expected);
                //Retrieve Created Entry
                var result = await repository.ListAsync();

                Assert.True(result != null);
                foreach (var item in result)
                {
                    await repository.DeleteAsync(item.Id);
                }
            }
        }

        [Fact]
        public async Task Verify_GetList_ReturnsNull()
        {
            using (var dbContext = new ApplicationDbContext(base.ContextOptions))
            {
                var repository = new CRUDRepository<Person>(dbContext);
           
                //Retrieve Created Entry
                var result = await repository.ListAsync();

                Assert.True(result.FirstOrDefault()==null);
            }
        }


    }
}
