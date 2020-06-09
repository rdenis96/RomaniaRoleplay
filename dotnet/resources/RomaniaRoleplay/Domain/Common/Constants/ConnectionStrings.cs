namespace Domain.Common.Constants
{
    public static class ConnectionStrings
    {
#if DEBUG
        public const string MysqlConnectionDatabase = "Server=127.0.0.1;Port=3306;Database=romania_roleplay_ragemp;Uid=root;Pwd=test;Convert Zero Datetime=True";
#elif RELEASE
        public const string MysqlConnectionDatabase = "Server=198.162.0.133;Port=3306;Database=romania_roleplay_ragemp;Uid=root;Pwd=test;Convert Zero Datetime=True";
#endif
    }
}
