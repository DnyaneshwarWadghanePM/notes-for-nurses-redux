﻿// -----------------------------------------------------------------------
// <copyright file="SessionContextTests.cs">
// Copyright Edward Wilde (c) 2013.
// </copyright>
// -----------------------------------------------------------------------


using System;

using Machine.Fakes;
using Machine.Specifications;

namespace core.net.tests.Service
{
    using Edward.Wilde.Note.For.Nurses.Core.Data;
    using Edward.Wilde.Note.For.Nurses.Core.Model;
    using Edward.Wilde.Note.For.Nurses.Core.Service;

    [Subject(typeof(SessionContext))]
    public class When_the_session_context_is_initialized : WithConcreteSubject<SessionContext, ISessionContext>
    {
        Because of = () => Subject.Initialize();        
    }
}