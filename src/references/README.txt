There's a pre-build event that copies some files from the MSFS SDK to this folder.

The SDK is expected in "C:\MSFS SDK" as well as the samples, if the SDK and samples are installed elsewhere, change the pre-build scripts.

If you don't have the SDK on your development machine, copy the files manually or put them there in the same structure as how they would be in the SDK.

The following dll's are copied:

- <SDK>\SimConnect SDK\lib\SimConnect.dll
- <SDK>\SimConnect SDK\lib\Microsoft.FlightSimulator.SimConnect.dll
- <SDK>\Samples\SimvarWatcher\SimConnect.cfg