'use strict';

var galleryApp = angular.module('galleryApp', ['ngRoute', 'ngResource', 'ngSanitize', 'pubnub.angular.service'])
    .config(function ($routeProvider) {
        $routeProvider
            .when('/home', {controller: 'HomeController', templateUrl: 'views/home.html'})
            .when('/signin', {controller: 'SignInController', templateUrl: 'views/sign-in.html'})
            .when('/signup', {controller: 'SignUpController', templateUrl: 'views/sign-up.html'})
            .when('/towns', {controller: 'TownsController', templateUrl: 'views/albums.html'})
            .when('/towns/:name/', {controller: 'PostsController', templateUrl: 'views/all-posts.html' })
            .when('/towns/:name/:id', {controller: 'OpenedPostController', templateUrl: 'views/opened-post.html'})
            .when('/post', {controller: 'AddPostController', templateUrl: 'views/new-post.html'})
            .when('/categories', {controller: 'CategoriesController', templateUrl: 'views/categories.html'})
            .when('/profile/:username/', {controller: 'ProfileController', templateUrl: 'views/profile.html'})
            .when('/wall-of-fame', {controller: 'WallOfFameController', templateUrl: 'views/wall-of-fame.html'})
            .otherwise({redirectTo: '/home'});

        // TODO: define all routes and templates
    })
    .constant('author', 'Team Hypnos')
    .constant('copyright', 'Telerik Academy');