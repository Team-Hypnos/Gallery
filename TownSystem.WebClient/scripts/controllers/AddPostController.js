'use strict';

galleryApp.controller('AddPostController', function AddPostController($location) {
    var isLogged = localStorage.getItem('isLoggedIn');

    if (!isLogged) {
        $location.path('/signin');
    }
});