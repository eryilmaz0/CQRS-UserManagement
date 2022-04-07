# CQRS PATTERN - USER MANAGEMENT PROJECT

## What is CQRS?
Cqrs is a design pattern recommends that command and query operations must be seperate. We can explain "command" and "query" concepts as follows; 

##### Command is data manipulation operations like insert, update and delete.
##### Query is data reading operations from a data source.

CQRS says, we must seperate the operations around these two concepts. By this way, command and query domains are also have been seperated. The advantages of CQRS pattern are; 

- Seperated Domains. Easy to understand and follow.
- high scalability. We can scale command project or query project alone when wasn't scaling other.
- Opportunity to use technology independent from each other. 


## Project
This project is a user management project. We have two projects that Command project and Query project. The Command project provides the following operations to be performed;

- Create User
- Update User
- Delete User
- Create User Role
- Update User Role
- Delete User Role
- Assign Role To User
- Update User Address

The Query project provides the following operations to be performed:

- List Users
- List User Roles
- Get User With Detail
- Get User With Roles
- Get User Address


## Tech Stacks
### Command
Command project uses PostgreSql as database. Runs on Onion Architecture as a Clean Architecture Implementation. Have 5 layers that, Domain, Application, Infrastructure, Persistence and API. 

For handle to command requests, uses mediatr library, and automapper for object mapping. Uses Redis as a cache mechanism, and implements basic distributed lock mechanism by using cache mechanism.

All these components which redis, postgresql and rabbitmq runs as a docker container.

### Query
Query project uses Mongodb as database.  Runs on Onion Architecture as a Clean Architecture Implementation. Have 5 layers that, Domain, Application, Infrastructure, Persistence and API. 

For handle to query requests, uses mediatr library, and automapper for object mapping. Also uses redis as a caching mechanism, and caches all the query data outputs for maksimum performance.

All these components runs on as a docker container.

## Asynchronous Communication 

When a command request handled by command project, we have to update our mongodb database too that working for query project for data consistency. Command and Query projects performs that by using Asynchronous Communication.

When a data manipulated on command side, command project exhibits event-driven design behavior and throws an integration event. This event will be pushed into a rabbitmq queue. Query project listens this queue, and an when event comes in, it updates specific data in the mongodb by handling event.

For this Asynchronous Event Driven Communication, RabbitMQ and Mass Transit Framework have been used. 

## Project Diagram
<p align="center">
  <img src="/img/projectarchitecture.png">
</p>

