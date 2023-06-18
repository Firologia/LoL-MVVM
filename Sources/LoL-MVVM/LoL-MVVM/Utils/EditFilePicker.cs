namespace LoL_MVVM.Utils;

public static class EditFilePicker
{
    public static async Task<FileResult> PickAFile(PickOptions options)
    {
        try
        {
            var result = await FilePicker.Default.PickAsync(options);
            if (result != null)
            {
                if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                    result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                {
                    using var stream = await result.OpenReadAsync();
                    var image = ImageSource.FromStream(() => stream);
                }
            }

            return result;
        }
        catch (Exception)
        {
            // The user canceled or something went wrong
        }

        return null;
    }
    
    public static async Task<string> PickImage()
    {
        var result = await EditFilePicker.PickAFile(new PickOptions
        {
            PickerTitle = "Pick an icon",
            FileTypes = FilePickerFileType.Images
        });

        if(result != null) return await result.ToBase64();
        return null;
    }
}