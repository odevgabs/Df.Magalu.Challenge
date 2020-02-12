using Df.Magalu.Challenge.Data;
using Df.Magalu.Challenge.Domain.Interfaces.Repositories;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Df.Magalu.Challenge.Tests.Repository
{
    public class UnitOfWorkTests
    {

        private Mock<IMongoContext> _mongoContextMock;
        private IUnitOfWork _unitOfWork;

        [SetUp]
        public void Setup()
        {
            _mongoContextMock = new Mock<IMongoContext>();
            _unitOfWork = new UnitOfWork(_mongoContextMock.Object);
        }

        [Test]
        public async Task ShouldCommitSuccessAsync()
        {
            _mongoContextMock.Setup(x => x.SaveChanges()).Returns(Task.FromResult(1));
            bool result = await _unitOfWork.CommitAsync();
            result.Should().BeTrue();
            _mongoContextMock.VerifyAll();
        }

        [Test]
        public async Task ShouldCommitNotSuccessAsync()
        {
            _mongoContextMock.Setup(x => x.SaveChanges()).Returns(Task.FromResult(0));
            bool result = await _unitOfWork.CommitAsync();
            result.Should().BeFalse();
            _mongoContextMock.VerifyAll();
        }

        [Test]
        public void ShouldDispose()
        {
            _unitOfWork.Dispose();
            _mongoContextMock.VerifyAll();
        }
    }
}
