using CSL.Encryption;
using Newtonsoft.Json;

namespace Lime.SecurityWrapper.CSLWrapper;

public class Protector : IDisposable
{
    public AES256KeyBasedProtector core { get; set; }
    public byte[] key {
        get => core.GetKey();
        set {
            key = value;
        }
    }

    //this does nothing and we do not need it to due to the fact that there is no unamaged code here
    public void Dispose() {}

    public Protector(byte[] key)
    {
        core = new AES256KeyBasedProtector(key);
        this.key = key;
    }

    public async Task<string> EncryptString(string data)
    {
        return await core.Protect(data);
    }

    public async Task<string> IntuitiveEncrypt(object data)
    {
        string str = JsonConvert.SerializeObject(data);
        return await core.Protect(str);
    }

    public async Task<T> Decrypt<T>(string data)
    {
        string decrypted = await core.Unprotect(data);
        T ret = JsonConvert.DeserializeObject<T>(decrypted) ?? throw new NullReferenceException();
        return ret;
    }
}