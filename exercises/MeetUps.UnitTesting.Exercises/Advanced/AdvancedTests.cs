using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Tests
{
    public class AdvancedTests
    {
        //Based on DeliveryService.Deliver(string productId) write the required tests.
        [Test]
        public void Test1()
        {
            Assert.Fail();
        }
    }

    internal class DeliveryService
    {
        private const string AdminEmail = "example@domain.com";

        private readonly IMailService _mailService;

        private readonly IRepository _repository;

        public DeliveryService(IRepository repository, IMailService mailService)
        {
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task Deliver(string productId)
        {
            // After having writen the tests, think about this question:
            // What happens if the order of the instruccions changes?
            // Can we write a test that ensures not only the calls, but also the order?

            try
            {
                var product = await _repository.GetAsync(productId);

                if (product.Status == ProductStatus.Delivered)
                {
                    throw new InvalidOperationException();
                }

                product.SetStatus(ProductStatus.Delivered);

                await _repository.UpdateAsync(product);

                await _mailService.SendEmailAsync(product.BuyerEmail, AdminEmail, $"Product {product.Id} delivered.");
            }
            catch (Exception)
            {
                await _mailService.SendEmailAsync(AdminEmail, AdminEmail, $"Error deliverying product {productId}");
            }
        }
    }

    internal interface IMailService
    {
        Task SendEmailAsync(string to, string from, string body);
    }

    internal interface IRepository
    {
        Task<Product> GetAsync(string id);
        Task UpdateAsync(Product product);
    }

    class Product
    {
        public string Id { get; }

        public ProductStatus Status { get; private set; }

        public string BuyerEmail { get; private set; }

        public void SetStatus(ProductStatus newStatus)
        {
            Status = newStatus;
        }
    }

    enum ProductStatus
    {
        Pending,
        Delivered
    }
}