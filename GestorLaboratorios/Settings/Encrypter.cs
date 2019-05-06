namespace GestorLaboratorios.Settings
{
    public class Encrypter
    {
        /// <summary>
        /// Encrytar
        /// </summary>
        /// <param name="strPalabras"></param>
        /// <returns></returns>
        public string Encrypt(string strPalabras)
        {
            byte[] key = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
            byte[] iv = { 8, 7, 6, 5, 4, 3, 2, 1 };

            ClsTripleDES _clsCrypto = new ClsTripleDES(key, iv);

            return _clsCrypto.Encrypt(strPalabras);
        }

        /// <summary>
        /// Desencryptar
        /// </summary>
        /// <param name="strPalabras"></param>
        /// <returns></returns>
        public string Decrypt(string strPalabras)
        {
            byte[] key = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
            byte[] iv = { 8, 7, 6, 5, 4, 3, 2, 1 };

            ClsTripleDES _clsCrypto = new ClsTripleDES(key, iv);

            return _clsCrypto.Decrypt(strPalabras);
        }
    }
}
