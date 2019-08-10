# -DynoImageApp
Simple app I use for processing screenshots of Dyno results to send to customers

This app is very basic but covered a need I had to avoid manual labour when prettifying Dyno prints to not have windows bar etc.

It basicly has an input and output folder and a path to a watermark which it will overlay on any of the imagery found in the input folder that matches
the extension or query your write in the configuration.

Quite simple and can be used I'm sure for many other things that what I'm using it for.

## Settings
Remember to update the settings in app.config, to match your required scenario. Version's indicates how many version you want the backup solution to contain. This means that you will have '5' versions of your source onces it creates the 6th it will remove the first oldeste version.

```xml
{
  "inputFolder"  : "input",
  "outputFolder" : "output",
  "fileextension": "*.png",
  "watermarkPath": "watermark.png",
}
```
