using System;
namespace LoL_MVVM.Utils
{
    public static class FileResultToBase64Converter
    {
        public static async Task<string> ToBase64(this FileResult fileResult)
        {
            using var memoryStream = new MemoryStream();
            await (await fileResult.OpenReadAsync()).CopyToAsync(memoryStream);
            return Convert.ToBase64String(memoryStream.ToArray());
        }
    }
}

