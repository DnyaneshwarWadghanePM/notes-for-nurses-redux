﻿// -----------------------------------------------------------------------
// <copyright file="LocationTests.cs">
// Copyright Edward Wilde (c) 2013.
// </copyright>
// -----------------------------------------------------------------------
namespace core.net.tests.Service
{
    using System.Diagnostics;

    using Edward.Wilde.Note.For.Nurses.Core.Model;
    using Edward.Wilde.Note.For.Nurses.Core.Service;

    using Machine.Fakes;
    using Machine.Specifications;

    using core.net.tests.TestData;

    [Subject(typeof(Location), "distance calculations")]
    public class when_calculating_the_distance_between_two_coordinates : WithSubjectAndResult<Location, double>
    {
        static Location london;

        static Location paris;

        Establish context = () =>
            {
                Subject.Coordinate = new LocationCoordinate(51.500288, -0.126269);
                london = Subject;
                paris = Resolve<Location>();
                paris.Coordinate = new LocationCoordinate(48.856495, 2.350907);
            };

        Because of = () =>
            {
                Result = london - paris;                 
            };

        It should_call_the_distance_calculator_service_to_work_out_the_distance_between_locations
            = () => Location.DistanceCalculator.WasToldTo(call => call.DistanceBetween(Param<LocationCoordinate>.IsAnything, Param<LocationCoordinate>.IsAnything));
    }
} 