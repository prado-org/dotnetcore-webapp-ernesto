using System.Text.RegularExpressions;

namespace MyFirstProject.Framework
{
    public static class Utils
    {
        public static string GetRandomString(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[length];
            var random = new Random();
            
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            
            return new String(stringChars);
        }

        public static string GetRandomEmail()
        {
            return $"{GetRandomString(10)}@{GetRandomString(5)}.com";
        }

        public static string GetRandomPhoneNumber()
        {
            return $"0{GetRandomString(9)}";
        }

        public static string GetRandomName()
        {
            return GetRandomString(10);
        }

        public static string GetRandomPassword()
        {
            return GetRandomString(10);
        }

        // validade if the cpf is valid
        public static bool IsCpf(string cpf)
        {
            int[] multiplier1 = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            
            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            
            if (cpf.Length != 11)
                return false;
            
            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                    return false;
            
            string tempCpf = cpf.Substring(0, 9);
            int sum = 0;
            
            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];
            
            int rest = sum % 11;
            
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            
            string digit = rest.ToString();
            tempCpf += digit;
            sum = 0;
            
            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];
            
            rest = sum % 11;
            
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            
            digit += rest.ToString();
            
            return cpf.EndsWith(digit);
        }

        // validade if the cnpj is valid
        public static bool IsCnpj(string cnpj)
        {
            int[] multiplier1 = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4 };
            int[] multiplier2 = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5 };
            
            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            
            if (cnpj.Length != 14)
                return false;
            
            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(14, char.Parse(j.ToString())) == cnpj)
                    return false;
            
            string tempCnpj = cnpj.Substring(0, 12);
            int sum = 0;
            
            for (int i = 0; i < 12; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * multiplier1[i];
            
            int rest = (sum % 11);
            
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            
            string digit = rest.ToString();
            tempCnpj += digit;
            sum = 0;
            
            for (int i = 0; i < 13; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * multiplier2[i];
            
            rest = (sum % 11);
            
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            
            digit += rest.ToString();
            
            return cnpj.EndsWith(digit);
        }

        // validade if the email is valid
        public static bool IsEmail(string email)
        {
            return Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }

        // validade if the phone number is valid
        public static bool IsPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"^\d{10}$");
        }

        // validade if the name is valid
        public static bool IsName(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z]+$");
        }
    }
}