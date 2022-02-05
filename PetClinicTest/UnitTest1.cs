using System;
using PetClinic.Services.NetworkService;
using Xunit;

namespace PetClinicTest
{
    public class UnitTest1
    {
        [Fact]
        public void GetOwnerTest()
        {
            NetworkService networkService = NetworkService.Instance;
            networkService.GetAsync
        }
    }
}
