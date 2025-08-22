using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitTExamplesAPI.Controllers;
using UnitTExamplesAPI.Data;
using UnitTExamplesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using UnitTExamplesAPI.Data;
using Microsoft.AspNetCore.Components;

namespace UnitTMSTest
{
    [TestClass]
    public class UnitTExamplesAPI
    {
        private UnitTExamplesContext uNitTExamplesContext;

        [TestInitialize]
        public void InMemoryContext()
        {
            var oPTions = new DbContextOptionsBuilder<UnitTExamplesContext>()
                .UseInMemoryDatabase(databaseName: "UnitTExamplesTestDB")
                .Options;

            uNitTExamplesContext = new UnitTExamplesContext(oPTions);
        }

        [TestCleanup]
        public void CleanUp()
        {
            uNitTExamplesContext.Dispose();
        }

        [TestMethod]
        public async Task GetUser()
        {
            uNitTExamplesContext.Users.Add(
                                            new User()
                                            {
                                                UserID = 4, Vorname = "Firat", Nachname = "Haksever",  Email = "@",  Password = "123456"
                                            }
                    );
            await uNitTExamplesContext.SaveChangesAsync();

            var uSer = await uNitTExamplesContext.Users.
                FirstOrDefaultAsync(F => F.Vorname == "Firat");

            Assert.IsNotNull(uSer);
        }

        [TestMethod]
        public async Task GetAllUsers()
        {
            uNitTExamplesContext.Users.AddRange(
                                                new User()
                                                {
                                                    UserID = 1, Vorname = "Firat",  Nachname = "Haksever",  Email = "@",  Password = "123456"
                                                },
                                                new User()
                                                {
                                                    UserID = 2, Vorname = "Firat", Nachname = "Haksever", Email = "@", Password = "123456"
                                                }
                    );
            await uNitTExamplesContext.SaveChangesAsync();

            var uSerL = await uNitTExamplesContext.Users.ToListAsync();

            Assert.AreEqual(2, uSerL.Count);
        }

        [TestMethod]
        public async Task DeleteUser()
        {
            uNitTExamplesContext.Users.AddRange(
                                                new User()
                                                {
                                                    UserID = 2, Vorname = "Firat", Nachname = "Haksever", Email = "@", Password = "123456"
                                                }
                    );
            await uNitTExamplesContext.SaveChangesAsync();

            var uSer = await uNitTExamplesContext.Users.
                FirstOrDefaultAsync(F => F.Vorname == "Firat");

            Assert.IsNotNull(uSer);

            uNitTExamplesContext.Users.Remove(uSer);
            await uNitTExamplesContext.SaveChangesAsync();

            var dELUser = await uNitTExamplesContext.Users.
                FirstOrDefaultAsync(F => F.Vorname == "Firat");

            Assert.IsNull(dELUser);
        }

        [TestMethod]
        public async Task UpdateUser()
        {
            uNitTExamplesContext.Users.Add(
                                            new User()
                                            {
                                                UserID = 3, Vorname = "Firat", Nachname = "Haksever", Email = "@", Password = "123456"
                                            }
                    );
            await uNitTExamplesContext.SaveChangesAsync();

            var uSer = await uNitTExamplesContext.Users.
                FirstOrDefaultAsync(F => F.Vorname == "Firat");
            Assert.IsNotNull(uSer);

            uSer.Vorname = "FiratUpdated";
            uSer.Nachname = "HakseverUpdated";

            await uNitTExamplesContext.SaveChangesAsync();

            var uSerUpdated = await uNitTExamplesContext.Users.
                FirstOrDefaultAsync(F => F.Vorname == "FiratUpdated");

            Assert.IsNotNull(uSerUpdated);
        }
    }
}
