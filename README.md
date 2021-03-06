# Team Hypnos
## Members:
* [Adrian Bojankov](https://telerikacademy.com/Users/Adrian.bozhankov)
* [Vyara Hristova](https://telerikacademy.com/Users/vyarah)
* [Dimitar Dzhurenov](https://telerikacademy.com/Users/dsd321)
* [Reni Getskova](https://telerikacademy.com/Users/geckova)
* [Zlatko Atanasov](https://telerikacademy.com/Users/baretata)

## Project purpose
Bulgaria Best Town is semi-gallery based application which purpose is to find
which is the best town of Bulgaria for 2015. It will be choosed by the 
number of votes in other words - by the users.

## Database models diagram
![Class diagram](http://i.imgur.com/McrUnnG.jpg)
## C# Web API diagram
![Class diagram](http://i.imgur.com/A9OHJOO.jpg)
## Services diagram
![Class diagram](http://i.imgur.com/B3nx2uW.jpg)

## Bulgaria Best Town Description

`User Roles`
 * NotRegistered - not registered user
 * Registered - user with registration
 * Admin - user with admin rights.

`User`

#### Not Registered
* Can view all categories, towns, posts, comments

#### Registered
 * register, login and logout.
 * create comments, posts, towns
 * can vote for comments, posts, towns
 * join event

#### Admin
* can create, delete categories
* CRUD operation for all controllers

`Category`
 * holds events

`Town` 
* town have 1 or more categories and can have posts and comments.
* holds comments

`Like`
* connected to `Post` 
* can like, dislike post

`Post`
* every `Town` has posts with different pictures
* posts can have comments and can be rated(like, dislike)

`Comment`
* every `Town` post has comments

`Notifications`
* when new chat message is sent
* when error occures
* when given operation is successful

## GitHub: [Bulgaria Best Town - repository](https://github.com/Team-Hypnos/Gallery)


## RESTful API Overview
| HTTP Method | Web service endpoint | Description |
|:----------:|:-----------:|:-------------|
|POST | api/users/register | Registers a new user in the events system |
|POST | api/users/login | Logs in a user in the events system 
|PUT | api/users/logout | Logs out a user from the events system |
|GET |api/categories|Gets all categories available|
|GET|api/events/{id}|Gets event by given id|
|POST (req auth)|api/categories|Creates a new category by given name|
|DELETE (req auth)|api/categories/{id}|Deletes given category by id|
|GET|api/towns|Gets all towns|
|GET|api/towns/{id}|Gets the town with its categories, ordered by name|
|POST (req auth)|api/towns|Creates a new town by given name and categories|
|GET|api/posts|Gets all posts|
|GET|api/posts/{id}|Gets all posts by given post id|
|POST (req auth)|api/posts|Creates a new post by given title and description|
|GET|api/posts?page=N|Get given 20 posts by certain page (page - 1) * pageSize|
|GET|api/comments|Gets all comments|
|GET|api/comments/ByPost/{id}|Gets all comments by given post id|
|PUT| api/comments/{id}|Updates given comment by id|
|POST (req auth)|api/comments|Creates a new comment by given name and given post id|
