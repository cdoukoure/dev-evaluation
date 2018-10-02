using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPI.Models
{
    public partial class IntegrationCharlesDoukoureDevEvalContext : DbContext
    {
        public IntegrationCharlesDoukoureDevEvalContext()
        {
        }

        public IntegrationCharlesDoukoureDevEvalContext(DbContextOptions<IntegrationCharlesDoukoureDevEvalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectTask> ProjectTask { get; set; }
        public virtual DbSet<ProjectTaskActionCollaborator> ProjectTaskActionCollaborator { get; set; }
        public virtual DbSet<ProjectTaskActionManager> ProjectTaskActionManager { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=DESKTOP-8302UEE;Database=IntegrationCharlesDoukoureDevEval;Trusted_Connection=True;MultipleActiveResultSets=true");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.UpdateBy).HasColumnName("update_by");

                entity.Property(e => e.UpdateOn)
                    .HasColumnName("update_on")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.PermissionCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Create_Permission");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Permission)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_Permission");

                entity.HasOne(d => d.UpdateByNavigation)
                    .WithMany(p => p.PermissionUpdateByNavigation)
                    .HasForeignKey(d => d.UpdateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Update_Permission");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ProjectCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Create_Project");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.ProjectUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Update_Project");
            });

            modelBuilder.Entity<ProjectTask>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasColumnType("datetime");

                entity.Property(e => e.Deadline)
                    .HasColumnName("deadline")
                    .HasColumnType("datetime");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("text");

                entity.Property(e => e.Priority)
                    .IsRequired()
                    .HasColumnName("priority")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.Sequence)
                    .IsRequired()
                    .HasColumnName("sequence")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TimeElapsed).HasColumnName("time_elapsed");

                entity.Property(e => e.TimePlanned).HasColumnName("time_planned");

                entity.Property(e => e.TimeRemaining).HasColumnName("time_remaining");

                entity.Property(e => e.UpdateBy).HasColumnName("update_by");

                entity.Property(e => e.UpdateOn)
                    .HasColumnName("update_on")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ProjectTaskCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Create_ProjectTask");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectTask)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Project_ProjectTask");

                entity.HasOne(d => d.UpdateByNavigation)
                    .WithMany(p => p.ProjectTaskUpdateByNavigation)
                    .HasForeignKey(d => d.UpdateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Update_ProjectTask");
            });

            modelBuilder.Entity<ProjectTaskActionCollaborator>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasColumnType("datetime");

                entity.Property(e => e.DatetimeEnd)
                    .HasColumnName("datetime_end")
                    .HasColumnType("datetime");

                entity.Property(e => e.DatetimeStart)
                    .HasColumnName("datetime_start")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.ProjectTaskId).HasColumnName("project_task_id");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ProjectTaskActionCollaboratorCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Create_ProjectTaskActionCollaborator");

                entity.HasOne(d => d.ProjectTask)
                    .WithMany(p => p.ProjectTaskActionCollaborator)
                    .HasForeignKey(d => d.ProjectTaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectTask_ProjectTaskActionCollaborator");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.ProjectTaskActionCollaboratorUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Update_ProjectTaskActionCollaborator");
            });

            modelBuilder.Entity<ProjectTaskActionManager>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.NewDeadline)
                    .HasColumnName("new_deadline")
                    .HasColumnType("datetime");

                entity.Property(e => e.Overtime).HasColumnName("overtime");

                entity.Property(e => e.ProjectTaskId).HasColumnName("project_task_id");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ProjectTaskActionManagerCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Create_ProjectTaskActionManager");

                entity.HasOne(d => d.ProjectTask)
                    .WithMany(p => p.ProjectTaskActionManager)
                    .HasForeignKey(d => d.ProjectTaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectTask_ProjectTaskActionManager");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.ProjectTaskActionManagerUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Update_ProjectTaskActionManager");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasColumnType("datetime");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateBy).HasColumnName("update_by");

                entity.Property(e => e.UpdateOn)
                    .HasColumnName("update_on")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.RoleCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Create_Role");

                entity.HasOne(d => d.UpdateByNavigation)
                    .WithMany(p => p.RoleUpdateByNavigation)
                    .HasForeignKey(d => d.UpdateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Update_Role");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LeftSight).HasColumnName("left_sight");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .IsUnicode(false);

                entity.Property(e => e.RightSight)
                    .HasColumnName("right_sight")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdateBy).HasColumnName("update_by");

                entity.Property(e => e.UpdateOn)
                    .HasColumnName("update_on")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.InverseCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Creation_User");

                entity.HasOne(d => d.UpdateByNavigation)
                    .WithMany(p => p.InverseUpdateByNavigation)
                    .HasForeignKey(d => d.UpdateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Update_User");
            });
        }
    }
}
