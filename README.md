Demonstrates a re-usbale library that targets `Microsoft.Extensions.DependencyInjection` version 1.1.0, 
being used within an application that targets `Microsoft.Extensions.DependencyInjection` version 2.0.0.

Shows that as long as the library doesn't call `BuildServiceProvider` directly then it's ok.
This workaround shows the application passing a delegate to the library to replace that particular call.
