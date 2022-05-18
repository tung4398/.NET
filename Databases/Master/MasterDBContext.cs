using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Demo.Databases.Master
{
    public partial class MasterDBContext : DbContext
    {
        public MasterDBContext()
        {
        }

        public MasterDBContext(DbContextOptions<MasterDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; } = null!;
        public virtual DbSet<AccountInformation> AccountInformation { get; set; } = null!;
        public virtual DbSet<AccountWallet> AccountWallet { get; set; } = null!;
        public virtual DbSet<ClientVersion> ClientVersion { get; set; } = null!;
        public virtual DbSet<DepositHistory> DepositHistory { get; set; } = null!;
        public virtual DbSet<GameProvider> GameProvider { get; set; } = null!;
        public virtual DbSet<GsApiHistory> GsApiHistory { get; set; } = null!;
        public virtual DbSet<GsUserGameLink> GsUserGameLink { get; set; } = null!;
        public virtual DbSet<GsUserLink> GsUserLink { get; set; } = null!;
        public virtual DbSet<Notification> Notification { get; set; } = null!;
        public virtual DbSet<Operation> Operation { get; set; } = null!;
        public virtual DbSet<PaymentMethod> PaymentMethod { get; set; } = null!;
        public virtual DbSet<PaymentProvider> PaymentProvider { get; set; } = null!;
        public virtual DbSet<Platform> Platform { get; set; } = null!;
        public virtual DbSet<Position> Position { get; set; } = null!;
        public virtual DbSet<RequestWithdraw> RequestWithdraw { get; set; } = null!;
        public virtual DbSet<RequestWithdrawState> RequestWithdrawState { get; set; } = null!;
        public virtual DbSet<Session> Session { get; set; } = null!;
        public virtual DbSet<SessionState> SessionState { get; set; } = null!;
        public virtual DbSet<TransactionAction> TransactionAction { get; set; } = null!;
        public virtual DbSet<TransactionHistory> TransactionHistory { get; set; } = null!;
        public virtual DbSet<Translate> Translate { get; set; } = null!;
        public virtual DbSet<Wallet> Wallet { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Uuid, e.Username })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("account");

                entity.HasIndex(e => e.Code, "code")
                    .IsUnique();

                entity.HasIndex(e => e.PositionId, "position_id");

                entity.HasIndex(e => e.Uuid, "uuid")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(36)
                    .HasColumnName("uuid")
                    .IsFixedLength();

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .HasColumnName("username");

                entity.Property(e => e.Activate)
                    .HasColumnType("bit(1)")
                    .HasColumnName("activate")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .HasColumnName("code");

                entity.Property(e => e.Lock)
                    .HasColumnType("bit(1)")
                    .HasColumnName("lock")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.PositionId)
                    .HasColumnType("tinyint(4) unsigned")
                    .HasColumnName("position_id");

                entity.Property(e => e.TimeCreated)
                    .HasColumnType("timestamp")
                    .HasColumnName("time_created")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.TimeLastLogin)
                    .HasColumnType("timestamp")
                    .HasColumnName("time_last_login");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("account_ibfk_1");
            });

            modelBuilder.Entity<AccountInformation>(entity =>
            {
                entity.ToTable("account_information");

                entity.HasIndex(e => e.AccountUuid, "account_uuid");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.AccountUuid)
                    .HasMaxLength(36)
                    .HasColumnName("account_uuid")
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(255)
                    .HasColumnName("phone_number");

                entity.Property(e => e.Trc20WalletAddress)
                    .HasMaxLength(255)
                    .HasColumnName("trc_20_wallet_address");

                entity.HasOne(d => d.AccountUu)
                    .WithMany(p => p.AccountInformation)
                    .HasPrincipalKey(p => p.Uuid)
                    .HasForeignKey(d => d.AccountUuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("account_information_ibfk_1");
            });

            modelBuilder.Entity<AccountWallet>(entity =>
            {
                entity.ToTable("account_wallet");

                entity.HasIndex(e => e.AccountUuid, "account_uuid");

                entity.HasIndex(e => e.WalletId, "balance_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.AccountUuid)
                    .HasMaxLength(36)
                    .HasColumnName("account_uuid")
                    .IsFixedLength();

                entity.Property(e => e.Amount)
                    .HasPrecision(15, 4)
                    .HasColumnName("amount");

                entity.Property(e => e.WalletId)
                    .HasColumnType("tinyint(4) unsigned")
                    .HasColumnName("wallet_id");

                entity.HasOne(d => d.AccountUu)
                    .WithMany(p => p.AccountWallet)
                    .HasPrincipalKey(p => p.Uuid)
                    .HasForeignKey(d => d.AccountUuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("account_wallet_ibfk_1");

                entity.HasOne(d => d.Wallet)
                    .WithMany(p => p.AccountWallet)
                    .HasForeignKey(d => d.WalletId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("account_wallet_ibfk_2");
            });

            modelBuilder.Entity<ClientVersion>(entity =>
            {
                entity.ToTable("_client_version");

                entity.Property(e => e.Id)
                    .HasColumnType("tinyint(4) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<DepositHistory>(entity =>
            {
                entity.ToTable("deposit_history");

                entity.HasIndex(e => e.AccountUuid, "account_uuid");

                entity.HasIndex(e => e.Method, "method");

                entity.HasIndex(e => e.Provider, "provider");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.AccountUuid)
                    .HasMaxLength(36)
                    .HasColumnName("account_uuid")
                    .IsFixedLength();

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(15,4) unsigned")
                    .HasColumnName("amount");

                entity.Property(e => e.Data)
                    .HasColumnType("text")
                    .HasColumnName("data");

                entity.Property(e => e.Method)
                    .HasColumnType("tinyint(4) unsigned")
                    .HasColumnName("method");

                entity.Property(e => e.Provider)
                    .HasColumnType("tinyint(4) unsigned")
                    .HasColumnName("provider");

                entity.Property(e => e.TimeCreated)
                    .HasColumnType("timestamp")
                    .HasColumnName("time_created")
                    .HasDefaultValueSql("current_timestamp()");

                entity.HasOne(d => d.AccountUu)
                    .WithMany(p => p.DepositHistory)
                    .HasPrincipalKey(p => p.Uuid)
                    .HasForeignKey(d => d.AccountUuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("deposit_history_ibfk_1");

                entity.HasOne(d => d.MethodNavigation)
                    .WithMany(p => p.DepositHistory)
                    .HasForeignKey(d => d.Method)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("deposit_history_ibfk_2");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.DepositHistory)
                    .HasForeignKey(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("deposit_history_ibfk_3");
            });

            modelBuilder.Entity<GameProvider>(entity =>
            {
                entity.ToTable("_game_provider");

                entity.Property(e => e.Id)
                    .HasColumnType("tinyint(4) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<GsApiHistory>(entity =>
            {
                entity.ToTable("gs_api_history");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Api)
                    .HasColumnType("text")
                    .HasColumnName("api");

                entity.Property(e => e.RequestData)
                    .HasColumnType("text")
                    .HasColumnName("request_data");

                entity.Property(e => e.ResponseData)
                    .HasColumnType("text")
                    .HasColumnName("response_data");

                entity.Property(e => e.TimeCreated)
                    .HasColumnType("timestamp")
                    .HasColumnName("time_created")
                    .HasDefaultValueSql("current_timestamp()");
            });

            modelBuilder.Entity<GsUserGameLink>(entity =>
            {
                entity.ToTable("gs_user_game_link");

                entity.HasIndex(e => e.GsuserUuid, "gsuser_uuid");

                entity.HasIndex(e => e.Provider, "provider");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.GsuserUuid)
                    .HasMaxLength(36)
                    .HasColumnName("gsuser_uuid")
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.Provider)
                    .HasColumnType("tinyint(4) unsigned")
                    .HasColumnName("provider");

                entity.Property(e => e.TimeCreated)
                    .HasColumnType("timestamp")
                    .HasColumnName("time_created")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .HasColumnName("username");

                entity.HasOne(d => d.GsuserUu)
                    .WithMany(p => p.GsUserGameLink)
                    .HasPrincipalKey(p => p.Uuid)
                    .HasForeignKey(d => d.GsuserUuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gs_user_game_link_ibfk_2");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.GsUserGameLink)
                    .HasForeignKey(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gs_user_game_link_ibfk_1");
            });

            modelBuilder.Entity<GsUserLink>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Uuid })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("gs_user_link");

                entity.HasIndex(e => e.Uuid, "uuid")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(36)
                    .HasColumnName("uuid")
                    .IsFixedLength();

                entity.Property(e => e.AccountUuid)
                    .HasMaxLength(36)
                    .HasColumnName("account_uuid")
                    .IsFixedLength();

                entity.Property(e => e.TimeCreated)
                    .HasColumnType("timestamp")
                    .HasColumnName("time_created")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("notification");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.Property(e => e.IsEnable)
                    .HasColumnType("bit(1)")
                    .HasColumnName("is_enable")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.TimeCreated)
                    .HasColumnType("timestamp")
                    .HasColumnName("time_created")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.TimeEnd)
                    .HasColumnType("timestamp")
                    .HasColumnName("time_end");

                entity.Property(e => e.TimeStart)
                    .HasColumnType("timestamp")
                    .HasColumnName("time_start");

                entity.Property(e => e.Title)
                    .HasColumnType("text")
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Operation>(entity =>
            {
                entity.ToTable("_operation");

                entity.Property(e => e.Id)
                    .HasColumnType("tinyint(4) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.ToTable("_payment_method");

                entity.Property(e => e.Id)
                    .HasColumnType("tinyint(4) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<PaymentProvider>(entity =>
            {
                entity.ToTable("_payment_provider");

                entity.Property(e => e.Id)
                    .HasColumnType("tinyint(4) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Platform>(entity =>
            {
                entity.ToTable("_platform");

                entity.Property(e => e.Id)
                    .HasColumnType("tinyint(4) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("_position");

                entity.Property(e => e.Id)
                    .HasColumnType("tinyint(4) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<RequestWithdraw>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Uuid })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("request_withdraw");

                entity.HasIndex(e => e.AccountUuid, "account_uuid");

                entity.HasIndex(e => e.Method, "method");

                entity.HasIndex(e => e.State, "state");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(36)
                    .HasColumnName("uuid")
                    .IsFixedLength();

                entity.Property(e => e.AccountUuid)
                    .HasMaxLength(36)
                    .HasColumnName("account_uuid")
                    .IsFixedLength();

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(15,4) unsigned")
                    .HasColumnName("amount");

                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .HasColumnName("code");

                entity.Property(e => e.Data)
                    .HasColumnType("text")
                    .HasColumnName("data");

                entity.Property(e => e.Fee)
                    .HasColumnType("decimal(15,4) unsigned")
                    .HasColumnName("fee");

                entity.Property(e => e.Method)
                    .HasColumnType("tinyint(4) unsigned")
                    .HasColumnName("method");

                entity.Property(e => e.Note)
                    .HasColumnType("text")
                    .HasColumnName("note");

                entity.Property(e => e.RefundState)
                    .HasColumnType("bit(1)")
                    .HasColumnName("refund_state")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.State)
                    .HasColumnType("tinyint(4) unsigned")
                    .HasColumnName("state");

                entity.Property(e => e.TimeCreated)
                    .HasColumnType("timestamp")
                    .HasColumnName("time_created")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.TimeDecide)
                    .HasColumnType("timestamp")
                    .HasColumnName("time_decide");

                entity.HasOne(d => d.AccountUu)
                    .WithMany(p => p.RequestWithdraw)
                    .HasPrincipalKey(p => p.Uuid)
                    .HasForeignKey(d => d.AccountUuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("request_withdraw_ibfk_3");

                entity.HasOne(d => d.MethodNavigation)
                    .WithMany(p => p.RequestWithdraw)
                    .HasForeignKey(d => d.Method)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("request_withdraw_ibfk_1");

                entity.HasOne(d => d.StateNavigation)
                    .WithMany(p => p.RequestWithdraw)
                    .HasForeignKey(d => d.State)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("request_withdraw_ibfk_2");
            });

            modelBuilder.Entity<RequestWithdrawState>(entity =>
            {
                entity.ToTable("_request_withdraw_state");

                entity.HasIndex(e => e.Translate, "translate");

                entity.Property(e => e.Id)
                    .HasColumnType("tinyint(4) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Translate)
                    .HasColumnType("tinyint(4) unsigned")
                    .HasColumnName("translate");

                entity.HasOne(d => d.TranslateNavigation)
                    .WithMany(p => p.RequestWithdrawState)
                    .HasForeignKey(d => d.Translate)
                    .HasConstraintName("_request_withdraw_state_ibfk_1");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("session");

                entity.HasIndex(e => e.AccountUuid, "account_uuid");

                entity.HasIndex(e => e.Operation, "operation");

                entity.HasIndex(e => e.Platform, "platform");

                entity.HasIndex(e => e.State, "state");

                entity.HasIndex(e => e.Token, "token")
                    .IsUnique();

                entity.HasIndex(e => e.Version, "version");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.AccountUuid)
                    .HasMaxLength(36)
                    .HasColumnName("account_uuid")
                    .IsFixedLength();

                entity.Property(e => e.Device)
                    .HasMaxLength(255)
                    .HasColumnName("device");

                entity.Property(e => e.Operation)
                    .HasColumnType("tinyint(4) unsigned")
                    .HasColumnName("operation");

                entity.Property(e => e.Platform)
                    .HasColumnType("tinyint(4) unsigned")
                    .HasColumnName("platform");

                entity.Property(e => e.State)
                    .HasColumnType("tinyint(4) unsigned")
                    .HasColumnName("state");

                entity.Property(e => e.TimeCreated)
                    .HasColumnType("timestamp")
                    .HasColumnName("time_created")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.TimeExpired)
                    .HasColumnType("timestamp")
                    .HasColumnName("time_expired");

                entity.Property(e => e.TimeLastAction)
                    .HasColumnType("timestamp")
                    .HasColumnName("time_last_action");

                entity.Property(e => e.Token)
                    .HasMaxLength(100)
                    .HasColumnName("token");

                entity.Property(e => e.Version)
                    .HasColumnType("tinyint(4) unsigned")
                    .HasColumnName("version");

                entity.HasOne(d => d.AccountUu)
                    .WithMany(p => p.Session)
                    .HasPrincipalKey(p => p.Uuid)
                    .HasForeignKey(d => d.AccountUuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("session_ibfk_1");

                entity.HasOne(d => d.OperationNavigation)
                    .WithMany(p => p.Session)
                    .HasForeignKey(d => d.Operation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("session_ibfk_5");

                entity.HasOne(d => d.PlatformNavigation)
                    .WithMany(p => p.Session)
                    .HasForeignKey(d => d.Platform)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("session_ibfk_3");

                entity.HasOne(d => d.StateNavigation)
                    .WithMany(p => p.Session)
                    .HasForeignKey(d => d.State)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("session_ibfk_2");

                entity.HasOne(d => d.VersionNavigation)
                    .WithMany(p => p.Session)
                    .HasForeignKey(d => d.Version)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("session_ibfk_4");
            });

            modelBuilder.Entity<SessionState>(entity =>
            {
                entity.ToTable("_session_state");

                entity.Property(e => e.Id)
                    .HasColumnType("tinyint(4) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<TransactionAction>(entity =>
            {
                entity.ToTable("_transaction_action");

                entity.HasIndex(e => e.Translate, "translate");

                entity.Property(e => e.Id)
                    .HasColumnType("tinyint(4) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Default)
                    .HasMaxLength(255)
                    .HasColumnName("default");

                entity.Property(e => e.Translate)
                    .HasColumnType("tinyint(4) unsigned")
                    .HasColumnName("translate");

                entity.HasOne(d => d.TranslateNavigation)
                    .WithMany(p => p.TransactionAction)
                    .HasForeignKey(d => d.Translate)
                    .HasConstraintName("_transaction_action_ibfk_1");
            });

            modelBuilder.Entity<TransactionHistory>(entity =>
            {
                entity.ToTable("transaction_history");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.AccountUuid)
                    .HasMaxLength(36)
                    .HasColumnName("account_uuid")
                    .IsFixedLength();

                entity.Property(e => e.Action)
                    .HasColumnType("tinyint(4) unsigned")
                    .HasColumnName("action");

                entity.Property(e => e.Balance)
                    .HasPrecision(15, 4)
                    .HasColumnName("balance");

                entity.Property(e => e.Changed)
                    .HasPrecision(15, 4)
                    .HasColumnName("changed");

                entity.Property(e => e.Note)
                    .HasColumnType("text")
                    .HasColumnName("note");

                entity.Property(e => e.TimeCreated)
                    .HasColumnType("timestamp")
                    .HasColumnName("time_created")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Wallet)
                    .HasColumnType("tinyint(4) unsigned")
                    .HasColumnName("wallet");
            });

            modelBuilder.Entity<Translate>(entity =>
            {
                entity.ToTable("_translate");

                entity.Property(e => e.Id)
                    .HasColumnType("tinyint(4) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.En)
                    .HasColumnType("text")
                    .HasColumnName("en");

                entity.Property(e => e.Vi)
                    .HasColumnType("text")
                    .HasColumnName("vi");
            });

            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.ToTable("_wallet");

                entity.Property(e => e.Id)
                    .HasColumnType("tinyint(4) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Unit)
                    .HasMaxLength(10)
                    .HasColumnName("unit");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
