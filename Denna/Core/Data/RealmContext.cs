﻿using Realms;
using Realms.Sync;
using System;

namespace Core.Data
{
    public static class RealmContext
    {
        public static Realm Instance;
        public static void Initialize()
        {
            var configuration = new SyncConfiguration(User.Current, new Uri("~/myRealm", UriKind.Relative));
            Instance = Realm.GetInstance(configuration);
        }

        public static void InitializeLocal() => Instance = Realm.GetInstance();
    }
}