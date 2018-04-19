namespace School.DAL
{
    public static class SchoolInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}