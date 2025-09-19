namespace EcommerRest.Services.Settings
{
    public class UploadSettings
    {
        public string UploadDirectory { get; set; }
        public string AllowedExtensions { get; set; }
        public int MaxFileSizeInMb { get; set; }

    }
}
