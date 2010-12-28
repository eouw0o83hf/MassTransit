﻿// Copyright 2007-2010 The Apache Software Foundation.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace MassTransit.Configuration
{
    using System;
    using Serialization;

    public interface BusConfiguration
    {
        void ReceiveFrom(string uriString);
        void ReceiveFrom(Uri uri);
        void SendErrorsTo(string uriString);
        void SendErrorsTo(Uri uri);

        //TODO: I may have to move these around
        void RegisterTransport<TTransport>() where TTransport : IEndpoint;
        void RegisterTransport(Type transportType);

        //serialization. should it be a sub thingy?
        //this maynot be able to be here?
        void UseDotNetXmlSerilaizer();
        void UseJsonSerializer();
        void UseXmlSerializer();
        void UseBinarySerializer();
        void UseCustomSerializer<TSerializer>() where TSerializer : IMessageSerializer;

        void ConfigureService<TService>(Action<TService> configure) where TService : IServiceConfigurator, new();

        void DisableAutoStart();
        void EnableAutoSubscribe();

        void Advanced(Action<AdvancedConfiguration> advCfg);
        ////// advanced settings
        // saga persistors?
        // subscription repo
    }
}