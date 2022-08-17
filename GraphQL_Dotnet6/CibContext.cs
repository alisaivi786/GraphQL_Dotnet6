using Microsoft.EntityFrameworkCore;

namespace GraphQL_Dotnet6
{
    public class CibContext : DbContext
    {
        public CibContext(DbContextOptions<CibContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyMember> CompanyMembers { get; set; }
        public DbSet<CompanyMemberPermission> CompanyMemberPermissions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SubProduct> SubProducts { get; set; }
    }
    public class Company
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Inn { get; set; }
        public string? Status { get; set; }
        public DateTime EstablishmentDate { get; set; }
        public ICollection<CompanyMember>? CompanyMembers { get; set; }
    }
    public class CompanyMember
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Pin { get; set; }
        public string? Status { get; set; }
        public CompanyMemberRole Role { get; set; }
        public DateTime MembershipDate { get; set; }
        public ICollection<CompanyMemberPermission>? Permissions { get; set; }
    }
    public enum CompanyMemberRole
    {
        Admin,
        Accountant
    }
    public class CompanyMemberPermission
    {
        public int Id { get; set; }
        public string? ProductCode { get; set; }
        public string? SubProductCode { get; set; }
        public string? Status { get; set; }
    }
    public class Product
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public ICollection<SubProduct>? SubProducts { get; set; }
    }
    public class SubProduct
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public Product? Product { get; set; }
    }
}
