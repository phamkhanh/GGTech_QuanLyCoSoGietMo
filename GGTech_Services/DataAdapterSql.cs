using GGTech_Common;
using GGTech_DataAccessLayer;

namespace GGTech_Services
{
    public class DataAdapterSql
    {
        public static void _FSetConnectionString()
        {
            SqlDataProvider.Instance.DataSource = AppCommon.ReadNodeXml("/settings/servername");
            SqlDataProvider.Instance.Database = AppCommon.ReadNodeXml("/settings/database");
        }
    }
}