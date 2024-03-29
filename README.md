# Before you judge

This is mostly a prototype-like project. It has some flaws. Few of them are caused by wrong decisions made at the beginning of this project. Some of them are simple to fix, other are architecture-level and concept-level based problems. But I'm learning from my mistakes. I know about this issues/bugs/mistakes and will address them in next projects because this one is going to be closed/archived in few months (or it is now - depends when you are reading this).

## Why

It started as a prototype when I was working with UWP for the first time. Prototype had just a desktop view and a browser. Later I had to do an engineering project. So I came with idea that I can expand this prototype to create a full-size solution.

## About

- Main purpose of this project is to bring desktop-like experience to IoT world.
- It uses Windows 10 IoT Core as a base (or a host) to work on.
- All data are stored in SQLite file. Because of that switching from one device running under this app to another or creating backup is very simple.
- User is limited by the build-in sub-apps like browser, calculator etc. It's because main target of this project are seniors and kids.

## Functionalities

- CRUD notes
- Creating, reading, loading and deleting favorites
- Creating, reading and deleting accounts
- Manging passwords for accounts
- Solving equation using Calculator
- Equation history in Calculator
- Browsing resources of the Internet
- Searching and connecting to selected Wi-Fi network
- Choosing one of pre-defined avatars

## Used technologies

- C#
- xUnit
- SQLite
- .NET Core
- Fluent Validation
- Windows 10 IoT Core
- Entity Framework Core
- UWP Community Toolkit
- Universal Windows Platform
- Syncfusion UWP UI Controls
- Metro Studio by Syncfusion

## Used hardware

- Raspberry Pi 3B
- Waveshare H LCD TFT 10,1" touch screen
- 32GB SD card

... to be continued ...
