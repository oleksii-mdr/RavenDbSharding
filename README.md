RavenDbSharding
===============

This sample project demonstrates sharding technique with RavenDB. It contains source code and three RavenDB servers (binaries only) which store data in-memory. Every restart of the servers clears the databases.

This sample uses RavenDB servers from the build 800 which is available from
http://builds.hibernatingrhinos.com/builds/RavenDB

Config file of every server has been modified to use specific IP (127.0.0.1), ports (8081-8083) and hold data in-memory. Also anonymous user has ALL access rights.
        
---------
To see it working you can

1. Start RavenDB servers, you can do so by running a cmd file
   \tools\RavenDB-Build-800\Just-Servers\Start.cmd
   This shall open three console application, one for each RavenDB server

2. [a] Either open solution in Visual Studio 2010 and run the project     
        or
   [b] Run the binary client directly from \bin\RavenDbSharding.exe

3. Take a look at the RavenDB servers to see which request goes to which server.
   Users are stored on the following shards:
      Users with id 1 - 10 are stored in shard "user_1_10"
      Users with id 11 - 20 are stored in shard "user_10_20"
      Users with id 21 - 30 are stored in shard "user_20_30"

For more details see my post: http://blog4work.com/post/2012/04/20/Sharding-with-RavenDB.aspx