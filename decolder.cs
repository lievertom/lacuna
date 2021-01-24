using System;

namespace lacuna
{
    public class Decolder
    {

        public static string Decode(User user, User user2)
        {
            var positionUserName = GetPositionUserName(user.Token, user2.Token);
            var charMagic = GetCharMagic(user.Token, user2.Token, user.Name, positionUserName);
            var masterUserName = MakeMasterUserName(charMagic, user.Name.Length);
            var masterToken = ForgeToken(user.Token, user.Name, masterUserName, positionUserName);

            return masterToken;
        }

        private static int GetPositionUserName(string token, string token2)
        {
            var bytes = new byte[token.Length / 2];
            var bytes2 = new byte[token.Length / 2];

            int pos;
            for (pos = 0; pos < bytes.Length; pos++)
            {
                bytes[pos] = Convert.ToByte(token.Substring(pos * 2, 2), 16);
                bytes2[pos] = Convert.ToByte(token2.Substring(pos * 2, 2), 16);
                bytes[pos] ^= bytes2[pos];
                if (bytes[pos] != 0)
                    break;
            }

            return pos;
        }

        private static char GetCharMagic(string token, string token2, string userName, int pos)
        {
            var byteCharMagic = Convert.ToByte(token.Substring((pos+userName.Length-1)*2, 2), 16);           
            byteCharMagic ^= Convert.ToByte(token2.Substring((pos+userName.Length-1)*2, 2), 16);
            byteCharMagic ^= Convert.ToByte(userName[userName.Length-1]);
           
            return Convert.ToChar(byteCharMagic);
        }

        private static string MakeMasterUserName(char charMagic, int length)
        {
            var masterName = "master";
            var stringMagic = new string(charMagic, length-masterName.Length);
        
            return masterName+stringMagic;
        }

        private static string ForgeToken(string token, string userName, string masterUserName, int pos)
        {
            var bytes = new byte[token.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(token.Substring(i * 2, 2), 16);
                if(i >= pos && i-pos < userName.Length)
                {
                    bytes[i] ^= Convert.ToByte(userName[i-pos]);
                    bytes[i] ^= Convert.ToByte(masterUserName[i-pos]);
                }
            }

            return BitConverter.ToString(bytes).Replace("-", "");
        }
    }
}