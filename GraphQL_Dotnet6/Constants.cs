namespace GraphQL_Dotnet6
{
    public class Constants
    {
        public const string ProductCodeTransfer = "TRANSFER";
        public const string SubProductCodeTransferWithInBank = "WITHIN_BANK";
        public const string SubProductCodeTransferWithInCountry = "WITHIN_COUNTRY";
        public const string SubProductCodeTransferForeign = "WITHIN_FOREIGN";

        public const string StatusActive = "A";
    }

    public static class DatabaseSeeder
    {
        public static async Task SeedAsync(CibContext context)
        {
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            await context.Products.AddAsync(new Product
            {
                Code = Constants.ProductCodeTransfer,
                Description = "Transfer permission",
                Status = Constants.StatusActive,
                SubProducts = new List<SubProduct>
            {
                new()
                {
                    Code = Constants.SubProductCodeTransferWithInBank, Description = "Transfer in bank",
                    Status = Constants.StatusActive
                },
                new()
                {
                    Code = Constants.SubProductCodeTransferWithInCountry, Description = "Transfer in country",
                    Status = Constants.StatusActive
                },
                new()
                {
                    Code = Constants.SubProductCodeTransferForeign, Description = "Transfer outside country",
                    Status = Constants.StatusActive
                },
            }
            });

            await context.Companies.AddAsync(new Company
            {
                Inn = "182987456",
                Name = "Company 1",
                Status = Constants.StatusActive,
                EstablishmentDate = DateTime.Now.AddYears(-2),
                CompanyMembers = new List<CompanyMember>
                {
                    new()
                    {
                        Name = "John",
                        Pin = "21837128362",
                        Role = CompanyMemberRole.Accountant,
                        Status = Constants.StatusActive,
                        MembershipDate = DateTime.Now.AddYears(-1),
                        Permissions = new List<CompanyMemberPermission>
                        {
                            new()
                            {
                                Status = Constants.StatusActive, ProductCode = Constants.ProductCodeTransfer,
                                SubProductCode = Constants.SubProductCodeTransferWithInBank
                            },
                            new()
                            {
                                Status = Constants.StatusActive, ProductCode = Constants.ProductCodeTransfer,
                                SubProductCode = Constants.SubProductCodeTransferWithInCountry
                            },
                            new()
                            {
                                Status = Constants.StatusActive, ProductCode = Constants.ProductCodeTransfer,
                                SubProductCode = Constants.SubProductCodeTransferForeign
                            },
                        }
                    },
                    new()
                    {
                        Name = "Michael",
                        Pin = "19237782364",
                        Role = CompanyMemberRole.Admin,
                        Status = Constants.StatusActive,
                        MembershipDate = DateTime.Now.AddYears(-2)
                    },
                }
            });

            await context.Companies.AddAsync(new Company
            {
                Inn = "712863924",
                Name = "Company 2",
                Status = Constants.StatusActive,
                EstablishmentDate = DateTime.Now.AddYears(-3),
                CompanyMembers = new List<CompanyMember>
            {
                new()
                {
                    Name = "David",
                    Pin = "45691428512",
                    Role = CompanyMemberRole.Admin,
                    Status = Constants.StatusActive,
                    MembershipDate = DateTime.Now.AddYears(-3),
                    Permissions = new List<CompanyMemberPermission>
                    {
                        new()
                        {
                            Status = Constants.StatusActive, ProductCode = Constants.ProductCodeTransfer,
                            SubProductCode = Constants.SubProductCodeTransferWithInBank
                        },
                        new()
                        {
                            Status = Constants.StatusActive, ProductCode = Constants.ProductCodeTransfer,
                            SubProductCode = Constants.SubProductCodeTransferWithInCountry
                        },
                        new()
                        {
                            Status = Constants.StatusActive, ProductCode = Constants.ProductCodeTransfer,
                            SubProductCode = Constants.SubProductCodeTransferForeign
                        },
                    }
                },
            }
            });

            await context.SaveChangesAsync();
        }
    }
}
