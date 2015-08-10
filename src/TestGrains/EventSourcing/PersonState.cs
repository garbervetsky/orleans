﻿/*
Project Orleans Cloud Service SDK ver. 1.0
 
Copyright (c) Microsoft Corporation
 
All rights reserved.
 
MIT License

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and 
associated documentation files (the ""Software""), to deal in the Software without restriction,
including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense,
and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED *AS IS*, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO
THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS
OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using Orleans.EventSourcing;
using TestGrainInterfaces;

namespace TestGrains
{
    public class PersonState : JournaledGrainState
    {
        public PersonState()
            : base(typeof(PersonState))
        { }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderType Gender { get; set; }

        public override void ApplyEvent(StateEvent @event)
        {
            if (@event is PersonRegistered)
                Apply(@event as PersonRegistered);
            else if (@event is PersonMarried)
                Apply(@event as PersonMarried);
            else if (@event is PersonLastNameChanged)
                Apply(@event as PersonLastNameChanged);
            else
                throw new ArgumentException(String.Format("Unsupported event of type {0}", @event.GetType().FullName));
        }

        public void Apply(PersonRegistered registered)
        {
            FirstName = registered.FirstName;
            LastName = registered.LastName;
            Gender = registered. Gender;
        }

        public void Apply(PersonMarried married)
        {
            // TODO
        }

        public void Apply(PersonLastNameChanged lnChanged)
        {
            LastName = lnChanged.LastName;
        }
    }
}