/*
https://github.com/nfarina/homebridge-legacy-plugins/blob/master/platforms/HomeSeer.js used for reference.
*/

'use strict';

var async = require('async');
var net = require('net');
var events = require('events');

var Service, Characteristic;

module.exports = function (homebridge) {
    Service = homebridge.hap.Service;
    Characteristic = homebridge.hap.Characteristic;
    homebridge.registerPlatform("homebridge-creskit", "CresKit", CresKit);
}

// TCP connection to Crestron Module
var cresKitSocket = new net.Socket();
var eventEmitter = new events.EventEmitter();


var openGetStatus = []; // Sometimes a getStatus does not come back. We need to re-try for the app to be responsive.
function closeGetStatus(what) {
    var found = openGetStatus.indexOf(what);
    openGetStatus.splice(found, 1);

    console.log(openGetStatus);
}

// Resend unclosed GetStatus
function retryGetStatus() {
    async.each(openGetStatus, function (writeString, callback) {
        try {
            cresKitSocket.write(writeString);
            console.log("RETRY: " + writeString);
        } catch (err) {
            console.log(err);
        }
        callback();
    }.bind(this), function (err) {
        //console.log("retryGetStatus complete");
    });
}
setInterval(function () { retryGetStatus(); }, 2000);

function CresKit(log, config) {
    this.log = log;
    this.config = config;
}

CresKit.prototype = {
    accessories: function (callback) {
        var foundAccessories = [];

        // Build Device List
        this.log("Starting CresKit Config");

        cresKitSocket.connect(this.config["port"], this.config["host"], function () {
            this.log('Connected to Crestron Machine');
            // ERROR CONNECITON
        }.bind(this));

        cresKitSocket.on('close', function () {
            this.log('Connection closed');
            // Handle error properly
            // Reconnect

            try {
                setTimeout(() => cresKitSocket.connect(this.config["port"], this.config["host"], function () {
                    this.log('Re-Connected to Crestron Machine');
                }.bind(this)), 25000);
            } catch (err) {
                this.log(err);
            }

        }.bind(this));

        // All Crestron replies goes via this connection
        cresKitSocket.on('data', function (data) {
            //this.log("Raw Crestron Data : " + data);

            // Data from Creston Module. This listener parses the information and updates Homebridge
            // get* - replies from get* requests
            // event* - sent upon any changes on Crestron side (including in response to set* commands)
            var dataArray = data.toString().split("*"); // Commands terminated with *
            async.each(dataArray, function (response, callback) {
                var responseArray = response.toString().split(":");
                // responseArray[0] = (config.type ie lightbulbs) : responseArray[1] = (id) : responseArray[2] = (command ie getPowerState) : responseArray[3] = (value)

                if (responseArray[0] != "") {
                    eventEmitter.emit(responseArray[0] + ":" + responseArray[1] + ":" + responseArray[2], parseInt(responseArray[3])); // convert string to value
                    //this.log("EMIT: " + responseArray[0] + ":" + responseArray[1] + ":" + responseArray[2] + " = " + responseArray[3]);
                }

                callback();

            }.bind(this), function (err) {
                //console.log("SockedRx Processed");
            });

        }.bind(this));

        // Accessories Configuration
        async.each(this.config.accessories, function (accessory, asynCallback) {

            var accessory = new CresKitAccessory(this.log, this.config, accessory);
            foundAccessories.push(accessory);

            return asynCallback();  //let async know we are done
        }.bind(this), function (err) {

            if (err) {
                this.log(err);
            } else {
                this.log("Success CresKit Config");
                callback(foundAccessories);
            }
        }.bind(this));

    }
}

function CresKitAccessory(log, platformConfig, accessoryConfig) {
    this.log = log;
    this.config = accessoryConfig;
    this.id = accessoryConfig.id;
    this.name = accessoryConfig.name
    this.model = "Komen v2.2.0";

}

CresKitAccessory.prototype = {

    identify: function (callback) {
        callback();
    },
    //---------------
    // PowerState - Lightbulb, Switch, SingleSpeedFan (Scenes)
    //---------------
    getPowerState: function (callback) { // this.config.type = Lightbulb, Switch, etc
        cresKitSocket.write(this.config.type + ":" + this.id + ":getPowerState:*"); // (:* required) on get
        openGetStatus.push(this.config.type + ":" + this.id + ":getPowerState:*");
        // Listen Once for value coming back, if it does trigger callback
        eventEmitter.once(this.config.type + ":" + this.id + ":getPowerState", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getPowerState:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventPowerState", value);
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
    setPowerState: function (value, callback) {
        //Do NOT send cmd to Crestron when Homebridge was notified from an Event - Crestron already knows the state!
        if (value) {
            value = 1;
        }
        else {
            value = 0;
        }
        cresKitSocket.write(this.config.type + ":" + this.id + ":setPowerState:" + value + "*"); // (* after value required on set)
        callback();
    },
    //---------------
    // Dimming Light
    //---------------
    getLightBrightness: function (callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":getLightBrightness:*"); // (:* required) on get
        openGetStatus.push(this.config.type + ":" + this.id + ":getLightBrightness:*");

        // Listen Once for value coming back, if it does trigger callback
        eventEmitter.once(this.config.type + ":" + this.id + ":getLightBrightness", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getLightBrightness:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventLightBrightness", value);
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
    
    setLightBrightness: function (value, callback) {
        // fix the light not dim to the set brightness,when the light closed
        setTimeout(()=>cresKitSocket.write(this.config.type + ":" + this.id + ":setLightBrightness:" + value + "*"),50);
        callback(null);
    },

    setLightState: function (value, callback) {
        
        this.log( this.config.type + ":" + this.id + ":setLightState:" + value + "*");
        if (value) {
            cresKitSocket.write(this.config.type + ":" + this.id + ":setLightBrightness:999*");
        } else {
            cresKitSocket.write(this.config.type + ":" + this.id + ":setLightBrightness:0*");
        }
        callback(null);    
    },

    //---------------
    // Garage
    //---------------
    getCurrentDoorState: function (callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":getCurrentDoorState:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getCurrentDoorState:*");

        // Listen Once for value coming back. 0 open, 1 closed
        eventEmitter.once(this.config.type + ":" + this.id + ":getCurrentDoorState", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getCurrentDoorState:*");

                // Update TargetDoorState via event event
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventCurrentDoorState", value);

                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
    setTargetDoorState: function (value, callback) {
        //this.log("setTargetDoorState %s", value);
        cresKitSocket.write(this.config.type + ":" + this.id + ":setTargetDoorState:" + value + "*");
        callback();
    },
    getObstructionDetected: function (callback) {
        // Not yet support
        callback(null, 0);
    },
    //---------------
    // Security System
    //---------------
    getSecuritySystemCurrentState: function (callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":getSecuritySystemCurrentState:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getSecuritySystemCurrentState:*");

        //armedStay=0 , armedAway=1, armedNight=2, disarmed=3, alarmValues = 4
        eventEmitter.once(this.config.type + ":" + this.id + ":getSecuritySystemCurrentState", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getSecuritySystemCurrentState:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventSecuritySystemCurrentState", value);
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
    setSecuritySystemTargetState: function (value, callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":setSecuritySystemTargetState:" + value + "*");

        callback();
    },

    //---------------
    // Lock (or any event that you needs push notifications)
    //---------------
    getLockCurrentState: function (callback) {
        //UNSECURED = 0;, SECURED = 1; .JAMMED = 2; UNKNOWN = 3;

        cresKitSocket.write(this.config.type + ":" + this.id + ":getLockCurrentState:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getLockCurrentState:*");

        // Listen Once for value coming back. 0 open, 1 closed
        eventEmitter.once(this.config.type + ":" + this.id + ":getLockCurrentState", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getLockCurrentState:*");

                // Update setLockTargetState via event event
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventLockCurrentState", value);

                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
    setLockTargetState: function (value, callback) {
        //UNSECURED = 0;, SECURED = 1;
        cresKitSocket.write(this.config.type + ":" + this.id + ":setLockTargetState:" + value + "*");
        callback();

    },
    //---------------
    // SpeedFan
    //---------------
    getRotationSpeed: function (callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":getRotationSpeed:*"); // (:* required) on get
        openGetStatus.push(this.config.type + ":" + this.id + ":getRotationSpeed:*");

        // Listen Once for value coming back, if it does trigger callback
        eventEmitter.once(this.config.type + ":" + this.id + ":getRotationSpeed", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getRotationSpeed:*");

                // Update RotationSpeed via event event
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventRotationSpeed", value);

                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
    setRotationSpeed: function (value, callback) {

        cresKitSocket.write(this.config.type + ":" + this.id + ":setRotationSpeed:" + value + "*"); // (* after value required on set)
        callback();
    },
    setRotationState: function (value, callback) {

        if (value === 0) {
            cresKitSocket.write(this.config.type + ":" + this.id + ":setRotationSpeed:0*");
        }
        else {
            cresKitSocket.write(this.config.type + ":" + this.id + ":setRotationSpeed:999*"); //999 = 100 if off, otherwise leave current
        }
        callback();
    },
    //---------------
    // Window Covering, Door
    //---------------
    getCurrentPosition: function (callback) {

        cresKitSocket.write(this.config.type + ":" + this.id + ":getCurrentPosition:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getCurrentPosition:*");

        eventEmitter.once(this.config.type + ":" + this.id + ":getCurrentPosition", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getCurrentPosition:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventCurrentPosition", value);
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
    setTargetPosition: function (value, callback) {

        cresKitSocket.write(this.config.type + ":" + this.id + ":setTargetPosition:" + value + "*"); // (* after value required on set)
        callback();
    },

    //---------------
    // Thermostat
    //---------------
    getTargetHeatingCoolingState: function (callback) {
        //INACTIVE = 0;, IDLE = 1; HEATING = 2; COOLING = 3;
        cresKitSocket.write(this.config.type + ":" + this.id + ":getTargetHeatingCoolingState:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getTargetHeatingCoolingState:*");

        eventEmitter.once(this.config.type + ":" + this.id + ":getTargetHeatingCoolingState", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getTargetHeatingCoolingState:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventTargetHeatingCoolingState", value);
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },

    setTargetHeatingCoolingState: function (value, callback) {
        //AUTO  = 0;, HEAT  = 1; COOL  = 2;
        cresKitSocket.write(this.config.type + ":" + this.id + ":setTargetHeatingCoolingState:" + value + "*");
        callback();
    },

    getCurrentTemperature: function (callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":getCurrentTemperature:*"); // (:* required) on get
        openGetStatus.push(this.config.type + ":" + this.id + ":getCurrentTemperature:*");

        eventEmitter.once(this.config.type + ":" + this.id + ":getCurrentTemperature", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getCurrrentTemperature:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventCurrentTemperature", value);
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },

    getTargetTemperature: function (callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":getTargetTemperature:*"); // (:* required) on get
        openGetStatus.push(this.config.type + ":" + this.id + ":getTargetTemperature:*");

        eventEmitter.once(this.config.type + ":" + this.id + ":getTargetTemperature", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getTargetTemperature:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventTargetTemperature", value);
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },

    setTargetTemperature: function (value, callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":setTargetTemperature:" + value + "*"); // (* after value required on set)
        callback();
    },

    //---------------
    // HeaterCooler
    //---------------
    getTargetHeaterCoolerState: function (callback) {
        //INACTIVE = 0;, IDLE = 1; HEATING = 2; COOLING = 3;
        cresKitSocket.write(this.config.type + ":" + this.id + ":getTargetHeaterCoolerState:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getTargetHeaterCoolerState:*");

        eventEmitter.once(this.config.type + ":" + this.id + ":getTargetHeaterCoolerState", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getTargetHeaterCoolerState:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventTargetHeaterCoolerState", value);
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },

    setTargetHeaterCoolerState: function (value, callback) {
        //AUTO  = 0;, HEAT  = 1; COOL  = 2;
        cresKitSocket.write(this.config.type + ":" + this.id + ":setTargetHeaterCoolerState:" + value + "*");
        callback();
    },

    setRotationSpeed: function (value, callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":setRotationSpeed:" + value + "*"); // (* after value required on set)
        callback();
    },
    getRotationSpeed: function (callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":getRotationSpeed:*"); // (:* required) on get
        openGetStatus.push(this.config.type + ":" + this.id + ":getRotationSpeed:*");

        eventEmitter.once(this.config.type + ":" + this.id + ":getRotationSpeed", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getRotationSpeed:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventRotationSpeed", value);
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },

    //---------------
    // AirPurifier
    //---------------
    getTargetAirPurifierState: function (callback) {
        //MANUAL = 0; AUTO  = 1;
        cresKitSocket.write(this.config.type + ":" + this.id + ":getTargetAirPurifierState:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getTargetAirPurifierState:*");

        eventEmitter.once(this.config.type + ":" + this.id + ":getTargetAirPurifierState", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getTargetAirPurifierState:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventTargetAirPurifierState", value);
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },

    setTargetAirPurifierState: function (value, callback) {
        //MANUAL = 0; AUTO  = 1;
        cresKitSocket.write(this.config.type + ":" + this.id + ":setTargetAirPurifierState:" + value + "*");
        callback();
    },
    getAirPurifierRotationSpeed: function (callback) {

        cresKitSocket.write(this.config.type + ":" + this.id + ":getAirPurifierRotationSpeed:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getAirPurifierRotationSpeed:*");

        eventEmitter.once(this.config.type + ":" + this.id + ":getAirPurifierRotationSpeed", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getAirPurifierRotationSpeed:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventAirPurifierRotationSpeed", value);
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },

    setAirPurifierRotationSpeed: function (value, callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":setAirPurifierRotationSpeed:" + value + "*");
        callback();
    },
    //---------------
    // AirQualitySensor
    //---------------
    /*getAirQuality: function (callback) {
        //UNKNOWN = 0; EXCELLENT = 1;GOOD = 2; FAIR = 3;INFERIOR = 4; POOR  = 5;

        cresKitSocket.write(this.config.type + ":" + this.id + ":getAirQuality:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getAirQuality:*");

        eventEmitter.once(this.config.type + ":" + this.id + ":getAirQuality", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getAirQuality:*");
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },*/

    getPM2_5Value: function (callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":getPM2_5Value:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getPM2_5Value:*");

        eventEmitter.once(this.config.type + ":" + this.id + ":getPM2_5Value", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getPM2_5Value:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventPM2_5Value", value);
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },

    getVOC_Value: function (callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":getVOC_Value:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getVOC_Value:*");

        eventEmitter.once(this.config.type + ":" + this.id + ":getVOC_Value", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getVOC_Value:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventVOC_Value", value);
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },

    getCarbonDioxideLevel: function (callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":getCarbonDioxideLevel:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getCarbonDioxideLevel:*");

        eventEmitter.once(this.config.type + ":" + this.id + ":getCarbonDioxideLevel", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getCarbonDioxideLevel:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventCarbonDioxideLevel", value);
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },

    //---------------
    // HumiditySensor
    //---------------
    getCurrentRelativeHumidity: function (callback) {
        //Humidity 0-100
        cresKitSocket.write(this.config.type + ":" + this.id + ":getCurrentRelativeHumidity:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getCurrentRelativeHumidity:*");

        eventEmitter.once(this.config.type + ":" + this.id + ":getCurrentRelativeHumidity", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getCurrentRelativeHumidity:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventCurrentRelativeHumidity", value);
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },

    //---------------
    // TemperatureSensor
    //---------------


    //---------------
    // Binary Sensor, SmokeSensor, OccupancySensor, MotionSensor, LeakSensor
    //---------------
    getSensorState: function (callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":getSensorState:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getSensorState:*");

        // Listen Once for value coming back. 0 open, 1 closed
        eventEmitter.once(this.config.type + ":" + this.id + ":getSensorState", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getSensorState:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventSensorState", value);
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },

    //---------------
    // LightSensor
    //---------------
    getCurrentAmbientLightLevel: function (callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":getCurrentAmbientLightLevel:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getCurrentAmbientLightLevel:*");

        // Listen Once for value coming back. 0 open, 1 closed
        eventEmitter.once(this.config.type + ":" + this.id + ":getCurrentAmbientLightLevel", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getCurrentAmbientLightLevel:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventCurrentAmbientLightLevel", value);
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },

    //---------------
    // Faucet
    //---------------
    getFaucetActive: function (callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":getFaucetActive:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getFaucetActive:*");

        // Listen Once for value coming back. 0 open, 1 closed
        eventEmitter.once(this.config.type + ":" + this.id + ":getFaucetActive", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getFaucetActive:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventFaucetActive", value);
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
    setFaucetActive: function (value, callback) {
        //INACTIVE = 0; ACTIVE  = 1;
        cresKitSocket.write(this.config.type + ":" + this.id + ":setFaucetActive:" + value + "*");
        callback();
    },

    //---------------
    // Outlet
    //---------------
    getOutletPower: function (callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":getOutletPower:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getOutletPower:*");

        // Listen Once for value coming back. 0 open, 1 closed
        eventEmitter.once(this.config.type + ":" + this.id + ":getOutletPower", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getOutletPower:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventOutletPower", value);
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
    setOutletPower: function (value, callback) {
        //ON = 1; OFF = 0
        cresKitSocket.write(this.config.type + ":" + this.id + ":setOutletPower:" + value + "*");
        callback();
    },

    //---------------
    // Valve
    //---------------
    getValveActive: function (callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":getValveActive:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getValveActive:*");

        eventEmitter.once(this.config.type + ":" + this.id + ":getValveActive", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getValveActive:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventValveActive", value);
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
    setValveActive: function (value, callback) {
        //ON = 1; OFF = 0
        cresKitSocket.write(this.config.type + ":" + this.id + ":setValveActive:" + value + "*");
        callback();
    },

    //---------------
    // FilterMaintenance
    //---------------
    getFilterLifeLevel: function (callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":getFilterLifeLevel:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getFilterLifeLevel:*");

        // Listen Once for value coming back. 0 open, 1 closed
        eventEmitter.once(this.config.type + ":" + this.id + ":getFilterLifeLevel", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getFilterLifeLevel:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventFilterLifeLevel", value);
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
    //---------------
    // Speaker
    //---------------
    getVolume: function (callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":getVolume:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getVolume:*");

        eventEmitter.once(this.config.type + ":" + this.id + ":getVolume", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getVolume:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventVolume", value);
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
    setVolume: function (value, callback) {
        //ON = 1; OFF = 0
        cresKitSocket.write(this.config.type + ":" + this.id + ":setVolume:" + value + "*");
        callback();
    },
    //---------------
    // Characteristic Config
    //---------------
    getServices: function () {
        var services = []

        var informationService = new Service.AccessoryInformation();
        informationService
            .setCharacteristic(Characteristic.Manufacturer, "CresKit")
            .setCharacteristic(Characteristic.Model, this.model)
            .setCharacteristic(Characteristic.SerialNumber, "CK " + this.config.type + " ID " + this.id);
        services.push(informationService);

        switch (this.config.type) {
            case "Lightbulb": {
                var lightbulbService = new Service.Lightbulb();
                var PowerState = lightbulbService
                    .getCharacteristic(Characteristic.On)
                    .on('set', this.setPowerState.bind(this))
                    .on('get', this.getPowerState.bind(this));

                // Register a listener
                eventEmitter.on(this.config.type + ":" + this.id + ":eventPowerState", function (value) {

                    PowerState.updateValue(value);
                }.bind(this));

                services.push(lightbulbService);
                break;
            }

            case "DimLightbulb": {
                var DimLightbulbService = new Service.Lightbulb();
                var LightState = DimLightbulbService
                    .getCharacteristic(Characteristic.On)
                    .on('set', this.setLightState.bind(this));

                var Brightness = DimLightbulbService
                    .getCharacteristic(Characteristic.Brightness)
                    .on('set', this.setLightBrightness.bind(this))
                    .on('get', this.getLightBrightness.bind(this));

                // Register a listener for event changes (dim-light)
                eventEmitter.on(this.config.type + ":" + this.id + ":eventLightBrightness", function (value) {
                    var light_power_value;
                    if (value) {
                        light_power_value = 1;
                    }
                    else {
                        light_power_value = 0;
                    }
                    Brightness.updateValue(value);
                    LightState.updateValue(light_power_value);
                }.bind(this));

                services.push(DimLightbulbService);
                break;
            }

            case "Switch": {
                var switchService = new Service.Switch();
                var PowerState = switchService
                    .getCharacteristic(Characteristic.On)
                    .on('set', this.setPowerState.bind(this))
                    .on('get', this.getPowerState.bind(this));

                // Register a listener for event changes
                eventEmitter.on(this.config.type + ":" + this.id + ":eventPowerState", function (value) {

                    PowerState.updateValue(value);
                }.bind(this));

                services.push(switchService);
                break;
            }

            case "TV": {
                var tvService = new Service.Television();


                var PowerState = tvService
                    .getCharacteristic(Characteristic.Active)
                    .on('get', this.getPowerState.bind(this))
                    .on('set', this.setPowerState.bind(this));

                // Register a listener for event changes
                eventEmitter.on(this.config.type + ":" + this.id + ":eventPowerState", function (value) {

                    PowerState.updateValue(value);
                }.bind(this));

                tvService
                    .setCharacteristic(
                        Characteristic.SleepDiscoveryMode,
                        Characteristic.SleepDiscoveryMode.ALWAYS_DISCOVERABLE
                    );


                var speakerService = new Service.TelevisionSpeaker();
                speakerService
                    .setCharacteristic(Characteristic.Active, Characteristic.Active.ACTIVE);
                speakerService
                    .setCharacteristic(Characteristic.Name, this.soundoutput);
                speakerService
                    .setCharacteristic(Characteristic.VolumeControlType, Characteristic.VolumeControlType.RELATIVE);
                speakerService
                    .getCharacteristic(Characteristic.VolumeSelector) //increase/decrease volume
                    .on('set', this.setVolume.bind(this));

                services.push(speakerService);

                tvService
                    .getCharacteristic(Characteristic.RemoteKey)
                    .on('set', 1);
                services.push(this.tvService);

                var inputSource = new Service.InputSource("test", "1"); //displayname, subtype?
                inputSource.setCharacteristic(Characteristic.Identifier, 1)
                    .setCharacteristic(Characteristic.ConfiguredName, "Apple TV")
                    .setCharacteristic(Characteristic.CurrentVisibilityState, Characteristic.CurrentVisibilityState.SHOWN)
                    .setCharacteristic(Characteristic.IsConfigured, Characteristic.IsConfigured.CONFIGURED)
                    .setCharacteristic(Characteristic.InputSourceType, Characteristic.InputSourceType.AIRPLAY);
                inputSource.uri = 1;
                inputSource.type = InputSourceType.AIRPLAY;
                inputSource.id = 1;
                services.push(inputSource);
                tvService.addLinkedService(inputSource);
                //this.inputSources[this.inputSourceCount] = inputSource;
                //this.uriToInputSource[uri] = inputSource;
                //this.inputSourceCount++;


                services.push(tvService);
                break;
            }

            case "Lock": {
                var lockService = new Service.LockMechanism();
                var LockCurrentState = lockService
                    .getCharacteristic(Characteristic.LockCurrentState)
                    .on('get', this.getLockCurrentState.bind(this));
                var LockTargetState = lockService
                    .getCharacteristic(Characteristic.LockTargetState)
                    .on('set', this.setLockTargetState.bind(this));

                // Register a listener for event changes
                eventEmitter.on(this.config.type + ":" + this.id + ":eventLockCurrentState", function (value) {

                    LockCurrentState.updateValue(value);
                    LockTargetState.updateValue(value)
                }.bind(this));

                services.push(lockService);
                break;
            }

            case "Fan": {
                var fanService = new Service.Fan();
                var PowerState = fanService
                    .getCharacteristic(Characteristic.On)
                    .on('set', this.setPowerState.bind(this))
                    .on('get', this.getPowerState.bind(this));

                // Register a listener for event changes
                eventEmitter.on(this.config.type + ":" + this.id + ":eventPowerState", function (value) {

                    PowerState.updateValue(value);
                }.bind(this));

                services.push(fanService);
                break;
            }

            case "GarageDoorOpener": {
                var garageDoorOpenerService = new Service.GarageDoorOpener();
                var CurrentDoorState = garageDoorOpenerService
                    .getCharacteristic(Characteristic.CurrentDoorState)
                    .on('get', this.getCurrentDoorState.bind(this));
                var TargetDoorState = garageDoorOpenerService
                    .getCharacteristic(Characteristic.TargetDoorState)
                    .on('set', this.setTargetDoorState.bind(this));
                garageDoorOpenerService
                    .getCharacteristic(Characteristic.ObstructionDetected)
                    .on('get', this.getObstructionDetected.bind(this));

                // Register a listener for event changes
                eventEmitter.on(this.config.type + ":" + this.id + ":eventCurrentDoorState", function (value) {
                    CurrentDoorState.updateValue(value); // also set target so the system knows we initiated it open/closed
                    TargetDoorState.updateValue(value);
                }.bind(this));

                services.push(garageDoorOpenerService);
                break;
            }

            case "SecuritySystem": {
                var securitySystemService = new Service.SecuritySystem();
                var SecuritySystemCurrentState = securitySystemService
                    .getCharacteristic(Characteristic.SecuritySystemCurrentState)
                    .on('get', this.getSecuritySystemCurrentState.bind(this));
                var SecuritySystemTargetState = securitySystemService
                    .getCharacteristic(Characteristic.SecuritySystemTargetState)
                    .on('set', this.setSecuritySystemTargetState.bind(this));

                // Register a listener for event changes
                eventEmitter.on(this.config.type + ":" + this.id + ":eventSecuritySystemCurrentState", function (value) {
                    SecuritySystemCurrentState.updateValue(value);
                    SecuritySystemTargetState.updateValue(value);
                }.bind(this));

                services.push(securitySystemService);
                break;
            }

            case "WindowCovering": {
                var windowCoveringService = new Service.WindowCovering();
                var CurrentPosition = windowCoveringService
                    .getCharacteristic(Characteristic.CurrentPosition)
                    .on('get', this.getCurrentPosition.bind(this));
                var TargetPosition = windowCoveringService
                    .getCharacteristic(Characteristic.TargetPosition)
                    .on('set', this.setTargetPosition.bind(this));
                //.on('get', this.getTargetPosition.bind(this));
                var PositionState = windowCoveringService
                    .getCharacteristic(Characteristic.PositionState)

                // Register a listener for event changes
                eventEmitter.on(this.config.type + ":" + this.id + ":eventCurrentPosition", function (value) {

                    TargetPosition.updateValue(value);
                    setTimeout(function () { CurrentPosition.updateValue(value); }, 2000);


                }.bind(this));

                services.push(windowCoveringService);

                break;
            }

            case "Thermostat": {
                var ThermostatService = new Service.Thermostat();

                var CurrentHeatingCoolingState = ThermostatService
                    .getCharacteristic(Characteristic.CurrentHeatingCoolingState)
                //.on('get', this.getCurrentHeatingCoolingState.bind(this));
                var TargetHeatingCoolingState = ThermostatService
                    .getCharacteristic(Characteristic.TargetHeatingCoolingState)
                    .on('get', this.getTargetHeatingCoolingState.bind(this))
                    .on('set', this.setTargetHeatingCoolingState.bind(this));
                var TargetTemperature = ThermostatService
                    .getCharacteristic(Characteristic.TargetTemperature)
                    .setProps({
                        minValue: 16,
                        maxValue: 32,
                        minStep: 1
                    })
                    .on('set', this.setTargetTemperature.bind(this))
                    .on('get', this.getTargetTemperature.bind(this));
                var CurrentTemperature = ThermostatService
                    .getCharacteristic(Characteristic.CurrentTemperature)
                    .setProps({
                        minValue: 16,
                        maxValue: 32
                    })
                    .on('get', this.getCurrentTemperature.bind(this));

                var TemperatureDisplayUnits = ThermostatService
                    .getCharacteristic(Characteristic.TemperatureDisplayUnits)

                TemperatureDisplayUnits.setValue(0);

                //State
                eventEmitter.on(this.config.type + ":" + this.id + ":eventTargetHeatingCoolingState", function (value) {

                    CurrentHeatingCoolingState.updateValue(value);
                    TargetHeatingCoolingState.updateValue(value);
                }.bind(this));

                //TargetTemperature
                eventEmitter.on(this.config.type + ":" + this.id + ":eventTargetTemperature", function (value) {

                    TargetTemperature.updateValue(value);

                }.bind(this));

                //CurrentTemperature
                eventEmitter.on(this.config.type + ":" + this.id + ":eventCurrentTemperature", function (value) {
                    CurrentTemperature.updateValue(value);
                }.bind(this));

                services.push(ThermostatService);

                break;
            }

            case "HeaterCooler": {
                var HeaterCoolerService = new Service.HeaterCooler();

                var HeaterCoolerPower = HeaterCoolerService
                    .getCharacteristic(Characteristic.Active)
                    .on('get', this.getPowerState.bind(this))
                    .on('set', this.setPowerState.bind(this));
                var TargetHeaterCoolerState = HeaterCoolerService
                    .getCharacteristic(Characteristic.TargetHeaterCoolerState)
                    .setProps({
                        validValues: [1, 2]
                    })
                    .on('get', this.getTargetHeaterCoolerState.bind(this))
                    .on('set', this.setTargetHeaterCoolerState.bind(this));
                var CurrentHeaterCoolerState = HeaterCoolerService
                    .getCharacteristic(Characteristic.CurrentHeaterCoolerState)

                var CoolingThresholdTemperature = HeaterCoolerService
                    .getCharacteristic(Characteristic.CoolingThresholdTemperature)
                    .setProps({
                        minValue: 16,
                        maxValue: 32,
                        minStep: 1
                    })
                    .on('set', this.setTargetTemperature.bind(this))
                    .on('get', this.getTargetTemperature.bind(this));
                var HeatingThresholdTemperature = HeaterCoolerService
                    .getCharacteristic(Characteristic.HeatingThresholdTemperature)
                    .setProps({
                        minValue: 16,
                        maxValue: 32,
                        minStep: 1
                    })
                    .on('set', this.setTargetTemperature.bind(this))
                    .on('get', this.getTargetTemperature.bind(this));
                var CurrentTemperature = HeaterCoolerService
                    .getCharacteristic(Characteristic.CurrentTemperature)
                    .on('get', this.getCurrentTemperature.bind(this));
                var RotationSpeed = HeaterCoolerService
                    .getCharacteristic(Characteristic.RotationSpeed)
                    .on('set', this.setRotationSpeed.bind(this))
                    .on('get', this.getRotationSpeed.bind(this));

                eventEmitter.on(this.config.type + ":" + this.id + ":eventPowerState", function (value) {
                    HeaterCoolerPower.updateValue(value);
                }.bind(this));

                eventEmitter.on(this.config.type + ":" + this.id + ":eventTargetHeaterCoolerState", function (value) {
                    var currStateValue;
                    if (value === 1) {
                        currStateValue = 2;
                    }
                    else if (value === 2) {
                        currStateValue = 3;
                    }

                    TargetHeaterCoolerState.updateValue(value);
                    setTimeout(function () { CurrentHeaterCoolerState.updateValue(currStateValue); }, 100);


                }.bind(this));

                //CurrentTemperature
                eventEmitter.on(this.config.type + ":" + this.id + ":eventCurrentTemperature", function (value) {
                    CurrentTemperature.updateValue(value);
                }.bind(this));

                //TargetTemperature
                eventEmitter.on(this.config.type + ":" + this.id + ":eventTargetTemperature", function (value) {
                    HeatingThresholdTemperature.updateValue(value);
                    CoolingThresholdTemperature.updateValue(value);
                }.bind(this));

                eventEmitter.on(this.config.type + ":" + this.id + ":eventRotationSpeed", function (value) {
                    RotationSpeed.updateValue(value);
                }.bind(this));

                services.push(HeaterCoolerService);
                break;
            }


            case "Heater": {
                var HeaterService = new Service.HeaterCooler();

                var HeaterPower = HeaterService
                    .getCharacteristic(Characteristic.Active)
                    .on('get', this.getPowerState.bind(this))
                    .on('set', this.setPowerState.bind(this));
                var TargetHeaterState = HeaterService
                    .getCharacteristic(Characteristic.TargetHeaterCoolerState)
                    .setProps({
                        validValues: [1]
                    })
                var CurrentHeaterState = HeaterService
                    .getCharacteristic(Characteristic.CurrentHeaterCoolerState)
                    .setProps({
                        validValues: [0, 2]
                    })

                var HeatingThresholdTemperature = HeaterService
                    .getCharacteristic(Characteristic.HeatingThresholdTemperature)
                    .setProps({
                        minValue: 16,
                        maxValue: 32,
                        minStep: 1
                    })
                    .on('set', this.setTargetTemperature.bind(this))
                    .on('get', this.getTargetTemperature.bind(this));
                var CurrentTemperature = HeaterService
                    .getCharacteristic(Characteristic.CurrentTemperature)
                    .on('get', this.getCurrentTemperature.bind(this));

                //PowerState
                eventEmitter.on(this.config.type + ":" + this.id + ":eventPowerState", function (value) {
                    if (value) {
                        CurrentHeaterState.updateValue(2);
                        TargetHeaterState.updateValue(1);
                    }
                    else {
                        CurrentHeaterState.updateValue(0);
                    }

                    HeaterPower.updateValue(value);
                }.bind(this));

                //CurrentTemperature
                eventEmitter.on(this.config.type + ":" + this.id + ":eventCurrentTemperature", function (value) {
                    CurrentTemperature.updateValue(value);
                }.bind(this));

                //TargetTemperature
                eventEmitter.on(this.config.type + ":" + this.id + ":eventTargetTemperature", function (value) {
                    HeatingThresholdTemperature.updateValue(value);
                }.bind(this));

                services.push(HeaterService);
                break;
            }

            case "Cooler": {
                var CoolerService = new Service.HeaterCooler();

                var CoolerPower = CoolerService
                    .getCharacteristic(Characteristic.Active)
                    .on('get', this.getPowerState.bind(this))
                    .on('set', this.setPowerState.bind(this));
                var TargetCoolerState = CoolerService
                    .getCharacteristic(Characteristic.TargetHeaterCoolerState)
                    .setProps({
                        validValues: [2]
                    })
                var CurrentCoolerState = CoolerService
                    .getCharacteristic(Characteristic.CurrentHeaterCoolerState)
                    .setProps({
                        validValues: [0, 3]
                    })

                var CoolingThresholdTemperature = CoolerService
                    .getCharacteristic(Characteristic.CoolingThresholdTemperature)
                    .setProps({
                        minValue: 16,
                        maxValue: 32,
                        minStep: 1
                    })
                    .on('set', this.setTargetTemperature.bind(this))
                    .on('get', this.getTargetTemperature.bind(this));
                var CurrentTemperature = CoolerService
                    .getCharacteristic(Characteristic.CurrentTemperature)
                    .on('get', this.getCurrentTemperature.bind(this));

                //PowerState
                eventEmitter.on(this.config.type + ":" + this.id + ":eventPowerState", function (value) {
                    if (value) {
                        CurrentCoolerState.updateValue(3);
                        TargetCoolerState.updateValue(2);
                    }
                    else {
                        CurrentCoolerState.updateValue(0);
                    }

                    CoolerPower.updateValue(value);
                }.bind(this));

                //CurrentTemperature
                eventEmitter.on(this.config.type + ":" + this.id + ":eventCurrentTemperature", function (value) {
                    CurrentTemperature.updateValue(value);
                }.bind(this));

                //TargetTemperature
                eventEmitter.on(this.config.type + ":" + this.id + ":eventTargetTemperature", function (value) {
                    CoolingThresholdTemperature.updateValue(value);
                }.bind(this));

                services.push(CoolerService);
                break;
            }

            case "SpeedFan": {
                var fanService = new Service.Fan();

                var RotationState = fanService
                    .getCharacteristic(Characteristic.On)
                    .on('set', this.setRotationState.bind(this)); // requied for turning off when not using slider interface

                var RotationSpeed = fanService
                    .getCharacteristic(Characteristic.RotationSpeed)
                    .on("set", this.setRotationSpeed.bind(this))
                    .on("get", this.getRotationSpeed.bind(this));

                eventEmitter.on(this.config.type + ":" + this.id + ":eventRotationSpeed", function (value) {

                    var power_value;
                    if (value == 0) {
                        power_value = 0;
                    } else {
                        power_value = 1;
                    }

                    RotationSpeed.updateValue(value);
                    RotationState.updateValue(power_value);

                }.bind(this));

                services.push(fanService);
                break;
            }

            case "AirPurifier": {
                var AirPurifierService = new Service.AirPurifier();
                var AirPurifierPowerState = AirPurifierService
                    .getCharacteristic(Characteristic.Active)
                    .on('set', this.setPowerState.bind(this))
                    .on('get', this.getPowerState.bind(this));
                var CurrentAirPurifierState = AirPurifierService
                    .getCharacteristic(Characteristic.CurrentAirPurifierState)
                //.on('get', this.getCurrentAirPurifierState.bind(this));
                var TargetAirPurifierState = AirPurifierService
                    .getCharacteristic(Characteristic.TargetAirPurifierState)
                    .on('set', this.setTargetAirPurifierState.bind(this))
                    .on('get', this.getTargetAirPurifierState.bind(this));
                var AirPurifierRotationSpeed = AirPurifierService
                    .getCharacteristic(Characteristic.RotationSpeed)
                    .on('set', this.setAirPurifierRotationSpeed.bind(this))
                    .on('get', this.getAirPurifierRotationSpeed.bind(this));
                var FilterChangeIndication = AirPurifierService
                    .getCharacteristic(Characteristic.FilterChangeIndication)
                var FilterLifeLevel = AirPurifierService
                    .getCharacteristic(Characteristic.FilterLifeLevel)
                    .on('get', this.getFilterLifeLevel.bind(this));

                eventEmitter.on(this.config.type + ":" + this.id + ":eventPowerState", function (value) {

                    if (value) {
                        CurrentAirPurifierState.updateValue(2);
                    } else {
                        CurrentAirPurifierState.updateValue(0);
                    }

                    AirPurifierPowerState.updateValue(value);
                }.bind(this));

                eventEmitter.on(this.config.type + ":" + this.id + ":eventAirPurifierRotationSpeed", function (value) {
                    if (value > 0) {
                        AirPurifierPowerState.updateValue(1);
                    }
                    else {
                        AirPurifierPowerState.updateValue(0);
                    }

                    AirPurifierRotationSpeed.updateValue(value);
                }.bind(this));

                eventEmitter.on(this.config.type + ":" + this.id + ":eventTargetAirPurifierState", function (value) {

                    TargetAirPurifierState.updateValue(value);
                }.bind(this));

                eventEmitter.on(this.config.type + ":" + this.id + ":eventFilterLifeLevel", function (value) {

                    let changeFilter;
                    if (value > 5) {
                        changeFilter = 0;
                    } else {
                        changeFilter = 1;
                    }
                    FilterLifeLevel.updateValue(value);
                    FilterChangeIndication.updateValue(changeFilter);
                }.bind(this));

                services.push(AirPurifierService);
                break;
            }

            case "AirQualitySensor": {
                var AirQualitySensorService = new Service.AirQualitySensor();
                var AirQuality = AirQualitySensorService
                    .getCharacteristic(Characteristic.AirQuality)
                //.on('get', this.getAirQuality.bind(this));
                var PM2_5Value = AirQualitySensorService
                    .getCharacteristic(Characteristic.PM2_5Density)
                    .on('get', this.getPM2_5Value.bind(this));
                var VOC_Value = AirQualitySensorService
                    .getCharacteristic(Characteristic.VOCDensity)
                    .on('get', this.getVOC_Value.bind(this));
                var CarbonDioxideLevel = AirQualitySensorService
                    .getCharacteristic(Characteristic.CarbonDioxideLevel)
                    .on('get', this.getCarbonDioxideLevel.bind(this));

                eventEmitter.on(this.config.type + ":" + this.id + ":eventPM2_5Value", function (value) {
                    var AIQ_value;
                    if (value < 35 && value > 0) {
                        AIQ_value = 1;
                    } else if (value < 75 && value >= 35) {
                        AIQ_value = 2;
                    }
                    else if (value < 115 && value >= 75) {
                        AIQ_value = 3;
                    }
                    else if (value < 150 && value >= 115) {
                        AIQ_value = 4;
                    }
                    else if (value >= 150) {
                        AIQ_value = 5;
                    } else {
                        AIQ_value = 0;
                    }
                    AirQuality.updateValue(AIQ_value);
                    PM2_5Value.updateValue(value);
                }.bind(this));

                eventEmitter.on(this.config.type + ":" + this.id + ":eventVOC_Value", function (value) {

                    VOC_Value.updateValue(value);
                }.bind(this));

                eventEmitter.on(this.config.type + ":" + this.id + ":eventCarbonDioxideLevel", function (value) {

                    CarbonDioxideLevel.updateValue(value);
                }.bind(this));

                services.push(AirQualitySensorService);
                break;
            }

            case "HumiditySensor": {
                var HumiditySensorService = new Service.HumiditySensor();
                var CurrentRelativeHumidity = HumiditySensorService
                    .getCharacteristic(Characteristic.CurrentRelativeHumidity)
                    .on('get', this.getCurrentRelativeHumidity.bind(this));

                eventEmitter.on(this.config.type + ":" + this.id + ":eventCurrentRelativeHumidity", function (value) {
                    CurrentRelativeHumidity.updateValue(value);
                }.bind(this));

                services.push(HumiditySensorService);
                break;
            }

            case "TemperatureSensor": {
                var TemperatureSensorService = new Service.TemperatureSensor();
                var TempSensorCurrentTemperature = TemperatureSensorService
                    .getCharacteristic(Characteristic.CurrentTemperature)
                    .on('get', this.getCurrentTemperature.bind(this));

                eventEmitter.on(this.config.type + ":" + this.id + ":eventCurrentTemperature", function (value) {
                    TempSensorCurrentTemperature.updateValue(value);
                }.bind(this));

                services.push(TemperatureSensorService);
                break;
            }

            case "ContactSensor": {
                var contactSensorService = new Service.ContactSensor();
                var ContactSensorState = contactSensorService
                    .getCharacteristic(Characteristic.ContactSensorState)
                    .on('get', this.getSensorState.bind(this));

                eventEmitter.on(this.config.type + ":" + this.id + ":eventSensorState", function (value) {
                    ContactSensorState.updateValue(value);
                }.bind(this));

                services.push(contactSensorService);
                break;
            }

            case "CarbonDioxideSensor": {
                var CarbonDioxideSensorService = new Service.CarbonDioxideSensor();
                var CarbonDioxideLevel = CarbonDioxideSensorService
                    .getCharacteristic(Characteristic.CarbonDioxideLevel)
                    .on('get', this.getCarbonDioxideLevel.bind(this));
                var CarbonDioxideDetected = CarbonDioxideSensorService
                    .getCharacteristic(Characteristic.CarbonDioxideDetected)
                //.on('get', this.getCarbonDioxideDetected.bind(this));

                eventEmitter.on(this.config.type + ":" + this.id + ":eventCarbonDioxideLevel", function (value) {

                    var Co2_value;
                    if (value > 800) {
                        Co2_value = 1;
                    }
                    else {
                        Co2_value = 0;
                    }
                    CarbonDioxideLevel.updateValue(value);
                    CarbonDioxideDetected.updateValue(Co2_value);
                }.bind(this));

                services.push(CarbonDioxideSensorService);
                break;
            }

            case "SmokeSensor": {
                var SmokeSensorService = new Service.SmokeSensor();
                var SmokeDetected = SmokeSensorService
                    .getCharacteristic(Characteristic.SmokeDetected)
                    .on('get', this.getSensorState.bind(this));

                eventEmitter.on(this.config.type + ":" + this.id + ":eventSensorState", function (value) {

                    SmokeDetected.updateValue(value);
                }.bind(this));

                services.push(SmokeSensorService);
                break;
            }

            case "OccupancySensor": {
                var OccupancySensorService = new Service.OccupancySensor();
                var OccupancyDetected = OccupancySensorService
                    .getCharacteristic(Characteristic.OccupancyDetected)
                    .on('get', this.getSensorState.bind(this));

                eventEmitter.on(this.config.type + ":" + this.id + ":eventSensorState", function (value) {

                    OccupancyDetected.updateValue(value);
                }.bind(this));

                services.push(OccupancySensorService);
                break;
            }

            case "MotionSensor": {
                var MotionSensorService = new Service.MotionSensor();
                var MotionDetected = MotionSensorService
                    .getCharacteristic(Characteristic.MotionDetected)
                    .on('get', this.getSensorState.bind(this));

                eventEmitter.on(this.config.type + ":" + this.id + ":eventSensorState", function (value) {

                    MotionDetected.updateValue(value);
                }.bind(this));

                services.push(MotionSensorService);
                break;
            }

            case "LightSensor": {
                var LightSensorService = new Service.LightSensor();
                var CurrentAmbientLightLevel = LightSensorService
                    .getCharacteristic(Characteristic.CurrentAmbientLightLevel)
                    .on('get', this.getCurrentAmbientLightLevel.bind(this));

                eventEmitter.on(this.config.type + ":" + this.id + ":eventCurrentAmbientLightLevel", function (value) {

                    CurrentAmbientLightLevel.updateValue(value);
                }.bind(this));

                services.push(LightSensorService);
                break;
            }

            case "LeakSensor": {
                var LeakSensorService = new Service.LeakSensor();
                var LeakDetected = LeakSensorService
                    .getCharacteristic(Characteristic.LeakDetected)
                    .on('get', this.getSensorState.bind(this));

                eventEmitter.on(this.config.type + ":" + this.id + ":eventSensorState", function (value) {

                    LeakDetected.setValue(value);
                }.bind(this));

                services.push(LeakSensorService);
                break;
            }

            case "Faucet": {
                var FaucetService = new Service.Faucet();
                var FaucetActive = FaucetService
                    .getCharacteristic(Characteristic.Active)
                    .on('get', this.getFaucetActive.bind(this))
                    .on('set', this.setFaucetActive.bind(this));

                eventEmitter.on(this.config.type + ":" + this.id + ":eventFaucetActive", function (value) {

                    FaucetActive.updateValue(value);
                }.bind(this));

                services.push(FaucetService);
                break;
            }

            case "Outlet": {
                var OutletService = new Service.Outlet();
                var OutletPower = OutletService
                    .getCharacteristic(Characteristic.On)
                    .on('get', this.getOutletPower.bind(this))
                    .on('set', this.setOutletPower.bind(this));
                var OutletInUse = OutletService
                    .getCharacteristic(Characteristic.InUse)

                eventEmitter.on(this.config.type + ":" + this.id + ":eventOutletPower", function (value) {

                    OutletInUse.updateValue(value);
                    OutletPower.updateValue(value);
                }.bind(this));

                services.push(OutletService);
                break;
            }

            case "Valve": {
                var ValveService = new Service.Valve();
                var ValveActive = ValveService
                    .getCharacteristic(Characteristic.Active)
                    .on('get', this.getValveActive.bind(this))
                    .on('set', this.setValveActive.bind(this));
                var ValveInUse = ValveService
                    .getCharacteristic(Characteristic.InUse)
                var ValveValveType = ValveService
                    .getCharacteristic(Characteristic.ValveType)

                ValveValveType.setValue(3);

                eventEmitter.on(this.config.type + ":" + this.id + ":eventValveActive", function (value) {

                    ValveInUse.updateValue(value);
                    ValveActive.updateValue(value);
                }.bind(this));

                services.push(ValveService);
                break;
            }

            case "Door": {
                var DoorService = new Service.Door();
                var CurrentPosition = DoorService
                    .getCharacteristic(Characteristic.CurrentPosition)
                    .on('get', this.getCurrentPosition.bind(this));
                var TargetPosition = DoorService
                    .getCharacteristic(Characteristic.TargetPosition)
                    .on('set', this.setTargetPosition.bind(this));
                var PositionState = DoorService
                    .getCharacteristic(Characteristic.PositionState)
                //.on('get', this.getPositionState.bind(this));

                eventEmitter.on(this.config.type + ":" + this.id + ":eventCurrentPosition", function (value) {
                    TargetPosition.updateValue(value);
                    setTimeout(function () { CurrentPosition.updateValue(value); }, 2000);
                }.bind(this));

                services.push(DoorService);
                break;
            }

            case "Window": {
                var WindowService = new Service.Window();
                var CurrentPosition = WindowService
                    .getCharacteristic(Characteristic.CurrentPosition)
                    .on('get', this.getCurrentPosition.bind(this));
                var TargetPosition = WindowService
                    .getCharacteristic(Characteristic.TargetPosition)
                    .on('set', this.setTargetPosition.bind(this));
                var PositionState = WindowService
                    .getCharacteristic(Characteristic.PositionState)

                eventEmitter.on(this.config.type + ":" + this.id + ":eventCurrentPosition", function (value) {
                    TargetPosition.updateValue(value);
                    setTimeout(function () { CurrentPosition.updateValue(value); }, 2000);
                }.bind(this));

                services.push(WindowService);
                break;
            }

            case "FilterMaintenance": {
                var FilterMaintenanceService = new Service.FilterMaintenance();
                var FilterChangeIndication = FilterMaintenanceService
                    .getCharacteristic(Characteristic.FilterChangeIndication)
                var FilterLifeLevel = FilterMaintenanceService
                    .getCharacteristic(Characteristic.FilterLifeLevel)
                    .on('get', this.getFilterLifeLevel.bind(this));

                eventEmitter.on(this.config.type + ":" + this.id + ":eventFilterLifeLevel", function (value) {
                    let changeFilter;
                    if (value > 5) {
                        changeFilter = 0;
                    } else {
                        changeFilter = 1;
                    }
                    FilterLifeLevel.updateValue(value);
                    FilterChangeIndication.updateValue(changeFilter);
                }.bind(this));

                services.push(FilterMaintenanceService);
                break;
            }

        }
        return services;
    }
}
