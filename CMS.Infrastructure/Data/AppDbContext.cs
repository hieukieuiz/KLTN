using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.SharedKernel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CMS.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>,
        ApplicationUserRole, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        private readonly IDomainEventDispatcher _dispatcher;
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options, IDomainEventDispatcher dispatcher)
               : base(options)
        {
            _dispatcher = dispatcher;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLazyLoadingProxies();
        }
        //public DbSet<HocVien> HocVien { get; set; }
        public DbSet<TinhThanh> TinhThanh { get; set; }
        public DbSet<QuanHuyen> QuanHuyen { get; set; }
        public DbSet<XaPhuong> XaPhuong { get; set; }
        public DbSet<TruongDaiHoc> TruongDaiHoc { get; set; }
        //public DbSet<DuAn> DuAn { get; set; }
       // public DbSet<TrangThaiDuAn> TrangThaiDuAn { get; set; }
        public DbSet<TrangThai> TrangThai { get; set; }
        //public DbSet<Quyen> Quyen { get; set; }
        //public DbSet<LichSuChiTietCongViec> LichSuChiTietCongViec { get; set; }
        //public DbSet<QuyenDuAn> QuyenDuAn { get; set; }
        //public DbSet<CongViec> CongViec { get; set; }
        //public DbSet<ChiTietCongViec> ChiTietCongViec { get; set; }
        //public DbSet<ThanhVienDuAn> ThanhVienDuAn { get; set; }
        //public DbSet<PhanViec> PhanViec { get; set; }
       // public DbSet<BaoCao> BaoCao { get; set; }
        public DbSet<BaiTestTuyenDung> LoaiCongViec { get; set; }
        public DbSet<BaiTuyenDung> BaiTuyenDung { get; set; }
        public DbSet<BangCapUngVien> BangCapUngVien { get; set; }
        public DbSet<CVUngVien> CVUngVien { get; set; }
        public DbSet<DanhGiaChungUngVien> DanhGiaChungUngVien { get; set; }
        public DbSet<DoanhNghiep> DoanhNghiep { get; set; }
        public DbSet<KyNang> KyNang { get; set; }
        public DbSet<KyNangUngVien> KyNangUngVien { get; set; }
        public DbSet<LoaiYeuCau> LoaiYeuCau { get; set; }
        public DbSet<FileUpload> FileUpload { get; set; }
        public DbSet<NhomKyNang> NhomKyNang { get; set; }
        public DbSet<QuaTrinhHocTap> QuaTrinhHocTap { get; set; }
        public DbSet<QuaTrinhLamDuAn> QuaTrinhLamDuAn { get; set; }
        public DbSet<UngTuyen> UngTuyen { get; set; }
        public DbSet<UngVien> UngVien { get; set; }
        public DbSet<UngVienLamBaiTest> UngVienLamBaiTest { get; set; }
        public DbSet<YeuCau> YeuCau { get; set; }
        //public DbSet<LoaiCongViec> LoaiCongViec { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }
        private void Dispatch()
        {
            // ignore events if no dispatcher provided
            if (_dispatcher == null) return;
            // dispatch events only if save was successful
            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.Events.ToArray();
                entity.Events.Clear();
                foreach (var domainEvent in events)
                {
                    _dispatcher.Dispatch(domainEvent);
                }
            }

        }
        public override int SaveChanges()
        {
            int result = base.SaveChanges();
            Dispatch();
            return result;
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            int result = await base.SaveChangesAsync();

            Dispatch();

            return result;
        }
    }
}
