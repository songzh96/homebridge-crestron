# It‘s based on [homebridge-creskit](https://github.com/marcusadolfsson/homebridge-creskit)

If you want to know how to use this plugin，please see Chinese [README](https://github.com/songzh96/homebridge-crestron/blob/master/README-ZhCN.md)（use Google translate）

CresKit (together with Homebridge) turns Creston controlled devices into HomeKit accessories, enabling you to control many functions using Siri and the iOS 10 Home app. 

It is an early prototype, but functional. It requires you to install a Homebridge on an appropriate server before continuing. I use a $20 RaspberryPi, using this [tutorial](https://github.com/nfarina/homebridge/wiki/Running-HomeBridge-on-a-Raspberry-Pi).
 
HomeKit accessories are supported:

- Lights (dimming is enabled)
- Switches (can also be used to for Creston Scenes)
- Garage Doors
- Alarm
- Thermostat
- HeaterCooler
- Shades
- Various Sensors
- Door Locks
- Airpurifier
- Valve

In Homebridge's config.json file you specify the accessories you want to enable, and link the appropiate Crestron signals via the included SIMPL+ Module (tested on MC3,AP3,PRO3). You can then use the iOS 10 Home app to tie the accessories to rooms and groups.

On the Crestron side, the SIMPL+ Module acts as a basic TCP Server and communicates using three type of commands:

- Set (Controls Crestron from Homebridge)
- Get (Requests Crestron status from Homebridge)
- Event (Push Crestron status changes to Homebridge)

More to come!

**Crestron Modules is a sample Simple reference，You can customize it according to your needs.**

## Development document

[install-homebridge-RaspberryPi](https://github.com/nfarina/homebridge/wiki/Running-HomeBridge-on-a-Raspberry-Pi)

[homebridge-creskit](https://github.com/marcusadolfsson/homebridge-creskit)

[homebridge](https://github.com/nfarina/homebridge)

[homekit-types](https://github.com/KhaosT/HAP-NodeJS/blob/master/lib/gen/HomeKitTypes.js)

[homekit-Characteristic](https://github.com/KhaosT/HAP-NodeJS/blob/master/lib/Characteristic.js)

[homebridge 多开+](https://github.com/nfarina/homebridge/issues/2054) 

