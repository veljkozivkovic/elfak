namespace ZatvorLibrary;

internal static class DataLayer
{

    private static ISessionFactory? factory;
    private static object lockObj;

    static DataLayer()
    {
        factory = null;
        lockObj = new object();
    }

    public static ISession? GetSession()
    {
        if (factory == null)
        {
            lock (lockObj)
            {
                if (factory == null)
                {
                    factory = CreateSessionFactory();
                }
            }
        }

        return factory?.OpenSession();
    }

    private static ISessionFactory? CreateSessionFactory()
    {
        try
        {
            string cs = ConfigurationManager.ConnectionStrings["OracleCS"].ConnectionString;
            var cfg = OracleManagedDataClientConfiguration.Oracle10
                        .ShowSql()
                        .ConnectionString(c => c.Is(cs));

            return Fluently.Configure()
                    .Database(cfg)
                    .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                    .BuildSessionFactory();
        }
        catch (Exception e)
        {
            return null;
        }
    }

}