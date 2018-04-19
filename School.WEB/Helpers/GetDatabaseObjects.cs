using School.DAL;

namespace School.WEB.Helpers
{
    public class GetDatabaseObjects
    {
        public static T GetObjectById<T>(int id) where T : class
        {
            using (var db = new SchoolContext())
            {
                var record = db.Set<T>().Find(id);
                return record;
            }
        }
    }
}
