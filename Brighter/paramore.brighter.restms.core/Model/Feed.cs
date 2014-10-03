﻿#region Licence
/* The MIT License (MIT)
Copyright © 2014 Ian Cooper <ian_hammond_cooper@yahoo.co.uk>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the “Software”), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE. */
#endregion

using System;
using paramore.brighter.restms.core.Ports.Common;

namespace paramore.brighter.restms.core.Model
{
    public class Feed : Resource, IAmAnAggregate
    {
        public Feed(Name name, FeedType feedType = FeedType.Direct, Title title = null, Name license = null)
        {
            Type = feedType;
            Name = name;
            Title = title;
            License = license;
            Version = new AggregateVersion(0);
            Href = new Uri(string.Format("http://{0}/restms/feed/{1}", Globals.HostName,Name.Value));
        }

        public Feed(Name name, AggregateVersion version, FeedType feedType = FeedType.Direct, Title title = null, Name license = null)
            : this(name, feedType, title, license)
        {
            Version = version;
        }

        public FeedType Type { get; private set; }
        public Title Title { get; private set; }
        public Name License { get; private set; }

        public Identity Id
        {
            get {return new Identity(Name.Value); }
        }
        public AggregateVersion Version { get; private set; }

    }
}