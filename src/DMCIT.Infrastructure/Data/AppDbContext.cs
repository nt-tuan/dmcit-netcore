using DMCIT.Core.Entities;
using DMCIT.Core.Entities.Accounting;
using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.DataCollector;
using DMCIT.Core.Entities.DataSynchronize;
using DMCIT.Core.Entities.Events;
using DMCIT.Core.Entities.Messaging;
using DMCIT.Core.Entities.Posts;
using DMCIT.Core.Entities.Processes;
using DMCIT.Core.Entities.Reports;
using DMCIT.Core.Entities.Sales;
using DMCIT.Core.Entities.SupportRequests;
using DMCIT.Core.Entities.Templates;
using DMCIT.Core.Entities.Workflow;
using DMCIT.Infrastructure.Data.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        #region CORE ENTITIES
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<AccountingPeriod> AccountingPeriods { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTitle> EmployeeTitles { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Tag> Tags { get; set; }

        private void onCoreModelCreating(ModelBuilder modelBuilder)
        {
            var coreConf = new CoreConfiguration();
            coreConf.ConfigureAll(modelBuilder);
        }
        #endregion
        #region DISTRIBUTED SERVERS
        public DbSet<DistributedServer> DistributedServers { get; set; }
        public DbSet<DistributedServerTableDefined> DistributedServerDefinedTable { get; set; }
        private void onDistributedCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BaseVSConfiguration<DistributedServer>());
            modelBuilder.ApplyConfiguration(new BaseVSConfiguration<DistributedServerTableDefined>());
            modelBuilder.Entity<DistributedServerTableDefined>().HasOne(u => u.DistributedServer)
                .WithMany(u => u.DistributedServerTableDefineds)
                .HasForeignKey(u => u.DistributedServerId);
            modelBuilder.Entity<DistributedServer>().HasIndex(u => u.DistributorCode);
        }
        #endregion
        #region MESSAGING ENTITIES
        public DbSet<AutoMessageConfig> AutoMessageConfigs { get; set; }
        public DbSet<AutoMessageConfigMessageReceiver> AutoMesasgeConfigMessageReceivers { get; set; }
        public DbSet<AutoMessageConfigMessageReceiverGroup> AutoMessageConfigMessageReceiverGroups { get; set; }
        public DbSet<AutoMessageConfigProvider> AutoMessageConfigProviders { get; set; }
        public DbSet<MessageReceiver> MessageReceivers { get; set; }
        public DbSet<MessageReceiverGroup> MessageReceiverGroups { get; set; }
        public DbSet<MessageReceiverGroupMessageReceiver> MessageReceiverGroupMessageReceivers { get; set; }
        public DbSet<MessageServiceProvider> MessageServiceProviders { get; set; }
        public DbSet<ReceiverCategory> ReceiverCategories { get; set; }
        public DbSet<ReceiverProvider> ReceiverProviders { get; set; }
        public DbSet<SentMessage> SentMessages { get; set; }
        public DbSet<MessageSource> MessageSources { get; set; }
        public DbSet<MessageBatch> MessageBatches { get; set; }
        private void onMessageModelCreating(ModelBuilder modelBuilder)
        {
            var receiverConf = new MessagingConfiguration();
            receiverConf.ConfigureAll(modelBuilder);
        }
        #endregion
        #region SALES ENTITIES
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Distributor> Distributors { get; set; }
        private void onSaleModelCreating(ModelBuilder modelBuilder)
        {
            var saleConf = new SaleConfiguration();
            saleConf.ConfigureAll(modelBuilder);
        }

        #endregion
        #region ACCOUNTING ENTITIES
        public DbSet<Diary131> Diary131s { get; set; }
        public DbSet<CustomerAR> CustomerARs { get; set; }
        public DbSet<CustomerARNow> CustomerARNows { get; set; }
        public DbSet<CustomerPayment> CustomerPayments { get; set; }
        private void onAccountingModelCreating(ModelBuilder modelBuilder)
        {
            var accountingConf = new AccountingConfigurations();
            accountingConf.ConfigureAll(modelBuilder);
        }
        #endregion
        #region SYSTEM JOBS
        public DbSet<BackgroundProcess> BackgroundProcesses { get; set; }
        public DbSet<SendingMessageJob> SendingMessageJobs { get; set; }
        public DbSet<EventEntity> Events { get; set; }
        private void onBackgroundProcessModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BackgroundProcess>().Property(u => u.Id).ValueGeneratedOnAdd();
        }
        #endregion
        #region TEMPLATE
        public DbSet<Template> Templates { get; set; }
        public DbSet<TemplateParser> TemplateParsers { get; set; }
        private void OnTemplateModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Template>().HasIndex(u => new { u.ModelName }).IsUnique();
            modelBuilder.Entity<TemplateParser>().HasIndex(u => u.ClassName).IsUnique();
        }
        #endregion
        #region WORKFLOW
        public DbSet<DefinedWorkflow> DefinedWorkflows { get; set; }
        public DbSet<HistoryWorkflowEntry> HistoryWorkflowEntries { get; set; }
        public DbSet<StatusCount> StatusCounts { get; set; }
        public DbSet<UserWorkflow> UserWorkflows { get; set; }
        public DbSet<WorkflowEntry> WorkflowEntries { get; set; }

        private void OnWorkflowModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserWorkflow>().HasOne(u => u.DefinedWorkflow).WithMany(u => u.UserWorkflows).HasForeignKey(u => u.DefinedWorkflowId);
            modelBuilder.Entity<UserWorkflow>().HasOne(u => u.AppUser).WithMany().HasForeignKey(u => u.AppUserId);
            modelBuilder.Entity<UserWorkflow>().HasKey(u => new { u.AppUserId, u.DefinedWorkflowId });
            modelBuilder.Entity<UserWorkflow>().Ignore(u => u.Id);
        }
        #endregion
        #region SUPPORT REQUEST ENTITIES
        public DbSet<SupportRequest> SupportRequests { get; set; }
        public DbSet<SupportAssistant> SupportAssistants { get; set; }
        private void OnSupportRequestModelCreating(ModelBuilder modelBuilder)
        {
            var conf = new SupportRequestConfiguration();
            conf.ConfigureAll(modelBuilder);
        }
        #endregion
        #region POST ENTITIES
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostAccessUser> PostAccessUsers { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostCategoryRelation> PostCategoryRelations { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<PostCommentRelation> PostCommentLevel2s { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        private void OnPostModelCreating(ModelBuilder modelBuilder)
        {
            var conf = new PostConfiguration();
            conf.ConfigureAll(modelBuilder);
        }
        #endregion
        public override async Task<int> SaveChangesAsync(CancellationToken token = default)
        {
            try
            {
                var result = await base.SaveChangesAsync(token);

                DetachAllEntities();
                return result;
            }
            catch (Exception e)
            {
                DetachAllEntities();
                throw e;
            }
        }
        public override int SaveChanges()
        {
            int result = base.SaveChanges();

            // dispatch events only if save was successful

            DetachAllEntities();
            return result;
        }

        public void DetachAllEntities()
        {
            var changedEntriesCopy = this.ChangeTracker.Entries()
    .ToList();
            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //apply version control constraints
            onCoreModelCreating(modelBuilder);
            onSaleModelCreating(modelBuilder);
            onAccountingModelCreating(modelBuilder);
            onMessageModelCreating(modelBuilder);
            onDistributedCreating(modelBuilder);
            onBackgroundProcessModelCreating(modelBuilder);
            OnWorkflowModelCreating(modelBuilder);
            OnSupportRequestModelCreating(modelBuilder);
            OnPostModelCreating(modelBuilder);
            OnTemplateModelCreating(modelBuilder);
        }
    }
}