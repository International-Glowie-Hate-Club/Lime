using CSL.Encryption;
using Newtonsoft.Json;

namespace Lime.SecurityWrapper.CSLWrapper;

public class Protector
{
    public AES256KeyBasedProtector core { get; set; }
    public byte[] key {
        get => core.GetKey();
        set {
            key = value;
        }
    }

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
}