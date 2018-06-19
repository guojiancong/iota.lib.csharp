﻿using System;
using Iota.Api;
using Iota.MAM.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iota.MAM.Tests.Core
{
    [TestClass]
    public class MamTest
    {
        [TestMethod]
        public void PublishPublicTest()
        {
            var iota = new IotaApi("node.iotawallet.info", 14265);
            var mam = new Mam(iota);
            string seed = "CNHIRWBWVPDBGHKYZDJEZVIRDBSEDTCRBESFXOGRSWWDQVRNQATQUKIVDUDINJKKNCULQFCWWIG9LAEHQ";

            var mamState = mam.InitMamState(seed, 2);
            // Create MAM Payload
            var mamMessage = mam.CreateMamMessage(mamState, "POTATO");

            Console.WriteLine($"Root: {mamMessage.Root}");
            Console.WriteLine($"Address: {mamMessage.Address}");

            mam.Attach(mamMessage.Payload, mamMessage.Address);

            // Fetch Stream Async to Test
            var result = mam.Fetch(mamMessage.Root, MamMode.Public);

            Console.WriteLine("Fetch result:");
            foreach (var message in result.Item1)
            {
                Console.WriteLine(message);
            }

            Console.WriteLine($"NextRoot:{result.Item2}");

        }

        [TestMethod]
        public void SingleLeafTree()
        {
            var iota = new IotaApi("node.iotawallet.info", 14265);
            var mam = new Mam(iota);
            string seed = "TX9XRR9SRCOBMTYDTMKNEIJCSZIMEUPWCNLC9DPDZKKAEMEFVSTEVUFTRUZXEHLULEIYJIEOWIC9STAHW";
            string message = "POTATO";

            var mamState = mam.InitMamState(seed, 1);
            mamState.Channel.Security = 1;
            mamState.Channel.Start = 0;
            mamState.Channel.Count = 1;
            mamState.Channel.NextCount = 1;

            var mamMessage = mam.CreateMamMessage(mamState, message);

            // parse
            var unmaskedMessage =
                mam.DecodeMessage(mamMessage.Payload,
                    mamMessage.State.Channel.SideKey,
                    mamMessage.Root);

            // compare
            Assert.AreEqual(message, unmaskedMessage.Item1);
        }
    }
}
