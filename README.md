# Sample of Dolittle from the ground up

Documentation for Dolittle can be found [here](https://dolittle.io).
Presentation can be found [here](https://1drv.ms/p/s!AhD7O7za4wxGgcV7820oWophkxSpJA).

## Application

The application consists of 2 microservices; MyBC1 and MyBC2. They are configured as follows:

**MyBC1**

Backend: http://localhost:5000
Frontend: http://localhost:8080

**MyBC2**

Backend: http://localhost:5001
Frontend: http://localhost:8081

### MongoDB

For the read models, you will be needing a Mongo, the easiest way through Docker is to run
it as a daemon for your self:

```shell
$ docker run -d -p 27017:27017 mongo:4.0.13
```

### EventStore

Events are stored in the EventStore, this needs to be running. Run it through Docker:

```shell
$ docker run -d -p 2113:2113 -p 1113:1113 eventstore/eventstore
```

Go [here](https://eventstore.org) to read more about EventStore.

#### Admin UI

EventStore has an Admin UI that you'll find here:

URL: http://localhost:2113
Username: admin
Password: changeit

### Starting the Microservices

Run them accordingly using multiple shell windows:

- `dotnet run` in the `Core` folder of both - this will run the backends
- `yarn` / `npm install` in the `Web` folder
- `yarn start` / `npm start` in the `Web` folder

### Event Horizon and events between microservices

In **MyBC2** there is a second event project called `Events.MyBC1`.
This holds the events **MyBC2** is interested in from **MyBC1**.
Notice that the event is tagged with an attribute of `Artifact` with
the identifier of the event found in `artifacts.json` in **MyBC1**
inside the `.dolittle` folder of the `Core` project.
This same identifier is also configured in the `event-horizons.json`
file of **MyBC2** in the `.dolittle` folder of the `Core` project there.
There is an `EventProcessor` in **MyBC2** that consumes this event and
prints out a message.
