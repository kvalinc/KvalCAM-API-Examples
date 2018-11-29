# KvalCAMAPIExamples
This repository hosts examples in various languages utilizing the KvalCAM API. Some of the examples start from a swagger code generator and others are written from scratch utilizing basic HTTP and JSON libraries.

## Getting Started
For getting started with the KvalCAM API go [here](https://docs.kvalinc.com/display/CAM/Getting+Started)

Once setup you can view up to date and interactive documentation by connecting to your KvalCAM host in a browser at http://{host_ip}:{port}/rest/api/docs

## .NET/CSharp Example
The CSharp example is mostly code generated from the swagger doc schema and has samples of:
* Loading a door job by name into the KvalCAM editor using the search function
* Creating/editing a door job completely from code and loading it into the KvalCAM editor
* Composing a door job from existing feature groups and loading it into the KvalCAM editor
* Listening to a serial port COM channel to load a door job by name into the KvalCAM editor (serial port is commonly used by barcode and QR code readers)

## Python Example
The python code shows some simple HTTP JSON requests to the API utilizing the python standard libraries.

# Links
[Kval Website](https://www.kvalinc.com/)

[Kval Technical Docs](https://docs.kvalinc.com/)
