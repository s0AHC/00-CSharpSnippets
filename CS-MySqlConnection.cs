string server = "127.0.0.1";
string database = "myDatabase";
string uid = "supervisor";
string password = "12345";
string connectionString = "server=" + server + ";" + "database="+database + ";" + "uid=" + uid ";" + "password=" + password + ";";
MySqlConnection sqlConnection = new MySqlConnection(connectionString);
MySqlCommand cmd = new MySqlCommand();
cmd.CommandText = "SELECT Password FROM myTable_Usertable WHERE Username='" + this.TextBox_UserName.Text + "';";
sqlConnection.Open();
cmd.Connection = sqlConnection;

MySqlDataReader reader = cmd.ExecuteReader();

while (reader.Read())
{
    string dbUserPassword= reader[0].ToString();

    string[] passwordString = dbUserPassword.Split("$");
    int iterationCount = Convert.ToInt32(passwordString[1]);
    string saltString = passwordString[2];
    string dbPasswordString = passwordString[3];
    int dkLength = 44;

    byte[] inputPasswordByte = System.Text.Encoding.UTF8.GetBytes(this.PasswordBox_Password.Password);
    byte[] saltByte = System.Text.Encoding.UTF8.GetBytes(saltString);
    byte[] hashedPasswordByte = PBKDF2Sha256GetBytes(dkLength,inputPasswordByte,saltByte,iterationCount);
    byte[] dbPasswordByte = System.Text.Encoding.UTF8.GetBytes(dbPasswordString);

    if( hashedPasswordByte == dbPasswordByte)
    {
        MessageBox.Show("Login succeed!");
        MainWindow.show();   
    }
    else
    {
        MessageBox.Show("Invalid password!");
    }

}

// this following function is from the above link
private static byte[] PBKDF2Sha256GetBytes(int dklen, byte[] password, byte[] salt, int iterationCount)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA256(password))
        {
            int hashLength = hmac.HashSize / 8;
            if ((hmac.HashSize & 7) != 0)
                hashLength++;
            int keyLength = dklen / hashLength;
            if ((long)dklen > (0xFFFFFFFFL * hashLength) || dklen < 0)
                throw new ArgumentOutOfRangeException("dklen");
            if (dklen % hashLength != 0)
                keyLength++;
            byte[] extendedkey = new byte[salt.Length + 4];
            Buffer.BlockCopy(salt, 0, extendedkey, 0, salt.Length);
            using (var ms = new System.IO.MemoryStream())
            {
                for (int i = 0; i < keyLength; i++)
                {
                    extendedkey[salt.Length] = (byte)(((i + 1) >> 24) & 0xFF);
                    extendedkey[salt.Length + 1] = (byte)(((i + 1) >> 16) & 0xFF);
                    extendedkey[salt.Length + 2] = (byte)(((i + 1) >> 8) & 0xFF);
                    extendedkey[salt.Length + 3] = (byte)(((i + 1)) & 0xFF);
                    byte[] u = hmac.ComputeHash(extendedkey);
                    Array.Clear(extendedkey, salt.Length, 4);
                    byte[] f = u;
                    for (int j = 1; j < iterationCount; j++)
                    {
                        u = hmac.ComputeHash(u);
                        for (int k = 0; k < f.Length; k++)
                        {
                            f[k] ^= u[k];
                        }
                    }
                    ms.Write(f, 0, f.Length);
                    Array.Clear(u, 0, u.Length);
                    Array.Clear(f, 0, f.Length);
                }
                byte[] dk = new byte[dklen];
                ms.Position = 0;
                ms.Read(dk, 0, dklen);
                ms.Position = 0;
                for (long i = 0; i < ms.Length; i++)
                {
                    ms.WriteByte(0);
                }
                Array.Clear(extendedkey, 0, extendedkey.Length);
                return dk;
            }
        }

    }