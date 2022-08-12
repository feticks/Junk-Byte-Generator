# Junk-Byte-Generator

> Simplistic junk byte generator that generates X amount of bytes and then writes a new file with the combined total.

```
public static int Build(OpenFileDialog Dialog, int amount) {
    var bytes = File.ReadAllBytes(Dialog.FileName);
    var combined = ByteCombine(bytes, Junk(amount));
    var extension = Path.GetExtension(Dialog.FileName);
    var renamed = Dialog.FileName.Replace(Dialog.SafeFileName,
    Dialog.SafeFileName.Replace(extension, $"_Junked{extension}"));
    File.WriteAllBytes(renamed, combined);
    return combined.Length;
}

private static byte[] Junk(int amount) {
    string bytes = "0";
    bytes = string.Concat(Enumerable.Repeat(bytes, amount));
    return Encoding.UTF8.GetBytes(bytes);
}

private static byte[] ByteCombine(params byte[][] arrays) {
    byte[] ret = new byte[arrays.Sum(x => x.Length)];
    int offset = 0;
    foreach (byte[] data in arrays) {
        Buffer.BlockCopy(data, 0, ret, offset, data.Length);
        offset += data.Length;
    }
    return ret;
}
```
