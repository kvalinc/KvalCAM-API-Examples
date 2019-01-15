# KvalCAMAPIExamples
This repository hosts examples in various languages utilizing the KvalCAM API. Some of the examples start from a swagger code generator and others are written from scratch utilizing basic HTTP and JSON libraries.

All examples are provided "as is" without any guarantees, and any generated code or libraries used within them is not maintained or supported by Kval. The core REST web API composed of HTTP requests and JSON is stable and supported, and as such these examples should continue to work without modification with all new versions of KvalCAM provided their supporting libraries/generated code continues to function.

## Getting Started
For getting started with the KvalCAM API go [here](https://docs.kvalinc.com/display/CAM/Getting+Started)

Once setup you can view up to date and interactive documentation by connecting to your KvalCAM host in a browser at http://{host_ip}:{port}/rest/api/docs

## .NET/CSharp Example
The CSharp example is mostly code generated from the swagger doc schema and has samples of:
* Loading a door job by name into the KvalCAM editor using the search function
* Creating/editing a door job completely from code and loading it into the KvalCAM editor
* Composing a door job from existing feature groups and loading it into the KvalCAM editor
* Listening to a serial port COM channel to load a door job by name into the KvalCAM editor (serial port is commonly used by barcode and QR code readers)

NOTE: The generated code in this example is updated over time to include new functionality/properties added to KvalCAM versions over time, see commit history for reference.

## Python Example
The python code shows some simple HTTP JSON requests to the API utilizing the python standard libraries.

# Links
[Kval Website](https://www.kvalinc.com/)

[Kval Technical Docs](https://docs.kvalinc.com/)
