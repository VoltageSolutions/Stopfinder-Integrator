<h1 align="center">
  Stopfinder-Integrator
</h1>

<p align="center">
  Enable self-hosted applications to capture and leverage bus schedule and student transportation data from Stopfinder.
</p>

<p align="center">
  <a href="https://github.com/VoltageSolutions/Stopfinder-Integrator/actions/workflows/merge.yml"><img alt="GitHub Workflow Status (with event)" src="https://img.shields.io/github/actions/workflow/status/VoltageSolutions/Stopfinder-Integrator/merge.yml"></a>
  &nbsp;
  <a href="https://github.com/VoltageSolutions/Stopfinder-Integrator/releases">
    <img alt="Current Release" src="https://img.shields.io/github/release/VoltageSolutions/Stopfinder-Integrator.svg"/>
  </a>
</p>

## Introduction

This project enables getting data from [Stopfinder](https://stopfinder.com/) and expose it over MQTT. This makes it possible to display current schedule information in other tools like Home Assistant.

## Getting start with the app

1. Download the latest [release](https://github.com/VoltageSolutions/Stopfinder-Integrator/releases), available as a `.zip` archive. Stopfinder-Integrator builds for both Linux and Windows.
1. Setup your `.env` file with your Stopfinder credentials, MQTT server, and MQTT credentials. You may want to secure this file to protect the secrets it contains.
1. Unpack the archive and run the application.
    1. If you do not have the .NET 9 Runtime installed, the app will prompt you to download it.
1. This app is not currently digitally signed. Tools like Microsoft Defender SmartScreen might block it. If so, click **More info** and then **Run anyway**. The app will start.
1. The current version is a console app that runs one time. It'll retrieve schedule data, display that data to the console, publish is to the MQTT broker, and close itself.

## Example `.env` file

```env
STOPFINDER_USERNAME=stopfinder_email@example.com
STOPFINDER_PASSWORD=stopfinder_password
TRANSFINDER_BASEURL=https://www.mytransfinder.com

MQTT_SERVER=mqttserver
MQTT_TOPIC_PREFIX=bus
MQTT_USERNAME=mqtt_user
MQTT_PASSWORD=mqtt_password
MQTT_TOPIC_MODE=perBus
```

## Building from source

1. Setup the .NET 9 SDK on your machine.
1. Clone the repo.
1. Build the solution (which should include restoring dependencies).

## How to contribute

### Ideas, Issues, or Bugs

Post to the [Issues page](https://github.com/VoltageSolutions/Stopfinder-Integrator/issues).

### Code

This project follows a modified version of Git Flow where `main` always represents the latest version. Submit a PR - if I approve it, I will merge to a version branch for testing prior to merging to `main` and creating a new release.

### Donate

Support this project on [ko-fi](https://ko-fi.com/voltagesolutions)!

## Roadmap

### Upcoming goals

- Improved code readability and maintainability.
- Improved code coverage.
- Improved MQTT topic and data structure.
- Improved error handling.
- Function to run in a continuous loop.
- Docker image.

## Known Bugs and Issues

- There's no handling for an incorrect `.env` file.
- There isn't really error handling in general, such as for network failures or authentication issues.

## License and copyright

Stopfinder is a product of Transfinder. Voltage Solutions is not affiliated with Transfinder in any way.

The Apache 2.0 license covers Stopfinder-Integrator's functionality to query Stopfinder data and make it available over MQTT.

```license
Copyright 2025 Voltage Solutions

Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License.

You may obtain a copy of the License at:

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    
See the License for the specific language governing permission and limitations under the License.
```
