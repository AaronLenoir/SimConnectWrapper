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
        /// A direct reference to he Microsoft.FlightSimulator.SimConnect.SimConnect object
        /// </summary>
        SimConnect Sim { get; }

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
    }
}
