using System;
using NUnit.Framework;
using Shouldly;
using Soloco.RealTimeWeb.Common.Infrastructure.Messages;
using Soloco.RealTimeWeb.Common.Tests;
using Soloco.RealTimeWeb.Membership.Messages.Queries;
using Soloco.RealTimeWeb.Membership.Messages.ViewModel;

namespace Soloco.RealTimeWeb.Membership.Tests.Integration.Queries
{
    [TestFixture]
    public class WhenQueryingClientByKey : ServiceTestBase<IMessageDispatcher>
    {
        private Client _result;
        private ClientByKeyQuery _query;
        private Domain.Client _client;

        protected override void Given()
        {
            base.Given();

            _client = new Domain.Client();
            _client.Id = Guid.NewGuid();
            _client.Key = Guid.NewGuid().ToString("n");
            _client.AllowedOrigin = Guid.NewGuid().ToString("n");

            Session.Store(_client);
            Session.SaveChanges();
        }

        protected override void When()
        {
            base.When();

            _query = new ClientByKeyQuery(_client.Key);

            _result = Service.ExecuteNowWithTimeout(_query);
        }

        [Test]
        public void ThenTheClientShouldBeReturned()
        {
            _result.ShouldNotBeNull();
        }

        [Test]
        public void ThenTheAllowedOriginShouldBeReturned()
        {
            _result.AllowedOrigin.ShouldBe(_client.AllowedOrigin);
        }
    }
}