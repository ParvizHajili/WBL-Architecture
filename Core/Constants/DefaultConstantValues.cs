namespace Core.Constants
{
    public static class DefaultConstantValues
    {
        public static string DATA_ADDED_SUCCESFULLY = "Məlumat uğurla əlavə olundu.";
        public static string DATA_UPDATED_SUCCESFULLY = "Məlumat uğurla yeniləndi.";
        public static string DATA_DELETED_SUCCESFULLY = "Məlumat uğurla silindi.";

        public static string ADD_MESSAGE = "Əlavə et";
        public static string UPDATE_MESSAGE = "Yenilə";
        public static string RETURN_TO_BACK = "Geriyə qayıt";


        public static int DEFAULT_PRIMARY_KEY_INCREMENT_VALUE = 10000;


        public static string GetRequiredMessage(string propName)
        {
            return $"{propName} mütləq daxil edilməlidir!";
        }

        public static string GetMinimumLengthMessage(string propName, int length)
        {
            return $"{propName} {length} simvoldan az ola bilməz!";
        }

        public static string GetMaxLengthMessage(string propName, int length)
        {
            return $"{propName} {length} simvoldan çox ola bilməz!";
        }
    }
}
