# homebridge-creskit

CresKit (together with Homebridge) turns Creston controlled devices into HomeKit accessories, enabling you to control many functions using Siri and the iOS 10 Home app. 

It is an early prototype, but functional. It requires you to install a Homebridge on an appropriate server before continuing. I use a $20 RaspberryPi, using this [tutorial](https://github.com/nfarina/homebridge/wiki/Running-HomeBridge-on-a-Raspberry-Pi).
 
As of CresKit 1.1.1 the following HomeKit accessories are supported:

- Lights (dimming not enabled)
- Switches (can also be used to for Creston Scenes)
- Garage Doors
- Alarm

Next up:

- Thermostat
- Shades
- Various Sensors
- Door Locks

In Homebridge's config.json file you specify the accessories you want to enable, and link the appropiate Crestron signals via the included SIMPL+ Module (only tested on MC3). You can then use the iOS 10 Home app to tie the accessories to rooms and groups.

On the Crestron side, the SIMPL+ Module acts as a basic TCP Server and communicates using three type of commands:

- Set (Controls Crestron from Homebridge)
- Get (Requests Crestron status from Homebridge)
- Event (Pushes Crestron status changes to Homebridge)

More to come!