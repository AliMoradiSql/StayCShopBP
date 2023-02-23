using StayCShop.Debugging;

namespace StayCShop
{
    public class StayCShopConsts
    {
        public const string LocalizationSourceName = "StayCShop";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = false;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "8b3dd80507124324bb0d01fdba9cc485";
    }
}
