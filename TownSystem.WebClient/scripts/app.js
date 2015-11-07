'use strict';

var galleryApp = angular.module('galleryApp', ['ngRoute', 'ngResource', 'ngSanitize'])
    .config(function ($routeProvider) {
        $routeProvider
            .when('/home', {controller: 'HomeController', templateUrl: 'views/home.html'})
            .when('/signin', {controller: 'SignInController', templateUrl: 'views/sign-in.html'})
            .when('/signup', {controller: 'SignUpController', templateUrl: 'views/sign-up.html'})
            .when('/towns', {controller: 'TownsController', templateUrl: 'views/albums.html'})
            .when('/towns/:name/', {controller: 'PostsController', templateUrl: 'views/all-posts.html', })
            .otherwise({redirectTo: '/home'});

        // TODO: define all routes and templates
    })
    .constant('author', 'Team Hypnos')
    .constant('copyright', 'Telerik Academy');