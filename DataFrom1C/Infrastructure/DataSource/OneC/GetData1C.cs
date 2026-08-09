using DataFrom1C.Application.Interfaces;
using DataFrom1C.Domain;
using DataFrom1C.Infrastructure.DataSource.Models.AdditionalInformation;
using DataFrom1C.Infrastructure.DataSource.Models.CashFlowArticles;
using DataFrom1C.Infrastructure.DataSource.Models.ConstructionOrder;
using DataFrom1C.Infrastructure.DataSource.Models.ContractCounterparties;
using DataFrom1C.Infrastructure.DataSource.Models.Counterparty;
using DataFrom1C.Infrastructure.DataSource.Models.CreditToCurrentAccount;
using DataFrom1C.Infrastructure.DataSource.Models.DebitToCurrentAccount;
using DataFrom1C.Infrastructure.DataSource.Models.ExpenseItem;
using DataFrom1C.Infrastructure.DataSource.Models.ImplementationConstructionWorks;
using DataFrom1C.Infrastructure.DataSource.Models.Nomenclature;
using DataFrom1C.Infrastructure.DataSource.Models.NomenclatureGroup;
using DataFrom1C.Infrastructure.DataSource.Models.ReceiptGoodsServices;
using DataFrom1C.Infrastructure.DataSource.Models.ReceiptProcessing;
using DataFrom1C.Infrastructure.DataSource.Models.SaleGoodsServices;
using DataFrom1C.Infrastructure.DataSource.Models.Storage;
using DataFrom1C.Infrastructure.DataSource.Models.UnitOfMeasure;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;

namespace DataFrom1C.Infrastructure.DataSource.OneC
{
    public class GetData1C : IGetData
    {
        private readonly HttpClient httpClient;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly Base1CConfiguration _base1CConfiguration;
        private readonly string ApiUrl;

        public GetData1C(IOptions<Base1CConfiguration> base1CConfiguration, IHttpClientFactory httpClientFactory)
        {
            _base1CConfiguration = base1CConfiguration.Value;
            var username = _base1CConfiguration.Username;
            var password = _base1CConfiguration.Password;
            ApiUrl = _base1CConfiguration.ApiUrl;
            var credentials = $"{username}:{password}";
            var byteArray = Encoding.ASCII.GetBytes(credentials);
            var base64Credentials = Convert.ToBase64String(byteArray);
            _httpClientFactory = httpClientFactory;
            httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64Credentials);
        }

        public async Task<IEnumerable<PurchasePayment>> PurchasePaymentAsync() // Списание с расчетного счета
        {
            var debitToCurrentAccountUrl = ApiUrl + "Document_СписаниеСРасчетногоСчета?$format=json"
                + "&$select=Ref_Key,Date,СуммаДокумента,ДоговорКонтрагента_Key,НазначениеПлатежа,СтатьяДвиженияДенежныхСредств_Key,ВидОперации"
                + "&$filter=(DeletionMark eq false) and (Posted eq true)";
            using HttpResponseMessage debitToCurrentAccountResponse = await httpClient.GetAsync(debitToCurrentAccountUrl);
            var debitToCurrentAccount = await debitToCurrentAccountResponse.Content.ReadFromJsonAsync<DebitToCurrentAccount>();
            return debitToCurrentAccount.Value.Select(x => new PurchasePayment
            {
                DocumentId = x.DocumentId,
                Date = x.Date,
                Amount = x.Amount,
                ContractId = x.ContractId,
                PaymentPurpose = x.PaymentPurpose,
                CashFlowItemId = x.CashFlowItemId,
                TypeOperation = x.TypeOperation
            });
        }

        public async Task<IEnumerable<SalesPayment>> SalesPaymentAsync() // Поступление на расчетный счет
        {
            var creditToCurrentAccountUrl = ApiUrl + "Document_ПоступлениеНаРасчетныйСчет?$format=json"
                + "&$select=Ref_Key,Date,СуммаДокумента,ДоговорКонтрагента_Key,НазначениеПлатежа,СтатьяДвиженияДенежныхСредств_Key,ВидОперации"
                + "&$filter=DeletionMark eq false and Posted eq true";
            using HttpResponseMessage creditToCurrentAccountResponse = await httpClient.GetAsync(creditToCurrentAccountUrl);
            var creditToCurrentAccount = await creditToCurrentAccountResponse.Content.ReadFromJsonAsync<CreditToCurrentAccount>();
            return creditToCurrentAccount.Value.Select(x => new SalesPayment
            {
                DocumentId = x.DocumentId,
                Date = x.Date,
                Amount = x.Amount,
                ContractId = x.ContractId,
                PaymentPurpose = x.PaymentPurpose,
                CashFlowItemId = x.CashFlowItemId,
                TypeOperation = x.TypeOperation
            });
        }

        public async Task<IEnumerable<PurchaseInvoice>> PurchaseInvoiceAsync()
        {
            var receiptGoodsServicesUrl = ApiUrl + "Document_ПоступлениеТоваровУслуг?$format=json"
                + "&$select=Ref_Key,Date,СуммаДокумента,ДоговорКонтрагента_Key,Склад_Key"
                + "&$filter=DeletionMark eq false and Posted eq true";
            using HttpResponseMessage receiptGoodsServicesResponse = await httpClient.GetAsync(receiptGoodsServicesUrl);
            var receiptGoodsServices = await receiptGoodsServicesResponse.Content.ReadFromJsonAsync<ReceiptGoodsServices>();
            var purchaseGoodsServices = receiptGoodsServices.Value.Select(x => new PurchaseInvoice
            {
                DocumentId = x.DocumentId,
                Date = x.Date,
                Amount = x.Amount,
                ContractId = x.ContractId,
                WarehouseId = x.WarehouseId
            });

            var receiptProcessingUrl = ApiUrl + "Document_ПоступлениеИзПереработки?$format=json"
                + "&$select=Ref_Key,Date,СуммаДокумента,ДоговорКонтрагента_Key,Склад_Key"
                + "&$filter=DeletionMark eq false and Posted eq true";
            using HttpResponseMessage receiptProcessingResponse = await httpClient.GetAsync(receiptProcessingUrl);
            var receiptProcessing = await receiptProcessingResponse.Content.ReadFromJsonAsync<ReceiptProcessing>();
            var purchaseProcessing = receiptProcessing.Value.Select(x => new PurchaseInvoice
            {
                DocumentId = x.DocumentId,
                Date = x.Date,
                Amount = x.Amount,
                ContractId = x.ContractId,
                WarehouseId = x.WarehouseId
            });

            return purchaseGoodsServices.Concat(purchaseProcessing);
        }

        public async Task<IEnumerable<SalesInvoice>> SalesInvoiceAsync()
        {
            var saleGoodsServicesUrl = ApiUrl + "Document_РеализацияТоваровУслуг?$format=json"
                + "&$select=Ref_Key,Date,СуммаДокумента,ДоговорКонтрагента_Key,Склад_Key"
                + "&$filter=DeletionMark eq false and Posted eq true";
            using HttpResponseMessage saleGoodsServicesResponse = await httpClient.GetAsync(saleGoodsServicesUrl);
            var saleGoodsServices = await saleGoodsServicesResponse.Content.ReadFromJsonAsync<SaleGoodsServices>();
            var SalesGoodsServices = saleGoodsServices.Value.Select(x => new SalesInvoice
            {
                DocumentId = x.DocumentId,
                Date = x.Date,
                Amount = x.Amount,
                ContractId = x.ContractId,
                WarehouseId = x.WarehouseId
            });

            var implementationConstructionWorksUrl = ApiUrl + "Document_ИмпРеализацияСтроительныхРаботУслуг?$format=json"
                + "&$select=Ref_Key,Date,СуммаДокумента,ДоговорКонтрагента_Key"
                + "&$filter=DeletionMark eq false and Posted eq true";
            using HttpResponseMessage implementationConstructionWorksResponse = await httpClient.GetAsync(implementationConstructionWorksUrl);
            var implementationConstructionWorks = await implementationConstructionWorksResponse.Content.ReadFromJsonAsync<ImplementationConstructionWorks>();
            var SalesImplementationConstructionWorks = implementationConstructionWorks.Value.Select(x => new SalesInvoice
            {
                DocumentId = x.DocumentId,
                Date = x.Date,
                Amount = x.Amount,
                ContractId = x.ContractId
            });

            return SalesGoodsServices.Concat(SalesImplementationConstructionWorks);
        }

        public async Task<IEnumerable<PurchaseGoodAndService>> PurchaseGoodAndServiceAsync()
        {
            var receiptGoodsServicesUrl = ApiUrl + "Document_ПоступлениеТоваровУслуг?$format=json"
                + "&$select=Товары,Услуги"
                + "&$filter=DeletionMark eq false and Posted eq true";
            using HttpResponseMessage receiptGoodsServicesResponse = await httpClient.GetAsync(receiptGoodsServicesUrl);
            var receiptGoodsServices = await receiptGoodsServicesResponse.Content.ReadFromJsonAsync<ReceiptGoodsServices>();

            var purchaseGood = receiptGoodsServices.Value.Where(x => x.Goods.Length > 0).SelectMany(y => y.Goods)
                .Select(z => new PurchaseGoodAndService
                {
                    DocumentId = z.DocumentId,
                    ProductAndServiceId = z.NomenclatureId,
                    UnitId = z.UnitsOfMeasureId,
                    Quantity = z.Quantity,
                    Price = z.Price,
                    Amount = z.Amount,
                });

            var purchaseServices = receiptGoodsServices.Value.Where(x => x.Services.Length > 0).SelectMany(y => y.Services)
                .Select(z => new PurchaseGoodAndService
                {
                    DocumentId = z.DocumentId,
                    ProductAndServiceId = z.NomenclatureId,
                    UnitId = z.UnitsOfMeasureId,
                    Quantity = z.Quantity,
                    Price = z.Price,
                    Amount = z.Amount,
                });

            return purchaseGood.Concat(purchaseServices);
        }

        public async Task<IEnumerable<Contract>> ContractAsync() // Договоры контрагентов
        {
            var contractCounterpartiesUrl = ApiUrl + "Catalog_ДоговорыКонтрагентов?$format=json"
                + "&$select=Ref_Key,Номер,Description,Дата,Сумма,Owner_Key,НоменклатурнаяГруппа_Key,Code"
                + "&$filter=DeletionMark eq false";
            using HttpResponseMessage contractCounterpartiesResponse = await httpClient.GetAsync(contractCounterpartiesUrl);
            var contractCounterparties = await contractCounterpartiesResponse.Content.ReadFromJsonAsync<ContractCounterparties>();
            return contractCounterparties.Value.Select(x => new Contract
            {
                ContractId = x.ContractId,
                Date = x.Date ?? new DateTime(),
                Amount = x.Amount ?? 0,
                Number = x.Number,
                Name = x.Name,
                ContractorId = x.ContractorId,
                ProductGroupId = x.ProductGroupId,
                CodeContract = x.Code
            });
        }

        public async Task<IEnumerable<Contractor>> ContractorAsync() // Контрагенты
        {
            var counterpartyUrl = ApiUrl + "Catalog_Контрагенты?$format=json"
                + "&$select=Ref_Key,Description";
            using HttpResponseMessage counterpartyResponse = await httpClient.GetAsync(counterpartyUrl);
            var counterparty = await counterpartyResponse.Content.ReadFromJsonAsync<Counterparty>();
            return counterparty.Value.Select(x => new Contractor
            {
                ContractorId = x.Ref_Key,
                Name = x.Description
            });
        }

        public async Task<IEnumerable<SalesGoodAndService>> SalesGoodAndServiceAsync()
        {
            var saleGoodsServicesUrl = ApiUrl + "Document_РеализацияТоваровУслуг?$format=json"
                + "&$select=Товары,Услуги"
                + "&$filter=DeletionMark eq false and Posted eq true";
            using HttpResponseMessage saleGoodsServicesResponse = await httpClient.GetAsync(saleGoodsServicesUrl);
            var saleGoodsServices = await saleGoodsServicesResponse.Content.ReadFromJsonAsync<ReceiptGoodsServices>();

            var salesGood = saleGoodsServices.Value.Where(x => x.Goods.Length > 0).SelectMany(y => y.Goods)
                .Select(z => new SalesGoodAndService
                {
                    DocumentId = z.DocumentId,
                    ProductAndServiceId = z.NomenclatureId,
                    UnitId = z.UnitsOfMeasureId,
                    Quantity = z.Quantity,
                    Price = z.Price,
                    Amount = z.Amount,
                });

            var salesServices = saleGoodsServices.Value.Where(x => x.Services.Length > 0).SelectMany(y => y.Services)
                .Select(z => new SalesGoodAndService
                {
                    DocumentId = z.DocumentId,
                    ProductAndServiceId = z.NomenclatureId,
                    UnitId = z.UnitsOfMeasureId,
                    Quantity = z.Quantity,
                    Price = z.Price,
                    Amount = z.Amount,
                });

            return salesGood.Concat(salesServices);
        }

        public async Task<IEnumerable<Unit>> UnitAsync() // Единицы измерения
        {
            var unitOfMeasureUrl = ApiUrl + "Catalog_КлассификаторЕдиницИзмерения?$format=json"
                + "&$select=Ref_Key,Description"
                + "&$filter=DeletionMark eq false";
            using HttpResponseMessage unitOfMeasureResponse = await httpClient.GetAsync(unitOfMeasureUrl);
            var unitOfMeasure = await unitOfMeasureResponse.Content.ReadFromJsonAsync<UnitOfMeasure>();
            return unitOfMeasure.Value.Select(x => new Unit
            {
                UnitId = x.Ref_Key,
                Name = x.Description
            });
        }

        public async Task<IEnumerable<ProductAndService>> ProductAndServiceAsync() // Номенклатура
        {
            var nomenclatureUrl = ApiUrl + "Catalog_Номенклатура?$format=json"
                + "&$select=Ref_Key,Description"
                + "&$filter=DeletionMark eq false";
            using HttpResponseMessage nomenclatureResponse = await httpClient.GetAsync(nomenclatureUrl);
            var nomenclature = await nomenclatureResponse.Content.ReadFromJsonAsync<Nomenclature>();
            return nomenclature.Value.Select(x => new ProductAndService
            {
                ProductAndServiceId = x.Ref_Key,
                Name = x.Description
            });
        }

        public async Task<IEnumerable<Warehouse>> WarehouseAsync() // Склады
        {
            var storageUrl = ApiUrl + "Catalog_Склады?$format=json"
                + "&$select=Ref_Key,Description"
                + "&$filter=DeletionMark eq false";
            using HttpResponseMessage storageResponse = await httpClient.GetAsync(storageUrl);
            var storage = await storageResponse.Content.ReadFromJsonAsync<Storage>();
            return storage.Value.Select(x => new Warehouse
            {
                WarehouseId = x.Ref_Key,
                Name = x.Description
            });
        }

        public async Task<IEnumerable<CashFlowItem>> CashFlowItemAsync() // Статьи движения денежных средств
        {
            var cashFlowArticlesUrl = ApiUrl + "Catalog_СтатьиДвиженияДенежныхСредств?$format=json"
                + "&$select=Ref_Key,Description"
                + "&$filter=DeletionMark eq false";
            using HttpResponseMessage cashFlowArticlesResponse = await httpClient.GetAsync(cashFlowArticlesUrl);
            var cashFlowArticles = await cashFlowArticlesResponse.Content.ReadFromJsonAsync<CashFlowArticles>();
            return cashFlowArticles.Value.Select(x => new CashFlowItem
            {
                CashFlowItemId = x.Ref_Key,
                Name = x.Description
            });
        }

        public async Task<IEnumerable<ProductGroup>> ProductGroupAsync() // Номенклатурные группы
        {
            var nomenclatureGroupsUrl = ApiUrl + "Catalog_НоменклатурныеГруппы?$format=json"
                + "&$select=Ref_Key,Description"
                + "&$filter=DeletionMark eq false";
            using HttpResponseMessage nomenclatureGroupsResponse = await httpClient.GetAsync(nomenclatureGroupsUrl);
            var nomenclatureGroups = await nomenclatureGroupsResponse.Content.ReadFromJsonAsync<NomenclatureGroup>();
            return nomenclatureGroups.Value.Select(x => new ProductGroup
            {
                ProductGroupId = x.Ref_Key,
                Name = x.Description
            });
        }

        public async Task<IEnumerable<MoreInformation>> MoreInformationAsync() // Дополнительные сведения
        {
            var additionalInformationUrl = ApiUrl + "InformationRegister_ДополнительныеСведения?$format=json"
                + "&$select=Объект,Значение,Значение_Type";
            using HttpResponseMessage additionalInformationResponse = await httpClient.GetAsync(additionalInformationUrl);
            var additionalInformation = await additionalInformationResponse.Content.ReadFromJsonAsync<AdditionalInformation>();
            return additionalInformation.Value.Select(x => new MoreInformation
            {
                ObjectId = x.ObjectId,
                ObjectValue = x.ObjectValue,
                ValueType = x.ValueType
            });
        }

        public async Task<IEnumerable<PaymentDetails>> PaymentDetailsAsync() // Расшифровка платежа
        {
            var paymentExplanationUrl = ApiUrl + "Document_СписаниеСРасчетногоСчета?$format=json"
                + "&$select=РасшифровкаПлатежа"
                + "&$filter=DeletionMark eq false and Posted eq true";
            using HttpResponseMessage paymentExplanationResponse = await httpClient.GetAsync(paymentExplanationUrl);
            var paymentExplanation = await paymentExplanationResponse.Content.ReadFromJsonAsync<DebitToCurrentAccount>();

            return paymentExplanation.Value.Where(x => x.PaymentsExplanation.Length > 0).SelectMany(y => y.PaymentsExplanation)
                .Select(z => new PaymentDetails
                {
                    DocumentId = z.Ref_Key,
                    ContractId = z.ContractId,
                    InvoiceId = z.InvoiceId,
                    Amount = z.Amount
                });
        }

        public async Task<IEnumerable<CostItem>> CostItemAsync() // Статьи затрат
        {
            var expenseItemUrl = ApiUrl + "Catalog_СтатьиЗатрат?$format=json"
                + "&$select=Ref_Key,Description"
                + "&$filter=DeletionMark eq false";
            using HttpResponseMessage expenseItemResponse = await httpClient.GetAsync(expenseItemUrl);
            var expenseItem = await expenseItemResponse.Content.ReadFromJsonAsync<ExpenseItem>();
            return expenseItem.Value.Select(x => new CostItem
            {
                CostItemId = x.Ref_Key,
                Name = x.Description
            });
        }

        public async Task<IEnumerable<ConstructionCompletionCertificate>> ConstructionCompletionCertificateAsync() // Акты об окончании СМР
        {
            var constructionOrderUrl = ApiUrl + "Document_ИмпЗаказСМР?$format=json"
                + "&$select=ДатаНачала,ДатаОкончания,ДоговорКонтрагента_Key"
                + "&$filter=DeletionMark eq false and Posted eq true";
            using HttpResponseMessage constructionOrderResponse = await httpClient.GetAsync(constructionOrderUrl);
            var constructionOrder = await constructionOrderResponse.Content.ReadFromJsonAsync<ConstructionOrder>();
            return constructionOrder.Value.Select(x => new ConstructionCompletionCertificate
            {
                ContractId = x.ContractId,
                StartDate = x.StartDate,
                EndDate = x.EndDate
            });
        }
    }
}
