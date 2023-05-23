namespace LoL_MVVM.Components;

public partial class ChampionItemView : ContentView
{
    private static string base64Image =
        "UklGRnYDAABXRUJQVlA4IGoDAABQDwCdASoqACoAPjEYiUQiIYjiQBABgljAJ0ztIcf+bqQavbmXbhvKVOAeq/jG9iKAXaH+M4dZeQPR8A87HobZ+nqD2Cf5L/X/+RwGaJqmy2IJw6dEwIW5TAGwqHN5PVWoSj7eAA6v5Eml+GGnkqobDWuB2SrWvkkm6kOf7WNMPDMggAD+//O6e5o6kUkiZ/dui/bMtCODB9Wrhc63V72+AccWiYI/8NcGvK1rPw78tP/sj4rcz66srssnpImRMxoqV9QCSVaw0sNPXNyLUxvHXIau6GKHG4C8YDr/iubIrCy9etz7IDPOEhI8nnZg3MCcjUGXkwSifKv1Tk2YJMuKyNvJoQ4/I1Wmszed7InvJPhLd9+2R9GHkjh7P/9muW6qth4DS3i/MUy4IXLIMSfJnyxk/3EoozXZ9yKNcYuP5uVjGnjXump/bFky92N1fk7ZGvxgelwnGaH8bnbAVOqmpe691gC89jKq5KDVkwt/9jW1u7QtUwdBDuL3TfHL6yWKdkr/lzTaYf1fyXBc685O1RscXRt5Gs+WiM/3t5bN/Wf/zfNuWneUDMXximEdoAlNQV1BXmpMBx3hKhMx/6jJfOA3UdDSmQegOUAFOOM4gRDJwaeMAGczT4MKjXvXqNvpWlKQPTrXQU81TxaunJ/19kbrUY72yPA98AqaZIHljwsNe4vZC5fe7gv7ylhvlZqf0BL3H5TV91t/CWuGnL/ril59G8IdFhF99iT3rnfr7Hce+Et39Bp2AGxUMG6Umi4v5PxK57aoVRQS+vqw4xA2/lDnyIKPt8YOEl+tIMw3VwdZ4QLoFZW73dJ6MPCXRzRgkNySb9/L1S2gStrDC/R3l/qgTJ3VN2G9+cBbXMvTl9kB4wAyaworKsdC3J/Br7Rtd8VERRx7P8mupGDlX8meRqRcYydhQoftf8FzS08EWJP/Nf8/kPhmFIRN2Qrt//wnrZ6XW9/QZiGVox8IulMbgbVJXD2yq9CcvpRRuh6M+dHJphbOboyWg+GpPsNdEguGCduy7FhNulsW9FMapSwMSGqYDoeo1bSVZPSKF7bGiNjyzazUlYDrHWPBVuZZYh31vDZFdi9JxRlyCUweKySK0z+EGxT1TXfM/exSvoFG1h1A3LqsehSWmv8ka4jlrTLO6u8zT9ADwgAA";

    private static byte[] imageBytes = Convert.FromBase64String(base64Image);

    public ImageSource ImageSource { get; set; } = ImageSource.FromStream(() => new MemoryStream(imageBytes));



    public ChampionItemView()
	{
		InitializeComponent();
	}
}