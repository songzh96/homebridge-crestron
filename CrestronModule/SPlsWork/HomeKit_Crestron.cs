using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;

namespace UserModule_HOMEKIT_CRESTRON
{
    public class UserModuleClass_HOMEKIT_CRESTRON : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        StringParameter IPADDR__DOLLAR__;
        UShortParameter PORT;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> TV_POWER_STATUS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> LIGHTS_STATUS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SWITCH_STATUS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> HEATERCOOLER_ONSTATUS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> HEATERCOOLER_OFFSTATUS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> HEATERCOOLERFANSPEED_LOWSTATUS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> HEATERCOOLERFANSPEED_MIDSTATUS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> HEATERCOOLERFANSPEED_HIGHSTATUS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> HEATERCOOLER_HEATSTATUS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> HEATERCOOLER_COOLSTATUS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> HEATER_ONSTATUS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> HEATER_OFFSTATUS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> COOLER_ONSTATUS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> COOLER_OFFSTATUS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> AIRPURIFIER_ONSTATUS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> AIRPURIFIER_OFFSTATUS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> AIRPURIFIER_AUTOSTATUS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> AIRPURIFIER_MANUALSTATUS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> AIRPURIFIERFANSPEED_LOWSTATUS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> AIRPURIFIERFANSPEED_MIDSTATUS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> AIRPURIFIERFANSPEED_HIGHSTATUS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> CONTACTSENSOR_STATUS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SMOKESENSOR_STATUS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> OCCUPANCYSENSOR_STATUS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> MOTIONSENSOR_STATUS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> LEAKSENSOR_STATUS;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> DIMLIGHT_BRIGHTNESS;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> SHADES_POSITION;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> HEATERCOOLER_GETTARGETTEMPERATURE;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> HEATERCOOLER_GETCURRENTTEMPERATURE;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> HEATER_GETTARGETTEMPERATURE;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> HEATER_GETCURRENTTEMPERATURE;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> COOLER_GETTARGETTEMPERATURE;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> COOLER_GETCURRENTTEMPERATURE;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> AIRPURIFIER_FILTERMAINTENANCE_STATUS;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> LIGHTSENSOR_STATUS;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> GET_PM2_5VALUE;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> GET_VOC_VALUE;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> GET_CO2;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> GET_HUMIDITY;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> GET_TEMPERATURE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> TV_ON;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> TV_OFF;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> LIGHTS_ON;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> LIGHTS_OFF;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> SWITCH_ON;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> SWITCH_OFF;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> HEATERCOOLER_ON;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> HEATERCOOLER_OFF;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> HEATERCOOLERFANSPEED_LOW;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> HEATERCOOLERFANSPEED_MID;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> HEATERCOOLERFANSPEED_HIGH;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> HEATERCOOLER_HEAT;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> HEATERCOOLER_COOL;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> HEATER_ON;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> HEATER_OFF;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> COOLER_ON;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> COOLER_OFF;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> AIRPURIFIER_ON;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> AIRPURIFIER_OFF;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> AIRPURIFIER_AUTO;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> AIRPURIFIER_MANUAL;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> AIRPURIFIERFANSPEED_LOW;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> AIRPURIFIERFANSPEED_MID;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> AIRPURIFIERFANSPEED_HIGH;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> DIMLIGHT_SET;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> SHADES_SET;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> HEATERCOOLER_SETTEMPERATURE;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> HEATER_SETTEMPERATURE;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> COOLER_SETTEMPERATURE;
        short DOSERVERCONNECTED = 0;
        CrestronString INTERNALRXBUFFER;
        SplusTcpServer MYSERVER;
        private void STARTSERVER (  SplusExecutionContext __context__ ) 
            { 
            short STATUS = 0;
            
            
            __context__.SourceCodeLine = 110;
            STATUS = (short) ( Functions.SocketServerStartListen( MYSERVER , IPADDR__DOLLAR__  , (ushort)( PORT  .Value ) ) ) ; 
            __context__.SourceCodeLine = 111;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( STATUS < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 112;
                Print( "Error listening to {0} on port {1:d} (status: {2:d})", IPADDR__DOLLAR__ , (ushort)PORT  .Value, (short)STATUS) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 114;
                Print( "Server started to {0} on port {1:d} (status: {2:d})", IPADDR__DOLLAR__ , (ushort)PORT  .Value, (short)STATUS) ; 
                } 
            
            
            }
            
        private void SOCKETTX (  SplusExecutionContext __context__, CrestronString SERVERTX ) 
            { 
            short ISTATUS = 0;
            
            
            __context__.SourceCodeLine = 121;
            ISTATUS = (short) ( Functions.SocketSend( MYSERVER , SERVERTX ) ) ; 
            __context__.SourceCodeLine = 123;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ISTATUS < 0 ))  ) ) 
                { 
                } 
            
            else 
                { 
                } 
            
            
            }
            
        private void CMDBUILDER (  SplusExecutionContext __context__, CrestronString SERVICE , CrestronString ID , CrestronString CMD , CrestronString VALUE ) 
            { 
            CrestronString CMDBUILDER__DOLLAR__;
            CMDBUILDER__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            
            
            __context__.SourceCodeLine = 132;
            CMDBUILDER__DOLLAR__  .UpdateValue ( SERVICE + ":" + ID + ":" + CMD + ":" + VALUE + "*"  ) ; 
            __context__.SourceCodeLine = 133;
            SOCKETTX (  __context__ , CMDBUILDER__DOLLAR__) ; 
            
            }
            
        private void CMDPARSER (  SplusExecutionContext __context__, CrestronString SERVERRX ) 
            { 
            CrestronString SERVICE;
            SERVICE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            
            CrestronString ID;
            ID  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            
            CrestronString CMD;
            CMD  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            
            CrestronString VALUE;
            VALUE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            
            ushort IDINT = 0;
            ushort VALUEINT = 0;
            
            ushort PULSETIME = 0;
            
            CrestronString RETURNVALUE__DOLLAR__;
            RETURNVALUE__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            
            ushort RETURNVALUE = 0;
            
            ushort TEMP = 0;
            
            
            __context__.SourceCodeLine = 147;
            SERVICE  .UpdateValue ( Functions.Remove ( ":" , SERVERRX )  ) ; 
            __context__.SourceCodeLine = 148;
            SERVICE  .UpdateValue ( Functions.Left ( SERVICE ,  (int) ( (Functions.Length( SERVICE ) - 1) ) )  ) ; 
            __context__.SourceCodeLine = 150;
            ID  .UpdateValue ( Functions.Remove ( ":" , SERVERRX )  ) ; 
            __context__.SourceCodeLine = 151;
            ID  .UpdateValue ( Functions.Left ( ID ,  (int) ( (Functions.Length( ID ) - 1) ) )  ) ; 
            __context__.SourceCodeLine = 152;
            IDINT = (ushort) ( Functions.Atoi( ID ) ) ; 
            __context__.SourceCodeLine = 154;
            CMD  .UpdateValue ( Functions.Remove ( ":" , SERVERRX )  ) ; 
            __context__.SourceCodeLine = 155;
            CMD  .UpdateValue ( Functions.Left ( CMD ,  (int) ( (Functions.Length( CMD ) - 1) ) )  ) ; 
            __context__.SourceCodeLine = 157;
            VALUE  .UpdateValue ( SERVERRX  ) ; 
            __context__.SourceCodeLine = 158;
            VALUEINT = (ushort) ( Functions.Atoi( VALUE ) ) ; 
            __context__.SourceCodeLine = 166;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "Lightbulb") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "setPowerState") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 168;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (VALUEINT == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 169;
                    Functions.Pulse ( 10, LIGHTS_ON [ IDINT] ) ; 
                    } 
                
                __context__.SourceCodeLine = 173;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (VALUEINT == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 174;
                    Functions.Pulse ( 10, LIGHTS_OFF [ IDINT] ) ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 179;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "DimLightbulb") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "setLightBrightness") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 181;
                RETURNVALUE = (ushort) ( VALUEINT ) ; 
                __context__.SourceCodeLine = 182;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( RETURNVALUE >= 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 183;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (RETURNVALUE == 999))  ) ) 
                        { 
                        __context__.SourceCodeLine = 185;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DIMLIGHT_BRIGHTNESS[ IDINT ] .UshortValue == 0))  ) ) 
                            { 
                            __context__.SourceCodeLine = 187;
                            DIMLIGHT_SET [ IDINT]  .Value = (ushort) ( 65535 ) ; 
                            } 
                        
                        else 
                            { 
                            } 
                        
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 197;
                        DIMLIGHT_SET [ IDINT]  .Value = (ushort) ( ((RETURNVALUE * 65535) / 100) ) ; 
                        } 
                    
                    } 
                
                } 
            
            __context__.SourceCodeLine = 204;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "Switch") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "setPowerState") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 206;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (VALUEINT == 1) ) && Functions.TestForTrue ( Functions.BoolToInt (SWITCH_STATUS[ IDINT ] .Value == 0) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 207;
                    Functions.Pulse ( 10, SWITCH_ON [ IDINT] ) ; 
                    } 
                
                __context__.SourceCodeLine = 210;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (VALUEINT == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (SWITCH_STATUS[ IDINT ] .Value == 1) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 211;
                    Functions.Pulse ( 10, SWITCH_OFF [ IDINT] ) ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 215;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "TV") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "setPowerState") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 217;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (VALUEINT == 1) ) && Functions.TestForTrue ( Functions.BoolToInt (TV_POWER_STATUS[ IDINT ] .Value == 0) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 218;
                    Functions.Pulse ( 10, TV_ON [ IDINT] ) ; 
                    } 
                
                __context__.SourceCodeLine = 221;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (VALUEINT == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (TV_POWER_STATUS[ IDINT ] .Value == 1) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 222;
                    Functions.Pulse ( 10, TV_OFF [ IDINT] ) ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 226;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "AirPurifier") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "setPowerState") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 229;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (VALUEINT == 1) ) && Functions.TestForTrue ( Functions.BoolToInt (AIRPURIFIER_ONSTATUS[ IDINT ] .Value == 0) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 230;
                    Functions.Pulse ( 10, AIRPURIFIER_ON [ IDINT] ) ; 
                    } 
                
                __context__.SourceCodeLine = 233;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (VALUEINT == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (AIRPURIFIER_ONSTATUS[ IDINT ] .Value == 1) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 234;
                    Functions.Pulse ( 10, AIRPURIFIER_OFF [ IDINT] ) ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 237;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "AirPurifier") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "setTargetAirPurifierState") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 240;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (VALUEINT == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 242;
                    Functions.Delay (  (int) ( 20 ) ) ; 
                    __context__.SourceCodeLine = 243;
                    Functions.Pulse ( 10, AIRPURIFIER_AUTO [ IDINT] ) ; 
                    } 
                
                __context__.SourceCodeLine = 246;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (VALUEINT == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 247;
                    Functions.Delay (  (int) ( 20 ) ) ; 
                    __context__.SourceCodeLine = 248;
                    Functions.Pulse ( 10, AIRPURIFIER_MANUAL [ IDINT] ) ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 251;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "AirPurifier") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "setAirPurifierRotationSpeed") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 253;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( VALUEINT <= 33 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( VALUEINT > 0 ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 255;
                    Functions.Pulse ( 10, AIRPURIFIERFANSPEED_LOW [ IDINT] ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 257;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( VALUEINT <= 66 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( VALUEINT > 33 ) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 259;
                        Functions.Pulse ( 10, AIRPURIFIERFANSPEED_MID [ IDINT] ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 261;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( VALUEINT <= 100 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( VALUEINT > 66 ) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 263;
                            Functions.Pulse ( 10, AIRPURIFIERFANSPEED_HIGH [ IDINT] ) ; 
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 266;
                            Functions.Pulse ( 10, AIRPURIFIER_OFF [ IDINT] ) ; 
                            } 
                        
                        }
                    
                    }
                
                } 
            
            __context__.SourceCodeLine = 270;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "WindowCovering") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "setTargetPosition") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 273;
                RETURNVALUE = (ushort) ( VALUEINT ) ; 
                __context__.SourceCodeLine = 275;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( RETURNVALUE >= 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 276;
                    SHADES_SET [ IDINT]  .Value = (ushort) ( (100 - RETURNVALUE) ) ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 281;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "Heater") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "setPowerState") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 283;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (VALUEINT == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 285;
                    Functions.Pulse ( 10, HEATER_ON [ IDINT] ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 289;
                    Functions.Pulse ( 10, HEATER_OFF [ IDINT] ) ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 293;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "HeaterCooler") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "setPowerState") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 295;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (VALUEINT == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 297;
                    Functions.Pulse ( 10, HEATERCOOLER_ON [ IDINT] ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 301;
                    Functions.Pulse ( 10, HEATERCOOLER_OFF [ IDINT] ) ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 306;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "HeaterCooler") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "setTargetHeaterCoolerState") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 308;
                
                    {
                    int __SPLS_TMPVAR__SWTCH_1__ = ((int)VALUEINT);
                    
                        { 
                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 313;
                            Functions.Delay (  (int) ( 20 ) ) ; 
                            __context__.SourceCodeLine = 314;
                            Functions.Pulse ( 10, HEATERCOOLER_HEAT [ IDINT] ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 319;
                            Functions.Delay (  (int) ( 20 ) ) ; 
                            __context__.SourceCodeLine = 320;
                            Functions.Pulse ( 10, HEATERCOOLER_COOL [ IDINT] ) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 325;
                            Print( "Unknown command {0:d}!\r\n", (short)VALUEINT) ; 
                            }
                        
                        } 
                        
                    }
                    
                
                } 
            
            __context__.SourceCodeLine = 332;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "HeaterCooler") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "setTargetTemperature") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 335;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( RETURNVALUE >= 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 336;
                    HEATERCOOLER_SETTEMPERATURE [ IDINT]  .Value = (ushort) ( VALUEINT ) ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 340;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "Heater") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "setTargetTemperature") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 343;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( RETURNVALUE >= 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 344;
                    HEATER_SETTEMPERATURE [ IDINT]  .Value = (ushort) ( VALUEINT ) ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 349;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "Cooler") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "setPowerState") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 351;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (VALUEINT == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 353;
                    Functions.Pulse ( 10, COOLER_ON [ IDINT] ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 357;
                    Functions.Pulse ( 10, COOLER_OFF [ IDINT] ) ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 360;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "Cooler") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "setTargetTemperature") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 363;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( RETURNVALUE >= 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 364;
                    COOLER_SETTEMPERATURE [ IDINT]  .Value = (ushort) ( VALUEINT ) ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 369;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "HeaterCooler") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "setRotationSpeed") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 371;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (HEATERCOOLER_ONSTATUS[ IDINT ] .Value == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 373;
                    CMDBUILDER (  __context__ , "HeaterCooler", Functions.LtoA( (int)( IDINT ) ), "eventRotationSpeed", "0") ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 377;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( VALUEINT <= 33 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 378;
                        Functions.Pulse ( 10, HEATERCOOLERFANSPEED_LOW [ IDINT] ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 380;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( VALUEINT <= 66 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( VALUEINT > 33 ) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 381;
                            Functions.Pulse ( 10, HEATERCOOLERFANSPEED_MID [ IDINT] ) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 383;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( VALUEINT <= 100 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( VALUEINT > 66 ) )) ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 384;
                                Functions.Pulse ( 10, HEATERCOOLERFANSPEED_HIGH [ IDINT] ) ; 
                                } 
                            
                            }
                        
                        }
                    
                    } 
                
                } 
            
            __context__.SourceCodeLine = 393;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "Lightbulb") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "getPowerState") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 394;
                CMDBUILDER (  __context__ , "Lightbulb", ID, "getPowerState", Functions.LtoA( (int)( LIGHTS_STATUS[ IDINT ] .Value ) )) ; 
                } 
            
            __context__.SourceCodeLine = 396;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "DimLightbulb") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "getLightBrightness") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 397;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DIMLIGHT_BRIGHTNESS[ IDINT ] .UshortValue == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 398;
                    RETURNVALUE__DOLLAR__  .UpdateValue ( "0"  ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 400;
                    RETURNVALUE__DOLLAR__  .UpdateValue ( Functions.LtoA (  (int) ( ((DIMLIGHT_BRIGHTNESS[ IDINT ] .UshortValue * 100) / 65535) ) )  ) ; 
                    } 
                
                __context__.SourceCodeLine = 402;
                CMDBUILDER (  __context__ , "DimLightbulb", ID, "getLightBrightness", RETURNVALUE__DOLLAR__) ; 
                } 
            
            __context__.SourceCodeLine = 405;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "Switch") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "getPowerState") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 406;
                CMDBUILDER (  __context__ , "Switch", ID, "getPowerState", Functions.LtoA( (int)( SWITCH_STATUS[ IDINT ] .Value ) )) ; 
                } 
            
            __context__.SourceCodeLine = 408;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "ContactSensor") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "getSensorState") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 409;
                CMDBUILDER (  __context__ , "ContactSensor", ID, "getSensorState", Functions.LtoA( (int)( CONTACTSENSOR_STATUS[ IDINT ] .Value ) )) ; 
                } 
            
            __context__.SourceCodeLine = 411;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "SmokeSensor") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "getSensorState") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 412;
                CMDBUILDER (  __context__ , "SmokeSensor", ID, "getSensorState", Functions.LtoA( (int)( SMOKESENSOR_STATUS[ IDINT ] .Value ) )) ; 
                } 
            
            __context__.SourceCodeLine = 414;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "OccupancySensor") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "getSensorState") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 415;
                CMDBUILDER (  __context__ , "OccupancySensor", ID, "getSensorState", Functions.LtoA( (int)( OCCUPANCYSENSOR_STATUS[ IDINT ] .Value ) )) ; 
                } 
            
            __context__.SourceCodeLine = 417;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "MotionSensor") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "getSensorState") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 418;
                CMDBUILDER (  __context__ , "MotionSensor", ID, "getSensorState", Functions.LtoA( (int)( MOTIONSENSOR_STATUS[ IDINT ] .Value ) )) ; 
                } 
            
            __context__.SourceCodeLine = 420;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "LeakSensor") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "getSensorState") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 421;
                CMDBUILDER (  __context__ , "LeakSensor", ID, "getSensorState", Functions.LtoA( (int)( LEAKSENSOR_STATUS[ IDINT ] .Value ) )) ; 
                } 
            
            __context__.SourceCodeLine = 423;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "LightSensor") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "getCurrentAmbientLightLevel") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 424;
                CMDBUILDER (  __context__ , "LightSensor", ID, "getCurrentAmbientLightLevel", Functions.LtoA( (int)( LIGHTSENSOR_STATUS[ IDINT ] .UshortValue ) )) ; 
                } 
            
            __context__.SourceCodeLine = 427;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "WindowCovering") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "getCurrentPosition") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 428;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SHADES_POSITION[ IDINT ] .UshortValue <= 100 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 429;
                    RETURNVALUE__DOLLAR__  .UpdateValue ( Functions.LtoA (  (int) ( (100 - SHADES_POSITION[ IDINT ] .UshortValue) ) )  ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 431;
                    RETURNVALUE__DOLLAR__  .UpdateValue ( Functions.LtoA (  (int) ( (((100 - SHADES_POSITION[ IDINT ] .UshortValue) * 100) / 65535) ) )  ) ; 
                    } 
                
                __context__.SourceCodeLine = 434;
                CMDBUILDER (  __context__ , "WindowCovering", ID, "getCurrentPosition", RETURNVALUE__DOLLAR__) ; 
                } 
            
            __context__.SourceCodeLine = 437;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "AirPurifier") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "getFilterLifeLevel") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 438;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( AIRPURIFIER_FILTERMAINTENANCE_STATUS[ IDINT ] .UshortValue <= 100 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 439;
                    RETURNVALUE__DOLLAR__  .UpdateValue ( Functions.LtoA (  (int) ( AIRPURIFIER_FILTERMAINTENANCE_STATUS[ IDINT ] .UshortValue ) )  ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 441;
                    RETURNVALUE__DOLLAR__  .UpdateValue ( Functions.LtoA (  (int) ( ((AIRPURIFIER_FILTERMAINTENANCE_STATUS[ IDINT ] .UshortValue * 100) / 65535) ) )  ) ; 
                    } 
                
                __context__.SourceCodeLine = 444;
                CMDBUILDER (  __context__ , "AirPurifier", ID, "getFilterLifeLevel", RETURNVALUE__DOLLAR__) ; 
                } 
            
            __context__.SourceCodeLine = 447;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "AirPurifier") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "getPowerState") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 448;
                CMDBUILDER (  __context__ , "AirPurifier", ID, "getPowerState", Functions.LtoA( (int)( AIRPURIFIER_ONSTATUS[ IDINT ] .Value ) )) ; 
                } 
            
            __context__.SourceCodeLine = 450;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "AirPurifier") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "getTargetAirPurifierState") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 451;
                CMDBUILDER (  __context__ , "AirPurifier", ID, "getTargetAirPurifierState", Functions.LtoA( (int)( AIRPURIFIER_AUTOSTATUS[ IDINT ] .Value ) )) ; 
                } 
            
            __context__.SourceCodeLine = 453;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "AirPurifier") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "getAirPurifierRotationSpeed") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 454;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (AIRPURIFIER_ONSTATUS[ IDINT ] .Value == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 455;
                    RETURNVALUE__DOLLAR__  .UpdateValue ( "0"  ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 458;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (AIRPURIFIERFANSPEED_LOWSTATUS[ IDINT ] .Value == 1))  ) ) 
                        { 
                        __context__.SourceCodeLine = 459;
                        RETURNVALUE__DOLLAR__  .UpdateValue ( "33"  ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 460;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (AIRPURIFIERFANSPEED_MIDSTATUS[ IDINT ] .Value == 1))  ) ) 
                            { 
                            __context__.SourceCodeLine = 461;
                            RETURNVALUE__DOLLAR__  .UpdateValue ( "66"  ) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 462;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (AIRPURIFIERFANSPEED_HIGHSTATUS[ IDINT ] .Value == 1))  ) ) 
                                { 
                                __context__.SourceCodeLine = 463;
                                RETURNVALUE__DOLLAR__  .UpdateValue ( "100"  ) ; 
                                } 
                            
                            }
                        
                        }
                    
                    } 
                
                __context__.SourceCodeLine = 466;
                CMDBUILDER (  __context__ , "AirPurifier", ID, "getAirPurifierRotationSpeed", RETURNVALUE__DOLLAR__) ; 
                } 
            
            __context__.SourceCodeLine = 469;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "AirQualitySensor") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "getPM2_5Value") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 470;
                CMDBUILDER (  __context__ , "AirQualitySensor", ID, "getPM2_5Value", Functions.LtoA( (int)( GET_PM2_5VALUE[ IDINT ] .UshortValue ) )) ; 
                } 
            
            __context__.SourceCodeLine = 472;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "AirQualitySensor") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "getVOC_Value") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 473;
                CMDBUILDER (  __context__ , "AirQualitySensor", ID, "getVOC_Value", Functions.LtoA( (int)( GET_VOC_VALUE[ IDINT ] .UshortValue ) )) ; 
                } 
            
            __context__.SourceCodeLine = 475;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "AirQualitySensor") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "getCarbonDioxideLevel") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 476;
                CMDBUILDER (  __context__ , "AirQualitySensor", ID, "getCarbonDioxideLevel", Functions.LtoA( (int)( GET_CO2[ IDINT ] .UshortValue ) )) ; 
                } 
            
            __context__.SourceCodeLine = 478;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "CarbonDioxideSensor") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "getCarbonDioxideLevel") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 479;
                CMDBUILDER (  __context__ , "CarbonDioxideSensor", ID, "getCarbonDioxideLevel", Functions.LtoA( (int)( GET_CO2[ IDINT ] .UshortValue ) )) ; 
                } 
            
            __context__.SourceCodeLine = 482;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "HumiditySensor") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "getCurrentRelativeHumidity") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 483;
                CMDBUILDER (  __context__ , "HumiditySensor", ID, "getCurrentRelativeHumidity", Functions.LtoA( (int)( GET_HUMIDITY[ IDINT ] .UshortValue ) )) ; 
                } 
            
            __context__.SourceCodeLine = 486;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "TemperatureSensor") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "getCurrentTemperature") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 487;
                CMDBUILDER (  __context__ , "TemperatureSensor", ID, "getCurrentTemperature", Functions.LtoA( (int)( GET_TEMPERATURE[ IDINT ] .UshortValue ) )) ; 
                } 
            
            __context__.SourceCodeLine = 491;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "HeaterCooler") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "getPowerState") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 492;
                CMDBUILDER (  __context__ , "HeaterCooler", ID, "getPowerState", Functions.LtoA( (int)( HEATERCOOLER_ONSTATUS[ IDINT ] .Value ) )) ; 
                } 
            
            __context__.SourceCodeLine = 496;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "Heater") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "getPowerState") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 497;
                CMDBUILDER (  __context__ , "Heater", ID, "getPowerState", Functions.LtoA( (int)( HEATER_ONSTATUS[ IDINT ] .Value ) )) ; 
                } 
            
            __context__.SourceCodeLine = 500;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "TV") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "getPowerState") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 501;
                CMDBUILDER (  __context__ , "TV", ID, "getPowerState", Functions.LtoA( (int)( TV_POWER_STATUS[ IDINT ] .Value ) )) ; 
                } 
            
            __context__.SourceCodeLine = 504;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "HeaterCooler") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "getRotationSpeed") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 505;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (HEATERCOOLER_ONSTATUS[ IDINT ] .Value == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 507;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (HEATERCOOLERFANSPEED_LOWSTATUS[ IDINT ] .Value == 1))  ) ) 
                        { 
                        __context__.SourceCodeLine = 509;
                        RETURNVALUE__DOLLAR__  .UpdateValue ( "33"  ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 510;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (HEATERCOOLERFANSPEED_MIDSTATUS[ IDINT ] .Value == 1))  ) ) 
                            { 
                            __context__.SourceCodeLine = 511;
                            RETURNVALUE__DOLLAR__  .UpdateValue ( "66"  ) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 512;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (HEATERCOOLERFANSPEED_HIGHSTATUS[ IDINT ] .Value == 1))  ) ) 
                                { 
                                __context__.SourceCodeLine = 513;
                                RETURNVALUE__DOLLAR__  .UpdateValue ( "100"  ) ; 
                                } 
                            
                            }
                        
                        }
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 519;
                    RETURNVALUE__DOLLAR__  .UpdateValue ( "0"  ) ; 
                    } 
                
                __context__.SourceCodeLine = 522;
                CMDBUILDER (  __context__ , "HeaterCooler", ID, "getRotationSpeed", RETURNVALUE__DOLLAR__) ; 
                } 
            
            __context__.SourceCodeLine = 525;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "HeaterCooler") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "getTargetHeaterCoolerState") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 526;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (HEATERCOOLER_ONSTATUS[ IDINT ] .Value == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 527;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (HEATERCOOLER_HEATSTATUS[ IDINT ] .Value == 1))  ) ) 
                        { 
                        __context__.SourceCodeLine = 528;
                        RETURNVALUE__DOLLAR__  .UpdateValue ( "1"  ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 529;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (HEATERCOOLER_COOLSTATUS[ IDINT ] .Value == 1))  ) ) 
                            { 
                            __context__.SourceCodeLine = 530;
                            RETURNVALUE__DOLLAR__  .UpdateValue ( "2"  ) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 531;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (HEATERCOOLER_COOLSTATUS[ IDINT ] .Value == 1))  ) ) 
                                { 
                                __context__.SourceCodeLine = 532;
                                RETURNVALUE__DOLLAR__  .UpdateValue ( "0"  ) ; 
                                } 
                            
                            }
                        
                        }
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 537;
                    RETURNVALUE__DOLLAR__  .UpdateValue ( "0"  ) ; 
                    } 
                
                __context__.SourceCodeLine = 539;
                CMDBUILDER (  __context__ , "HeaterCooler", ID, "getTargetHeaterCoolerState", RETURNVALUE__DOLLAR__) ; 
                } 
            
            __context__.SourceCodeLine = 542;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "HeaterCooler") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "getTargetTemperature") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 544;
                RETURNVALUE__DOLLAR__  .UpdateValue ( Functions.LtoA (  (int) ( HEATERCOOLER_GETTARGETTEMPERATURE[ IDINT ] .UshortValue ) )  ) ; 
                __context__.SourceCodeLine = 545;
                CMDBUILDER (  __context__ , "HeaterCooler", ID, "getTargetTemperature", RETURNVALUE__DOLLAR__) ; 
                } 
            
            __context__.SourceCodeLine = 549;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "HeaterCooler") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "getCurrentTemperature") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 551;
                RETURNVALUE__DOLLAR__  .UpdateValue ( Functions.LtoA (  (int) ( HEATERCOOLER_GETCURRENTTEMPERATURE[ IDINT ] .UshortValue ) )  ) ; 
                __context__.SourceCodeLine = 552;
                CMDBUILDER (  __context__ , "HeaterCooler", ID, "getCurrentTemperature", RETURNVALUE__DOLLAR__) ; 
                } 
            
            __context__.SourceCodeLine = 555;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "Heater") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "getTargetTemperature") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 557;
                RETURNVALUE__DOLLAR__  .UpdateValue ( Functions.LtoA (  (int) ( HEATER_GETTARGETTEMPERATURE[ IDINT ] .UshortValue ) )  ) ; 
                __context__.SourceCodeLine = 558;
                CMDBUILDER (  __context__ , "Heater", ID, "getTargetTemperature", RETURNVALUE__DOLLAR__) ; 
                } 
            
            __context__.SourceCodeLine = 562;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "Heater") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "getCurrentTemperature") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 564;
                RETURNVALUE__DOLLAR__  .UpdateValue ( Functions.LtoA (  (int) ( HEATER_GETCURRENTTEMPERATURE[ IDINT ] .UshortValue ) )  ) ; 
                __context__.SourceCodeLine = 565;
                CMDBUILDER (  __context__ , "Heater", ID, "getCurrentTemperature", RETURNVALUE__DOLLAR__) ; 
                } 
            
            __context__.SourceCodeLine = 571;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "Cooler") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "getPowerState") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 572;
                CMDBUILDER (  __context__ , "Cooler", ID, "getPowerState", Functions.LtoA( (int)( COOLER_ONSTATUS[ IDINT ] .Value ) )) ; 
                } 
            
            __context__.SourceCodeLine = 575;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "Cooler") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "getTargetTemperature") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 577;
                RETURNVALUE__DOLLAR__  .UpdateValue ( Functions.LtoA (  (int) ( COOLER_GETTARGETTEMPERATURE[ IDINT ] .UshortValue ) )  ) ; 
                __context__.SourceCodeLine = 578;
                CMDBUILDER (  __context__ , "Cooler", ID, "getTargetTemperature", RETURNVALUE__DOLLAR__) ; 
                } 
            
            __context__.SourceCodeLine = 582;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SERVICE == "Cooler") ) && Functions.TestForTrue ( Functions.BoolToInt (CMD == "getCurrentTemperature") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 584;
                RETURNVALUE__DOLLAR__  .UpdateValue ( Functions.LtoA (  (int) ( COOLER_GETCURRENTTEMPERATURE[ IDINT ] .UshortValue ) )  ) ; 
                __context__.SourceCodeLine = 585;
                CMDBUILDER (  __context__ , "Cooler", ID, "getCurrentTemperature", RETURNVALUE__DOLLAR__) ; 
                } 
            
            
            }
            
        private void SOCKETRX (  SplusExecutionContext __context__ ) 
            { 
            CrestronString TEMP__DOLLAR__;
            TEMP__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 65000, this );
            
            
            __context__.SourceCodeLine = 596;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( INTERNALRXBUFFER ) > 1 ))  ) ) 
                { 
                __context__.SourceCodeLine = 597;
                TEMP__DOLLAR__  .UpdateValue ( Functions.Remove ( "*" , INTERNALRXBUFFER )  ) ; 
                __context__.SourceCodeLine = 598;
                TEMP__DOLLAR__  .UpdateValue ( Functions.Left ( TEMP__DOLLAR__ ,  (int) ( (Functions.Length( TEMP__DOLLAR__ ) - 1) ) )  ) ; 
                __context__.SourceCodeLine = 599;
                CMDPARSER (  __context__ , TEMP__DOLLAR__) ; 
                __context__.SourceCodeLine = 596;
                } 
            
            
            }
            
        object LIGHTS_STATUS_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort ID = 0;
                
                
                __context__.SourceCodeLine = 609;
                ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 610;
                CMDBUILDER (  __context__ , "Lightbulb", Functions.LtoA( (int)( ID ) ), "eventPowerState", Functions.LtoA( (int)( LIGHTS_STATUS[ ID ] .Value ) )) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object SWITCH_STATUS_OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort ID = 0;
            
            
            __context__.SourceCodeLine = 614;
            ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
            __context__.SourceCodeLine = 615;
            CMDBUILDER (  __context__ , "Switch", Functions.LtoA( (int)( ID ) ), "eventPowerState", Functions.LtoA( (int)( SWITCH_STATUS[ ID ] .Value ) )) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object TV_POWER_STATUS_OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        
        __context__.SourceCodeLine = 620;
        CMDBUILDER (  __context__ , "TV", Functions.LtoA( (int)( ID ) ), "eventPowerState", Functions.LtoA( (int)( TV_POWER_STATUS[ ID ] .Value ) )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CONTACTSENSOR_STATUS_OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        
        __context__.SourceCodeLine = 625;
        ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 626;
        CMDBUILDER (  __context__ , "ContactSensor", Functions.LtoA( (int)( ID ) ), "eventSensorState", Functions.LtoA( (int)( CONTACTSENSOR_STATUS[ ID ] .Value ) )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SMOKESENSOR_STATUS_OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        
        __context__.SourceCodeLine = 630;
        ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 631;
        CMDBUILDER (  __context__ , "SmokeSensor", Functions.LtoA( (int)( ID ) ), "eventSensorState", Functions.LtoA( (int)( SMOKESENSOR_STATUS[ ID ] .Value ) )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object OCCUPANCYSENSOR_STATUS_OnChange_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        
        __context__.SourceCodeLine = 635;
        ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 636;
        CMDBUILDER (  __context__ , "OccupancySensor", Functions.LtoA( (int)( ID ) ), "eventSensorState", Functions.LtoA( (int)( OCCUPANCYSENSOR_STATUS[ ID ] .Value ) )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MOTIONSENSOR_STATUS_OnChange_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        
        __context__.SourceCodeLine = 640;
        ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 641;
        CMDBUILDER (  __context__ , "MotionSensor", Functions.LtoA( (int)( ID ) ), "eventSensorState", Functions.LtoA( (int)( MOTIONSENSOR_STATUS[ ID ] .Value ) )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object LEAKSENSOR_STATUS_OnChange_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        
        __context__.SourceCodeLine = 645;
        ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 646;
        CMDBUILDER (  __context__ , "LeakSensor", Functions.LtoA( (int)( ID ) ), "eventSensorState", Functions.LtoA( (int)( LEAKSENSOR_STATUS[ ID ] .Value ) )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object LIGHTSENSOR_STATUS_OnChange_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        
        __context__.SourceCodeLine = 650;
        ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 651;
        CMDBUILDER (  __context__ , "LightSensor", Functions.LtoA( (int)( ID ) ), "eventCurrentAmbientLightLevel", Functions.LtoA( (int)( LIGHTSENSOR_STATUS[ ID ] .UshortValue ) )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SHADES_POSITION_OnChange_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        CrestronString RETURNVALUE;
        RETURNVALUE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
        
        
        __context__.SourceCodeLine = 657;
        ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 659;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SHADES_POSITION[ ID ] .UshortValue <= 100 ))  ) ) 
            { 
            __context__.SourceCodeLine = 660;
            RETURNVALUE  .UpdateValue ( Functions.LtoA (  (int) ( (100 - SHADES_POSITION[ ID ] .UshortValue) ) )  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 662;
            RETURNVALUE  .UpdateValue ( Functions.LtoA (  (int) ( (((100 - SHADES_POSITION[ ID ] .UshortValue) * 100) / 65535) ) )  ) ; 
            } 
        
        __context__.SourceCodeLine = 664;
        CMDBUILDER (  __context__ , "WindowCovering", Functions.LtoA( (int)( ID ) ), "eventCurrentPosition", RETURNVALUE) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DIMLIGHT_BRIGHTNESS_OnChange_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        CrestronString RETURNVALUE;
        RETURNVALUE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
        
        
        __context__.SourceCodeLine = 669;
        ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 670;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( DIMLIGHT_BRIGHTNESS[ ID ] .UshortValue <= 100 ))  ) ) 
            { 
            __context__.SourceCodeLine = 671;
            RETURNVALUE  .UpdateValue ( Functions.LtoA (  (int) ( DIMLIGHT_BRIGHTNESS[ ID ] .UshortValue ) )  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 673;
            RETURNVALUE  .UpdateValue ( Functions.LtoA (  (int) ( ((DIMLIGHT_BRIGHTNESS[ ID ] .UshortValue * 100) / 65535) ) )  ) ; 
            } 
        
        __context__.SourceCodeLine = 675;
        CMDBUILDER (  __context__ , "DimLightbulb", Functions.LtoA( (int)( ID ) ), "eventLightBrightness", RETURNVALUE) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object HEATER_ONSTATUS_OnChange_11 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        
        __context__.SourceCodeLine = 680;
        ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 682;
        CMDBUILDER (  __context__ , "Heater", Functions.LtoA( (int)( ID ) ), "eventPowerState", Functions.LtoA( (int)( HEATER_ONSTATUS[ ID ] .Value ) )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object HEATERCOOLER_ONSTATUS_OnChange_12 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        
        __context__.SourceCodeLine = 688;
        ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 689;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (HEATERCOOLER_ONSTATUS[ ID ] .Value == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 691;
            CMDBUILDER (  __context__ , "HeaterCooler", Functions.LtoA( (int)( ID ) ), "eventPowerState", "0") ; 
            __context__.SourceCodeLine = 692;
            CMDBUILDER (  __context__ , "HeaterCooler", Functions.LtoA( (int)( ID ) ), "eventRotationSpeed", "0") ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 696;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (HEATERCOOLER_HEATSTATUS[ ID ] .Value == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 698;
                CMDBUILDER (  __context__ , "HeaterCooler", Functions.LtoA( (int)( ID ) ), "eventTargetHeaterCoolerState", "1") ; 
                __context__.SourceCodeLine = 699;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (HEATERCOOLERFANSPEED_LOWSTATUS[ ID ] .Value == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 701;
                    CMDBUILDER (  __context__ , "HeaterCooler", Functions.LtoA( (int)( ID ) ), "eventRotationSpeed", "33") ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 702;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (HEATERCOOLERFANSPEED_MIDSTATUS[ ID ] .Value == 1))  ) ) 
                        { 
                        __context__.SourceCodeLine = 704;
                        CMDBUILDER (  __context__ , "HeaterCooler", Functions.LtoA( (int)( ID ) ), "eventRotationSpeed", "66") ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 707;
                        CMDBUILDER (  __context__ , "HeaterCooler", Functions.LtoA( (int)( ID ) ), "eventRotationSpeed", "100") ; 
                        } 
                    
                    }
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 710;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (HEATERCOOLER_COOLSTATUS[ ID ] .Value == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 712;
                    CMDBUILDER (  __context__ , "HeaterCooler", Functions.LtoA( (int)( ID ) ), "eventTargetHeaterCoolerState", "2") ; 
                    __context__.SourceCodeLine = 713;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (HEATERCOOLERFANSPEED_LOWSTATUS[ ID ] .Value == 1))  ) ) 
                        { 
                        __context__.SourceCodeLine = 715;
                        CMDBUILDER (  __context__ , "HeaterCooler", Functions.LtoA( (int)( ID ) ), "eventRotationSpeed", "33") ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 716;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (HEATERCOOLERFANSPEED_MIDSTATUS[ ID ] .Value == 1))  ) ) 
                            { 
                            __context__.SourceCodeLine = 718;
                            CMDBUILDER (  __context__ , "HeaterCooler", Functions.LtoA( (int)( ID ) ), "eventRotationSpeed", "66") ; 
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 721;
                            CMDBUILDER (  __context__ , "HeaterCooler", Functions.LtoA( (int)( ID ) ), "eventRotationSpeed", "100") ; 
                            } 
                        
                        }
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 726;
                    CMDBUILDER (  __context__ , "HeaterCooler", Functions.LtoA( (int)( ID ) ), "eventTargetHeaterCoolerState", "0") ; 
                    __context__.SourceCodeLine = 727;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (HEATERCOOLERFANSPEED_LOWSTATUS[ ID ] .Value == 1))  ) ) 
                        { 
                        __context__.SourceCodeLine = 729;
                        CMDBUILDER (  __context__ , "HeaterCooler", Functions.LtoA( (int)( ID ) ), "eventRotationSpeed", "33") ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 730;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (HEATERCOOLERFANSPEED_MIDSTATUS[ ID ] .Value == 1))  ) ) 
                            { 
                            __context__.SourceCodeLine = 732;
                            CMDBUILDER (  __context__ , "HeaterCooler", Functions.LtoA( (int)( ID ) ), "eventRotationSpeed", "66") ; 
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 735;
                            CMDBUILDER (  __context__ , "HeaterCooler", Functions.LtoA( (int)( ID ) ), "eventRotationSpeed", "100") ; 
                            } 
                        
                        }
                    
                    } 
                
                }
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object HEATERCOOLERFANSPEED_LOWSTATUS_OnPush_13 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        
        __context__.SourceCodeLine = 743;
        ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 744;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (HEATERCOOLER_ONSTATUS[ ID ] .Value == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 746;
            CMDBUILDER (  __context__ , "HeaterCooler", Functions.LtoA( (int)( ID ) ), "eventRotationSpeed", "33") ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object HEATERCOOLERFANSPEED_MIDSTATUS_OnPush_14 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        
        __context__.SourceCodeLine = 752;
        ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 753;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (HEATERCOOLER_ONSTATUS[ ID ] .Value == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 755;
            CMDBUILDER (  __context__ , "HeaterCooler", Functions.LtoA( (int)( ID ) ), "eventRotationSpeed", "66") ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object HEATERCOOLERFANSPEED_HIGHSTATUS_OnPush_15 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        
        __context__.SourceCodeLine = 761;
        ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 763;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (HEATERCOOLER_ONSTATUS[ ID ] .Value == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 765;
            CMDBUILDER (  __context__ , "HeaterCooler", Functions.LtoA( (int)( ID ) ), "eventRotationSpeed", "100") ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object HEATERCOOLER_HEATSTATUS_OnPush_16 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        
        __context__.SourceCodeLine = 771;
        ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 772;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (HEATERCOOLER_ONSTATUS[ ID ] .Value == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 774;
            CMDBUILDER (  __context__ , "HeaterCooler", Functions.LtoA( (int)( ID ) ), "eventTargetHeaterCoolerState", "1") ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object HEATERCOOLER_COOLSTATUS_OnPush_17 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        
        __context__.SourceCodeLine = 781;
        ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 782;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (HEATERCOOLER_ONSTATUS[ ID ] .Value == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 784;
            CMDBUILDER (  __context__ , "HeaterCooler", Functions.LtoA( (int)( ID ) ), "eventTargetHeaterCoolerState", "2") ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object HEATERCOOLER_GETCURRENTTEMPERATURE_OnChange_18 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        CrestronString RETURNVALUE;
        RETURNVALUE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
        
        
        __context__.SourceCodeLine = 792;
        ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 794;
        RETURNVALUE  .UpdateValue ( Functions.LtoA (  (int) ( HEATERCOOLER_GETCURRENTTEMPERATURE[ ID ] .UshortValue ) )  ) ; 
        __context__.SourceCodeLine = 796;
        CMDBUILDER (  __context__ , "HeaterCooler", Functions.LtoA( (int)( ID ) ), "eventCurrentTemperature", RETURNVALUE) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object HEATERCOOLER_GETTARGETTEMPERATURE_OnChange_19 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        CrestronString RETURNVALUE;
        RETURNVALUE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
        
        
        __context__.SourceCodeLine = 802;
        ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 804;
        RETURNVALUE  .UpdateValue ( Functions.LtoA (  (int) ( HEATERCOOLER_GETTARGETTEMPERATURE[ ID ] .UshortValue ) )  ) ; 
        __context__.SourceCodeLine = 806;
        CMDBUILDER (  __context__ , "HeaterCooler", Functions.LtoA( (int)( ID ) ), "eventTargetTemperature", RETURNVALUE) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object HEATER_GETTARGETTEMPERATURE_OnChange_20 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        CrestronString RETURNVALUE;
        RETURNVALUE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
        
        
        __context__.SourceCodeLine = 812;
        ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 814;
        RETURNVALUE  .UpdateValue ( Functions.LtoA (  (int) ( HEATER_GETTARGETTEMPERATURE[ ID ] .UshortValue ) )  ) ; 
        __context__.SourceCodeLine = 815;
        CMDBUILDER (  __context__ , "Heater", Functions.LtoA( (int)( ID ) ), "eventTargetTemperature", RETURNVALUE) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object HEATER_GETCURRENTTEMPERATURE_OnChange_21 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        CrestronString RETURNVALUE;
        RETURNVALUE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
        
        
        __context__.SourceCodeLine = 821;
        ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 823;
        RETURNVALUE  .UpdateValue ( Functions.LtoA (  (int) ( HEATER_GETCURRENTTEMPERATURE[ ID ] .UshortValue ) )  ) ; 
        __context__.SourceCodeLine = 824;
        CMDBUILDER (  __context__ , "Heater", Functions.LtoA( (int)( ID ) ), "eventCurrentTemperature", RETURNVALUE) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object AIRPURIFIER_FILTERMAINTENANCE_STATUS_OnChange_22 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        CrestronString RETURNVALUE;
        RETURNVALUE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
        
        
        __context__.SourceCodeLine = 830;
        ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 832;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( AIRPURIFIER_FILTERMAINTENANCE_STATUS[ ID ] .UshortValue <= 100 ))  ) ) 
            { 
            __context__.SourceCodeLine = 833;
            RETURNVALUE  .UpdateValue ( Functions.LtoA (  (int) ( AIRPURIFIER_FILTERMAINTENANCE_STATUS[ ID ] .UshortValue ) )  ) ; 
            } 
        
        __context__.SourceCodeLine = 835;
        CMDBUILDER (  __context__ , "AirPurifier", Functions.LtoA( (int)( ID ) ), "eventFilterLifeLevel", RETURNVALUE) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object AIRPURIFIER_ONSTATUS_OnChange_23 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        
        __context__.SourceCodeLine = 840;
        ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 842;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (AIRPURIFIER_ONSTATUS[ ID ] .Value == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 844;
            CMDBUILDER (  __context__ , "AirPurifier", Functions.LtoA( (int)( ID ) ), "eventPowerState", "1") ; 
            __context__.SourceCodeLine = 846;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (AIRPURIFIER_AUTOSTATUS[ ID ] .Value == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 848;
                CMDBUILDER (  __context__ , "AirPurifier", Functions.LtoA( (int)( ID ) ), "eventTargetAirPurifierState", "1") ; 
                __context__.SourceCodeLine = 849;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (AIRPURIFIERFANSPEED_LOWSTATUS[ ID ] .Value == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 851;
                    CMDBUILDER (  __context__ , "AirPurifier", Functions.LtoA( (int)( ID ) ), "eventAirPurifierRotationSpeed", "33") ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 853;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (AIRPURIFIERFANSPEED_MIDSTATUS[ ID ] .Value == 1))  ) ) 
                        { 
                        __context__.SourceCodeLine = 855;
                        CMDBUILDER (  __context__ , "AirPurifier", Functions.LtoA( (int)( ID ) ), "eventAirPurifierRotationSpeed", "66") ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 857;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (AIRPURIFIERFANSPEED_HIGHSTATUS[ ID ] .Value == 1))  ) ) 
                            { 
                            __context__.SourceCodeLine = 859;
                            CMDBUILDER (  __context__ , "AirPurifier", Functions.LtoA( (int)( ID ) ), "eventAirPurifierRotationSpeed", "100") ; 
                            } 
                        
                        }
                    
                    }
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 864;
                CMDBUILDER (  __context__ , "AirPurifier", Functions.LtoA( (int)( ID ) ), "eventTargetAirPurifierState", "0") ; 
                __context__.SourceCodeLine = 865;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (AIRPURIFIERFANSPEED_LOWSTATUS[ ID ] .Value == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 867;
                    CMDBUILDER (  __context__ , "AirPurifier", Functions.LtoA( (int)( ID ) ), "eventAirPurifierRotationSpeed", "33") ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 869;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (AIRPURIFIERFANSPEED_MIDSTATUS[ ID ] .Value == 1))  ) ) 
                        { 
                        __context__.SourceCodeLine = 871;
                        CMDBUILDER (  __context__ , "AirPurifier", Functions.LtoA( (int)( ID ) ), "eventAirPurifierRotationSpeed", "66") ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 873;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (AIRPURIFIERFANSPEED_HIGHSTATUS[ ID ] .Value == 1))  ) ) 
                            { 
                            __context__.SourceCodeLine = 875;
                            CMDBUILDER (  __context__ , "AirPurifier", Functions.LtoA( (int)( ID ) ), "eventAirPurifierRotationSpeed", "100") ; 
                            } 
                        
                        }
                    
                    }
                
                } 
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 880;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (AIRPURIFIER_ONSTATUS[ ID ] .Value == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 882;
                CMDBUILDER (  __context__ , "AirPurifier", Functions.LtoA( (int)( ID ) ), "eventPowerState", "0") ; 
                } 
            
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object AIRPURIFIER_AUTOSTATUS_OnPush_24 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        
        __context__.SourceCodeLine = 888;
        ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 889;
        CMDBUILDER (  __context__ , "AirPurifier", Functions.LtoA( (int)( ID ) ), "eventTargetAirPurifierState", "1") ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object AIRPURIFIER_MANUALSTATUS_OnPush_25 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        
        __context__.SourceCodeLine = 894;
        ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 895;
        CMDBUILDER (  __context__ , "AirPurifier", Functions.LtoA( (int)( ID ) ), "eventTargetAirPurifierState", "0") ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object AIRPURIFIERFANSPEED_LOWSTATUS_OnPush_26 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        
        __context__.SourceCodeLine = 900;
        ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 901;
        CMDBUILDER (  __context__ , "AirPurifier", Functions.LtoA( (int)( ID ) ), "eventAirPurifierRotationSpeed", "33") ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object AIRPURIFIERFANSPEED_MIDSTATUS_OnPush_27 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        
        __context__.SourceCodeLine = 905;
        ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 906;
        CMDBUILDER (  __context__ , "AirPurifier", Functions.LtoA( (int)( ID ) ), "eventAirPurifierRotationSpeed", "66") ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object AIRPURIFIERFANSPEED_HIGHSTATUS_OnPush_28 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        
        __context__.SourceCodeLine = 910;
        ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 911;
        CMDBUILDER (  __context__ , "AirPurifier", Functions.LtoA( (int)( ID ) ), "eventAirPurifierRotationSpeed", "100") ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object GET_PM2_5VALUE_OnChange_29 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        
        __context__.SourceCodeLine = 918;
        ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 919;
        CMDBUILDER (  __context__ , "AirQualitySensor", Functions.LtoA( (int)( ID ) ), "eventPM2_5Value", Functions.LtoA( (int)( GET_PM2_5VALUE[ ID ] .UshortValue ) )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object GET_VOC_VALUE_OnChange_30 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        
        __context__.SourceCodeLine = 924;
        ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 925;
        CMDBUILDER (  __context__ , "AirQualitySensor", Functions.LtoA( (int)( ID ) ), "eventVOC_Value", Functions.LtoA( (int)( GET_VOC_VALUE[ ID ] .UshortValue ) )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object GET_CO2_OnChange_31 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        
        __context__.SourceCodeLine = 930;
        ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 931;
        CMDBUILDER (  __context__ , "AirQualitySensor", Functions.LtoA( (int)( ID ) ), "eventCarbonDioxideLevel", Functions.LtoA( (int)( GET_CO2[ ID ] .UshortValue ) )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object GET_HUMIDITY_OnChange_32 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        
        __context__.SourceCodeLine = 936;
        ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 937;
        CMDBUILDER (  __context__ , "HumiditySensor", Functions.LtoA( (int)( ID ) ), "eventCurrentRelativeHumidity", Functions.LtoA( (int)( GET_HUMIDITY[ ID ] .UshortValue ) )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object GET_TEMPERATURE_OnChange_33 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        
        __context__.SourceCodeLine = 942;
        ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 943;
        CMDBUILDER (  __context__ , "TemperatureSensor", Functions.LtoA( (int)( ID ) ), "eventCurrentTemperature", Functions.LtoA( (int)( GET_TEMPERATURE[ ID ] .UshortValue ) )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object COOLER_ONSTATUS_OnChange_34 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        
        __context__.SourceCodeLine = 949;
        ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 951;
        CMDBUILDER (  __context__ , "Cooler", Functions.LtoA( (int)( ID ) ), "eventPowerState", Functions.LtoA( (int)( COOLER_ONSTATUS[ ID ] .Value ) )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object COOLER_GETTARGETTEMPERATURE_OnChange_35 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        CrestronString RETURNVALUE;
        RETURNVALUE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
        
        
        __context__.SourceCodeLine = 957;
        ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 959;
        RETURNVALUE  .UpdateValue ( Functions.LtoA (  (int) ( COOLER_GETTARGETTEMPERATURE[ ID ] .UshortValue ) )  ) ; 
        __context__.SourceCodeLine = 961;
        CMDBUILDER (  __context__ , "Cooler", Functions.LtoA( (int)( ID ) ), "eventTargetTemperature", RETURNVALUE) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object COOLER_GETCURRENTTEMPERATURE_OnChange_36 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ID = 0;
        
        CrestronString RETURNVALUE;
        RETURNVALUE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
        
        
        __context__.SourceCodeLine = 966;
        ID = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 968;
        RETURNVALUE  .UpdateValue ( Functions.LtoA (  (int) ( COOLER_GETCURRENTTEMPERATURE[ ID ] .UshortValue ) )  ) ; 
        __context__.SourceCodeLine = 969;
        CMDBUILDER (  __context__ , "Cooler", Functions.LtoA( (int)( ID ) ), "eventCurrentTemperature", RETURNVALUE) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MYSERVER_OnSocketConnect_37 ( Object __Info__ )

    { 
    SocketEventInfo __SocketInfo__ = (SocketEventInfo)__Info__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SocketInfo__);
        
        __context__.SourceCodeLine = 977;
        DOSERVERCONNECTED = (short) ( 1 ) ; 
        __context__.SourceCodeLine = 978;
        Print( "OnConnect: input buffer size is: {0:d}\r\n", (short)Functions.Length( MYSERVER.SocketRxBuf )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SocketInfo__ ); }
    return this;
    
}

object MYSERVER_OnSocketDisconnect_38 ( Object __Info__ )

    { 
    SocketEventInfo __SocketInfo__ = (SocketEventInfo)__Info__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SocketInfo__);
        
        __context__.SourceCodeLine = 982;
        DOSERVERCONNECTED = (short) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SocketInfo__ ); }
    return this;
    
}

object MYSERVER_OnSocketStatus_39 ( Object __Info__ )

    { 
    SocketEventInfo __SocketInfo__ = (SocketEventInfo)__Info__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SocketInfo__);
        short STATUS = 0;
        
        
        __context__.SourceCodeLine = 987;
        STATUS = (short) ( __SocketInfo__.SocketStatus ) ; 
        __context__.SourceCodeLine = 989;
        Print( "The SocketGetStatus returns:       {0:d}\r\n", (short)STATUS) ; 
        __context__.SourceCodeLine = 990;
        Print( "The MyServer.SocketStatus returns: {0:d}\r\n", (short)MYSERVER.SocketStatus) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SocketInfo__ ); }
    return this;
    
}

object MYSERVER_OnSocketReceive_40 ( Object __Info__ )

    { 
    SocketEventInfo __SocketInfo__ = (SocketEventInfo)__Info__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SocketInfo__);
        
        __context__.SourceCodeLine = 994;
        INTERNALRXBUFFER  .UpdateValue ( INTERNALRXBUFFER + MYSERVER .  SocketRxBuf  ) ; 
        __context__.SourceCodeLine = 995;
        Functions.ClearBuffer ( MYSERVER .  SocketRxBuf ) ; 
        __context__.SourceCodeLine = 996;
        SOCKETRX (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SocketInfo__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 1002;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 1004;
        STARTSERVER (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    SocketInfo __socketinfo__ = new SocketInfo( 1, this );
    InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
    _SplusNVRAM = new SplusNVRAM( this );
    INTERNALRXBUFFER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 65000, this );
    MYSERVER  = new SplusTcpServer ( 9999, this );
    
    TV_POWER_STATUS = new InOutArray<DigitalInput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        TV_POWER_STATUS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( TV_POWER_STATUS__DigitalInput__ + i, TV_POWER_STATUS__DigitalInput__, this );
        m_DigitalInputList.Add( TV_POWER_STATUS__DigitalInput__ + i, TV_POWER_STATUS[i+1] );
    }
    
    LIGHTS_STATUS = new InOutArray<DigitalInput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        LIGHTS_STATUS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( LIGHTS_STATUS__DigitalInput__ + i, LIGHTS_STATUS__DigitalInput__, this );
        m_DigitalInputList.Add( LIGHTS_STATUS__DigitalInput__ + i, LIGHTS_STATUS[i+1] );
    }
    
    SWITCH_STATUS = new InOutArray<DigitalInput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        SWITCH_STATUS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SWITCH_STATUS__DigitalInput__ + i, SWITCH_STATUS__DigitalInput__, this );
        m_DigitalInputList.Add( SWITCH_STATUS__DigitalInput__ + i, SWITCH_STATUS[i+1] );
    }
    
    HEATERCOOLER_ONSTATUS = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        HEATERCOOLER_ONSTATUS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( HEATERCOOLER_ONSTATUS__DigitalInput__ + i, HEATERCOOLER_ONSTATUS__DigitalInput__, this );
        m_DigitalInputList.Add( HEATERCOOLER_ONSTATUS__DigitalInput__ + i, HEATERCOOLER_ONSTATUS[i+1] );
    }
    
    HEATERCOOLER_OFFSTATUS = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        HEATERCOOLER_OFFSTATUS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( HEATERCOOLER_OFFSTATUS__DigitalInput__ + i, HEATERCOOLER_OFFSTATUS__DigitalInput__, this );
        m_DigitalInputList.Add( HEATERCOOLER_OFFSTATUS__DigitalInput__ + i, HEATERCOOLER_OFFSTATUS[i+1] );
    }
    
    HEATERCOOLERFANSPEED_LOWSTATUS = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        HEATERCOOLERFANSPEED_LOWSTATUS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( HEATERCOOLERFANSPEED_LOWSTATUS__DigitalInput__ + i, HEATERCOOLERFANSPEED_LOWSTATUS__DigitalInput__, this );
        m_DigitalInputList.Add( HEATERCOOLERFANSPEED_LOWSTATUS__DigitalInput__ + i, HEATERCOOLERFANSPEED_LOWSTATUS[i+1] );
    }
    
    HEATERCOOLERFANSPEED_MIDSTATUS = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        HEATERCOOLERFANSPEED_MIDSTATUS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( HEATERCOOLERFANSPEED_MIDSTATUS__DigitalInput__ + i, HEATERCOOLERFANSPEED_MIDSTATUS__DigitalInput__, this );
        m_DigitalInputList.Add( HEATERCOOLERFANSPEED_MIDSTATUS__DigitalInput__ + i, HEATERCOOLERFANSPEED_MIDSTATUS[i+1] );
    }
    
    HEATERCOOLERFANSPEED_HIGHSTATUS = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        HEATERCOOLERFANSPEED_HIGHSTATUS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( HEATERCOOLERFANSPEED_HIGHSTATUS__DigitalInput__ + i, HEATERCOOLERFANSPEED_HIGHSTATUS__DigitalInput__, this );
        m_DigitalInputList.Add( HEATERCOOLERFANSPEED_HIGHSTATUS__DigitalInput__ + i, HEATERCOOLERFANSPEED_HIGHSTATUS[i+1] );
    }
    
    HEATERCOOLER_HEATSTATUS = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        HEATERCOOLER_HEATSTATUS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( HEATERCOOLER_HEATSTATUS__DigitalInput__ + i, HEATERCOOLER_HEATSTATUS__DigitalInput__, this );
        m_DigitalInputList.Add( HEATERCOOLER_HEATSTATUS__DigitalInput__ + i, HEATERCOOLER_HEATSTATUS[i+1] );
    }
    
    HEATERCOOLER_COOLSTATUS = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        HEATERCOOLER_COOLSTATUS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( HEATERCOOLER_COOLSTATUS__DigitalInput__ + i, HEATERCOOLER_COOLSTATUS__DigitalInput__, this );
        m_DigitalInputList.Add( HEATERCOOLER_COOLSTATUS__DigitalInput__ + i, HEATERCOOLER_COOLSTATUS[i+1] );
    }
    
    HEATER_ONSTATUS = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        HEATER_ONSTATUS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( HEATER_ONSTATUS__DigitalInput__ + i, HEATER_ONSTATUS__DigitalInput__, this );
        m_DigitalInputList.Add( HEATER_ONSTATUS__DigitalInput__ + i, HEATER_ONSTATUS[i+1] );
    }
    
    HEATER_OFFSTATUS = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        HEATER_OFFSTATUS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( HEATER_OFFSTATUS__DigitalInput__ + i, HEATER_OFFSTATUS__DigitalInput__, this );
        m_DigitalInputList.Add( HEATER_OFFSTATUS__DigitalInput__ + i, HEATER_OFFSTATUS[i+1] );
    }
    
    COOLER_ONSTATUS = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        COOLER_ONSTATUS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( COOLER_ONSTATUS__DigitalInput__ + i, COOLER_ONSTATUS__DigitalInput__, this );
        m_DigitalInputList.Add( COOLER_ONSTATUS__DigitalInput__ + i, COOLER_ONSTATUS[i+1] );
    }
    
    COOLER_OFFSTATUS = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        COOLER_OFFSTATUS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( COOLER_OFFSTATUS__DigitalInput__ + i, COOLER_OFFSTATUS__DigitalInput__, this );
        m_DigitalInputList.Add( COOLER_OFFSTATUS__DigitalInput__ + i, COOLER_OFFSTATUS[i+1] );
    }
    
    AIRPURIFIER_ONSTATUS = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        AIRPURIFIER_ONSTATUS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( AIRPURIFIER_ONSTATUS__DigitalInput__ + i, AIRPURIFIER_ONSTATUS__DigitalInput__, this );
        m_DigitalInputList.Add( AIRPURIFIER_ONSTATUS__DigitalInput__ + i, AIRPURIFIER_ONSTATUS[i+1] );
    }
    
    AIRPURIFIER_OFFSTATUS = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        AIRPURIFIER_OFFSTATUS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( AIRPURIFIER_OFFSTATUS__DigitalInput__ + i, AIRPURIFIER_OFFSTATUS__DigitalInput__, this );
        m_DigitalInputList.Add( AIRPURIFIER_OFFSTATUS__DigitalInput__ + i, AIRPURIFIER_OFFSTATUS[i+1] );
    }
    
    AIRPURIFIER_AUTOSTATUS = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        AIRPURIFIER_AUTOSTATUS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( AIRPURIFIER_AUTOSTATUS__DigitalInput__ + i, AIRPURIFIER_AUTOSTATUS__DigitalInput__, this );
        m_DigitalInputList.Add( AIRPURIFIER_AUTOSTATUS__DigitalInput__ + i, AIRPURIFIER_AUTOSTATUS[i+1] );
    }
    
    AIRPURIFIER_MANUALSTATUS = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        AIRPURIFIER_MANUALSTATUS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( AIRPURIFIER_MANUALSTATUS__DigitalInput__ + i, AIRPURIFIER_MANUALSTATUS__DigitalInput__, this );
        m_DigitalInputList.Add( AIRPURIFIER_MANUALSTATUS__DigitalInput__ + i, AIRPURIFIER_MANUALSTATUS[i+1] );
    }
    
    AIRPURIFIERFANSPEED_LOWSTATUS = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        AIRPURIFIERFANSPEED_LOWSTATUS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( AIRPURIFIERFANSPEED_LOWSTATUS__DigitalInput__ + i, AIRPURIFIERFANSPEED_LOWSTATUS__DigitalInput__, this );
        m_DigitalInputList.Add( AIRPURIFIERFANSPEED_LOWSTATUS__DigitalInput__ + i, AIRPURIFIERFANSPEED_LOWSTATUS[i+1] );
    }
    
    AIRPURIFIERFANSPEED_MIDSTATUS = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        AIRPURIFIERFANSPEED_MIDSTATUS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( AIRPURIFIERFANSPEED_MIDSTATUS__DigitalInput__ + i, AIRPURIFIERFANSPEED_MIDSTATUS__DigitalInput__, this );
        m_DigitalInputList.Add( AIRPURIFIERFANSPEED_MIDSTATUS__DigitalInput__ + i, AIRPURIFIERFANSPEED_MIDSTATUS[i+1] );
    }
    
    AIRPURIFIERFANSPEED_HIGHSTATUS = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        AIRPURIFIERFANSPEED_HIGHSTATUS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( AIRPURIFIERFANSPEED_HIGHSTATUS__DigitalInput__ + i, AIRPURIFIERFANSPEED_HIGHSTATUS__DigitalInput__, this );
        m_DigitalInputList.Add( AIRPURIFIERFANSPEED_HIGHSTATUS__DigitalInput__ + i, AIRPURIFIERFANSPEED_HIGHSTATUS[i+1] );
    }
    
    CONTACTSENSOR_STATUS = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        CONTACTSENSOR_STATUS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( CONTACTSENSOR_STATUS__DigitalInput__ + i, CONTACTSENSOR_STATUS__DigitalInput__, this );
        m_DigitalInputList.Add( CONTACTSENSOR_STATUS__DigitalInput__ + i, CONTACTSENSOR_STATUS[i+1] );
    }
    
    SMOKESENSOR_STATUS = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        SMOKESENSOR_STATUS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SMOKESENSOR_STATUS__DigitalInput__ + i, SMOKESENSOR_STATUS__DigitalInput__, this );
        m_DigitalInputList.Add( SMOKESENSOR_STATUS__DigitalInput__ + i, SMOKESENSOR_STATUS[i+1] );
    }
    
    OCCUPANCYSENSOR_STATUS = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        OCCUPANCYSENSOR_STATUS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( OCCUPANCYSENSOR_STATUS__DigitalInput__ + i, OCCUPANCYSENSOR_STATUS__DigitalInput__, this );
        m_DigitalInputList.Add( OCCUPANCYSENSOR_STATUS__DigitalInput__ + i, OCCUPANCYSENSOR_STATUS[i+1] );
    }
    
    MOTIONSENSOR_STATUS = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        MOTIONSENSOR_STATUS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( MOTIONSENSOR_STATUS__DigitalInput__ + i, MOTIONSENSOR_STATUS__DigitalInput__, this );
        m_DigitalInputList.Add( MOTIONSENSOR_STATUS__DigitalInput__ + i, MOTIONSENSOR_STATUS[i+1] );
    }
    
    LEAKSENSOR_STATUS = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        LEAKSENSOR_STATUS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( LEAKSENSOR_STATUS__DigitalInput__ + i, LEAKSENSOR_STATUS__DigitalInput__, this );
        m_DigitalInputList.Add( LEAKSENSOR_STATUS__DigitalInput__ + i, LEAKSENSOR_STATUS[i+1] );
    }
    
    TV_ON = new InOutArray<DigitalOutput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        TV_ON[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( TV_ON__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( TV_ON__DigitalOutput__ + i, TV_ON[i+1] );
    }
    
    TV_OFF = new InOutArray<DigitalOutput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        TV_OFF[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( TV_OFF__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( TV_OFF__DigitalOutput__ + i, TV_OFF[i+1] );
    }
    
    LIGHTS_ON = new InOutArray<DigitalOutput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        LIGHTS_ON[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( LIGHTS_ON__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( LIGHTS_ON__DigitalOutput__ + i, LIGHTS_ON[i+1] );
    }
    
    LIGHTS_OFF = new InOutArray<DigitalOutput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        LIGHTS_OFF[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( LIGHTS_OFF__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( LIGHTS_OFF__DigitalOutput__ + i, LIGHTS_OFF[i+1] );
    }
    
    SWITCH_ON = new InOutArray<DigitalOutput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        SWITCH_ON[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( SWITCH_ON__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( SWITCH_ON__DigitalOutput__ + i, SWITCH_ON[i+1] );
    }
    
    SWITCH_OFF = new InOutArray<DigitalOutput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        SWITCH_OFF[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( SWITCH_OFF__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( SWITCH_OFF__DigitalOutput__ + i, SWITCH_OFF[i+1] );
    }
    
    HEATERCOOLER_ON = new InOutArray<DigitalOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        HEATERCOOLER_ON[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( HEATERCOOLER_ON__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( HEATERCOOLER_ON__DigitalOutput__ + i, HEATERCOOLER_ON[i+1] );
    }
    
    HEATERCOOLER_OFF = new InOutArray<DigitalOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        HEATERCOOLER_OFF[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( HEATERCOOLER_OFF__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( HEATERCOOLER_OFF__DigitalOutput__ + i, HEATERCOOLER_OFF[i+1] );
    }
    
    HEATERCOOLERFANSPEED_LOW = new InOutArray<DigitalOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        HEATERCOOLERFANSPEED_LOW[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( HEATERCOOLERFANSPEED_LOW__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( HEATERCOOLERFANSPEED_LOW__DigitalOutput__ + i, HEATERCOOLERFANSPEED_LOW[i+1] );
    }
    
    HEATERCOOLERFANSPEED_MID = new InOutArray<DigitalOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        HEATERCOOLERFANSPEED_MID[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( HEATERCOOLERFANSPEED_MID__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( HEATERCOOLERFANSPEED_MID__DigitalOutput__ + i, HEATERCOOLERFANSPEED_MID[i+1] );
    }
    
    HEATERCOOLERFANSPEED_HIGH = new InOutArray<DigitalOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        HEATERCOOLERFANSPEED_HIGH[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( HEATERCOOLERFANSPEED_HIGH__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( HEATERCOOLERFANSPEED_HIGH__DigitalOutput__ + i, HEATERCOOLERFANSPEED_HIGH[i+1] );
    }
    
    HEATERCOOLER_HEAT = new InOutArray<DigitalOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        HEATERCOOLER_HEAT[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( HEATERCOOLER_HEAT__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( HEATERCOOLER_HEAT__DigitalOutput__ + i, HEATERCOOLER_HEAT[i+1] );
    }
    
    HEATERCOOLER_COOL = new InOutArray<DigitalOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        HEATERCOOLER_COOL[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( HEATERCOOLER_COOL__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( HEATERCOOLER_COOL__DigitalOutput__ + i, HEATERCOOLER_COOL[i+1] );
    }
    
    HEATER_ON = new InOutArray<DigitalOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        HEATER_ON[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( HEATER_ON__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( HEATER_ON__DigitalOutput__ + i, HEATER_ON[i+1] );
    }
    
    HEATER_OFF = new InOutArray<DigitalOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        HEATER_OFF[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( HEATER_OFF__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( HEATER_OFF__DigitalOutput__ + i, HEATER_OFF[i+1] );
    }
    
    COOLER_ON = new InOutArray<DigitalOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        COOLER_ON[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( COOLER_ON__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( COOLER_ON__DigitalOutput__ + i, COOLER_ON[i+1] );
    }
    
    COOLER_OFF = new InOutArray<DigitalOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        COOLER_OFF[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( COOLER_OFF__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( COOLER_OFF__DigitalOutput__ + i, COOLER_OFF[i+1] );
    }
    
    AIRPURIFIER_ON = new InOutArray<DigitalOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        AIRPURIFIER_ON[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( AIRPURIFIER_ON__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( AIRPURIFIER_ON__DigitalOutput__ + i, AIRPURIFIER_ON[i+1] );
    }
    
    AIRPURIFIER_OFF = new InOutArray<DigitalOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        AIRPURIFIER_OFF[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( AIRPURIFIER_OFF__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( AIRPURIFIER_OFF__DigitalOutput__ + i, AIRPURIFIER_OFF[i+1] );
    }
    
    AIRPURIFIER_AUTO = new InOutArray<DigitalOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        AIRPURIFIER_AUTO[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( AIRPURIFIER_AUTO__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( AIRPURIFIER_AUTO__DigitalOutput__ + i, AIRPURIFIER_AUTO[i+1] );
    }
    
    AIRPURIFIER_MANUAL = new InOutArray<DigitalOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        AIRPURIFIER_MANUAL[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( AIRPURIFIER_MANUAL__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( AIRPURIFIER_MANUAL__DigitalOutput__ + i, AIRPURIFIER_MANUAL[i+1] );
    }
    
    AIRPURIFIERFANSPEED_LOW = new InOutArray<DigitalOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        AIRPURIFIERFANSPEED_LOW[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( AIRPURIFIERFANSPEED_LOW__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( AIRPURIFIERFANSPEED_LOW__DigitalOutput__ + i, AIRPURIFIERFANSPEED_LOW[i+1] );
    }
    
    AIRPURIFIERFANSPEED_MID = new InOutArray<DigitalOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        AIRPURIFIERFANSPEED_MID[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( AIRPURIFIERFANSPEED_MID__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( AIRPURIFIERFANSPEED_MID__DigitalOutput__ + i, AIRPURIFIERFANSPEED_MID[i+1] );
    }
    
    AIRPURIFIERFANSPEED_HIGH = new InOutArray<DigitalOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        AIRPURIFIERFANSPEED_HIGH[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( AIRPURIFIERFANSPEED_HIGH__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( AIRPURIFIERFANSPEED_HIGH__DigitalOutput__ + i, AIRPURIFIERFANSPEED_HIGH[i+1] );
    }
    
    DIMLIGHT_BRIGHTNESS = new InOutArray<AnalogInput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        DIMLIGHT_BRIGHTNESS[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( DIMLIGHT_BRIGHTNESS__AnalogSerialInput__ + i, DIMLIGHT_BRIGHTNESS__AnalogSerialInput__, this );
        m_AnalogInputList.Add( DIMLIGHT_BRIGHTNESS__AnalogSerialInput__ + i, DIMLIGHT_BRIGHTNESS[i+1] );
    }
    
    SHADES_POSITION = new InOutArray<AnalogInput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        SHADES_POSITION[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( SHADES_POSITION__AnalogSerialInput__ + i, SHADES_POSITION__AnalogSerialInput__, this );
        m_AnalogInputList.Add( SHADES_POSITION__AnalogSerialInput__ + i, SHADES_POSITION[i+1] );
    }
    
    HEATERCOOLER_GETTARGETTEMPERATURE = new InOutArray<AnalogInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        HEATERCOOLER_GETTARGETTEMPERATURE[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( HEATERCOOLER_GETTARGETTEMPERATURE__AnalogSerialInput__ + i, HEATERCOOLER_GETTARGETTEMPERATURE__AnalogSerialInput__, this );
        m_AnalogInputList.Add( HEATERCOOLER_GETTARGETTEMPERATURE__AnalogSerialInput__ + i, HEATERCOOLER_GETTARGETTEMPERATURE[i+1] );
    }
    
    HEATERCOOLER_GETCURRENTTEMPERATURE = new InOutArray<AnalogInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        HEATERCOOLER_GETCURRENTTEMPERATURE[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( HEATERCOOLER_GETCURRENTTEMPERATURE__AnalogSerialInput__ + i, HEATERCOOLER_GETCURRENTTEMPERATURE__AnalogSerialInput__, this );
        m_AnalogInputList.Add( HEATERCOOLER_GETCURRENTTEMPERATURE__AnalogSerialInput__ + i, HEATERCOOLER_GETCURRENTTEMPERATURE[i+1] );
    }
    
    HEATER_GETTARGETTEMPERATURE = new InOutArray<AnalogInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        HEATER_GETTARGETTEMPERATURE[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( HEATER_GETTARGETTEMPERATURE__AnalogSerialInput__ + i, HEATER_GETTARGETTEMPERATURE__AnalogSerialInput__, this );
        m_AnalogInputList.Add( HEATER_GETTARGETTEMPERATURE__AnalogSerialInput__ + i, HEATER_GETTARGETTEMPERATURE[i+1] );
    }
    
    HEATER_GETCURRENTTEMPERATURE = new InOutArray<AnalogInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        HEATER_GETCURRENTTEMPERATURE[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( HEATER_GETCURRENTTEMPERATURE__AnalogSerialInput__ + i, HEATER_GETCURRENTTEMPERATURE__AnalogSerialInput__, this );
        m_AnalogInputList.Add( HEATER_GETCURRENTTEMPERATURE__AnalogSerialInput__ + i, HEATER_GETCURRENTTEMPERATURE[i+1] );
    }
    
    COOLER_GETTARGETTEMPERATURE = new InOutArray<AnalogInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        COOLER_GETTARGETTEMPERATURE[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( COOLER_GETTARGETTEMPERATURE__AnalogSerialInput__ + i, COOLER_GETTARGETTEMPERATURE__AnalogSerialInput__, this );
        m_AnalogInputList.Add( COOLER_GETTARGETTEMPERATURE__AnalogSerialInput__ + i, COOLER_GETTARGETTEMPERATURE[i+1] );
    }
    
    COOLER_GETCURRENTTEMPERATURE = new InOutArray<AnalogInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        COOLER_GETCURRENTTEMPERATURE[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( COOLER_GETCURRENTTEMPERATURE__AnalogSerialInput__ + i, COOLER_GETCURRENTTEMPERATURE__AnalogSerialInput__, this );
        m_AnalogInputList.Add( COOLER_GETCURRENTTEMPERATURE__AnalogSerialInput__ + i, COOLER_GETCURRENTTEMPERATURE[i+1] );
    }
    
    AIRPURIFIER_FILTERMAINTENANCE_STATUS = new InOutArray<AnalogInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        AIRPURIFIER_FILTERMAINTENANCE_STATUS[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( AIRPURIFIER_FILTERMAINTENANCE_STATUS__AnalogSerialInput__ + i, AIRPURIFIER_FILTERMAINTENANCE_STATUS__AnalogSerialInput__, this );
        m_AnalogInputList.Add( AIRPURIFIER_FILTERMAINTENANCE_STATUS__AnalogSerialInput__ + i, AIRPURIFIER_FILTERMAINTENANCE_STATUS[i+1] );
    }
    
    LIGHTSENSOR_STATUS = new InOutArray<AnalogInput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        LIGHTSENSOR_STATUS[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( LIGHTSENSOR_STATUS__AnalogSerialInput__ + i, LIGHTSENSOR_STATUS__AnalogSerialInput__, this );
        m_AnalogInputList.Add( LIGHTSENSOR_STATUS__AnalogSerialInput__ + i, LIGHTSENSOR_STATUS[i+1] );
    }
    
    GET_PM2_5VALUE = new InOutArray<AnalogInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        GET_PM2_5VALUE[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( GET_PM2_5VALUE__AnalogSerialInput__ + i, GET_PM2_5VALUE__AnalogSerialInput__, this );
        m_AnalogInputList.Add( GET_PM2_5VALUE__AnalogSerialInput__ + i, GET_PM2_5VALUE[i+1] );
    }
    
    GET_VOC_VALUE = new InOutArray<AnalogInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        GET_VOC_VALUE[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( GET_VOC_VALUE__AnalogSerialInput__ + i, GET_VOC_VALUE__AnalogSerialInput__, this );
        m_AnalogInputList.Add( GET_VOC_VALUE__AnalogSerialInput__ + i, GET_VOC_VALUE[i+1] );
    }
    
    GET_CO2 = new InOutArray<AnalogInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        GET_CO2[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( GET_CO2__AnalogSerialInput__ + i, GET_CO2__AnalogSerialInput__, this );
        m_AnalogInputList.Add( GET_CO2__AnalogSerialInput__ + i, GET_CO2[i+1] );
    }
    
    GET_HUMIDITY = new InOutArray<AnalogInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        GET_HUMIDITY[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( GET_HUMIDITY__AnalogSerialInput__ + i, GET_HUMIDITY__AnalogSerialInput__, this );
        m_AnalogInputList.Add( GET_HUMIDITY__AnalogSerialInput__ + i, GET_HUMIDITY[i+1] );
    }
    
    GET_TEMPERATURE = new InOutArray<AnalogInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        GET_TEMPERATURE[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( GET_TEMPERATURE__AnalogSerialInput__ + i, GET_TEMPERATURE__AnalogSerialInput__, this );
        m_AnalogInputList.Add( GET_TEMPERATURE__AnalogSerialInput__ + i, GET_TEMPERATURE[i+1] );
    }
    
    DIMLIGHT_SET = new InOutArray<AnalogOutput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        DIMLIGHT_SET[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( DIMLIGHT_SET__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( DIMLIGHT_SET__AnalogSerialOutput__ + i, DIMLIGHT_SET[i+1] );
    }
    
    SHADES_SET = new InOutArray<AnalogOutput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        SHADES_SET[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( SHADES_SET__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( SHADES_SET__AnalogSerialOutput__ + i, SHADES_SET[i+1] );
    }
    
    HEATERCOOLER_SETTEMPERATURE = new InOutArray<AnalogOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        HEATERCOOLER_SETTEMPERATURE[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( HEATERCOOLER_SETTEMPERATURE__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( HEATERCOOLER_SETTEMPERATURE__AnalogSerialOutput__ + i, HEATERCOOLER_SETTEMPERATURE[i+1] );
    }
    
    HEATER_SETTEMPERATURE = new InOutArray<AnalogOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        HEATER_SETTEMPERATURE[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( HEATER_SETTEMPERATURE__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( HEATER_SETTEMPERATURE__AnalogSerialOutput__ + i, HEATER_SETTEMPERATURE[i+1] );
    }
    
    COOLER_SETTEMPERATURE = new InOutArray<AnalogOutput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        COOLER_SETTEMPERATURE[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( COOLER_SETTEMPERATURE__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( COOLER_SETTEMPERATURE__AnalogSerialOutput__ + i, COOLER_SETTEMPERATURE[i+1] );
    }
    
    PORT = new UShortParameter( PORT__Parameter__, this );
    m_ParameterList.Add( PORT__Parameter__, PORT );
    
    IPADDR__DOLLAR__ = new StringParameter( IPADDR__DOLLAR____Parameter__, this );
    m_ParameterList.Add( IPADDR__DOLLAR____Parameter__, IPADDR__DOLLAR__ );
    
    
    for( uint i = 0; i < 10; i++ )
        LIGHTS_STATUS[i+1].OnDigitalChange.Add( new InputChangeHandlerWrapper( LIGHTS_STATUS_OnChange_0, false ) );
        
    for( uint i = 0; i < 10; i++ )
        SWITCH_STATUS[i+1].OnDigitalChange.Add( new InputChangeHandlerWrapper( SWITCH_STATUS_OnChange_1, false ) );
        
    for( uint i = 0; i < 10; i++ )
        TV_POWER_STATUS[i+1].OnDigitalChange.Add( new InputChangeHandlerWrapper( TV_POWER_STATUS_OnChange_2, false ) );
        
    for( uint i = 0; i < 2; i++ )
        CONTACTSENSOR_STATUS[i+1].OnDigitalChange.Add( new InputChangeHandlerWrapper( CONTACTSENSOR_STATUS_OnChange_3, false ) );
        
    for( uint i = 0; i < 2; i++ )
        SMOKESENSOR_STATUS[i+1].OnDigitalChange.Add( new InputChangeHandlerWrapper( SMOKESENSOR_STATUS_OnChange_4, false ) );
        
    for( uint i = 0; i < 2; i++ )
        OCCUPANCYSENSOR_STATUS[i+1].OnDigitalChange.Add( new InputChangeHandlerWrapper( OCCUPANCYSENSOR_STATUS_OnChange_5, false ) );
        
    for( uint i = 0; i < 2; i++ )
        MOTIONSENSOR_STATUS[i+1].OnDigitalChange.Add( new InputChangeHandlerWrapper( MOTIONSENSOR_STATUS_OnChange_6, false ) );
        
    for( uint i = 0; i < 2; i++ )
        LEAKSENSOR_STATUS[i+1].OnDigitalChange.Add( new InputChangeHandlerWrapper( LEAKSENSOR_STATUS_OnChange_7, false ) );
        
    for( uint i = 0; i < 5; i++ )
        LIGHTSENSOR_STATUS[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( LIGHTSENSOR_STATUS_OnChange_8, false ) );
        
    for( uint i = 0; i < 5; i++ )
        SHADES_POSITION[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( SHADES_POSITION_OnChange_9, false ) );
        
    for( uint i = 0; i < 5; i++ )
        DIMLIGHT_BRIGHTNESS[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( DIMLIGHT_BRIGHTNESS_OnChange_10, false ) );
        
    for( uint i = 0; i < 2; i++ )
        HEATER_ONSTATUS[i+1].OnDigitalChange.Add( new InputChangeHandlerWrapper( HEATER_ONSTATUS_OnChange_11, false ) );
        
    for( uint i = 0; i < 2; i++ )
        HEATERCOOLER_ONSTATUS[i+1].OnDigitalChange.Add( new InputChangeHandlerWrapper( HEATERCOOLER_ONSTATUS_OnChange_12, false ) );
        
    for( uint i = 0; i < 2; i++ )
        HEATERCOOLERFANSPEED_LOWSTATUS[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( HEATERCOOLERFANSPEED_LOWSTATUS_OnPush_13, false ) );
        
    for( uint i = 0; i < 2; i++ )
        HEATERCOOLERFANSPEED_MIDSTATUS[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( HEATERCOOLERFANSPEED_MIDSTATUS_OnPush_14, false ) );
        
    for( uint i = 0; i < 2; i++ )
        HEATERCOOLERFANSPEED_HIGHSTATUS[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( HEATERCOOLERFANSPEED_HIGHSTATUS_OnPush_15, false ) );
        
    for( uint i = 0; i < 2; i++ )
        HEATERCOOLER_HEATSTATUS[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( HEATERCOOLER_HEATSTATUS_OnPush_16, false ) );
        
    for( uint i = 0; i < 2; i++ )
        HEATERCOOLER_COOLSTATUS[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( HEATERCOOLER_COOLSTATUS_OnPush_17, false ) );
        
    for( uint i = 0; i < 2; i++ )
        HEATERCOOLER_GETCURRENTTEMPERATURE[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( HEATERCOOLER_GETCURRENTTEMPERATURE_OnChange_18, false ) );
        
    for( uint i = 0; i < 2; i++ )
        HEATERCOOLER_GETTARGETTEMPERATURE[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( HEATERCOOLER_GETTARGETTEMPERATURE_OnChange_19, false ) );
        
    for( uint i = 0; i < 2; i++ )
        HEATER_GETTARGETTEMPERATURE[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( HEATER_GETTARGETTEMPERATURE_OnChange_20, false ) );
        
    for( uint i = 0; i < 2; i++ )
        HEATER_GETCURRENTTEMPERATURE[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( HEATER_GETCURRENTTEMPERATURE_OnChange_21, false ) );
        
    for( uint i = 0; i < 2; i++ )
        AIRPURIFIER_FILTERMAINTENANCE_STATUS[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( AIRPURIFIER_FILTERMAINTENANCE_STATUS_OnChange_22, false ) );
        
    for( uint i = 0; i < 2; i++ )
        AIRPURIFIER_ONSTATUS[i+1].OnDigitalChange.Add( new InputChangeHandlerWrapper( AIRPURIFIER_ONSTATUS_OnChange_23, false ) );
        
    for( uint i = 0; i < 2; i++ )
        AIRPURIFIER_AUTOSTATUS[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( AIRPURIFIER_AUTOSTATUS_OnPush_24, false ) );
        
    for( uint i = 0; i < 2; i++ )
        AIRPURIFIER_MANUALSTATUS[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( AIRPURIFIER_MANUALSTATUS_OnPush_25, false ) );
        
    for( uint i = 0; i < 2; i++ )
        AIRPURIFIERFANSPEED_LOWSTATUS[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( AIRPURIFIERFANSPEED_LOWSTATUS_OnPush_26, false ) );
        
    for( uint i = 0; i < 2; i++ )
        AIRPURIFIERFANSPEED_MIDSTATUS[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( AIRPURIFIERFANSPEED_MIDSTATUS_OnPush_27, false ) );
        
    for( uint i = 0; i < 2; i++ )
        AIRPURIFIERFANSPEED_HIGHSTATUS[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( AIRPURIFIERFANSPEED_HIGHSTATUS_OnPush_28, false ) );
        
    for( uint i = 0; i < 2; i++ )
        GET_PM2_5VALUE[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( GET_PM2_5VALUE_OnChange_29, false ) );
        
    for( uint i = 0; i < 2; i++ )
        GET_VOC_VALUE[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( GET_VOC_VALUE_OnChange_30, false ) );
        
    for( uint i = 0; i < 2; i++ )
        GET_CO2[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( GET_CO2_OnChange_31, false ) );
        
    for( uint i = 0; i < 2; i++ )
        GET_HUMIDITY[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( GET_HUMIDITY_OnChange_32, false ) );
        
    for( uint i = 0; i < 2; i++ )
        GET_TEMPERATURE[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( GET_TEMPERATURE_OnChange_33, false ) );
        
    for( uint i = 0; i < 2; i++ )
        COOLER_ONSTATUS[i+1].OnDigitalChange.Add( new InputChangeHandlerWrapper( COOLER_ONSTATUS_OnChange_34, false ) );
        
    for( uint i = 0; i < 2; i++ )
        COOLER_GETTARGETTEMPERATURE[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( COOLER_GETTARGETTEMPERATURE_OnChange_35, false ) );
        
    for( uint i = 0; i < 2; i++ )
        COOLER_GETCURRENTTEMPERATURE[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( COOLER_GETCURRENTTEMPERATURE_OnChange_36, false ) );
        
    MYSERVER.OnSocketConnect.Add( new SocketHandlerWrapper( MYSERVER_OnSocketConnect_37, false ) );
    MYSERVER.OnSocketDisconnect.Add( new SocketHandlerWrapper( MYSERVER_OnSocketDisconnect_38, false ) );
    MYSERVER.OnSocketStatus.Add( new SocketHandlerWrapper( MYSERVER_OnSocketStatus_39, false ) );
    MYSERVER.OnSocketReceive.Add( new SocketHandlerWrapper( MYSERVER_OnSocketReceive_40, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_HOMEKIT_CRESTRON ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint IPADDR__DOLLAR____Parameter__ = 10;
const uint PORT__Parameter__ = 11;
const uint TV_POWER_STATUS__DigitalInput__ = 0;
const uint LIGHTS_STATUS__DigitalInput__ = 10;
const uint SWITCH_STATUS__DigitalInput__ = 20;
const uint HEATERCOOLER_ONSTATUS__DigitalInput__ = 30;
const uint HEATERCOOLER_OFFSTATUS__DigitalInput__ = 32;
const uint HEATERCOOLERFANSPEED_LOWSTATUS__DigitalInput__ = 34;
const uint HEATERCOOLERFANSPEED_MIDSTATUS__DigitalInput__ = 36;
const uint HEATERCOOLERFANSPEED_HIGHSTATUS__DigitalInput__ = 38;
const uint HEATERCOOLER_HEATSTATUS__DigitalInput__ = 40;
const uint HEATERCOOLER_COOLSTATUS__DigitalInput__ = 42;
const uint HEATER_ONSTATUS__DigitalInput__ = 44;
const uint HEATER_OFFSTATUS__DigitalInput__ = 46;
const uint COOLER_ONSTATUS__DigitalInput__ = 48;
const uint COOLER_OFFSTATUS__DigitalInput__ = 50;
const uint AIRPURIFIER_ONSTATUS__DigitalInput__ = 52;
const uint AIRPURIFIER_OFFSTATUS__DigitalInput__ = 54;
const uint AIRPURIFIER_AUTOSTATUS__DigitalInput__ = 56;
const uint AIRPURIFIER_MANUALSTATUS__DigitalInput__ = 58;
const uint AIRPURIFIERFANSPEED_LOWSTATUS__DigitalInput__ = 60;
const uint AIRPURIFIERFANSPEED_MIDSTATUS__DigitalInput__ = 62;
const uint AIRPURIFIERFANSPEED_HIGHSTATUS__DigitalInput__ = 64;
const uint CONTACTSENSOR_STATUS__DigitalInput__ = 66;
const uint SMOKESENSOR_STATUS__DigitalInput__ = 68;
const uint OCCUPANCYSENSOR_STATUS__DigitalInput__ = 70;
const uint MOTIONSENSOR_STATUS__DigitalInput__ = 72;
const uint LEAKSENSOR_STATUS__DigitalInput__ = 74;
const uint DIMLIGHT_BRIGHTNESS__AnalogSerialInput__ = 0;
const uint SHADES_POSITION__AnalogSerialInput__ = 5;
const uint HEATERCOOLER_GETTARGETTEMPERATURE__AnalogSerialInput__ = 10;
const uint HEATERCOOLER_GETCURRENTTEMPERATURE__AnalogSerialInput__ = 12;
const uint HEATER_GETTARGETTEMPERATURE__AnalogSerialInput__ = 14;
const uint HEATER_GETCURRENTTEMPERATURE__AnalogSerialInput__ = 16;
const uint COOLER_GETTARGETTEMPERATURE__AnalogSerialInput__ = 18;
const uint COOLER_GETCURRENTTEMPERATURE__AnalogSerialInput__ = 20;
const uint AIRPURIFIER_FILTERMAINTENANCE_STATUS__AnalogSerialInput__ = 22;
const uint LIGHTSENSOR_STATUS__AnalogSerialInput__ = 24;
const uint GET_PM2_5VALUE__AnalogSerialInput__ = 29;
const uint GET_VOC_VALUE__AnalogSerialInput__ = 31;
const uint GET_CO2__AnalogSerialInput__ = 33;
const uint GET_HUMIDITY__AnalogSerialInput__ = 35;
const uint GET_TEMPERATURE__AnalogSerialInput__ = 37;
const uint TV_ON__DigitalOutput__ = 0;
const uint TV_OFF__DigitalOutput__ = 10;
const uint LIGHTS_ON__DigitalOutput__ = 20;
const uint LIGHTS_OFF__DigitalOutput__ = 30;
const uint SWITCH_ON__DigitalOutput__ = 40;
const uint SWITCH_OFF__DigitalOutput__ = 50;
const uint HEATERCOOLER_ON__DigitalOutput__ = 60;
const uint HEATERCOOLER_OFF__DigitalOutput__ = 62;
const uint HEATERCOOLERFANSPEED_LOW__DigitalOutput__ = 64;
const uint HEATERCOOLERFANSPEED_MID__DigitalOutput__ = 66;
const uint HEATERCOOLERFANSPEED_HIGH__DigitalOutput__ = 68;
const uint HEATERCOOLER_HEAT__DigitalOutput__ = 70;
const uint HEATERCOOLER_COOL__DigitalOutput__ = 72;
const uint HEATER_ON__DigitalOutput__ = 74;
const uint HEATER_OFF__DigitalOutput__ = 76;
const uint COOLER_ON__DigitalOutput__ = 78;
const uint COOLER_OFF__DigitalOutput__ = 80;
const uint AIRPURIFIER_ON__DigitalOutput__ = 82;
const uint AIRPURIFIER_OFF__DigitalOutput__ = 84;
const uint AIRPURIFIER_AUTO__DigitalOutput__ = 86;
const uint AIRPURIFIER_MANUAL__DigitalOutput__ = 88;
const uint AIRPURIFIERFANSPEED_LOW__DigitalOutput__ = 90;
const uint AIRPURIFIERFANSPEED_MID__DigitalOutput__ = 92;
const uint AIRPURIFIERFANSPEED_HIGH__DigitalOutput__ = 94;
const uint DIMLIGHT_SET__AnalogSerialOutput__ = 0;
const uint SHADES_SET__AnalogSerialOutput__ = 5;
const uint HEATERCOOLER_SETTEMPERATURE__AnalogSerialOutput__ = 10;
const uint HEATER_SETTEMPERATURE__AnalogSerialOutput__ = 12;
const uint COOLER_SETTEMPERATURE__AnalogSerialOutput__ = 14;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    
}

SplusNVRAM _SplusNVRAM = null;

public class __CEvent__ : CEvent
{
    public __CEvent__() {}
    public void Close() { base.Close(); }
    public int Reset() { return base.Reset() ? 1 : 0; }
    public int Set() { return base.Set() ? 1 : 0; }
    public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
}
public class __CMutex__ : CMutex
{
    public __CMutex__() {}
    public void Close() { base.Close(); }
    public void ReleaseMutex() { base.ReleaseMutex(); }
    public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
}
 public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
