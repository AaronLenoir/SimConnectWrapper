using Microsoft.FlightSimulator.SimConnect;
using System;
using System.Collections.Generic;

namespace SimConnectWrapper
{
    public interface ISimConnectWrapper
    {
        /// <summary>
        /// Will be true if the connection to SimConnect was not succesful
        /// </summary>
        bool HasError { get; }

        /// <summary>
        /// Will contain the latest observed error if <see cref="HasError"/> is true
        /// </summary>
        /// <remarks>If no error occured this will be null</remarks>
        Exception LatestError { get; }

        /// <summary>
        /// If an error occurs, this event will be raised
        /// </summary>
        event EventHandler<Exception> OnError;

        /// <summary>
        /// The last time any kind of data was received from SimConnect
        /// </summary>
        /// <remarks>The data itself can be found in <see cref="LatestData"/></remarks>
        DateTime LastDataReceivedOn { get; }

        /// <summary>
        /// The latest data received from SimConnect
        /// </summary>
        /// <remarks>If nothing has been received for a property you are subscribed to you will find an Empty <see cref="SimConnectPropertyValue"/></remarks>
        Dictionary<SimConnectProperty, SimConnectPropertyValue> LatestData { get; }

        /// <summary>
        /// SimConnect properties that have been subscribed to
        /// </summary>
        IEnumerable<SimConnectProperty> Subscriptions { get; }

        /// <summary>
        /// A direct reference to he Microsoft.FlightSimulator.SimConnect.SimConnect object
        /// </summary>
        SimConnect Sim { get; }

        /// <summary>
        /// Defines the interval by which a connection attempt to SimConnect is attempted
        /// </summary>
        /// <remarks>If set to 0, no polling is done for a connection and </remarks>
        int ConnectionPollingInterval { get; set; }

        /// <summary>
        /// Defines the interval by which data is requested from SimConnect
        /// </summary>
        /// <remarks>If set to 0, no polling is done for data and GetData should be called manually</remarks>
        int DataPollingInterval { get; set; }

        /// <summary>
        /// Starts listening to SimConnect, as soon as possible
        /// </summary>
        void Connect();

        /// <summary>
        /// Must be called to retrieve messages from SimConnect
        /// </summary>
        void ReceiveMessage();

        /// <summary>
        /// Subscribe to a SimConnect property
        /// </summary>
        /// <param name="property">The property to subscribe to</param>
        void Subscribe(SimConnectProperty property);

        /// <summary>
        /// Subscribe to one or more SimConnect properties
        /// </summary>
        /// <param name="properties">The properties to subscribe to</param>
        void Subscribe(IEnumerable<SimConnectProperty> properties);

        /// <summary>
        /// Tries to initialize a connection with SimConnect
        /// </summary>
        /// <remarks>Should only be called manually if ConnectionPollingInterval is 0 (no polling)</remarks>
        void PollConnection();

        /// <summary>
        /// Requests data from SimConnect for all Subscriptions
        /// </summary>
        /// <remarks>Should only be called manually if DataPollingInterval is 0 (no polling)</remarks>
        void PollData();
    }
}
