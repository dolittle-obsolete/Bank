# Sample of Dolittle from the ground up

Documentation for Dolittle can be found [here](https://dolittle.io).
Presentation can be found [here](https://1drv.ms/p/s!AhD7O7za4wxGgcV7820oWophkxSpJA).

## Application

The application consists of 2 microservices; Banking and Glance. They are configured as follows:

**Banking**

Backend: http://localhost:5000
Frontend: http://localhost:8080

**Glance**

Backend: http://localhost:5001
Frontend: http://localhost:8081

### MongoDB

For the read models, you will be needing a Mongo, the easiest way through Docker is to run
it as a daemon for your self:

```shell
$ docker run -d -p 27017:27017 mongo:4.0.13
```

This sample utilizes MongoDB as an event store as well.

### Starting the Microservices

Run them accordingly using multiple shell windows:

- `dotnet run` in the `Core` folder of both - this will run the backends
- `yarn` / `npm install` in the `Web` folder
- `yarn start` / `npm start` in the `Web` folder

### Event Horizon and events between microservices

In **Glance** there is a second event project called `Events.Banking`.
This holds the events **Blance** is interested in from **Banking**.
Notice that the event is tagged with an attribute of `Artifact` with
the identifier of the event found in `artifacts.json` in **MyBC1**
inside the `.dolittle` folder of the `Core` project.
This same identifier is also configured in the `event-horizons.json`
file of **Glance** in the `.dolittle` folder of the `Core` project there.
There is an `EventProcessor` in **Glance** that consumes this event and
prints out a message.
