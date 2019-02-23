// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

// This application uses the Azure IoT Hub device SDK for .NET
// For samples see: https://github.com/Azure/azure-iot-sdk-csharp/tree/master/iothub/device/samples

using System;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace simulated_device
{
    class SimulatedDevice
    {

        private static DeviceClient s_deviceClient;

        // The device connection string to authenticate the device with your IoT hub.
        // Using the Azure CLI:
        // az iot hub device-identity show-connection-string --hub-name {YourIoTHubName} --device-id MyDotnetDevice --output table
        private readonly static string s_connectionString = "HostName=digitalCar.azure-devices.net;DeviceId=prueba;SharedAccessKey=nPh5ND6bMSw20CQwb3PfnCfL4hVP+2dcC6/KLrlGqU0=";


        // Async method to send simulated telemetry
        private static async void SendDeviceToCloudMessagesAsync()
        {
            // Initial telemetry values
            double minTemperature = 20;
            double minHumidity = 60;
            Random rand = new Random();

            while (true)
            {
                double currentTemperature = minTemperature + rand.NextDouble() * 15;
                double currentHumidity = minHumidity + rand.NextDouble() * 20;
           
                // Create JSON message
                // 
                // 
                // 
                // 
                
               var f=new  {
                        TripId= "f9d72f22-654c-44d8-aa71-102d8ab94bfd",
                        Lat= -12.0925866,
                        Lon= -77.0258867,
                        Speed= 12,
                        RecordedTimeStamp= "2018-07-27T22:01:11.9992370Z",
                        Sequence= 13,
                        EngineRPM= 305,
                        ShortTermFuelBank1= -76,
                        LongTermFuelBank1= -76,
                        ThrottlePosition= 12,
                        RelativeThrottlePosition= 12,
                        Runtime= 52,
                        DistancewithMIL= 2,
                        EngineLoad= 12,
                        MAFFlowRate= 6,
                        EngineFuelRate= 8.73227093961661,
                        VIN= "SIMULATORANDROID1",
                        IsSimulated= 1,
                        TripPointId= "5a776f84-7bd5-4761-9bb2-614fcc2aa37d"
                      };
/*
                   var io=new {
                        MessageId= "",
                        CorrelationId="",
                        ConnectionDeviceId= "driving",
                        ConnectionDeviceGenerationId= "636683185044744993",
                        EnqueuedTime= "2018-07-27T22:01:11.5470000Z",
                        StreamId= ""
                      }   ;*/
             /*   var telemetryDataPoint = new 
                {
                      TripId= "f9d72f22-654c-44d8-aa71-102d8ab94bfd",
                      UserId= "1",
                      //TripDataPoint=JsonConvert.SerializeObject(f),
                      EventProcessedUtcTime= "2018-07-27T22:01:11.6334088Z",
                      PartitionId= 0,
                      EventEnqueuedUtcTime= "2018-07-27T22:01:11.5410000Z",
                    //  IoTHub=JsonConvert.SerializeObject(io)
                    };*/
                var messageString = JsonConvert.SerializeObject(f);
                var message = new Message(Encoding.ASCII.GetBytes(messageString));

                // Add a custom application property to the message.
                // An IoT hub can filter on these properties without access to the message body.
                message.Properties.Add("temperatureAlert", (currentTemperature > 30) ? "true" : "false");

                // Send the tlemetry message
                await s_deviceClient.SendEventAsync(message);
                Console.WriteLine("{0} > Sending message: {1}",DateTime.Now,messageString);

                await Task.Delay(1000);
            }
        }
        private static void Main(string[] args)
        {
            Console.WriteLine("IoT Hub Quickstarts #1 - Simulated device. Ctrl-C to exit.\n");

            // Connect to the IoT hub using the MQTT protocol
            s_deviceClient = DeviceClient.CreateFromConnectionString(s_connectionString, TransportType.Mqtt);
            SendDeviceToCloudMessagesAsync();
            Console.ReadLine();
        }
    }
}
