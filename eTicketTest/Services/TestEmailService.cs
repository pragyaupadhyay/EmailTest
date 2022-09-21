using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using FluentAssertions;
using Moq;
using Microsoft.Extensions.Logging;
using eTicket.Service;
using eTicket.Models;
using Microsoft.Extensions.Options;
using eTicket.Data;
using System.Threading.Tasks;

namespace eTicketTest
{
    [TestClass]
    public class EmailTest
    {
        private readonly IFixture _fixture;
        private readonly Mock<AppDbContext> _dbMock;
        private readonly Mock<IOptions<SMTPConfigModel>> _SmtpConfigMock;
        private readonly EmailService _sut;
        public EmailTest()
        {
            _fixture = new Fixture();
            _dbMock = _fixture.Freeze<Mock<AppDbContext>>();
            _SmtpConfigMock = _fixture.Freeze<Mock<IOptions<SMTPConfigModel>>>();
            _sut = new EmailService(_dbMock.Object, _SmtpConfigMock.Object);
        }

        [TestMethod]
        public async Task GetId_shouldReturnId_WhenDataFound()
        {
            //arrange
            var EmailMock = Get<EmailTemplate>();
          

            //Act
         

            //Assert


        }

    }

}
