namespace GoInsp.Core
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Model;

    public partial class AppContext : DbContext
    {
        #region Fields

        private static AppContext _instance;

        #endregion


        #region Constructors

        public AppContext()
            : base("name=GoInsp")
        {

        }

        #endregion


        #region Properties

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<AnswerInstance> AnswerInstances { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Inspection> Inspections { get; set; }
        public virtual DbSet<InspectionType> InspectionTypes { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Node> Nodes { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionInstance> QuestionInstances { get; set; }
        public virtual DbSet<QuestionType> QuestionTypes { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleNode> RoleNodes { get; set; }
        public virtual DbSet<Template> Templates { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        public static AppContext Instance
        {
            get
            {
                return _instance ?? (_instance = new AppContext());
            }
        }

        #endregion


        #region Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>()
                .Property(e => e.AnswerTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Answer>()
                .Property(e => e.AnswerDescription)
                .IsUnicode(false);

            modelBuilder.Entity<AnswerInstance>()
                .Property(e => e.AnswerInstanceTitle)
                .IsUnicode(false);

            modelBuilder.Entity<AnswerInstance>()
                .Property(e => e.AnswerInstanceDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Inspections)
                .WithOptional(e => e.Company)
                .HasForeignKey(e => e.InspectionCompanyID);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Company)
                .HasForeignKey(e => e.UserCompanyID);

            modelBuilder.Entity<Inspection>()
                .Property(e => e.InspectionTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Inspection>()
                .Property(e => e.InspectionDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Inspection>()
                .HasMany(e => e.Files)
                .WithRequired(e => e.Inspection)
                .HasForeignKey(e => e.FileInspectionID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Inspection>()
                .HasMany(e => e.Locations)
                .WithRequired(e => e.Inspection)
                .HasForeignKey(e => e.LocationInspectionID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Inspection>()
                .HasMany(e => e.QuestionInstances)
                .WithRequired(e => e.Inspection)
                .HasForeignKey(e => e.QuestionInstanceInspectionID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InspectionType>()
                .HasMany(e => e.Inspections)
                .WithRequired(e => e.InspectionType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.LocationTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.LocationDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Node>()
                .HasMany(e => e.RoleNodes)
                .WithRequired(e => e.Node)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.QuestionTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.QuestionDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.Answers)
                .WithRequired(e => e.Question)
                .HasForeignKey(e => e.AnswerQuestionID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuestionInstance>()
                .Property(e => e.QuestionInstanceTitle)
                .IsUnicode(false);

            modelBuilder.Entity<QuestionInstance>()
                .Property(e => e.QuestionInstanceDescription)
                .IsUnicode(false);

            modelBuilder.Entity<QuestionInstance>()
                .Property(e => e.QuestionInstanceValue)
                .IsUnicode(false);

            modelBuilder.Entity<QuestionInstance>()
                .Property(e => e.QuestionInstanceComment)
                .IsUnicode(false);

            modelBuilder.Entity<QuestionInstance>()
                .HasMany(e => e.AnswerInstances)
                .WithRequired(e => e.QuestionInstance)
                .HasForeignKey(e => e.AnswerInstanceQuestionInstanceID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuestionType>()
                .HasMany(e => e.Questions)
                .WithRequired(e => e.QuestionType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Region>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Region)
                .HasForeignKey(e => e.UserRegionID);

            modelBuilder.Entity<Role>()
                .Property(e => e.RoleDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.RoleNodes)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.UserRoles)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Template>()
                .Property(e => e.TemplateDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Template>()
                .HasMany(e => e.Questions)
                .WithRequired(e => e.Template)
                .HasForeignKey(e => e.QuestionTemplateID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Inspections)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.InspectionUserID);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Templates)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.TemplateUserID);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserRoles)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }

        #endregion
    }
}
