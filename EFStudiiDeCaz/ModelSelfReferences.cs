namespace EFStudiiDeCaz
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class ModelSelfReferences : DbContext
    {
        // Your context has been configured to use a 'ModelSelfReferences' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'EFStudiiDeCaz.ModelSelfReferences' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ModelSelfReferences' 
        // connection string in the application configuration file.
        public ModelSelfReferences()
            : base("name=ModelSelfReferences")
        {
        }

        public virtual DbSet<SelfReference> SelfReferences { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SelfReference>()
            .HasMany(m => m.References)
            .WithOptional(m => m.ParentSelfReference);
        }
    }

    public class SelfReference
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SelfReferenceId { get; private set; }
        public string Name { get; set; }
        [ForeignKey("ParentSelfReferenceId")]
        public int? ParentSelfReferenceId { get; private set; }
        public SelfReference ParentSelfReference { get; set; }
        public virtual ICollection<SelfReference> References { get; set; }
        public SelfReference()
        {
            References = new HashSet<SelfReference>();
        }
    }

}