//namespace RandomQuotes.Data
//{
//    public class Hold
//    {
//        Makiing CreatedAt and UpdatedAt to be Automatically into thr database
//        public override int SaveChanges()
//        {
//            var entries = ChangeTracker
//                .Entries()
//                .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added ||
//                            e.State == EntityState.Modified));
//            foreach (var entityEntry in entries)
//            {
//                ((BaseEntity)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;
//                if (entityEntry.State == EntityState.Added)
//                {
//                    ((BaseEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
//                }
//            }
//            return base.SaveChanges();
//        }
//    }
//}
