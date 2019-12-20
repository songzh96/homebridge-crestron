/*
https://github.com/nfarina/homebridge-legacy-plugins/blob/master/platforms/HomeSeer.js used for reference.
*/

'use strict';

var async = require('async');
<<<<<<< HEAD
var net = require('net');
var events = require('events');

var Service, Characteristic;

module.exports = function (homebridge) {
=======
var request = require("request");
var net = require('net');
var events = require('events');
var Service, Characteristic;

module.exports = function(homebridge) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
    Service = homebridge.hap.Service;
    Characteristic = homebridge.hap.Characteristic;
    homebridge.registerPlatform("homebridge-creskit", "CresKit", CresKit);
}

// TCP connection to Crestron Module
var cresKitSocket = new net.Socket();
var eventEmitter = new events.EventEmitter();

<<<<<<< HEAD
=======
// fromEventCheck
// Events from Crestron to Homebridge should NOT repeat back to Crestron after updating Homebridge (as Crestron already knows the status).
// Store the event name/value in a global array, stop the cmd from sending if match.
var eventCheckData = [];
function fromEventCheck(what) {
    var found = eventCheckData.indexOf(what);
    var originalFound = found;
    while (found !== -1) { // Remove all references
        eventCheckData.splice(found, 1);
        found = eventCheckData.indexOf(what);
    }
    if (originalFound==-1) { // No match
        return false;
    } else {
        return true;
    }
}
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c

var openGetStatus = []; // Sometimes a getStatus does not come back. We need to re-try for the app to be responsive.
function closeGetStatus(what) {
    var found = openGetStatus.indexOf(what);
    openGetStatus.splice(found, 1);

<<<<<<< HEAD
    // console.log(openGetStatus);
=======
    console.log(openGetStatus);
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
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
<<<<<<< HEAD
setInterval(function () { retryGetStatus(); }, 2000);
=======
setInterval(function() { retryGetStatus(); }, 2000);
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c

function CresKit(log, config) {
    this.log = log;
    this.config = config;
}

CresKit.prototype = {
<<<<<<< HEAD
    accessories: function (callback) {
=======
    accessories: function(callback) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
        var foundAccessories = [];

        // Build Device List
        this.log("Starting CresKit Config");

<<<<<<< HEAD
        cresKitSocket.connect(this.config["port"], this.config["host"], function () {
=======
        cresKitSocket.connect(this.config["port"], this.config["host"], function() {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
            this.log('Connected to Crestron Machine');
            // ERROR CONNECITON
        }.bind(this));

<<<<<<< HEAD
        cresKitSocket.on('close', function () {
=======
        cresKitSocket.on('close', function() {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
            this.log('Connection closed');
            // Handle error properly
            // Reconnect
            try {
<<<<<<< HEAD
                cresKitSocket.connect(this.config["port"], this.config["host"], function () {
=======
                cresKitSocket.connect(this.config["port"], this.config["host"], function() {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                    this.log('Re-Connected to Crestron Machine');
                }.bind(this));
            } catch (err) {
                this.log(err);
            }


        }.bind(this));

        // All Crestron replies goes via this connection
<<<<<<< HEAD
        cresKitSocket.on('data', function (data) {
=======
        cresKitSocket.on('data', function(data) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
            //this.log("Raw Crestron Data : " + data);

            // Data from Creston Module. This listener parses the information and updates Homebridge
            // get* - replies from get* requests
            // event* - sent upon any changes on Crestron side (including in response to set* commands)
            var dataArray = data.toString().split("*"); // Commands terminated with *
<<<<<<< HEAD
            async.each(dataArray, function (response, callback) {
                var responseArray = response.toString().split(":");
                // responseArray[0] = (config.type ie lightbulbs) : responseArray[1] = (id) : responseArray[2] = (command ie getPowerState) : responseArray[3] = (value)

                if (responseArray[0] != "") {
=======
            async.each(dataArray, function(response, callback) {
                var responseArray = response.toString().split(":");
                // responseArray[0] = (config.type ie lightbulbs) : responseArray[1] = (id) : responseArray[2] = (command ie getPowerState) : responseArray[3] = (value)

                if (responseArray[0]!="") {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                    eventEmitter.emit(responseArray[0] + ":" + responseArray[1] + ":" + responseArray[2], parseInt(responseArray[3])); // convert string to value
                    //this.log("EMIT: " + responseArray[0] + ":" + responseArray[1] + ":" + responseArray[2] + " = " + responseArray[3]);
                }

                callback();

<<<<<<< HEAD
            }.bind(this), function (err) {
=======
            }.bind(this), function(err) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                //console.log("SockedRx Processed");
            });

        }.bind(this));

        // Accessories Configuration
<<<<<<< HEAD
        async.each(this.config.accessories, function (accessory, asynCallback) {

            var accessory = new CresKitAccessory(this.log, this.config, accessory);
            foundAccessories.push(accessory);

            return asynCallback();  //let async know we are done
        }.bind(this), function (err) {

            if (err) {
=======
        async.each(this.config.accessories, function(accessory, asynCallback) {

            var accessory = new CresKitAccessory( this.log, this.config, accessory);
            foundAccessories.push(accessory);

            return asynCallback();  //let async know we are done
        }.bind(this), function(err) {

            if(err) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
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
<<<<<<< HEAD
    this.model = "Komen v2.1.2";
=======
    this.model = "CresKit";
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c

}

CresKitAccessory.prototype = {

<<<<<<< HEAD
    identify: function (callback) {
=======
    identify: function(callback) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
        callback();
    },
    //---------------
    // PowerState - Lightbulb, Switch, SingleSpeedFan (Scenes)
    //---------------
<<<<<<< HEAD
    getPowerState: function (callback) { // this.config.type = Lightbulb, Switch, etc
        cresKitSocket.write(this.config.type + ":" + this.id + ":getPowerState:*"); // (:* required) on get
        openGetStatus.push(this.config.type + ":" + this.id + ":getPowerState:*");
        // Listen Once for value coming back, if it does trigger callback
        eventEmitter.once(this.config.type + ":" + this.id + ":getPowerState", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getPowerState:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventPowerState", value);
                callback(null, value);
=======
    getPowerState: function(callback) { // this.config.type = Lightbulb, Switch, etc
        cresKitSocket.write(this.config.type + ":" + this.id + ":getPowerState:*"); // (:* required) on get
        openGetStatus.push(this.config.type + ":" + this.id + ":getPowerState:*");
        //this.log("cresKitSocket.write - " + this.config.type + ":" + this.id + ":getPowerState:*");

        // Listen Once for value coming back, if it does trigger callback
        eventEmitter.once(this.config.type + ":" + this.id + ":getPowerState", function(value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getPowerState:*");
                callback( null, value);
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
<<<<<<< HEAD
    setPowerState: function (value, callback) {
        //Do NOT send cmd to Crestron when Homebridge was notified from an Event - Crestron already knows the state!
        if (value) {
            value = 1;
        }
        else {
            value = 0;
        }
        cresKitSocket.write(this.config.type + ":" + this.id + ":setPowerState:" + value + "*"); // (* after value required on set)
=======
    setPowerState: function(value, callback) {
        //Do NOT send cmd to Crestron when Homebridge was notified from an Event - Crestron already knows the state!
        if (value)
        {
            value = 1;
        }
        else
        {
            value = 0;
        }
        cresKitSocket.write(this.config.type + ":" + this.id + ":setPowerState:" + value + "*"); // (* after value required on set)
        //this.log("cresKitSocket.write" + (this.config.type + ":" + this.id + ":setPowerState:" + value + "*"));
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
        callback();
    },
    //---------------
    // Dimming Light
    //---------------
<<<<<<< HEAD
    getLightBrightness: function (callback) {
=======
    getLightBrightness: function(callback) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
        cresKitSocket.write(this.config.type + ":" + this.id + ":getLightBrightness:*"); // (:* required) on get
        openGetStatus.push(this.config.type + ":" + this.id + ":getLightBrightness:*");

        // Listen Once for value coming back, if it does trigger callback
<<<<<<< HEAD
        eventEmitter.once(this.config.type + ":" + this.id + ":getLightBrightness", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getLightBrightness:*");

                eventEmitter.emit(this.config.type + ":" + this.id + ":eventLightBrightness", value);
                callback(null, value);
=======
        eventEmitter.once(this.config.type + ":" + this.id + ":getLightBrightness", function(value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getLightBrightness:*");

                // Update LightBrightness via event event
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventLightBrightness", value);
                callback( null, value);//
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
<<<<<<< HEAD
    setLightBrightness: function (value, callback) {

=======
    setLightBrightness: function(value, callback) {
        //Do NOT send cmd to Crestron when Homebridge was recently notified from an Event - Crestron already knows the state!
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
        cresKitSocket.write(this.config.type + ":" + this.id + ":setLightBrightness:" + value + "*"); // (* after value required on set)
        //this.log("cresKitSocket.write" + (this.config.type + ":" + this.id + ":setLightBrightness:" + value + "*"));
        callback();
    },

<<<<<<< HEAD
    setLightState: function (value, callback) {

        if (value) {
            cresKitSocket.write(this.config.type + ":" + this.id + ":setLightBrightness:999*");
        } else {
            cresKitSocket.write(this.config.type + ":" + this.id + ":setLightBrightness:0*");
=======
    setLightState: function(value, callback) {

        if (value) {
            cresKitSocket.write(this.config.type + ":" + this.id + ":setLightBrightness:999*");

        } else  {
            cresKitSocket.write(this.config.type + ":" + this.id + ":setLightBrightness:0*");

            //cresKitSocket.write(this.config.type + ":" + this.id + ":setLightBrightness:" + value + "*"); //65536 = 100 if off, otherwise leave current
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
        }

        callback();
    },
<<<<<<< HEAD

    //---------------
    // Garage
    //---------------
    getCurrentDoorState: function (callback) {
=======
    //---------------
    // Garage
    //---------------
    getCurrentDoorState: function(callback) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
        cresKitSocket.write(this.config.type + ":" + this.id + ":getCurrentDoorState:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getCurrentDoorState:*");

        // Listen Once for value coming back. 0 open, 1 closed
<<<<<<< HEAD
        eventEmitter.once(this.config.type + ":" + this.id + ":getCurrentDoorState", function (value) {
=======
        eventEmitter.once(this.config.type + ":" + this.id + ":getCurrentDoorState", function(value) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getCurrentDoorState:*");

                // Update TargetDoorState via event event
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventCurrentDoorState", value);

<<<<<<< HEAD
                callback(null, value);
=======
                callback( null, value);
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
<<<<<<< HEAD
    setTargetDoorState: function (value, callback) {
=======
    setTargetDoorState: function(value, callback) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
        //this.log("setTargetDoorState %s", value);
        cresKitSocket.write(this.config.type + ":" + this.id + ":setTargetDoorState:" + value + "*");
        callback();
    },
<<<<<<< HEAD
    getObstructionDetected: function (callback) {
        // Not yet support
        callback(null, 0);
=======
    getObstructionDetected: function(callback) {
        // Not yet support
        callback( null, 0 );
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
    },
    //---------------
    // Security System
    //---------------
<<<<<<< HEAD
    getSecuritySystemCurrentState: function (callback) {
=======
    getSecuritySystemCurrentState: function(callback) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
        cresKitSocket.write(this.config.type + ":" + this.id + ":getSecuritySystemCurrentState:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getSecuritySystemCurrentState:*");

        //armedStay=0 , armedAway=1, armedNight=2, disarmed=3, alarmValues = 4
<<<<<<< HEAD
        eventEmitter.once(this.config.type + ":" + this.id + ":getSecuritySystemCurrentState", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getSecuritySystemCurrentState:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventSecuritySystemCurrentState", value);
                callback(null, value);
=======
        eventEmitter.once(this.config.type + ":" + this.id + ":getSecuritySystemCurrentState", function(value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getSecuritySystemCurrentState:*");

                // Update securitySystemTargetState via event event
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventSecuritySystemCurrentState", value);

                callback( null, value);
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
<<<<<<< HEAD
    setSecuritySystemTargetState: function (value, callback) {
=======
    setSecuritySystemTargetState: function(value, callback) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
        cresKitSocket.write(this.config.type + ":" + this.id + ":setSecuritySystemTargetState:" + value + "*");

        callback();
    },
<<<<<<< HEAD

    //---------------
    // Lock (or any event that you needs push notifications)
    //---------------
    getLockCurrentState: function (callback) {
=======
    //---------------
    // Binary Sensor
    //---------------
    getBinarySensorState: function(callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":getBinarySensorState:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getBinarySensorState:*");

        // Listen Once for value coming back. 0 open, 1 closed
        eventEmitter.once(this.config.type + ":" + this.id + ":getBinarySensorState", function(value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getBinarySensorState:*");
                callback( null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
    //---------------
    // Lock (or any event that you needs push notifications)
    //---------------
    getLockCurrentState: function(callback) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
        //UNSECURED = 0;, SECURED = 1; .JAMMED = 2; UNKNOWN = 3;

        cresKitSocket.write(this.config.type + ":" + this.id + ":getLockCurrentState:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getLockCurrentState:*");

        // Listen Once for value coming back. 0 open, 1 closed
<<<<<<< HEAD
        eventEmitter.once(this.config.type + ":" + this.id + ":getLockCurrentState", function (value) {
=======
        eventEmitter.once(this.config.type + ":" + this.id + ":getLockCurrentState", function(value) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getLockCurrentState:*");

                // Update setLockTargetState via event event
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventLockCurrentState", value);

<<<<<<< HEAD
                callback(null, value);
=======
                callback( null, value);
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
<<<<<<< HEAD
    setLockTargetState: function (value, callback) {
=======
    setLockTargetState: function(value, callback) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
        //UNSECURED = 0;, SECURED = 1;
        cresKitSocket.write(this.config.type + ":" + this.id + ":setLockTargetState:" + value + "*");
        callback();

    },
    //---------------
<<<<<<< HEAD
    // SpeedFan
    //---------------
    getRotationSpeed: function (callback) {
=======
    // MultiSpeedFan
    //---------------
    getRotationSpeed: function(callback) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
        cresKitSocket.write(this.config.type + ":" + this.id + ":getRotationSpeed:*"); // (:* required) on get
        openGetStatus.push(this.config.type + ":" + this.id + ":getRotationSpeed:*");

        // Listen Once for value coming back, if it does trigger callback
<<<<<<< HEAD
        eventEmitter.once(this.config.type + ":" + this.id + ":getRotationSpeed", function (value) {
=======
        eventEmitter.once(this.config.type + ":" + this.id + ":getRotationSpeed", function(value) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getRotationSpeed:*");

                // Update RotationSpeed via event event
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventRotationSpeed", value);

<<<<<<< HEAD
                callback(null, value);
=======
                callback( null, value);
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
<<<<<<< HEAD
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
=======
    setRotationSpeed: function(value, callback) {

        //Do NOT send cmd to Crestron when Homebridge was recently notified from an Event - Crestron already knows the state!
        cresKitSocket.write(this.config.type + ":" + this.id + ":setRotationSpeed:" + value + "*"); // (* after value required on set)
        //this.log("cresKitSocket.write("+this.config.type + ":" + this.id + ":setRotationSpeed:" + value + "*");

        callback();
    },
    setRotationState: function(value, callback) {

        if (fromEventCheck(this.config.type + ":" + this.id + ":eventRotationState:" + value)==false) {
            if (value == 0) {
                cresKitSocket.write(this.config.type + ":" + this.id + ":setRotationSpeed:0*");
                //this.log("cresKitSocket.write("+this.config.type + ":" + this.id + ":setRotationSpeed:0*");
            }
            if (value == 1) {

                //cresKitSocket.write(this.config.type + ":" + this.id + ":setRotationSpeed:999*"); //999 = 100 if off, otherwise leave current
                //this.log("cresKitSocket.write("+this.config.type + ":" + this.id + ":setRotationSpeed:999*");
            }
        }

        callback();
    },
    //---------------
    // Window Covering
    //---------------
    getCurrentPosition: function(callback) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c

        cresKitSocket.write(this.config.type + ":" + this.id + ":getCurrentPosition:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getCurrentPosition:*");

<<<<<<< HEAD
        eventEmitter.once(this.config.type + ":" + this.id + ":getCurrentPosition", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getCurrentPosition:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventCurrentPosition", value);
                callback(null, value);
=======
        eventEmitter.once(this.config.type + ":" + this.id + ":getCurrentPosition", function(value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getCurrentPosition:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventCurrentPosition", value);
                callback( null, value);
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
<<<<<<< HEAD
    setTargetPosition: function (value, callback) {

        cresKitSocket.write(this.config.type + ":" + this.id + ":setTargetPosition:" + value + "*"); // (* after value required on set)
        callback();
    },

=======
    setTargetPosition: function(value, callback) {

        cresKitSocket.write(this.config.type + ":" + this.id + ":setTargetPosition:" + value + "*"); // (* after value required on set)
        //this.log("cresKitSocket.write("+this.config.type + ":" + this.id + ":setTargetPosition:" + value + "*");
        callback();

    },
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
    //---------------
    // Thermostat
    //---------------
    getTargetHeatingCoolingState: function (callback) {
        //INACTIVE = 0;, IDLE = 1; HEATING = 2; COOLING = 3;
<<<<<<< HEAD
=======

>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
        cresKitSocket.write(this.config.type + ":" + this.id + ":getTargetHeatingCoolingState:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getTargetHeatingCoolingState:*");

        eventEmitter.once(this.config.type + ":" + this.id + ":getTargetHeatingCoolingState", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getTargetHeatingCoolingState:*");
<<<<<<< HEAD
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventTargetHeatingCoolingState", value);
=======

                // Update setTargetHeatingCoolingState via event event
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventTargetHeatingCoolingState", value);

>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },

    setTargetHeatingCoolingState: function (value, callback) {
        //AUTO  = 0;, HEAT  = 1; COOL  = 2;
        cresKitSocket.write(this.config.type + ":" + this.id + ":setTargetHeatingCoolingState:" + value + "*");
<<<<<<< HEAD
=======
        //this.log("cresKitSocket.write(" + this.config.type + ":" + this.id + ":setTargetHeatingCoolingState:" + value + "*");
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
        callback();
    },

    getCurrentTemperature: function (callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":getCurrentTemperature:*"); // (:* required) on get
        openGetStatus.push(this.config.type + ":" + this.id + ":getCurrentTemperature:*");

<<<<<<< HEAD
        eventEmitter.once(this.config.type + ":" + this.id + ":getCurrentTemperature", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getCurrrentTemperature:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventCurrrentTemperature", value);
=======
        // Listen Once for value coming back, if it does trigger callback
        eventEmitter.once(this.config.type + ":" + this.id + ":getCurrentTemperature", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getCurrentTemperature:*");

>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },

    getTargetTemperature: function (callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":getTargetTemperature:*"); // (:* required) on get
        openGetStatus.push(this.config.type + ":" + this.id + ":getTargetTemperature:*");

<<<<<<< HEAD
        eventEmitter.once(this.config.type + ":" + this.id + ":getTargetTemperature", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getTargetTemperature:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventTargetTemperature", value);
=======
        // Listen Once for value coming back, if it does trigger callback
        eventEmitter.once(this.config.type + ":" + this.id + ":getTargetTemperature", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getTargetTemperature:*");

>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },

    setTargetTemperature: function (value, callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":setTargetTemperature:" + value + "*"); // (* after value required on set)
<<<<<<< HEAD
        callback();
    },

    //---------------
    // HeaterCooler
    //---------------
    getTargetHeaterCoolerState: function (callback) {
        //INACTIVE = 0;, IDLE = 1; HEATING = 2; COOLING = 3;
=======
        //this.log("cresKitSocket.write(" + this.config.type + ":" + this.id + ":setTargetTemperature:" + value + "*");

        callback();
    },
    //---------------
    // HeaterCooler
    //---------------
    getHeaterCoolerPower: function (callback) {
        //OFF  = 0; ON  = 1;

        cresKitSocket.write(this.config.type + ":" + this.id + ":getHeaterCoolerPower:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getHeaterCoolerPower:*");

        eventEmitter.once(this.config.type + ":" + this.id + ":getHeaterCoolerPower", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getHeaterCoolerPower:*");

                // Update setTargetHeatingCoolingState via event event
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventHeaterCoolerPower", value);

                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },

    setHeaterCoolerPower: function (value, callback) {
        //OFF  = 0; ON  = 1;
        cresKitSocket.write(this.config.type + ":" + this.id + ":setHeaterCoolerPower:" + value + "*");
        //this.log("cresKitSocket.write(" + this.config.type + ":" + this.id + ":setTargetHeatingCoolingState:" + value + "*");
        callback();
    },
    getTargetHeaterCoolerState: function (callback) {
        //INACTIVE = 0;, IDLE = 1; HEATING = 2; COOLING = 3;

>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
        cresKitSocket.write(this.config.type + ":" + this.id + ":getTargetHeaterCoolerState:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getTargetHeaterCoolerState:*");

        eventEmitter.once(this.config.type + ":" + this.id + ":getTargetHeaterCoolerState", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getTargetHeaterCoolerState:*");
<<<<<<< HEAD
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventTargetHeaterCoolerState", value);
=======

                // Update setTargetHeatingCoolingState via event event
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventTargetHeaterCoolerState", value);

>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },

    setTargetHeaterCoolerState: function (value, callback) {
        //AUTO  = 0;, HEAT  = 1; COOL  = 2;
        cresKitSocket.write(this.config.type + ":" + this.id + ":setTargetHeaterCoolerState:" + value + "*");
<<<<<<< HEAD
=======
        //this.log("cresKitSocket.write(" + this.config.type + ":" + this.id + ":setTargetHeatingCoolingState:" + value + "*");
        callback();
    },

    getCurrentTemperature: function (callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":getCurrentTemperature:*"); // (:* required) on get
        openGetStatus.push(this.config.type + ":" + this.id + ":getCurrentTemperature:*");

        // Listen Once for value coming back, if it does trigger callback
        eventEmitter.once(this.config.type + ":" + this.id + ":getCurrentTemperature", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getCurrentTemperature:*");

                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },

    getTargetTemperature: function (callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":getTargetTemperature:*"); // (:* required) on get
        openGetStatus.push(this.config.type + ":" + this.id + ":getTargetTemperature:*");

        // Listen Once for value coming back, if it does trigger callback
        eventEmitter.once(this.config.type + ":" + this.id + ":getTargetTemperature", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getTargetTemperature:*");

                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
    setTargetTemperature: function (value, callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":setTargetTemperature:" + value + "*"); // (* after value required on set)
        //this.log("cresKitSocket.write(" + this.config.type + ":" + this.id + ":setTargetTemperature:" + value + "*");

>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
        callback();
    },

    setRotationSpeed: function (value, callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":setRotationSpeed:" + value + "*"); // (* after value required on set)
<<<<<<< HEAD
=======
        //this.log("cresKitSocket.write(" + this.config.type + ":" + this.id + ":setTargetTemperature:" + value + "*");

>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
        callback();
    },
    getRotationSpeed: function (callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":getRotationSpeed:*"); // (:* required) on get
        openGetStatus.push(this.config.type + ":" + this.id + ":getRotationSpeed:*");

<<<<<<< HEAD
        eventEmitter.once(this.config.type + ":" + this.id + ":getRotationSpeed", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getRotationSpeed:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventRotationSpeed", value);
=======
        // Listen Once for value coming back, if it does trigger callback
        eventEmitter.once(this.config.type + ":" + this.id + ":getRotationSpeed", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getRotationSpeed:*");

>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
<<<<<<< HEAD

    //---------------
    // AirPurifier
    //---------------
    getTargetAirPurifierState: function (callback) {
        //MANUAL = 0; AUTO  = 1;
=======
    //---------------
    // AirPurifier
    //---------------
    getAirPurifierPowerState: function (callback) {
        //OFF = 0; ON = 1;

        cresKitSocket.write(this.config.type + ":" + this.id + ":getAirPurifierPowerState:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getAirPurifierPowerState:*");

        eventEmitter.once(this.config.type + ":" + this.id + ":getAirPurifierPowerState", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getAirPurifierPowerState:*");

                eventEmitter.emit(this.config.type + ":" + this.id + ":eventAirPurifierPowerState",value);
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },

    setAirPurifierPowerState: function (value, callback) {
        //OFF = 0; ON = 1;
        cresKitSocket.write(this.config.type + ":" + this.id + ":setAirPurifierPowerState:" + value + "*");
        //this.log("cresKitSocket.write(" + this.config.type + ":" + this.id + ":setAirPurifierPowerState:" + value + "*");
        callback();
    },
    getTargetAirPurifierState: function (callback) {
        //MANUAL = 0; AUTO  = 1;

>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
        cresKitSocket.write(this.config.type + ":" + this.id + ":getTargetAirPurifierState:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getTargetAirPurifierState:*");

        eventEmitter.once(this.config.type + ":" + this.id + ":getTargetAirPurifierState", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getTargetAirPurifierState:*");
<<<<<<< HEAD
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventTargetAirPurifierState", value);
=======

                // Update setTargetAirPurifierState via event event
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventTargetAirPurifierState", value);

>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },

    setTargetAirPurifierState: function (value, callback) {
        //MANUAL = 0; AUTO  = 1;
        cresKitSocket.write(this.config.type + ":" + this.id + ":setTargetAirPurifierState:" + value + "*");
<<<<<<< HEAD
        callback();
    },
    getAirPurifierRotationSpeed: function (callback) {
=======
        //this.log("cresKitSocket.write(" + this.config.type + ":" + this.id + ":setTargetAirPurifierState:" + value + "*");
        callback();
    },
    getAirPurifierRotationSpeed: function (callback) {
        //AirPurifierRotationSpeed 0-100
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c

        cresKitSocket.write(this.config.type + ":" + this.id + ":getAirPurifierRotationSpeed:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getAirPurifierRotationSpeed:*");

        eventEmitter.once(this.config.type + ":" + this.id + ":getAirPurifierRotationSpeed", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getAirPurifierRotationSpeed:*");
<<<<<<< HEAD
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventAirPurifierRotationSpeed", value);
=======

                // Update setAirPurifierRotationSpeed via event event
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventAirPurifierRotationSpeed", value);

>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },

    setAirPurifierRotationSpeed: function (value, callback) {
<<<<<<< HEAD
        cresKitSocket.write(this.config.type + ":" + this.id + ":setAirPurifierRotationSpeed:" + value + "*");
=======
        //AirPurifierRotationSpeed 0-100
        cresKitSocket.write(this.config.type + ":" + this.id + ":setAirPurifierRotationSpeed:" + value + "*");
        //this.log("cresKitSocket.write(" + this.config.type + ":" + this.id + ":setAirPurifierRotationSpeed:" + value + "*");
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
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
<<<<<<< HEAD
=======
        //AirPurifierRotationSpeed 0-100

>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
        cresKitSocket.write(this.config.type + ":" + this.id + ":getPM2_5Value:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getPM2_5Value:*");

        eventEmitter.once(this.config.type + ":" + this.id + ":getPM2_5Value", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getPM2_5Value:*");
<<<<<<< HEAD
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventPM2_5Value", value);
=======
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },

    getVOC_Value: function (callback) {
<<<<<<< HEAD
=======
        //AirPurifierRotationSpeed 0-100

>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
        cresKitSocket.write(this.config.type + ":" + this.id + ":getVOC_Value:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getVOC_Value:*");

        eventEmitter.once(this.config.type + ":" + this.id + ":getVOC_Value", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getVOC_Value:*");
<<<<<<< HEAD
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventVOC_Value", value);
=======
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },

    getCarbonDioxideLevel: function (callback) {
<<<<<<< HEAD
=======
        //AirPurifierRotationSpeed 0-100

>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
        cresKitSocket.write(this.config.type + ":" + this.id + ":getCarbonDioxideLevel:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getCarbonDioxideLevel:*");

        eventEmitter.once(this.config.type + ":" + this.id + ":getCarbonDioxideLevel", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getCarbonDioxideLevel:*");
<<<<<<< HEAD
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventCarbonDioxideLevel", value);
=======
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
<<<<<<< HEAD

=======
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
    //---------------
    // HumiditySensor
    //---------------
    getCurrentRelativeHumidity: function (callback) {
        //Humidity 0-100
<<<<<<< HEAD
=======

>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
        cresKitSocket.write(this.config.type + ":" + this.id + ":getCurrentRelativeHumidity:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getCurrentRelativeHumidity:*");

        eventEmitter.once(this.config.type + ":" + this.id + ":getCurrentRelativeHumidity", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getCurrentRelativeHumidity:*");
<<<<<<< HEAD
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventCurrentRelativeHumidity", value);
=======
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },

    //---------------
    // TemperatureSensor
    //---------------
<<<<<<< HEAD
    

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
=======
    getTempSensorCurrentTemperature: function (callback) {
        //CurrentTemperature 0-100

        cresKitSocket.write(this.config.type + ":" + this.id + ":getTempSensorCurrentTemperature:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getTempSensorCurrentTemperature:*");

        eventEmitter.once(this.config.type + ":" + this.id + ":getTempSensorCurrentTemperature", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getTempSensorCurrentTemperature:*");
                callback(null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
    //---------------
    // SmokeSensor
    //---------------
    getSmokeDetected: function(callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":getSmokeDetected:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getSmokeDetected:*");

        // Listen Once for value coming back. 0 open, 1 closed
        eventEmitter.once(this.config.type + ":" + this.id + ":getSmokeDetected", function(value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getSmokeDetected:*");
                callback( null, value);
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
<<<<<<< HEAD

    //---------------
    // LightSensor
    //---------------
    getCurrentAmbientLightLevel: function (callback) {
=======
    //---------------
    // OccupancySensor
    //---------------
    getOccupancyDetected: function(callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":getOccupancyDetected:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getOccupancyDetected:*");

        // Listen Once for value coming back. 0 open, 1 closed
        eventEmitter.once(this.config.type + ":" + this.id + ":getOccupancyDetected", function(value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getOccupancyDetected:*");
                callback( null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
    //---------------
    // MotionSensor
    //---------------
    getMotionDetected: function(callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":getMotionDetected:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getMotionDetected:*");

        // Listen Once for value coming back. 0 open, 1 closed
        eventEmitter.once(this.config.type + ":" + this.id + ":getMotionDetected", function(value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getMotionDetected:*");
                callback( null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
    //---------------
    // LightSensor
    //---------------
    getCurrentAmbientLightLevel: function(callback) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
        cresKitSocket.write(this.config.type + ":" + this.id + ":getCurrentAmbientLightLevel:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getCurrentAmbientLightLevel:*");

        // Listen Once for value coming back. 0 open, 1 closed
<<<<<<< HEAD
        eventEmitter.once(this.config.type + ":" + this.id + ":getCurrentAmbientLightLevel", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getCurrentAmbientLightLevel:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventCurrentAmbientLightLevel", value);
                callback(null, value);
=======
        eventEmitter.once(this.config.type + ":" + this.id + ":getCurrentAmbientLightLevel", function(value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getCurrentAmbientLightLevel:*");
                callback( null, value);
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
<<<<<<< HEAD

    //---------------
    // Faucet
    //---------------
    getFaucetActive: function (callback) {
=======
    //---------------
    // LeakSensor
    //---------------
    getLeakDetected: function(callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":getLeakDetected:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getLeakDetected:*");

        // Listen Once for value coming back. 0 open, 1 closed
        eventEmitter.once(this.config.type + ":" + this.id + ":getLeakDetected", function(value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getLeakDetected:*");
                callback( null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
    //---------------
    // Faucet
    //---------------
    getFaucetActive: function(callback) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
        cresKitSocket.write(this.config.type + ":" + this.id + ":getFaucetActive:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getFaucetActive:*");

        // Listen Once for value coming back. 0 open, 1 closed
<<<<<<< HEAD
        eventEmitter.once(this.config.type + ":" + this.id + ":getFaucetActive", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getFaucetActive:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventFaucetActive", value);
                callback(null, value);
=======
        eventEmitter.once(this.config.type + ":" + this.id + ":getFaucetActive", function(value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getFaucetActive:*");
                // Update FaucetActive via event event
                //eventEmitter.emit(this.config.type + ":" + this.id + ":eventFaucetActive", value);

                callback( null, value);
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
    setFaucetActive: function (value, callback) {
        //INACTIVE = 0; ACTIVE  = 1;
        cresKitSocket.write(this.config.type + ":" + this.id + ":setFaucetActive:" + value + "*");
<<<<<<< HEAD
        callback();
    },
        
    //---------------
    // Outlet
    //---------------
    getOutletPower: function (callback) {
=======
        //this.log("cresKitSocket.write(" + this.config.type + ":" + this.id + ":setFaucetActive:" + value + "*");

        callback();
    },

    //---------------
    // Door
    //---------------
    getCurrentPosition: function(callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":getCurrentPosition:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getCurrentPosition:*");

        // Listen Once for value coming back. 0 open, 1 closed
        eventEmitter.once(this.config.type + ":" + this.id + ":getCurrentPosition", function(value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getCurrentPosition:*");
                // Update LeakDetected via event event
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventCurrentPosition", value);

                callback( null, value);
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
    setTargetPosition: function (value, callback) {
        //TargetPosition 0-100

        cresKitSocket.write(this.config.type + ":" + this.id + ":setTargetPosition:" + value + "*");
        //this.log("cresKitSocket.write(" + this.config.type + ":" + this.id + ":setTargetPosition:" + value + "*");

        callback();
    },

    //---------------
    // Outlet
    //---------------
    getOutletPower: function(callback) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
        cresKitSocket.write(this.config.type + ":" + this.id + ":getOutletPower:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getOutletPower:*");

        // Listen Once for value coming back. 0 open, 1 closed
<<<<<<< HEAD
        eventEmitter.once(this.config.type + ":" + this.id + ":getOutletPower", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getOutletPower:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventOutletPower", value);
                callback(null, value);
=======
        eventEmitter.once(this.config.type + ":" + this.id + ":getOutletPower", function(value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getOutletPower:*");
                // Update LeakDetected via event event
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventOutletPower", value);

                callback( null, value);
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
    setOutletPower: function (value, callback) {
        //ON = 1; OFF = 0
<<<<<<< HEAD
        cresKitSocket.write(this.config.type + ":" + this.id + ":setOutletPower:" + value + "*");
=======

        cresKitSocket.write(this.config.type + ":" + this.id + ":setOutletPower:" + value + "*");
        //this.log("cresKitSocket.write(" + this.config.type + ":" + this.id + ":setOutletPower:" + value + "*");

>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
        callback();
    },

    //---------------
    // Valve
    //---------------
<<<<<<< HEAD
    getValveActive: function (callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":getValveActive:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getValveActive:*");

        eventEmitter.once(this.config.type + ":" + this.id + ":getValveActive", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getValveActive:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventValveActive", value);
                callback(null, value);
=======
    getValveActive: function(callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":getValveActive:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getValveActive:*");

        // Listen Once for value coming back. 0 open, 1 closed
        eventEmitter.once(this.config.type + ":" + this.id + ":getValveActive", function(value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getValveActive:*");
                // Update LeakDetected via event event
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventValveActive", value);

                callback( null, value);
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
    setValveActive: function (value, callback) {
        //ON = 1; OFF = 0
<<<<<<< HEAD
        cresKitSocket.write(this.config.type + ":" + this.id + ":setValveActive:" + value + "*");
        callback();
    },

    //---------------
    // FilterMaintenance
    //---------------
    getFilterLifeLevel: function (callback) {
=======

            cresKitSocket.write(this.config.type + ":" + this.id + ":setValveActive:" + value + "*");
        callback();
    },
    //---------------
    // FilterMaintenance
    //---------------
    getFilterLifeLevel: function(callback) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
        cresKitSocket.write(this.config.type + ":" + this.id + ":getFilterLifeLevel:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getFilterLifeLevel:*");

        // Listen Once for value coming back. 0 open, 1 closed
<<<<<<< HEAD
        eventEmitter.once(this.config.type + ":" + this.id + ":getFilterLifeLevel", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getFilterLifeLevel:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventFilterLifeLevel", value);
                callback(null, value);
=======
        eventEmitter.once(this.config.type + ":" + this.id + ":getFilterLifeLevel", function(value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getFilterLifeLevel:*");
                // Update LeakDetected via event event
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventFilterLifeLevel", value);

                callback( null, value);
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
    //---------------
    // Speaker
    //---------------
<<<<<<< HEAD
    getVolume: function (callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":getVolume:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getVolume:*");

        eventEmitter.once(this.config.type + ":" + this.id + ":getVolume", function (value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getVolume:*");
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventVolume", value);
                callback(null, value);
=======
    getVolume: function(callback) {
        cresKitSocket.write(this.config.type + ":" + this.id + ":getVolume:*"); // (:* required)
        openGetStatus.push(this.config.type + ":" + this.id + ":getVolume:*");

        // Listen Once for value coming back. 0 open, 1 closed
        eventEmitter.once(this.config.type + ":" + this.id + ":getVolume", function(value) {
            try {
                closeGetStatus(this.config.type + ":" + this.id + ":getVolume:*");
                // Update LeakDetected via event
                eventEmitter.emit(this.config.type + ":" + this.id + ":eventVolume", value);

                callback( null, value);
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
            } catch (err) {
                this.log(err);
            }
        }.bind(this));
    },
    setVolume: function (value, callback) {
        //ON = 1; OFF = 0
<<<<<<< HEAD
        cresKitSocket.write(this.config.type + ":" + this.id + ":setVolume:" + value + "*");
=======
        console.log(value);
        if (fromEventCheck(this.config.type + ":" + this.id + ":eventVolume:" + value) == false) {
            cresKitSocket.write(this.config.type + ":" + this.id + ":setVolume:" + value + "*");
            //this.log("cresKitSocket.write(" + this.config.type + ":" + this.id + ":setVolume:" + value + "*");
        }
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
        callback();
    },
    //---------------
    // Characteristic Config
    //---------------
<<<<<<< HEAD
    getServices: function () {
=======
    getServices: function() {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
        var services = []

        var informationService = new Service.AccessoryInformation();
        informationService
            .setCharacteristic(Characteristic.Manufacturer, "CresKit")
<<<<<<< HEAD
            .setCharacteristic(Characteristic.Model, this.model)
            .setCharacteristic(Characteristic.SerialNumber, "CK " + this.config.type + " ID " + this.id);
        services.push(informationService);

        switch (this.config.type) {
=======
            .setCharacteristic(Characteristic.Model, this.model )
            .setCharacteristic(Characteristic.SerialNumber, "CK " + this.config.type + " ID " + this.id);
        services.push( informationService );

        switch( this.config.type ) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
            case "Lightbulb": {
                var lightbulbService = new Service.Lightbulb();
                var PowerState = lightbulbService
                    .getCharacteristic(Characteristic.On)
                    .on('set', this.setPowerState.bind(this))
                    .on('get', this.getPowerState.bind(this));

                // Register a listener
<<<<<<< HEAD
                eventEmitter.on(this.config.type + ":" + this.id + ":eventPowerState", function (value) {
=======
                eventEmitter.on(this.config.type + ":" + this.id + ":eventPowerState", function(value) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c

                    PowerState.updateValue(value);
                }.bind(this));

<<<<<<< HEAD
                services.push(lightbulbService);
=======
                services.push( lightbulbService );
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                break;
            }

            case "DimLightbulb": {
                var DimLightbulbService = new Service.Lightbulb();
                var LightState = DimLightbulbService
                    .getCharacteristic(Characteristic.On)
                    .on('set', this.setLightState.bind(this));

                var Brightness = DimLightbulbService
                    .getCharacteristic(Characteristic.Brightness)
<<<<<<< HEAD
                    .on('set', this.setLightBrightness.bind(this))
                    .on('get', this.getLightBrightness.bind(this));

                // Register a listener for event changes (dim-light)
                eventEmitter.on(this.config.type + ":" + this.id + ":eventLightBrightness", function (value) {
                    var light_power_value;
                    if (value) {
                        light_power_value = 1;
                    }
                    else {
=======
                    .on('set',this.setLightBrightness.bind(this))
                    .on('get',this.getLightBrightness.bind(this));

                // Register a listener for event changes (dim-light)
                eventEmitter.on(this.config.type + ":" + this.id + ":eventLightBrightness", function(value) {
                    var light_power_value;
                    if(value)
                    {
                        light_power_value = 1;
                    }
                    else{
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                        light_power_value = 0;
                    }
                    Brightness.updateValue(value);
                    LightState.updateValue(light_power_value);
                }.bind(this));

<<<<<<< HEAD
                services.push(DimLightbulbService);
=======
                services.push( DimLightbulbService );
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                break;
            }

            case "Switch": {
                var switchService = new Service.Switch();
                var PowerState = switchService
                    .getCharacteristic(Characteristic.On)
                    .on('set', this.setPowerState.bind(this))
                    .on('get', this.getPowerState.bind(this));

                // Register a listener for event changes
<<<<<<< HEAD
                eventEmitter.on(this.config.type + ":" + this.id + ":eventPowerState", function (value) {
=======
                eventEmitter.on(this.config.type + ":" + this.id + ":eventPowerState", function(value) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c

                    PowerState.updateValue(value);
                }.bind(this));

<<<<<<< HEAD
                services.push(switchService);
=======
                services.push( switchService );
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                break;
            }

            case "TV": {
                var tvService = new Service.Television();
<<<<<<< HEAD


                var PowerState = tvService
                    .getCharacteristic(Characteristic.Active)
                    .on('get', this.getPowerState.bind(this))
                    .on('set', this.setPowerState.bind(this));

                // Register a listener for event changes
                eventEmitter.on(this.config.type + ":" + this.id + ":eventPowerState", function (value) {
=======
                /**
                var PowerState = tvService
                    .getCharacteristic(Characteristic.PowerModeSelection)
                    .on('set', this.setPowerState.bind(this))
                    .on('get', this.getPowerState.bind(this));
                **/

                var PowerState = tvService
                  .getCharacteristic(Characteristic.Active)
                  .on('get', this.getPowerState.bind(this))
                  .on('set', this.setPowerState.bind(this));

                // Register a listener for event changes
                eventEmitter.on(this.config.type + ":" + this.id + ":eventPowerState", function(value) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c

                    PowerState.updateValue(value);
                }.bind(this));

                tvService
<<<<<<< HEAD
                    .setCharacteristic(
                        Characteristic.SleepDiscoveryMode,
                        Characteristic.SleepDiscoveryMode.ALWAYS_DISCOVERABLE
                    );
=======
                .setCharacteristic(
                  Characteristic.SleepDiscoveryMode,
                  Characteristic.SleepDiscoveryMode.ALWAYS_DISCOVERABLE
                );
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c


                var speakerService = new Service.TelevisionSpeaker();
                speakerService
<<<<<<< HEAD
                    .setCharacteristic(Characteristic.Active, Characteristic.Active.ACTIVE);
                speakerService
                    .setCharacteristic(Characteristic.Name, this.soundoutput);
                speakerService
                    .setCharacteristic(Characteristic.VolumeControlType, Characteristic.VolumeControlType.RELATIVE);
                speakerService
                    .getCharacteristic(Characteristic.VolumeSelector) //increase/decrease volume
                    .on('set', this.setVolume.bind(this));
=======
                  .setCharacteristic(Characteristic.Active, Characteristic.Active.ACTIVE);
                speakerService
                  .setCharacteristic(Characteristic.Name, this.soundoutput);
                speakerService
                  .setCharacteristic(Characteristic.VolumeControlType, Characteristic.VolumeControlType.RELATIVE);
                speakerService
                  .getCharacteristic(Characteristic.VolumeSelector) //increase/decrease volume
                  .on('set', this.setVolume.bind(this));
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c


                services.push(speakerService);

                tvService
<<<<<<< HEAD
                    .getCharacteristic(Characteristic.RemoteKey)
                    .on('set', 1);
=======
                .getCharacteristic(Characteristic.RemoteKey)
                .on('set', 1);
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                services.push(this.tvService);



                var inputSource = new Service.InputSource("test", "1"); //displayname, subtype?
<<<<<<< HEAD
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
=======
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


                services.push( tvService );
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
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
<<<<<<< HEAD
                eventEmitter.on(this.config.type + ":" + this.id + ":eventLockCurrentState", function (value) {
=======
                eventEmitter.on(this.config.type + ":" + this.id + ":eventLockCurrentState", function(value) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c

                    LockCurrentState.updateValue(value);
                    LockTargetState.updateValue(value)
                }.bind(this));

<<<<<<< HEAD
                services.push(lockService);
                break;
            }

            case "Fan": {
=======
                services.push( lockService );
                break;
            }

            case "SingleSpeedFan": {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                var fanService = new Service.Fan();
                var PowerState = fanService
                    .getCharacteristic(Characteristic.On)
                    .on('set', this.setPowerState.bind(this))
                    .on('get', this.getPowerState.bind(this));

                // Register a listener for event changes
<<<<<<< HEAD
                eventEmitter.on(this.config.type + ":" + this.id + ":eventPowerState", function (value) {
=======
                eventEmitter.on(this.config.type + ":" + this.id + ":eventPowerState", function(value) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c

                    PowerState.updateValue(value);
                }.bind(this));

<<<<<<< HEAD
                services.push(fanService);
=======
                services.push( fanService );
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
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
<<<<<<< HEAD
                eventEmitter.on(this.config.type + ":" + this.id + ":eventCurrentDoorState", function (value) {
=======
                eventEmitter.on(this.config.type + ":" + this.id + ":eventCurrentDoorState", function(value) {
                    eventCheckData.push(this.config.type + ":" + this.id + ":eventCurrentDoorState:" + value);
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                    CurrentDoorState.updateValue(value); // also set target so the system knows we initiated it open/closed
                    TargetDoorState.updateValue(value);
                }.bind(this));

<<<<<<< HEAD
                services.push(garageDoorOpenerService);
=======
                services.push( garageDoorOpenerService );
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
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
<<<<<<< HEAD
                eventEmitter.on(this.config.type + ":" + this.id + ":eventSecuritySystemCurrentState", function (value) {
=======
                eventEmitter.on(this.config.type + ":" + this.id + ":eventSecuritySystemCurrentState", function(value) {
                    eventCheckData.push(this.config.type + ":" + this.id + ":eventSecuritySystemCurrentState:" + value);
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                    SecuritySystemCurrentState.updateValue(value);
                    SecuritySystemTargetState.updateValue(value);
                }.bind(this));

<<<<<<< HEAD
                services.push(securitySystemService);
=======
                services.push( securitySystemService );
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
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
<<<<<<< HEAD
                //.on('get', this.getTargetPosition.bind(this));
=======
                    //.on('get', this.getTargetPosition.bind(this));
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                var PositionState = windowCoveringService
                    .getCharacteristic(Characteristic.PositionState)

                // Register a listener for event changes
<<<<<<< HEAD
                eventEmitter.on(this.config.type + ":" + this.id + ":eventCurrentPosition", function (value) {

                    TargetPosition.updateValue(value);
                    setTimeout(function () { CurrentPosition.updateValue(value); }, 2000);
=======
                eventEmitter.on(this.config.type + ":" + this.id + ":eventCurrentPosition", function(value) {

                    PositionState.updateValue(state_value);
                    TargetPosition.updateValue(value);

>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c


                }.bind(this));

<<<<<<< HEAD
                services.push(windowCoveringService);
=======
                services.push( windowCoveringService );
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c

                break;
            }

            case "Thermostat": {
                var ThermostatService = new Service.Thermostat();

                var CurrentHeatingCoolingState = ThermostatService
                    .getCharacteristic(Characteristic.CurrentHeatingCoolingState)
<<<<<<< HEAD
                //.on('get', this.getCurrentHeatingCoolingState.bind(this));
=======
                    //.on('get', this.getCurrentHeatingCoolingState.bind(this));
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                var TargetHeatingCoolingState = ThermostatService
                    .getCharacteristic(Characteristic.TargetHeatingCoolingState)
                    .on('get', this.getTargetHeatingCoolingState.bind(this))
                    .on('set', this.setTargetHeatingCoolingState.bind(this));
                var TargetTemperature = ThermostatService
                    .getCharacteristic(Characteristic.TargetTemperature)
                    .setProps({
                        minValue: 16,
                        maxValue: 32,
<<<<<<< HEAD
                        minStep: 1
                    })
=======
                        minStep:1
                      })
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                    .on('set', this.setTargetTemperature.bind(this))
                    .on('get', this.getTargetTemperature.bind(this));
                var CurrentTemperature = ThermostatService
                    .getCharacteristic(Characteristic.CurrentTemperature)
                    .setProps({
                        minValue: 16,
                        maxValue: 32
<<<<<<< HEAD
                    })
=======
                      })
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                    .on('get', this.getCurrentTemperature.bind(this));

                var TemperatureDisplayUnits = ThermostatService
                    .getCharacteristic(Characteristic.TemperatureDisplayUnits)

                TemperatureDisplayUnits.setValue(0);

                //State
<<<<<<< HEAD
                eventEmitter.on(this.config.type + ":" + this.id + ":eventTargetHeatingCoolingState", function (value) {
=======
                eventEmitter.on(this.config.type + ":" + this.id + ":eventTargetHeatingCoolingState", function(value) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c

                    CurrentHeatingCoolingState.updateValue(value);
                    TargetHeatingCoolingState.updateValue(value);
                }.bind(this));

                //TargetTemperature
<<<<<<< HEAD
                eventEmitter.on(this.config.type + ":" + this.id + ":eventTargetTemperature", function (value) {
=======
                eventEmitter.on(this.config.type + ":" + this.id + ":eventTargetTemperature", function(value) {

                    eventCheckData.push(this.config.type + ":" + this.id + ":eventTargetTemperature:" + value);
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c

                    TargetTemperature.updateValue(value);

                }.bind(this));

                //CurrentTemperature
<<<<<<< HEAD
                eventEmitter.on(this.config.type + ":" + this.id + ":eventCurrentTemperature", function (value) {
                    CurrentTemperature.updateValue(value);
                }.bind(this));

                services.push(ThermostatService);
=======
                eventEmitter.on(this.config.type + ":" + this.id + ":eventCurrentTemperature", function(value) {

                    CurrentTemperature.updateValue(value);

                }.bind(this));

                services.push( ThermostatService );
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c

                break;
            }

            case "HeaterCooler": {
                var HeaterCoolerService = new Service.HeaterCooler();

                var HeaterCoolerPower = HeaterCoolerService
                    .getCharacteristic(Characteristic.Active)
<<<<<<< HEAD
                    .on('get', this.getPowerState.bind(this))
                    .on('set', this.setPowerState.bind(this));
=======
                    .on('get', this.getHeaterCoolerPower.bind(this))
                    .on('set', this.setHeaterCoolerPower.bind(this));
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                var TargetHeaterCoolerState = HeaterCoolerService
                    .getCharacteristic(Characteristic.TargetHeaterCoolerState)
                    .on('get', this.getTargetHeaterCoolerState.bind(this))
                    .on('set', this.setTargetHeaterCoolerState.bind(this));
                var CurrentHeaterCoolerState = HeaterCoolerService
                    .getCharacteristic(Characteristic.CurrentHeaterCoolerState)
<<<<<<< HEAD
                //.on('get', this.getCurrentHeaterCoolerState.bind(this));
=======
                    //.on('get', this.getCurrentHeaterCoolerState.bind(this));
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                var CoolingThresholdTemperature = HeaterCoolerService
                    .getCharacteristic(Characteristic.CoolingThresholdTemperature)
                    .setProps({
                        minValue: 16,
                        maxValue: 32,
<<<<<<< HEAD
                        minStep: 1
                    })
=======
                        minStep:1
                      })
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                    .on('set', this.setTargetTemperature.bind(this))
                    .on('get', this.getTargetTemperature.bind(this));
                var HeatingThresholdTemperature = HeaterCoolerService
                    .getCharacteristic(Characteristic.HeatingThresholdTemperature)
                    .setProps({
                        minValue: 16,
                        maxValue: 32,
<<<<<<< HEAD
                        minStep: 1
                    })
=======
                        minStep:1
                      })
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                    .on('set', this.setTargetTemperature.bind(this))
                    .on('get', this.getTargetTemperature.bind(this));
                var CurrentTemperature = HeaterCoolerService
                    .getCharacteristic(Characteristic.CurrentTemperature)
<<<<<<< HEAD
=======
                    .setProps({
                        minValue: 16,
                        maxValue: 32
                      })
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                    .on('get', this.getCurrentTemperature.bind(this));
                var RotationSpeed = HeaterCoolerService
                    .getCharacteristic(Characteristic.RotationSpeed)
                    .on('set', this.setRotationSpeed.bind(this))
                    .on('get', this.getRotationSpeed.bind(this));

<<<<<<< HEAD
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
                    else if (value === 0) {
=======
                //PowerState
                eventEmitter.on(this.config.type + ":" + this.id + ":eventHeaterCoolerPower", function(value) {

                    HeaterCoolerPower.updateValue(value);

                }.bind(this));

                //TargetHeaterCoolerState and CurrentHeaterCoolerState
                eventEmitter.on(this.config.type + ":" + this.id + ":eventTargetHeaterCoolerState", function(value) {

                    eventCheckData.push(this.config.type + ":" + this.id + ":eventTargetHeaterCoolerState:" + value);
                    var currStateValue;
                    if( value == 1)
                    {
                        currStateValue = 2;

                    }
                    else if(value == 2)
                    {
                        currStateValue = 3;

                    }
                    else if(value == 0){
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                        currStateValue = 1;
                    }
                    TargetHeaterCoolerState.updateValue(value);
                    CurrentHeaterCoolerState.updateValue(currStateValue);

                }.bind(this));

                //CurrentTemperature
<<<<<<< HEAD
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

                var HeaterCoolerPower = HeaterService
                    .getCharacteristic(Characteristic.Active)
                    .on('get', this.getPowerState.bind(this))
                    .on('set', this.setPowerState.bind(this));
                var TargetHeaterCoolerState = HeaterService
                    .getCharacteristic(Characteristic.TargetHeaterCoolerState)
                    .setProps({
                        validValues: [1]
                    })
                var CurrentHeaterCoolerState = HeaterService
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
                        CurrentHeaterCoolerState.updateValue(2);
                        TargetHeaterCoolerState.updateValue(1);
                    }
                    else {
                        CurrentHeaterCoolerState.updateValue(0);
                    }

                    HeaterCoolerPower.updateValue(value);
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

            case "SpeedFan": {
=======
                eventEmitter.on(this.config.type + ":" + this.id + ":eventCurrentTemperature", function(value) {

                    CurrentTemperature.updateValue(value);

                }.bind(this));

                //TargetTemperature
                eventEmitter.on(this.config.type + ":" + this.id + ":eventTargetTemperature", function(value) {

                    HeatingThresholdTemperature.updateValue(value);
                    CoolingThresholdTemperature.updateValue(value);

                }.bind(this));

                eventEmitter.on(this.config.type + ":" + this.id + ":eventRotationSpeed", function(value) {

                    RotationSpeed.updateValue(value);

                }.bind(this));

                services.push( HeaterCoolerService );
                break;
            }

            case "ThermostatFan": {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                var fanService = new Service.Fan();

                var RotationState = fanService
                    .getCharacteristic(Characteristic.On)
                    .on('set', this.setRotationState.bind(this)); // requied for turning off when not using slider interface

                var RotationSpeed = fanService
                    .getCharacteristic(Characteristic.RotationSpeed)
                    .on("set", this.setRotationSpeed.bind(this))
                    .on("get", this.getRotationSpeed.bind(this));

<<<<<<< HEAD
                eventEmitter.on(this.config.type + ":" + this.id + ":eventRotationSpeed", function (value) {
=======
                eventEmitter.on(this.config.type + ":" + this.id + ":eventRotationSpeed", function(value) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c

                    var power_value;
                    if (value == 0) {
                        power_value = 0;
                    } else {
                        power_value = 1;
                    }

<<<<<<< HEAD
=======
                    //this.log("FAN DEBUG " + this.config.type + ":" + this.id + ":eventRotationSpeed " + value + " " + power_value);

>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                    RotationSpeed.updateValue(value);
                    RotationState.updateValue(power_value);

                }.bind(this));

<<<<<<< HEAD
                services.push(fanService);
=======
                services.push( fanService );
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                break;
            }

            case "AirPurifier": {
                var AirPurifierService = new Service.AirPurifier();
                var AirPurifierPowerState = AirPurifierService
                    .getCharacteristic(Characteristic.Active)
<<<<<<< HEAD
                    .on('set', this.setPowerState.bind(this))
                    .on('get', this.getPowerState.bind(this));
                var CurrentAirPurifierState = AirPurifierService
                    .getCharacteristic(Characteristic.CurrentAirPurifierState)
                //.on('get', this.getCurrentAirPurifierState.bind(this));
=======
                    .on('set', this.setAirPurifierPowerState.bind(this))
                    .on('get', this.getAirPurifierPowerState.bind(this));
                var CurrentAirPurifierState = AirPurifierService
                    .getCharacteristic(Characteristic.CurrentAirPurifierState)
                    //.on('get', this.getCurrentAirPurifierState.bind(this));
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
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

<<<<<<< HEAD
                eventEmitter.on(this.config.type + ":" + this.id + ":eventPowerState", function (value) {

                    if (value) {
                        CurrentAirPurifierState.updateValue(2);
                    } else {
                        CurrentAirPurifierState.updateValue(0);
=======
                // Register a listener
                eventEmitter.on(this.config.type + ":" + this.id + ":eventAirPurifierPowerState", function(value) {


                    if (value)
                    {
                        CurrentAirPurifierState.updateValue(2);
                    } else
                    {
                        CurrentAirPurifierState.updateValue(value);
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                    }

                    AirPurifierPowerState.updateValue(value);
                }.bind(this));

<<<<<<< HEAD
                eventEmitter.on(this.config.type + ":" + this.id + ":eventAirPurifierRotationSpeed", function (value) {
                    if (value > 0)
                    {
                        AirPurifierPowerState.updateValue(1);
                    }
                    else
                    {
                        AirPurifierPowerState.updateValue(0);
                    }
=======
                eventEmitter.on(this.config.type + ":" + this.id + ":eventAirPurifierRotationSpeed", function(value) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c

                    AirPurifierRotationSpeed.updateValue(value);
                }.bind(this));

<<<<<<< HEAD
                eventEmitter.on(this.config.type + ":" + this.id + ":eventTargetAirPurifierState", function (value) {
=======
                eventEmitter.on(this.config.type + ":" + this.id + ":eventTargetAirPurifierState", function(value) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c

                    TargetAirPurifierState.updateValue(value);
                }.bind(this));

<<<<<<< HEAD
                eventEmitter.on(this.config.type + ":" + this.id + ":eventFilterLifeLevel", function (value) {

                    let changeFilter;
                    if (value > 5) {
                        changeFilter = 0;
                    } else {
=======
                eventEmitter.on(this.config.type + ":" + this.id + ":eventFilterLifeLevel", function(value) {

                    var changeFilter;
                    if(value>5)
                    {
                        changeFilter = 0;
                    } else
                    {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                        changeFilter = 1;
                    }
                    FilterLifeLevel.updateValue(value);
                    FilterChangeIndication.updateValue(changeFilter);
                }.bind(this));

<<<<<<< HEAD
                services.push(AirPurifierService);
=======
                services.push( AirPurifierService );
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                break;
            }

            case "AirQualitySensor": {
                var AirQualitySensorService = new Service.AirQualitySensor();
                var AirQuality = AirQualitySensorService
                    .getCharacteristic(Characteristic.AirQuality)
<<<<<<< HEAD
                //.on('get', this.getAirQuality.bind(this));
=======
                    //.on('get', this.getAirQuality.bind(this));
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                var PM2_5Value = AirQualitySensorService
                    .getCharacteristic(Characteristic.PM2_5Density)
                    .on('get', this.getPM2_5Value.bind(this));
                var VOC_Value = AirQualitySensorService
                    .getCharacteristic(Characteristic.VOCDensity)
                    .on('get', this.getVOC_Value.bind(this));
                var CarbonDioxideLevel = AirQualitySensorService
                    .getCharacteristic(Characteristic.CarbonDioxideLevel)
                    .on('get', this.getCarbonDioxideLevel.bind(this));

<<<<<<< HEAD
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
=======
                eventEmitter.on(this.config.type + ":" + this.id + ":eventPM2_5Value", function(value) {
                    eventCheckData.push(this.config.type + ":" + this.id + ":eventPM2_5Value:" + value);
                    var AIQ_value;
                    if (value < 35 && value > 0)
                    {
                        AIQ_value = 1;
                    } else if (value < 75 && value >=35)
                    {
                        AIQ_value = 2;
                    }
                    else if (value < 115 && value >=75)
                    {
                        AIQ_value = 3;
                    }
                    else if (value < 150 && value >=115)
                    {
                        AIQ_value = 4;
                    }
                    else if (value >=150)
                    {
                        AIQ_value = 5;
                    } else
                    {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                        AIQ_value = 0;
                    }
                    AirQuality.updateValue(AIQ_value);
                    PM2_5Value.updateValue(value);
                }.bind(this));

<<<<<<< HEAD
                eventEmitter.on(this.config.type + ":" + this.id + ":eventVOC_Value", function (value) {
=======
                eventEmitter.on(this.config.type + ":" + this.id + ":eventVOC_Value", function(value) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c

                    VOC_Value.updateValue(value);
                }.bind(this));

<<<<<<< HEAD
                eventEmitter.on(this.config.type + ":" + this.id + ":eventCarbonDioxideLevel", function (value) {
=======
                eventEmitter.on(this.config.type + ":" + this.id + ":eventCarbonDioxideLevel", function(value) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c

                    CarbonDioxideLevel.updateValue(value);
                }.bind(this));

<<<<<<< HEAD
                services.push(AirQualitySensorService);
=======
                services.push( AirQualitySensorService );
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                break;
            }

            case "HumiditySensor": {
                var HumiditySensorService = new Service.HumiditySensor();
                var CurrentRelativeHumidity = HumiditySensorService
                    .getCharacteristic(Characteristic.CurrentRelativeHumidity)
                    .on('get', this.getCurrentRelativeHumidity.bind(this));

<<<<<<< HEAD
                eventEmitter.on(this.config.type + ":" + this.id + ":eventCurrentRelativeHumidity", function (value) {
                    CurrentRelativeHumidity.updateValue(value);
                }.bind(this));

                services.push(HumiditySensorService);
=======
                // Register a listener
                eventEmitter.on(this.config.type + ":" + this.id + ":eventCurrentRelativeHumidity", function(value) {

                    CurrentRelativeHumidity.updateValue(value);
                }.bind(this));


                services.push( HumiditySensorService );
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                break;
            }

            case "TemperatureSensor": {
                var TemperatureSensorService = new Service.TemperatureSensor();
                var TempSensorCurrentTemperature = TemperatureSensorService
                    .getCharacteristic(Characteristic.CurrentTemperature)
<<<<<<< HEAD
                    .on('get', this.getCurrentTemperature.bind(this));

                eventEmitter.on(this.config.type + ":" + this.id + ":eventCurrentTemperature", function (value) {
                    TempSensorCurrentTemperature.updateValue(value);
                }.bind(this));

                services.push(TemperatureSensorService);
=======
                    .on('get', this.getTempSensorCurrentTemperature.bind(this));

                // Register a listener
                eventEmitter.on(this.config.type + ":" + this.id + ":eventTempSensorCurrentTemperature", function(value) {

                    TempSensorCurrentTemperature.updateValue(value);
                }.bind(this));

                services.push( TemperatureSensorService );
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                break;
            }

            case "ContactSensor": {
                var contactSensorService = new Service.ContactSensor();
<<<<<<< HEAD
                var ContactSensorState = contactSensorService
                    .getCharacteristic(Characteristic.ContactSensorState)
                    .on('get', this.getSensorState.bind(this));

                eventEmitter.on(this.config.type + ":" + this.id + ":eventSensorState", function (value) {
                    ContactSensorState.updateValue(value);
                }.bind(this));

                services.push(contactSensorService);
=======
                var BinarySensorState = contactSensorService
                    .getCharacteristic(Characteristic.ContactSensorState)
                    .on('get', this.getBinarySensorState.bind(this));

                // Register a listener for event changes
                eventEmitter.on(this.config.type + ":" + this.id + ":eventBinarySensorState", function(value) {

                    BinarySensorState.updateValue(value);
                }.bind(this));

                services.push( contactSensorService );
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                break;
            }

            case "CarbonDioxideSensor": {
                var CarbonDioxideSensorService = new Service.CarbonDioxideSensor();
                var CarbonDioxideLevel = CarbonDioxideSensorService
                    .getCharacteristic(Characteristic.CarbonDioxideLevel)
                    .on('get', this.getCarbonDioxideLevel.bind(this));
                var CarbonDioxideDetected = CarbonDioxideSensorService
                    .getCharacteristic(Characteristic.CarbonDioxideDetected)
<<<<<<< HEAD
                //.on('get', this.getCarbonDioxideDetected.bind(this));

                eventEmitter.on(this.config.type + ":" + this.id + ":eventCarbonDioxideLevel", function (value) {

                    var Co2_value;
                    if (value > 800) {
                        Co2_value = 1;
                    }
                    else {
=======
                    //.on('get', this.getCarbonDioxideDetected.bind(this));

                // Register a listener
                eventEmitter.on(this.config.type + ":" + this.id + ":eventCarbonDioxideLevel", function(value) {

                    var Co2_value;
                    if (value >800)
                    {
                        Co2_value = 1;
                    }
                    else
                    {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                        Co2_value = 0;
                    }
                    CarbonDioxideLevel.updateValue(value);
                    CarbonDioxideDetected.updateValue(Co2_value);
                }.bind(this));

<<<<<<< HEAD
                services.push(CarbonDioxideSensorService);
=======
                services.push( CarbonDioxideSensorService );
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                break;
            }

            case "SmokeSensor": {
                var SmokeSensorService = new Service.SmokeSensor();
                var SmokeDetected = SmokeSensorService
                    .getCharacteristic(Characteristic.SmokeDetected)
<<<<<<< HEAD
                    .on('get', this.getSensorState.bind(this));

                eventEmitter.on(this.config.type + ":" + this.id + ":eventSensorState", function (value) {
=======
                    .on('get', this.getSmokeDetected.bind(this));

                // Register a listener
                eventEmitter.on(this.config.type + ":" + this.id + ":eventSmokeDetected", function(value) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c

                    SmokeDetected.updateValue(value);
                }.bind(this));

<<<<<<< HEAD
                services.push(SmokeSensorService);
=======
                services.push( SmokeSensorService );
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                break;
            }

            case "OccupancySensor": {
                var OccupancySensorService = new Service.OccupancySensor();
                var OccupancyDetected = OccupancySensorService
                    .getCharacteristic(Characteristic.OccupancyDetected)
<<<<<<< HEAD
                    .on('get', this.getSensorState.bind(this));

                eventEmitter.on(this.config.type + ":" + this.id + ":eventSensorState", function (value) {
=======
                    .on('get', this.getOccupancyDetected.bind(this));

                // Register a listener
                eventEmitter.on(this.config.type + ":" + this.id + ":eventOccupancyDetected", function(value) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c

                    OccupancyDetected.updateValue(value);
                }.bind(this));

<<<<<<< HEAD
                services.push(OccupancySensorService);
=======
                services.push( OccupancySensorService );
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                break;
            }

            case "MotionSensor": {
                var MotionSensorService = new Service.MotionSensor();
                var MotionDetected = MotionSensorService
                    .getCharacteristic(Characteristic.MotionDetected)
<<<<<<< HEAD
                    .on('get', this.getSensorState.bind(this));

                eventEmitter.on(this.config.type + ":" + this.id + ":eventSensorState", function (value) {
=======
                    .on('get', this.getMotionDetected.bind(this));

                // Register a listener
                eventEmitter.on(this.config.type + ":" + this.id + ":eventMotionDetected", function(value) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c

                    MotionDetected.updateValue(value);
                }.bind(this));

<<<<<<< HEAD
                services.push(MotionSensorService);
=======
                services.push( MotionSensorService );
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                break;
            }

            case "LightSensor": {
                var LightSensorService = new Service.LightSensor();
                var CurrentAmbientLightLevel = LightSensorService
                    .getCharacteristic(Characteristic.CurrentAmbientLightLevel)
                    .on('get', this.getCurrentAmbientLightLevel.bind(this));

<<<<<<< HEAD
                eventEmitter.on(this.config.type + ":" + this.id + ":eventCurrentAmbientLightLevel", function (value) {
=======
                // Register a listener
                eventEmitter.on(this.config.type + ":" + this.id + ":eventCurrentAmbientLightLevel", function(value) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c

                    CurrentAmbientLightLevel.updateValue(value);
                }.bind(this));

<<<<<<< HEAD
                services.push(LightSensorService);
=======
                services.push( LightSensorService );
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                break;
            }

            case "LeakSensor": {
                var LeakSensorService = new Service.LeakSensor();
                var LeakDetected = LeakSensorService
                    .getCharacteristic(Characteristic.LeakDetected)
<<<<<<< HEAD
                    .on('get', this.getSensorState.bind(this));

                eventEmitter.on(this.config.type + ":" + this.id + ":eventSensorState", function (value) {
=======
                    .on('get', this.getLeakDetected.bind(this));

                // Register a listener
                eventEmitter.on(this.config.type + ":" + this.id + ":eventLeakDetected", function(value) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c

                    LeakDetected.setValue(value);
                }.bind(this));

<<<<<<< HEAD
                services.push(LeakSensorService);
=======
                services.push( LeakSensorService );
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                break;
            }

            case "Faucet": {
                var FaucetService = new Service.Faucet();
                var FaucetActive = FaucetService
                    .getCharacteristic(Characteristic.Active)
                    .on('get', this.getFaucetActive.bind(this))
                    .on('set', this.setFaucetActive.bind(this));

<<<<<<< HEAD
                eventEmitter.on(this.config.type + ":" + this.id + ":eventFaucetActive", function (value) {
=======
                // Register a listener
                eventEmitter.on(this.config.type + ":" + this.id + ":eventFaucetActive", function(value) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c

                    FaucetActive.updateValue(value);
                }.bind(this));

<<<<<<< HEAD
                services.push(FaucetService);
=======
                services.push( FaucetService );
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
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

<<<<<<< HEAD
                eventEmitter.on(this.config.type + ":" + this.id + ":eventOutletPower", function (value) {
=======
                // Register a listener
                eventEmitter.on(this.config.type + ":" + this.id + ":eventOutletPower", function(value) {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c

                    OutletInUse.updateValue(value);
                    OutletPower.updateValue(value);
                }.bind(this));

<<<<<<< HEAD
                services.push(OutletService);
=======
                services.push( OutletService );
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
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

<<<<<<< HEAD
                ValveValveType.setValue(3);

                eventEmitter.on(this.config.type + ":" + this.id + ":eventValveActive", function (value) {

                    ValveInUse.updateValue(value);
                    ValveActive.updateValue(value);
                }.bind(this));

                services.push(ValveService);
=======
                    ValveValveType.setValue(3);
                // Register a listener
                eventEmitter.on(this.config.type + ":" + this.id + ":eventValveActive", function(value) {

                   ValveInUse.updateValue(value);
                   ValveActive.updateValue(value);
                }.bind(this));

                services.push( ValveService );
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
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
<<<<<<< HEAD
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
=======
                    //.on('get', this.getPositionState.bind(this));

                // Register a listener
                eventEmitter.on(this.config.type + ":" + this.id + ":eventCurrentPosition", function(value) {

                    CurrentPosition.updateValue(value);
                    //TargetPosition.updateValue(value);
                }.bind(this));


                services.push( DoorService );
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                break;
            }

            case "FilterMaintenance": {
                var FilterMaintenanceService = new Service.FilterMaintenance();
                var FilterChangeIndication = FilterMaintenanceService
                    .getCharacteristic(Characteristic.FilterChangeIndication)
                var FilterLifeLevel = FilterMaintenanceService
                    .getCharacteristic(Characteristic.FilterLifeLevel)
                    .on('get', this.getFilterLifeLevel.bind(this));

<<<<<<< HEAD
                eventEmitter.on(this.config.type + ":" + this.id + ":eventFilterLifeLevel", function (value) {
                    let changeFilter;
                    if (value > 5) {
                        changeFilter = 0;
                    } else {
=======
                // Register a listener
                eventEmitter.on(this.config.type + ":" + this.id + ":eventFilterLifeLevel", function(value) {

                    var changeFilter;
                    if(value>5)
                    {
                        changeFilter = 0;
                    } else
                    {
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                        changeFilter = 1;
                    }
                    FilterLifeLevel.updateValue(value);
                    FilterChangeIndication.updateValue(changeFilter);
                }.bind(this));

<<<<<<< HEAD
                services.push(FilterMaintenanceService);
=======
                services.push( FilterMaintenanceService );
>>>>>>> 6e53c86f064905ecbd09d739b89f9d8d3c8d378c
                break;
            }

        }
        return services;
    }
}
